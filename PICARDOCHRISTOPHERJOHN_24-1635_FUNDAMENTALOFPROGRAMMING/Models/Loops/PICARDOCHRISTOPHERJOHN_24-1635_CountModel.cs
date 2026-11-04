using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Loops;

public class PICARDOCHRISTOPHERJOHN_24_1635_CountModel
{
    [Required]
    [Range(1, 20)]
    public int? Limit { get; set; }

    public string? Result { get; private set; }

    public void Calculate()
    {
        int current = 1;
        var numbers = new List<int>();
        while (current <= Limit.GetValueOrDefault())
        {
            numbers.Add(current);
            current++;
        }
        Result = string.Join(", ", numbers);
    }
}
