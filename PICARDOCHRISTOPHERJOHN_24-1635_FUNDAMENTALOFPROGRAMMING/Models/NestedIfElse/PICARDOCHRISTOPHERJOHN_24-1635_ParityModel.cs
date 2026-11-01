using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.NestedIfElse;

public class PICARDOCHRISTOPHERJOHN_24_1635_ParityModel
{
    [Required]
    [Range(-1000000, 1000000)]
    public int? Value { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        int number = Value.GetValueOrDefault();
        if (number > 0)
        {
            if (number % 2 == 0)
                Result = "Positive and even.";
            else
                Result = "Positive and odd.";
        }
        else if (number < 0)
        {
            if (number % 2 == 0)
                Result = "Negative and even.";
            else
                Result = "Negative and odd.";
        }
        else
        {
            Result = "Zero is even.";
        }
    }
}
