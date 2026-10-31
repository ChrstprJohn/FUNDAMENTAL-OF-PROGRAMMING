using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Loops;

public class PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationModel
{
    [Required]
    [Range(1, 100)]
    public int? Number { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        int number = Number.GetValueOrDefault();
        var lines = new List<string>();
        for (int multiplier = 1; multiplier <= 10; multiplier++)
        {
            lines.Add($"{number} × {multiplier} = {number * multiplier}");
        }
        Result = string.Join("\n", lines);
    }
}
