using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.NestedIfElse;

public class PICARDOCHRISTOPHERJOHN_24_1635_LargestNumberModel
{
    [Required]
    [Range(-1000000, 1000000)]
    public int? First { get; set; }

    [Required]
    [Range(-1000000, 1000000)]
    public int? Second { get; set; }

    [Required]
    [Range(-1000000, 1000000)]
    public int? Third { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        int first = First.GetValueOrDefault();
        int second = Second.GetValueOrDefault();
        int third = Third.GetValueOrDefault();
        int largest;
        if (first >= second)
        {
            if (first >= third)
                largest = first;
            else
                largest = third;
        }
        else
        {
            if (second >= third)
                largest = second;
            else
                largest = third;
        }
        Result = $"Largest number: {largest}";
    }
}
