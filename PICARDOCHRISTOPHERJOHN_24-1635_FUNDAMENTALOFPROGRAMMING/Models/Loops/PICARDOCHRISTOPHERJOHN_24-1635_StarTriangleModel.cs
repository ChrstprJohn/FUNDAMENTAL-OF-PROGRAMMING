using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Loops;

public class PICARDOCHRISTOPHERJOHN_24_1635_StarTriangleModel
{
    [Required]
    [Range(1, 20)]
    public int? Rows { get; set; }

    public string? Result { get; private set; }

    public void Calculate()
    {
        int row = 1;
        string stars = "";
        var lines = new List<string>();
        do
        {
            stars += "*";
            lines.Add(stars);
            row++;
        }
        while (row <= Rows.GetValueOrDefault());
        Result = string.Join("\n", lines);
    }
}
