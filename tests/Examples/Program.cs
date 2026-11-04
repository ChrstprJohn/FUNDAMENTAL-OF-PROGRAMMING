using System.ComponentModel.DataAnnotations;
using System.Globalization;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.BasicIO;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.NestedIfElse;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Loops;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Arrays;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
int checks = 0;

void Check(bool condition, string description)
{
    if (!condition)
        throw new Exception($"FAILED: {description}");
    checks++;
}

bool IsValid(object model)
{
    return Validator.TryValidateObject(model, new ValidationContext(model),
        new List<ValidationResult>(), validateAllProperties: true);
}

var calculator = new PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel { FirstNumber = 10, SecondNumber = 5, Operation = "add" };
Check(IsValid(calculator), "Calculator addition accepts valid input");
calculator.Calculate();
Check(calculator.Result == 15m, "Calculator addition result");

var bmi = new PICARDOCHRISTOPHERJOHN_24_1635_BmiModel { Weight = 70, Height = 175 };
Check(IsValid(bmi), "BMI accepts valid input");
bmi.Calculate();
Check(bmi.Result == "BMI: 22.86 kg/m²", "BMI result");

var temperature = new PICARDOCHRISTOPHERJOHN_24_1635_TemperatureModel { Value = 0, Direction = "c-to-f" };
Check(IsValid(temperature), "Celsius conversion accepts valid input");
temperature.Calculate();
Check(temperature.Result == "32.00 °F", "Celsius conversion result");

var greeting = new PICARDOCHRISTOPHERJOHN_24_1635_GreetingModel { Name = " Ada " };
Check(IsValid(greeting), "Greeting accepts valid input");
greeting.Calculate();
Check(greeting.Result == "Hello, Ada! Welcome to Fundamental of Programming.", "Greeting result");

var circle = new PICARDOCHRISTOPHERJOHN_24_1635_CircleModel { Radius = 2 };
Check(IsValid(circle), "Circle accepts valid input");
circle.Calculate();
Check(circle.Result == "Area: 12.57 square units; Circumference: 12.57 units", "Circle result");

var number = new PICARDOCHRISTOPHERJOHN_24_1635_NumberCheckModel { Value = -2 };
Check(IsValid(number), "Number sign accepts valid input");
number.Calculate();
Check(number.Result == "The number is negative.", "Number sign result");

var grade = new PICARDOCHRISTOPHERJOHN_24_1635_GradeModel { Score = 90 };
Check(IsValid(grade), "Grade accepts valid input");
grade.Calculate();
Check(grade.Result == "Passed with distinction.", "Grade result");

var age = new PICARDOCHRISTOPHERJOHN_24_1635_AgeGroupModel { Years = 18 };
Check(IsValid(age), "Age group accepts valid input");
age.Calculate();
Check(age.Result == "Adult", "Age group result");

var largest = new PICARDOCHRISTOPHERJOHN_24_1635_LargestNumberModel { First = -3, Second = -1, Third = -2 };
Check(IsValid(largest), "Largest of three accepts valid input");
largest.Calculate();
Check(largest.Result == "Largest number: -1", "Largest of three result");

var parity = new PICARDOCHRISTOPHERJOHN_24_1635_ParityModel { Value = 2 };
Check(IsValid(parity), "Number Check accepts valid input");
parity.Calculate();
Check(parity.Result == "Positive and even.", "Number Check result");

var table = new PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationModel { Number = 3 };
Check(IsValid(table), "For multiplication accepts valid input");
table.Calculate();
Check(table.Result == string.Join("\n", Enumerable.Range(1, 10).Select(n => $"3 × {n} = {3 * n}")), "For multiplication result");

var count = new PICARDOCHRISTOPHERJOHN_24_1635_CountModel { Limit = 3 };
Check(IsValid(count), "While count accepts valid input");
count.Calculate();
Check(count.Result == "1, 2, 3", "While count result");

var digits = new PICARDOCHRISTOPHERJOHN_24_1635_StarLineModel { Count = 5 };
Check(IsValid(digits), "While star line accepts valid input");
digits.Calculate();
Check(digits.Result == "*****", "While star line result");

