using Microsoft.AspNetCore.Mvc;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Controllers;

public class PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElseController : Controller
{
    [HttpGet("/nested-if-else")]
    public IActionResult Index()
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel());
    }

    [HttpPost("/nested-if-else/number")]
    [ValidateAntiForgeryToken]
    public IActionResult Number([Bind(Prefix = "Number")] PICARDOCHRISTOPHERJOHN_24_1635_NumberCheckModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Number = model });
    }

    [HttpPost("/nested-if-else/grade")]
    [ValidateAntiForgeryToken]
    public IActionResult Grade([Bind(Prefix = "Grade")] PICARDOCHRISTOPHERJOHN_24_1635_GradeModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Grade = model });
    }

    [HttpPost("/nested-if-else/age")]
    [ValidateAntiForgeryToken]
    public IActionResult Age([Bind(Prefix = "Age")] PICARDOCHRISTOPHERJOHN_24_1635_AgeGroupModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Age = model });
    }

    [HttpPost("/nested-if-else/largest")]
    [ValidateAntiForgeryToken]
    public IActionResult Largest([Bind(Prefix = "Largest")] PICARDOCHRISTOPHERJOHN_24_1635_LargestNumberModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Largest = model });
    }

    [HttpPost("/nested-if-else/shipping")]
    [ValidateAntiForgeryToken]
    public IActionResult Shipping([Bind(Prefix = "Shipping")] PICARDOCHRISTOPHERJOHN_24_1635_ShippingModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Shipping = model });
    }
}
