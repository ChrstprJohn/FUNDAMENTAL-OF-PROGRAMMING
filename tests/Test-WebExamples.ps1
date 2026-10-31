#requires -Version 7.0
param([string]$BaseUrl = 'http://localhost:5291')

$ErrorActionPreference = 'Stop'
$session = [Microsoft.PowerShell.Commands.WebRequestSession]::new()
$checks = 0

function Submit-Example([string]$route, [hashtable]$body) {
    $page = Invoke-WebRequest -Uri "$BaseUrl/basic-io" -WebSession $session
    $match = [regex]::Match($page.Content, 'name="__RequestVerificationToken"[^>]*value="([^"]+)"')
    if (-not $match.Success) { throw 'Missing antiforgery token.' }
    $body['__RequestVerificationToken'] = [System.Net.WebUtility]::HtmlDecode($match.Groups[1].Value)
    return Invoke-WebRequest -Uri "$BaseUrl$route" -Method Post -Body $body -WebSession $session
}

function Assert-Result([string]$route, [hashtable]$body, [string]$expected) {
    $response = Submit-Example $route $body
    $decoded = [System.Net.WebUtility]::HtmlDecode($response.Content)
    $match = [regex]::Match($decoded, '<pre class="example-output"[^>]*><output>([\s\S]*?)</output>')
    if (-not $match.Success -or $match.Groups[1].Value.Trim() -ne $expected) {
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
        throw "Expected five examples on $route."
    }
    $checks++
}

Assert-Result '/basic-io' @{ 'Calculator.FirstNumber' = '10'; 'Calculator.SecondNumber' = '5'; 'Calculator.Operation' = 'add' } 'Result: 15'
Assert-Result '/basic-io/bmi' @{ 'Bmi.Weight' = '70'; 'Bmi.Height' = '175' } 'BMI: 22.86 kg/m²'
Assert-Result '/basic-io/temperature' @{ 'Temperature.Value' = '0'; 'Temperature.Direction' = 'c-to-f' } '32.00 °F'
Assert-Result '/basic-io/greeting' @{ 'Greeting.Name' = 'Ada' } 'Hello, Ada! Welcome to Fundamental of Programming.'
Assert-Result '/basic-io/circle' @{ 'Circle.Radius' = '2' } 'Area: 12.57 square units; Circumference: 12.57 units'
Assert-Result '/nested-if-else/number' @{ 'Number.Value' = '0' } 'The number is zero.'
Assert-Result '/nested-if-else/grade' @{ 'Grade.Score' = '90' } 'Passed with distinction.'
Assert-Result '/nested-if-else/age' @{ 'Age.Years' = '18' } 'Adult'
Assert-Result '/nested-if-else/largest' @{ 'Largest.First' = '-3'; 'Largest.Second' = '-1'; 'Largest.Third' = '-2' } 'Largest number: -1'
Assert-Result '/nested-if-else/shipping' @{ 'Shipping.OrderTotal' = '1000'; 'Shipping.IsMember' = 'true' } 'Shipping fee: ₱0.00'
Assert-Result '/loops/table' @{ 'Table.Number' = '3' } '3 × 1 = 3
3 × 2 = 6
3 × 3 = 9
3 × 4 = 12
3 × 5 = 15
3 × 6 = 18
3 × 7 = 21
3 × 8 = 24
3 × 9 = 27
3 × 10 = 30'
Assert-Result '/loops/count' @{ 'Count.Limit' = '3' } '1, 2, 3'
Assert-Result '/loops/digits' @{ 'Digits.Number' = '123' } 'Sum of digits: 6'
Assert-Result '/loops/countdown' @{ 'Countdown.Start' = '3' } '3, 2, 1, 0'
Assert-Result '/loops/sum' @{ 'Sum.Limit' = '5' } 'Sum: 15'
Assert-Result '/arrays/sum' @{ 'Sum.Values' = '1,2,3,4,5' } 'Sum: 15'
Assert-Result '/arrays/largest' @{ 'Largest.Values' = '-5,-2,-9,-1,-3' } 'Largest value: -1'
Assert-Result '/arrays/display' @{ 'Display.Values' = '1,2,3,4' } '1  2
3  4'
Assert-Result '/arrays/row-totals' @{ 'RowTotals.Values' = '1,2,3,4' } 'Row 1 sum: 3
Row 2 sum: 7'
Assert-Result '/arrays/transpose' @{ 'Transpose.Values' = '1,2,3,4' } '1  3
2  4'

Assert-Result '/basic-io' @{ 'Calculator.FirstNumber' = '1'; 'Calculator.SecondNumber' = '2'; 'Calculator.Operation' = 'add'; 'Calculator.Result' = '999' } 'Result: 3'
Assert-Invalid '/basic-io' @{ 'Calculator.FirstNumber' = '10'; 'Calculator.SecondNumber' = '0'; 'Calculator.Operation' = 'divide' } 'Cannot divide by zero.'
Assert-Invalid '/basic-io' @{ 'Calculator.FirstNumber' = ''; 'Calculator.SecondNumber' = '2'; 'Calculator.Operation' = 'add'; 'Calculator.Result' = '999' } 'Enter the first number.'
Assert-Invalid '/basic-io' @{ 'Calculator.FirstNumber' = '1'; 'Calculator.SecondNumber' = '2'; 'Calculator.Operation' = 'invalid' } 'Choose a valid operation.'
Assert-Invalid '/basic-io' @{ 'Calculator.FirstNumber' = '79228162514264337593543950335'; 'Calculator.SecondNumber' = '2'; 'Calculator.Operation' = 'multiply' } 'Try smaller numbers.'
Assert-Invalid '/basic-io/bmi' @{ 'Bmi.Weight' = '70'; 'Bmi.Height' = '0' } 'between'
Assert-Invalid '/basic-io/bmi' @{ 'Bmi.Weight' = 'NaN'; 'Bmi.Height' = '175' } 'between'
Assert-Invalid '/loops/count' @{ 'Count.Limit' = '1000000' } 'between'
Assert-Invalid '/arrays/sum' @{ 'Sum.Values' = '1,2,no,4,5' } 'exactly 5'
Assert-Invalid '/arrays/display' @{ 'Display.Values' = '1,2,3' } 'exactly 4'

$unsafeName = '<script>alert(1)</script>'
$greeting = Submit-Example '/basic-io/greeting' @{ 'Greeting.Name' = $unsafeName }
if ($greeting.Content.Contains($unsafeName) -or -not $greeting.Content.Contains('&lt;script&gt;')) {
    throw 'Greeting text was not safely encoded.'
}
$checks++

$rejected = Invoke-WebRequest -Uri "$BaseUrl/basic-io" -Method Post -Body @{ 'Calculator.FirstNumber' = '1' } -WebSession $session -SkipHttpErrorCheck
if ($rejected.StatusCode -ne 400) { throw 'Missing antiforgery token was not rejected.' }
$checks++

Write-Output "Passed $checks HTTP checks, including all 20 forms, validation, encoding, and antiforgery."
