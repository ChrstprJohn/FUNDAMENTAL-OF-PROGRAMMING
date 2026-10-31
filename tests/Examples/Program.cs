using System.ComponentModel.DataAnnotations;
using System.Globalization;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

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

var shipping = new PICARDOCHRISTOPHERJOHN_24_1635_ShippingModel { OrderTotal = 1000, IsMember = true };
Check(IsValid(shipping), "Shipping accepts valid input");
shipping.Calculate();
Check(shipping.Result == "Shipping fee: ₱0.00", "Shipping result");

var table = new PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationModel { Number = 3 };
Check(IsValid(table), "For multiplication accepts valid input");
table.Calculate();
Check(table.Result == string.Join("\n", Enumerable.Range(1, 10).Select(n => $"3 × {n} = {3 * n}")), "For multiplication result");

var count = new PICARDOCHRISTOPHERJOHN_24_1635_CountModel { Limit = 3 };
Check(IsValid(count), "While count accepts valid input");
count.Calculate();
Check(count.Result == "1, 2, 3", "While count result");

var digits = new PICARDOCHRISTOPHERJOHN_24_1635_DigitSumModel { Number = 123 };
Check(IsValid(digits), "While digits accepts valid input");
digits.Calculate();
Check(digits.Result == "Sum of digits: 6", "While digits result");

var countdown = new PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel { Start = 3 };
Check(IsValid(countdown), "Do-while countdown accepts valid input");
countdown.Calculate();
Check(countdown.Result == "3, 2, 1, 0", "Do-while countdown result");

var sum = new PICARDOCHRISTOPHERJOHN_24_1635_NumberSumModel { Limit = 5 };
Check(IsValid(sum), "Do-while sum accepts valid input");
sum.Calculate();
Check(sum.Result == "Sum: 15", "Do-while sum result");

var arraySum = new PICARDOCHRISTOPHERJOHN_24_1635_ArrayModel { Values = "1, 2, 3, 4, 5" };
Check(IsValid(arraySum), "Array sum accepts valid input");
arraySum.CalculateSum();
Check(arraySum.Result == "Sum: 15", "Array sum result");

var arrayLargest = new PICARDOCHRISTOPHERJOHN_24_1635_ArrayModel { Values = "-5,-2,-9,-1,-3" };
Check(IsValid(arrayLargest), "Array maximum accepts valid input");
arrayLargest.FindLargest();
Check(arrayLargest.Result == "Largest value: -1", "Array maximum result");

var matrix = new PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel { Values = "1,2,3,4" };
Check(IsValid(matrix), "Matrix display accepts valid input");
matrix.Display();
Check(matrix.Result == "1  2\n3  4", "Matrix display result");

var rows = new PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel { Values = "1,2,3,4" };
Check(IsValid(rows), "Matrix row totals accepts valid input");
rows.CalculateRowTotals();
Check(rows.Result == "Row 1 sum: 3\nRow 2 sum: 7", "Matrix row totals result");

var transpose = new PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel { Values = "1,2,3,4" };
Check(IsValid(transpose), "Matrix transpose accepts valid input");
transpose.Transpose();
Check(transpose.Result == "1  3\n2  4", "Matrix transpose result");

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
foreach (var (order, member, expected) in new[] { (1000m, false, 50m), (999m, true, 50m), (999m, false, 100m) })
{
    shipping.OrderTotal = order; shipping.IsMember = member;
    shipping.Calculate();
    Check(shipping.Result == $"Shipping fee: ₱{expected:F2}", "Shipping branch");
}
digits.Number = 0;
digits.Calculate();
Check(digits.Result == "Sum of digits: 0", "Zero digit sum");
countdown.Start = 1;
countdown.Calculate();
Check(countdown.Result == "1, 0", "Countdown lower bound");
sum.Limit = 100;
sum.Calculate();
Check(sum.Result == "Sum: 5050", "Sum upper bound");

Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_BmiModel { Weight = 70, Height = 0 }), "Reject zero height");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_BmiModel { Weight = double.NaN, Height = 175 }), "Reject nonfinite weight");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_BmiModel { Weight = 0.9, Height = 175 }), "Reject fractional out-of-range weight");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ShippingModel { OrderTotal = decimal.MaxValue }), "Reject oversized order without overflow");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_CircleModel { Radius = -1 }), "Reject negative radius");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_TemperatureModel { Value = 0, Direction = "invalid" }), "Reject invalid conversion");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_GreetingModel { Name = " " }), "Reject blank greeting");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_GradeModel { Score = 101 }), "Reject invalid grade");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_AgeGroupModel { Years = -1 }), "Reject negative age");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_CountModel { Limit = 1000000 }), "Bound while loop");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel { Start = 0 }), "Bound countdown");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_NumberSumModel { Limit = 0 }), "Bound do-while sum");
Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel()), "Reject missing calculator inputs");
foreach (string invalid in new[] { "", "1,2", "1,2,3,4,no", "1,2,3,4,1001", "1,,3,4,5", "1,2,3,4,5,6" })
    Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_ArrayModel { Values = invalid }), "Reject malformed array");
foreach (string invalid in new[] { "", "1,2,3", "1,2,3,4,5", "1,2,3,1.5" })
    Check(!IsValid(new PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel { Values = invalid }), "Reject malformed matrix");

Console.WriteLine($"Passed {checks} checks across all 20 examples.");
