using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.NestedIfElse;

public class PICARDOCHRISTOPHERJOHN_24_1635_AgeGroupModel
{
    [Required]
    [Display(Name = "Age")]
    [Range(0, 120)]
    public int? Years { get; set; }

    public string? Result { get; private set; }

    public void Calculate()
    {
        int age = Years.GetValueOrDefault();
        if (age >= 18)
        {
            if (age >= 60)
                Result = "Senior";
            else
                Result = "Adult";
        }
        else
        {
            if (age >= 13)
                Result = "Teenager";
            else
                Result = "Child";
        }
    }
}
