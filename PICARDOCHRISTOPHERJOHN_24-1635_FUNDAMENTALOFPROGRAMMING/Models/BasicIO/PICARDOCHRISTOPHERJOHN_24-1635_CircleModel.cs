using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.BasicIO;

public class PICARDOCHRISTOPHERJOHN_24_1635_CircleModel
{
    [Required]
    [Range(0.01, 1000000)]
    public double? Radius { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        double radius = Radius.GetValueOrDefault();
        double area = Math.PI * radius * radius;
        double circumference = 2 * Math.PI * radius;
        Result = $"Area: {area:F2} square units; Circumference: {circumference:F2} units";
    }
}
