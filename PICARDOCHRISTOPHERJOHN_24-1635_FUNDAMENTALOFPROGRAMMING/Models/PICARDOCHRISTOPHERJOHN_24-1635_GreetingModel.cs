using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

public class PICARDOCHRISTOPHERJOHN_24_1635_GreetingModel
{
    [Required]
    [StringLength(60)]
    public string? Name { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        Result = $"Hello, {Name?.Trim()}! Welcome to Fundamental of Programming.";
    }
}
