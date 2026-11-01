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

        var inputs = model.Numbers ?? [];
        if (inputs.Length < 5)
        {
            Array.Resize(ref inputs, 5);
            model.Numbers = inputs;
        }

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Sum = model });
    }

    [HttpPost("/arrays/largest")]
    [ValidateAntiForgeryToken]
    public IActionResult Largest([Bind(Prefix = "Largest")] PICARDOCHRISTOPHERJOHN_24_1635_ArrayModel model)
    {
        if (ModelState.IsValid)
            model.FindLargest();

        var inputs = model.Numbers ?? [];
        if (inputs.Length < 5)
        {
            Array.Resize(ref inputs, 5);
            model.Numbers = inputs;
        }

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Largest = model });
    }

    [HttpPost("/arrays/totals")]
    [ValidateAntiForgeryToken]
    public IActionResult Totals([Bind(Prefix = "Totals")] PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel model)
    {
        if (ModelState.IsValid)
            model.CalculateTotals();
        var cells = model.Cells ?? [];
        if (cells.Length < 4)
        {
            Array.Resize(ref cells, 4);
            model.Cells = cells;
        }
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Totals = model });
    }

    [HttpPost("/arrays/extremes")]
    [ValidateAntiForgeryToken]
    public IActionResult Extremes([Bind(Prefix = "Extremes")] PICARDOCHRISTOPHERJOHN_24_1635_MatrixModel model)
    {
        if (ModelState.IsValid)
            model.FindExtremes();
        var cells = model.Cells ?? [];
        if (cells.Length < 4)
        {
            Array.Resize(ref cells, 4);
            model.Cells = cells;
        }
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Extremes = model });
    }

    [HttpPost("/arrays/grid")]
    [ValidateAntiForgeryToken]
    public IActionResult Grid([Bind(Prefix = "Grid")] PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationGridModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Grid = model });
    }

}
