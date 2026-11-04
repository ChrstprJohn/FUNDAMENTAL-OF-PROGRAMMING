using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Loops;

public class PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel
{
    [Required]
    [Range(1, 20)]
    public int? Start { get; set; }

    public string? Result { get; private set; }

    public void Calculate()
    {
        int current = Start.GetValueOrDefault();
        var numbers = new List<int>();
        do
        {
            numbers.Add(current);
            current--;
        }
        while (current >= 0);
        Result = string.Join(", ", numbers);
    }
}
