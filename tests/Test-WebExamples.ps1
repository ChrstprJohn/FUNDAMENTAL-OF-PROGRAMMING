#requires -Version 7.0
param([string]$BaseUrl = 'http://localhost:5291')

Import-Module Microsoft.PowerShell.Utility

$ErrorActionPreference = 'Stop'
$session = [Microsoft.PowerShell.Commands.WebRequestSession]::new()
$checks = 0

function Submit-Example([string]$route, [hashtable]$body) {
    return Invoke-WebRequest -Uri "$BaseUrl$route" -Method Post -Body $body -WebSession $session
}

function Assert-Result([string]$route, [hashtable]$body, [string]$expected) {
    $response = Submit-Example $route $body
    $decoded = [System.Net.WebUtility]::HtmlDecode($response.Content)
    $match = [regex]::Match($decoded, '<pre class="example-output"[^>]*><output>([\s\S]*?)</output>')
    if (-not $match.Success -or $match.Groups[1].Value.Trim().Replace("`r`n", "`n") -ne $expected.Replace("`r`n", "`n")) {
        throw "Unexpected output for $route. Actual: $($match.Groups[1].Value)"
    }
    $script:checks++
}

function Assert-Invalid([string]$route, [hashtable]$body, [string]$message) {
    $response = Submit-Example $route $body
    $decoded = [System.Net.WebUtility]::HtmlDecode($response.Content)
    if ($decoded -match '<pre class="example-output"' -or -not $decoded.Contains($message)) {
        throw "Validation failed for $route."
    }
    $script:checks++
}

foreach ($route in @('/', '/error')) {
    $page = Invoke-WebRequest -Uri "$BaseUrl$route" -WebSession $session
    if ($page.StatusCode -ne 200) { throw "Failed route: $route" }
    $checks++
}

foreach ($route in @('/basic-io', '/nested-if-else', '/loops', '/arrays')) {
    $page = Invoke-WebRequest -Uri "$BaseUrl$route" -WebSession $session
    if ([regex]::Matches($page.Content, '<section id=').Count -ne 5) {
        throw "Unexpected example count on $route."
    }
    $checks++
}

Assert-Result '/calculator' @{ 'Calculator.FirstNumber' = '10'; 'Calculator.SecondNumber' = '5'; 'Calculator.Operation' = 'add' } 'Result: 15'
Assert-Result '/bmi' @{ 'Bmi.Weight' = '70'; 'Bmi.Height' = '175' } 'BMI: 22.86 kg/m²'
Assert-Result '/temperature' @{ 'Temperature.Value' = '0'; 'Temperature.Direction' = 'c-to-f' } '32.00 °F'
Assert-Result '/greeting' @{ 'Greeting.Name' = 'Ada' } 'Hello, Ada! Welcome to Fundamental of Programming.'
Assert-Result '/circle' @{ 'Circle.Radius' = '2' } 'Area: 12.57 square units; Circumference: 12.57 units'
Assert-Result '/number-sign' @{ 'Number.Value' = '0' } 'The number is zero.'
Assert-Result '/grade' @{ 'Grade.Score' = '90' } 'Passed with distinction.'
Assert-Result '/age' @{ 'Age.Years' = '18' } 'Adult'
Assert-Result '/largest-of-three' @{ 'Largest.First' = '-3'; 'Largest.Second' = '-1'; 'Largest.Third' = '-2' } 'Largest number: -1'
Assert-Result '/sign-and-parity' @{ 'Parity.Value' = '-3' } 'Negative and odd.'
Assert-Result '/multiplication-table' @{ 'Table.Number' = '3' } '3 × 1 = 3
3 × 2 = 6
3 × 3 = 9
3 × 4 = 12
3 × 5 = 15
3 × 6 = 18
3 × 7 = 21
3 × 8 = 24
3 × 9 = 27
3 × 10 = 30'
Assert-Result '/count-to-n' @{ 'Count.Limit' = '3' } '1, 2, 3'
Assert-Result '/star-line' @{ 'StarLine.Count' = '5' } '*****'
Assert-Result '/countdown' @{ 'Countdown.Start' = '3' } '3, 2, 1, 0'
Assert-Result '/star-triangle' @{ 'StarTriangle.Rows' = '3' } ("*"+[char]10+"**"+[char]10+"***")
Assert-Result '/array-sum' @{ 'Sum.Numbers[0]'='1'; 'Sum.Numbers[1]'='2'; 'Sum.Numbers[2]'='3'; 'Sum.Numbers[3]'='4'; 'Sum.Numbers[4]'='5' } 'Sum: 15'
Assert-Result '/array-largest' @{ 'Largest.Numbers[0]'='-5'; 'Largest.Numbers[1]'='-2'; 'Largest.Numbers[2]'='-9'; 'Largest.Numbers[3]'='-1'; 'Largest.Numbers[4]'='-3' } 'Largest value: -1'

