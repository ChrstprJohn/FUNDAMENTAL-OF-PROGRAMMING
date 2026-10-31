using Microsoft.AspNetCore.Mvc;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Arrays;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Controllers;

public class PICARDOCHRISTOPHERJOHN_24_1635_ArraysController : Controller
{
    [HttpGet("/arrays")]
    public IActionResult Index()
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel());
    }

    [HttpPost("/arrays/sum")]
    [ValidateAntiForgeryToken]
    public IActionResult Sum([Bind(Prefix = "Sum")] PICARDOCHRISTOPHERJOHN_24_1635_ArrayModel model)
    {
        if (ModelState.IsValid)
            model.CalculateSum();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Sum = model });
    }

    [HttpPost("/arrays/largest")]
    [ValidateAntiForgeryToken]
    public IActionResult Largest([Bind(Prefix = "Largest")] PICARDOCHRISTOPHERJOHN_24_1635_ArrayModel model)
    {
        if (ModelState.IsValid)
            model.FindLargest();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Largest = model });
    }

    [HttpPost("/arrays/display")]
    [ValidateAntiForgeryToken]
    public IActionResult Display([Bind(Prefix = "Display")] PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel model)
    {
        if (ModelState.IsValid)
            model.Display();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Display = model });
    }

    [HttpPost("/arrays/row-totals")]
    [ValidateAntiForgeryToken]
    public IActionResult RowTotals([Bind(Prefix = "RowTotals")] PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel model)
    {
        if (ModelState.IsValid)
            model.CalculateRowTotals();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { RowTotals = model });
    }

    [HttpPost("/arrays/transpose")]
    [ValidateAntiForgeryToken]
    public IActionResult Transpose([Bind(Prefix = "Transpose")] PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel model)
    {
        if (ModelState.IsValid)
            model.Transpose();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Transpose = model });
    }
}
