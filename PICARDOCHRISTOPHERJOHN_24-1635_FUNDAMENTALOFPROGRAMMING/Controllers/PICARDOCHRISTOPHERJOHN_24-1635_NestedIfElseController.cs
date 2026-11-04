using Microsoft.AspNetCore.Mvc;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.NestedIfElse;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Controllers;

public class PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElseController : Controller
{
    [HttpGet("/nested-if-else")]
    public IActionResult Index()
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel());
    }

    [HttpPost("/number-sign")]
    public IActionResult Number(PICARDOCHRISTOPHERJOHN_24_1635_NumberCheckModel Number)
    {
        if (ModelState.IsValid)
            Number.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Number = Number });
    }

    [HttpPost("/grade")]
    public IActionResult Grade(PICARDOCHRISTOPHERJOHN_24_1635_GradeModel Grade)
    {
        if (ModelState.IsValid)
            Grade.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Grade = Grade });
    }

    [HttpPost("/age")]
    public IActionResult Age(PICARDOCHRISTOPHERJOHN_24_1635_AgeGroupModel Age)
    {
        if (ModelState.IsValid)
            Age.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Age = Age });
    }

    [HttpPost("/largest-of-three")]
    public IActionResult Largest(PICARDOCHRISTOPHERJOHN_24_1635_LargestNumberModel Largest)
    {
        if (ModelState.IsValid)
            Largest.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Largest = Largest });
    }

    [HttpPost("/sign-and-parity")]
    public IActionResult Parity(PICARDOCHRISTOPHERJOHN_24_1635_ParityModel Parity)
    {
        if (ModelState.IsValid)
            Parity.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Parity = Parity });
    }
}
