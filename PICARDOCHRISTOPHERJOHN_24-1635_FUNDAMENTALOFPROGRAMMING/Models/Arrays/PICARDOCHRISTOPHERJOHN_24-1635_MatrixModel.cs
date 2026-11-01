using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Arrays;

public class PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel : IValidatableObject
{
    public int?[] Cells { get; set; } = [10, 20, 30, 40];
    [BindNever]
    public string? ArrayContents { get; private set; }
    [BindNever]
    public string? Result { get; private set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (Cells == null || Cells.Length != 4)
        {
            yield return new ValidationResult("Fill all four array cells.", ["Cells[0]"]);
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
        int[,] numbers = new int[2, 2];
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
                numbers[row, column] = Cells[row * 2 + column].GetValueOrDefault();
        }
        ArrayContents = "int[,] numbers = { { " + numbers[0, 0] + ", " + numbers[0, 1]
            + " }, { " + numbers[1, 0] + ", " + numbers[1, 1] + " } };";
        return numbers;
    }

    public void CalculateTotals()
    {
        int[,] numbers = PopulateArray();
        int[] rowTotals = new int[2];
        int[] columnTotals = new int[2];
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
            {
                rowTotals[row] += numbers[row, column];
                columnTotals[column] += numbers[row, column];
            }
        }
        Result = $"Row index 0: {rowTotals[0]}, Row index 1: {rowTotals[1]}\nColumn index 0: {columnTotals[0]}, Column index 1: {columnTotals[1]}";
    }

    public void FindExtremes()
    {
        int[,] numbers = PopulateArray();
        int highest = numbers[0, 0];
        int lowest = numbers[0, 0];
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
            {
                if (numbers[row, column] > highest) highest = numbers[row, column];
                if (numbers[row, column] < lowest) lowest = numbers[row, column];
            }
        }
        var highPositions = new List<string>();
        var lowPositions = new List<string>();
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
            {
                string position = $"numbers[{row},{column}]";
                if (numbers[row, column] == highest) highPositions.Add(position);
                if (numbers[row, column] == lowest) lowPositions.Add(position);
            }
        }
        Result = $"Highest: {highest} at {string.Join("; ", highPositions)}\nLowest: {lowest} at {string.Join("; ", lowPositions)}";
    }
}
