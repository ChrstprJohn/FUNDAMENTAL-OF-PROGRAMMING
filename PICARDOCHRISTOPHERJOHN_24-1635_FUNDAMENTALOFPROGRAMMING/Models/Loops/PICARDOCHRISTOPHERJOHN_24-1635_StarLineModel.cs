using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Loops;

public class PICARDOCHRISTOPHERJOHN_24_1635_StarLineModel
{
    [Required]
    [Range(1, 50)]
    public int? Count { get; set; }

    public string? Result { get; private set; }

    public void Calculate()
    {
        int current = 0;
        string stars = "";
        while (current < Count.GetValueOrDefault())
        {
            stars += "*";
            current++;
        }
        Result = stars;
    }
}
