using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Loops;

public class PICARDOCHRISTOPHERJOHN_24_1635_NumberSumModel
{
    [Required]
    [Range(1, 100)]
    public int? Limit { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        int current = 1;
        int total = 0;
        do
        {
            total += current;
            current++;
        }
        while (current <= Limit.GetValueOrDefault());
        Result = $"Sum: {total}";
    }
}
