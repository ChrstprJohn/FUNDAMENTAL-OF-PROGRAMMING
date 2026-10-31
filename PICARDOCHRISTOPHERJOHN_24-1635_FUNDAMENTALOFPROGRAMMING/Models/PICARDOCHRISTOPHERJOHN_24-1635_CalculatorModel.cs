using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

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

    [BindNever]
    public decimal? Result { get; set; }

    public void Calculate()
    {
        // The controller validates the inputs before calling this method.
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
