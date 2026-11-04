using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Arrays;

public class PICARDOCHRISTOPHERJOHN_24_1635_MatrixTotalsModel : IValidatableObject
{
    public int?[] Cells { get; set; } = [10, 20, 30, 40, 50, 60, 70, 80, 90];
    public string? ArrayContents { get; private set; }
    public string? Result { get; private set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (Cells == null || Cells.Length != 9)
        {
            yield return new ValidationResult("Fill all nine array cells.", ["Cells[0]"]);
            yield break;
        }
        for (int index = 0; index < Cells.Length; index++)
        {
            if (!Cells[index].HasValue || Cells[index] < -1000 || Cells[index] > 1000)
                yield return new ValidationResult("Enter a whole number from -1000 to 1000.", [$"Cells[{index}]"]);
        }
    }

    private int[,] PopulateArray()
    {
        int[,] numbers = new int[3, 3];
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
                numbers[row, column] = Cells[row * 3 + column].GetValueOrDefault();
        }
        ArrayContents = "int[,] numbers = { { " + numbers[0, 0] + ", " + numbers[0, 1] + ", " + numbers[0, 2]
            + " }, { " + numbers[1, 0] + ", " + numbers[1, 1] + ", " + numbers[1, 2]
            + " }, { " + numbers[2, 0] + ", " + numbers[2, 1] + ", " + numbers[2, 2] + " } };";
        return numbers;
    }

    public void Calculate()
    {
        int[,] numbers = PopulateArray();
        int[] rowTotals = new int[3];
        int[] columnTotals = new int[3];
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                rowTotals[row] += numbers[row, column];
                columnTotals[column] += numbers[row, column];
            }
        }
        Result = $"Row index 0: {rowTotals[0]}, Row index 1: {rowTotals[1]}, Row index 2: {rowTotals[2]}\nColumn index 0: {columnTotals[0]}, Column index 1: {columnTotals[1]}, Column index 2: {columnTotals[2]}";
    }
}