var countdown = new PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel { Start = 3 };
Check(IsValid(countdown), "Do-while countdown accepts valid input");
countdown.Calculate();
Check(countdown.Result == "3, 2, 1, 0", "Do-while countdown result");

var sum = new PICARDOCHRISTOPHERJOHN_24_1635_StarTriangleModel { Rows = 3 };
Check(IsValid(sum), "Do-while triangle accepts valid input");
sum.Calculate();
Check(sum.Result == "*\n**\n***", "Do-while triangle result");

var arraySum = new PICARDOCHRISTOPHERJOHN_24_1635_ArraySumModel { Numbers = [1, 2, 3, 4, 5] };
Check(IsValid(arraySum), "Array sum accepts valid input");
arraySum.Calculate();
Check(arraySum.Result == "Sum: 15", "Array sum result");

var arrayLargest = new PICARDOCHRISTOPHERJOHN_24_1635_ArrayLargestModel { Numbers = [-5, -2, -9, -1, -3] };
Check(IsValid(arrayLargest), "Array maximum accepts valid input");
arrayLargest.Calculate();
Check(arrayLargest.Result == "Largest value: -1", "Array maximum result");

foreach (var (operation, expected) in new[] { ("subtract", 5m), ("multiply", 50m), ("divide", 2m) })
{
    calculator.Operation = operation;
    calculator.Calculate();
    Check(calculator.Result == expected, $"Calculator {operation}");
}
calculator.SecondNumber = 0;
bool divisionRejected = false;
try { calculator.Calculate(); }
catch (DivideByZeroException) { divisionRejected = true; }
Check(divisionRejected, "Division by zero is rejected");
calculator.FirstNumber = decimal.MaxValue;
calculator.SecondNumber = 2;
calculator.Operation = "multiply";
bool overflowRejected = false;
try { calculator.Calculate(); }
catch (OverflowException) { overflowRejected = true; }
Check(overflowRejected, "Calculator overflow is rejected");
calculator.Operation = "invalid";
Check(!IsValid(calculator), "Invalid calculator operation");

temperature.Direction = "f-to-c";
temperature.Value = 212;
temperature.Calculate();
Check(temperature.Result == "100.00 °C", "Fahrenheit conversion");
foreach (var (value, expected) in new[] { (0, "The number is zero."), (1, "The number is positive.") })
{
    number.Value = value;
    number.Calculate();
    Check(number.Result == expected, "Number sign branch");
}
foreach (var (score, expected) in new[] { (75, "Passed."), (60, "Needs improvement."), (59, "Failed.") })
{
    grade.Score = score;
    grade.Calculate();
    Check(grade.Result == expected, "Grade boundary");
}
foreach (var (years, expected) in new[] { (0, "Child"), (13, "Teenager"), (60, "Senior") })
{
    age.Years = years;
    age.Calculate();
    Check(age.Result == expected, "Age boundary");
}
foreach (var (first, second, third, expected) in new[] { (3, 2, 1, 3), (2, 1, 3, 3), (1, 2, 3, 3), (2, 2, 1, 2) })
{
    largest.First = first; largest.Second = second; largest.Third = third;
    largest.Calculate();
    Check(largest.Result == $"Largest number: {expected}", "Largest number branches and ties");
}
foreach (var (value, expected) in new[] { (3, "Positive and odd."), (-2, "Negative and even."), (-3, "Negative and odd."), (0, "Zero is even.") })
{
    parity.Value = value;
    parity.Calculate();
    Check(parity.Result == expected, "Number Check branch");
}
digits.Count = 1;
digits.Calculate();
Check(digits.Result == "*", "Single star");
countdown.Start = 1;
countdown.Calculate();
Check(countdown.Result == "1, 0", "Countdown lower bound");
sum.Rows = 20;
sum.Calculate();
Check(sum.Result!.Split('\n').Length == 20 && sum.Result.Split('\n')[19] == new string('*', 20), "Triangle upper bound");

Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_BmiModel { Weight = 70, Height = 0 }), "Reject zero height");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_BmiModel { Weight = double.NaN, Height = 175 }), "Reject nonfinite weight");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_BmiModel { Weight = 0.9, Height = 175 }), "Reject fractional out-of-range weight");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ParityModel { Value = 1000001 }), "Reject out-of-range number");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_CircleModel { Radius = -1 }), "Reject negative radius");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_TemperatureModel { Value = 0, Direction = "invalid" }), "Reject invalid conversion");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_GreetingModel { Name = " " }), "Reject blank greeting");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_GradeModel { Score = 101 }), "Reject invalid grade");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_AgeGroupModel { Years = -1 }), "Reject negative age");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_CountModel { Limit = 1000000 }), "Bound while loop");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel { Start = 0 }), "Bound countdown");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_StarTriangleModel { Rows = 0 }), "Bound do-while sum");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel()), "Reject missing calculator inputs");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ArraySumModel { Numbers = [1, 2] }), "Reject incomplete array");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ArraySumModel { Numbers = [1, 2, null, 4, 5] }), "Reject missing element");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ArraySumModel { Numbers = [1, 2, 3, 4, 1001] }), "Reject out-of-range element");
Check(arraySum.ArrayContents == "int[] numbers = { 1, 2, 3, 4, 5 };", "Show populated array");


