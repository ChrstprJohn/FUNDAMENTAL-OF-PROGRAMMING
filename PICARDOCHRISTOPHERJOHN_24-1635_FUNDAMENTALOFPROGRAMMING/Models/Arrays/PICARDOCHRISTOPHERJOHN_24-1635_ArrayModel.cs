using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Arrays;

public class PICARDOCHRISTOPHERJOHN_24_1635_ArrayModel : IValidatableObject
{
    [Required]
    [StringLength(100)]
    public string? Values { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (!PICARDOCHRISTOPHERJOHN_24_1635_NumberInput.TryRead(Values, 5, out _))
            yield return new ValidationResult(
                "Enter exactly 5 comma-separated whole numbers from -1000 to 1000.",
                [nameof(Values)]);
    }

    public void CalculateSum()
    {
        if (!PICARDOCHRISTOPHERJOHN_24_1635_NumberInput.TryRead(Values, 5, out int[] numbers))
            return;

        int total = 0;
        foreach (int number in numbers)
            total += number;

        Result = $"Sum: {total}";
    }

    public void FindLargest()
    {
        if (!PICARDOCHRISTOPHERJOHN_24_1635_NumberInput.TryRead(Values, 5, out int[] numbers))
            return;

        int largest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > largest)
                largest = number;
        }

        Result = $"Largest value: {largest}";
    }
}
