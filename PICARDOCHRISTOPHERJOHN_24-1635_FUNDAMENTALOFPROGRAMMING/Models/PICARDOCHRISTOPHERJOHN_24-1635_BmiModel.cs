using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

public class PICARDOCHRISTOPHERJOHN_24_1635_BmiModel
{
    [Required]
    [Range(1.0, 500.0)]
    public double? Weight { get; set; }

    [Required]
    [Range(50.0, 300.0)]
    public double? Height { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        double heightInMetres = Height.GetValueOrDefault() / 100;
        double bmi = Weight.GetValueOrDefault() / (heightInMetres * heightInMetres);
        Result = $"BMI: {bmi:F2} kg/m²";
    }
}