var totals = new PICARDOCHRISTOPHERJOHN_24_1635_MatrixTotalsModel();
Check(IsValid(totals), "Totals sample valid");
totals.Calculate();
Check(totals.Result == "Row index 0: 60, Row index 1: 150, Row index 2: 240\nColumn index 0: 120, Column index 1: 150, Column index 2: 180", "Row and column totals");
totals.Cells = [-2, 0, 3, -1, 4, 2, 5, -3, 1]; totals.Calculate();
Check(totals.Result == "Row index 0: 1, Row index 1: 5, Row index 2: 3\nColumn index 0: 2, Column index 1: 1, Column index 2: 6", "Edited totals");
var extremes = new PICARDOCHRISTOPHERJOHN_24_1635_MatrixExtremesModel();
extremes.Calculate();
Check(extremes.Result == "Highest: 40 at numbers[1,1]\nLowest: 10 at numbers[0,0]", "Highest and lowest coordinates");
extremes.Cells = [7, -1, 7, -1]; extremes.Calculate();
Check(extremes.Result == "Highest: 7 at numbers[0,0]; numbers[1,0]\nLowest: -1 at numbers[0,1]; numbers[1,1]", "All tied coordinates");
extremes.Cells = [0, 0, 0, 0]; extremes.Calculate();
Check(extremes.Result!.Contains("numbers[1,1]"), "All equal values");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_MatrixTotalsModel { Cells = [1] }), "Incomplete matrix");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_MatrixTotalsModel { Cells = [1, 2, null, 4, 5, 6, 7, 8, 9] }), "Missing matrix cell");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_MatrixTotalsModel { Cells = [1, 2, 3, 4, 5, 6, 7, 8, 1001] }), "Matrix bounds");
var grid = new PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationGridModel();
Check(IsValid(grid), "Grid defaults valid");
grid.Calculate();
Check(grid.Result!.Split('\n').Length == 10 && grid.Result.Split('\n')[9].EndsWith(" 100"), "10 by 10 multiplication grid");
grid.Rows = 2; grid.Columns = 3; grid.Calculate();
Check(grid.Result == "   1   2   3\n   2   4   6", "Editable multiplication dimensions");
grid.Rows = 0;
Check(!IsValid(grid), "Reject zero grid dimension");
grid.Rows = 11;
Check(!IsValid(grid), "Bound grid size");



Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ArrayLargestModel { Numbers = [1, 2] }), "ArrayLargestModel rejects invalid input");

Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ArrayLargestModel { Numbers = [1, 2, null, 4, 5] }), "ArrayLargestModel rejects invalid input");

Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ArrayLargestModel { Numbers = [1, 2, 3, 4, 1001] }), "ArrayLargestModel rejects invalid input");

Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_MatrixExtremesModel { Cells = [1] }), "MatrixExtremesModel rejects invalid input");

Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_MatrixExtremesModel { Cells = [1, 2, null, 4] }), "MatrixExtremesModel rejects invalid input");

Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_MatrixExtremesModel { Cells = [1, 2, 3, 1001] }), "MatrixExtremesModel rejects invalid input");

Console.WriteLine($"Passed {checks} checks across all 20 examples.");
