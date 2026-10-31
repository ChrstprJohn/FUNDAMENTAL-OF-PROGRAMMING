using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

public class PICARDOCHRISTOPHERJOHN_24_1635_NumberCheckModel
{
    [Required]
    [Display(Name = "Number")]
    [Range(-1000000, 1000000)]
    public int? Value { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        int number = Value.GetValueOrDefault();
        if (number >= 0)
        {
            if (number == 0)
                Result = "The number is zero.";
            else
                Result = "The number is positive.";
        }
        else
        {
            Result = "The number is negative.";
        }
    }
}
