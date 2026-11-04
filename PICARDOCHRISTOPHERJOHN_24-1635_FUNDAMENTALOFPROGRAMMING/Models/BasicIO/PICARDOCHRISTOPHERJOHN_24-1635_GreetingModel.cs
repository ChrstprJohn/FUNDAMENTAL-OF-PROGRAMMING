using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.BasicIO;

public class PICARDOCHRISTOPHERJOHN_24_1635_GreetingModel
{
    [Required]
    [StringLength(60)]
    public string? Name { get; set; }

    public string? Result { get; private set; }

    public void Calculate()
    {
        Result = $"Hello, {Name?.Trim()}! Welcome to Fundamental of Programming.";
    }
}
