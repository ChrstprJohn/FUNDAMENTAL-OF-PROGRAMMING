using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Arrays;

public class PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationGridModel
{
    [Required]
    [Range(1, 10)]
    public int? Rows { get; set; } = 10;
    [Required]
    [Range(1, 10)]
    public int? Columns { get; set; } = 10;
    public string? ArrayContents { get; private set; }
    public string? Result { get; private set; }

    public void Calculate()
    {
        int rows = Rows.GetValueOrDefault();
        int columns = Columns.GetValueOrDefault();
        int[,] table = new int[rows, columns];
        var lines = new List<string>();
        for (int row = 0; row < rows; row++)
        {
            string line = "";
            for (int column = 0; column < columns; column++)
            {
                table[row, column] = (row + 1) * (column + 1);
                line += table[row, column].ToString().PadLeft(4);
            }
            lines.Add(line);
        }
        Result = string.Join("\n", lines);
        ArrayContents = $"int[,] table = new int[{rows}, {columns}];";
    }
}