Assert-Result '/calculator' @{ 'Calculator.FirstNumber' = '1'; 'Calculator.SecondNumber' = '2'; 'Calculator.Operation' = 'add'; 'Calculator.Result' = '999' } 'Result: 3'
Assert-Invalid '/calculator' @{ 'Calculator.FirstNumber' = '10'; 'Calculator.SecondNumber' = '0'; 'Calculator.Operation' = 'divide' } 'Cannot divide by zero.'
Assert-Invalid '/calculator' @{ 'Calculator.FirstNumber' = ''; 'Calculator.SecondNumber' = '2'; 'Calculator.Operation' = 'add'; 'Calculator.Result' = '999' } 'Enter the first number.'
Assert-Invalid '/calculator' @{ 'Calculator.FirstNumber' = '1'; 'Calculator.SecondNumber' = '2'; 'Calculator.Operation' = 'invalid' } 'Choose a valid operation.'
Assert-Invalid '/calculator' @{ 'Calculator.FirstNumber' = '79228162514264337593543950335'; 'Calculator.SecondNumber' = '2'; 'Calculator.Operation' = 'multiply' } 'Try smaller numbers.'
Assert-Invalid '/bmi' @{ 'Bmi.Weight' = '70'; 'Bmi.Height' = '0' } 'between'
Assert-Invalid '/bmi' @{ 'Bmi.Weight' = 'NaN'; 'Bmi.Height' = '175' } 'between'
Assert-Invalid '/count-to-n' @{ 'Count.Limit' = '1000000' } 'between'
Assert-Invalid '/array-sum' @{ 'Sum.Numbers[0]' = '1' } 'five array elements'


Assert-Result '/row-column-totals' @{ 'Totals.Cells[0]'='10'; 'Totals.Cells[1]'='20'; 'Totals.Cells[2]'='30'; 'Totals.Cells[3]'='40'; 'Totals.Cells[4]'='50'; 'Totals.Cells[5]'='60'; 'Totals.Cells[6]'='70'; 'Totals.Cells[7]'='80'; 'Totals.Cells[8]'='90' } ("Row index 0: 60, Row index 1: 150, Row index 2: 240"+[char]10+"Column index 0: 120, Column index 1: 150, Column index 2: 180")
Assert-Result '/highest-lowest' @{ 'Extremes.Cells[0]'='10'; 'Extremes.Cells[1]'='20'; 'Extremes.Cells[2]'='30'; 'Extremes.Cells[3]'='40' } ("Highest: 40 at numbers[1,1]"+[char]10+"Lowest: 10 at numbers[0,0]")
Assert-Result '/multiplication-grid' @{ 'Grid.Rows'='2'; 'Grid.Columns'='3' } ("1   2   3"+[char]10+"   2   4   6")
Assert-Invalid '/row-column-totals' @{ 'Totals.Cells[0]'='10' } 'nine array cells'
Assert-Invalid '/multiplication-grid' @{ 'Grid.Rows'='11'; 'Grid.Columns'='3' } 'between'

$unsafeName = '<script>alert(1)</script>'
$greeting = Submit-Example '/greeting' @{ 'Greeting.Name' = $unsafeName }
if ($greeting.Content.Contains($unsafeName) -or -not $greeting.Content.Contains('&lt;script&gt;')) {
    throw 'Greeting text was not safely encoded.'
}
$checks++


Write-Output "Passed $checks HTTP checks, including all 20 forms, validation and encoding (without antiforgery checks)."
