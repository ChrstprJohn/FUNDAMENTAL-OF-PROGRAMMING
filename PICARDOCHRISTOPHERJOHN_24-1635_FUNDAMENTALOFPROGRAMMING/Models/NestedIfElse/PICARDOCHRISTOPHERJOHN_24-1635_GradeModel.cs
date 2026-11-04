using System.ComponentModel.DataAnnotations;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.NestedIfElse;

public class PICARDOCHRISTOPHERJOHN_24_1635_GradeModel
{
    [Required]
    [Display(Name = "Grade")]
    [Range(0, 100)]
    public int? Score { get; set; }

    public string? Result { get; private set; }

    public void Calculate()
    {
        int grade = Score.GetValueOrDefault();
        if (grade >= 75)
        {
            if (grade >= 90)
                Result = "Passed with distinction.";
            else
                Result = "Passed.";
        }
        else
        {
            if (grade >= 60)
                Result = "Needs improvement.";
            else
                Result = "Failed.";
        }
    }
}
