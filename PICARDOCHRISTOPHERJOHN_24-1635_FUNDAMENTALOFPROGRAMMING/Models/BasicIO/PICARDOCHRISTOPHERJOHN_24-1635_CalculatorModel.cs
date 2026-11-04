using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.BasicIO;

public class PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel
{
    [Required(ErrorMessage = "Enter the first number.")]
    public decimal? FirstNumber { get; set; }

    [Required(ErrorMessage = "Enter the second number.")]
    public decimal? SecondNumber { get; set; }

    [Required]
    [RegularExpression("^(add|subtract|multiply|divide)$",
        ErrorMessage = "Choose a valid operation.")]
    public string Operation { get; set; } = "add";

    public decimal? Result { get; private set; }

    public void Calculate()
    {
        decimal first = FirstNumber.GetValueOrDefault();
        decimal second = SecondNumber.GetValueOrDefault();

        switch (Operation)
        {
            case "add":
                Result = first + second;
                break;

            case "subtract":
                Result = first - second;
                break;

            case "multiply":
                Result = first * second;
                break;

            case "divide":
                Result = first / second;
                break;
        }
    }
}
