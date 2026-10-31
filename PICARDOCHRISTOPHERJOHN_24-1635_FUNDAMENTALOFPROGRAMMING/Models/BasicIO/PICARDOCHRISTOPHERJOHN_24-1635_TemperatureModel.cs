using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.BasicIO;

public class PICARDOCHRISTOPHERJOHN_24_1635_TemperatureModel
{
    [Required]
    [Display(Name = "Temperature")]
    [Range(-1000000.0, 1000000.0)]
    public double? Value { get; set; }

    [Required]
    [RegularExpression("^(c-to-f|f-to-c)$", ErrorMessage = "Choose a valid conversion.")]
    public string Direction { get; set; } = "c-to-f";

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        double temperature = Value.GetValueOrDefault();
        if (Direction == "c-to-f")
            Result = $"{temperature * 9 / 5 + 32:F2} °F";
        else
            Result = $"{(temperature - 32) * 5 / 9:F2} °C";
    }
}
