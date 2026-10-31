using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

public class PICARDOCHRISTOPHERJOHN_24_1635_DigitSumModel
{
    [Required]
    [Range(0, 999999999)]
    public int? Number { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        int number = Number.GetValueOrDefault();
        int total = 0;
        while (number > 0)
        {
            total += number % 10;
            number /= 10;
        }
        Result = $"Sum of digits: {total}";
    }
}
