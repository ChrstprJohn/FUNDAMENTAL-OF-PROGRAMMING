using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

public class PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel : IValidatableObject
{
    [Required]
    [StringLength(100)]
    public string? Values { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (!PICARDOCHRISTOPHERJOHN_24_1635_NumberInput.TryRead(Values, 4, out _))
            yield return new ValidationResult(
                "Enter exactly 4 comma-separated whole numbers from -1000 to 1000.",
                [nameof(Values)]);
    }

    private int[,] ReadMatrix()
    {
        PICARDOCHRISTOPHERJOHN_24_1635_NumberInput.TryRead(Values, 4, out int[] numbers);
        return new int[,] { { numbers[0], numbers[1] }, { numbers[2], numbers[3] } };
    }

    public void Display()
    {
        int[,] matrix = ReadMatrix();
        var rows = new List<string>();
        for (int row = 0; row < 2; row++)
        {
            rows.Add($"{matrix[row, 0]}  {matrix[row, 1]}");
        }
        Result = string.Join("\n", rows);
    }

    public void CalculateRowTotals()
    {
        int[,] matrix = ReadMatrix();
        var rows = new List<string>();
        for (int row = 0; row < 2; row++)
        {
            int total = 0;
            for (int column = 0; column < 2; column++)
                total += matrix[row, column];

            rows.Add($"Row {row + 1} sum: {total}");
        }
        Result = string.Join("\n", rows);
    }

    public void Transpose()
    {
        int[,] matrix = ReadMatrix();
        int[,] transposed = new int[2, 2];
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
                transposed[column, row] = matrix[row, column];
        }

        Result = $"{transposed[0, 0]}  {transposed[0, 1]}\n{transposed[1, 0]}  {transposed[1, 1]}";
    }
}
