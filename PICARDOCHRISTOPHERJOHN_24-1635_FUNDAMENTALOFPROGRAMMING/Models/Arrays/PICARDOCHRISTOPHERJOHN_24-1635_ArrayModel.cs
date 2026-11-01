using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Arrays;

public class PICARDOCHRISTOPHERJOHN_24_1635_ArrayModel : IValidatableObject
{
    public int?[] Numbers { get; set; } = [1, 2, 3, 4, 5];

    [BindNever]
    public string? ArrayContents { get; private set; }

    [BindNever]
    public string? Result { get; private set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (Numbers == null || Numbers.Length != 5)
        {
            yield return new ValidationResult("Fill all five array elements.", ["Numbers[0]"]);
            yield break;
        }
        for (int index = 0; index < Numbers.Length; index++)
        {
            if (!Numbers[index].HasValue || Numbers[index] < -1000 || Numbers[index] > 1000)
                yield return new ValidationResult("Enter a whole number from -1000 to 1000.", [$"Numbers[{index}]"]);
        }
    }

    private int[] PopulateArray()
    {
        int[] numbers = new int[5];
        for (int index = 0; index < numbers.Length; index++)
            numbers[index] = Numbers[index].GetValueOrDefault();

        ArrayContents = "int[] numbers = { " + string.Join(", ", numbers) + " };";
        return numbers;
    }

    public void CalculateSum()
    {
        int[] numbers = PopulateArray();
        int total = 0;
        foreach (int number in numbers)
            total += number;
        Result = $"Sum: {total}";
    }

    public void FindLargest()
    {
        int[] numbers = PopulateArray();
        int largest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > largest)
                largest = number;
        }
        Result = $"Largest value: {largest}";
    }
}
