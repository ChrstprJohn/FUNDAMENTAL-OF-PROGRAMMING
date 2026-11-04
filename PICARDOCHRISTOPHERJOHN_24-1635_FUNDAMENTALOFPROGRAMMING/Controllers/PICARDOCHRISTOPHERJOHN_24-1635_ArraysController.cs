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

    [HttpPost("/array-sum")]
    public IActionResult Sum(PICARDOCHRISTOPHERJOHN_24_1635_ArraySumModel Sum)
    {
        if (ModelState.IsValid)
            Sum.Calculate();

        var inputs = Sum.Numbers ?? [];
        if (inputs.Length < 5)
        {
            Array.Resize(ref inputs, 5);
            Sum.Numbers = inputs;
        }

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Sum = Sum });
    }

    [HttpPost("/array-largest")]
    public IActionResult Largest(PICARDOCHRISTOPHERJOHN_24_1635_ArrayLargestModel Largest)
    {
        if (ModelState.IsValid)
            Largest.Calculate();

        var inputs = Largest.Numbers ?? [];
        if (inputs.Length < 5)
        {
            Array.Resize(ref inputs, 5);
            Largest.Numbers = inputs;
        }

        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Largest = Largest });
    }

    [HttpPost("/row-column-totals")]
    public IActionResult Totals(PICARDOCHRISTOPHERJOHN_24_1635_MatrixTotalsModel Totals)
    {
        if (ModelState.IsValid)
            Totals.Calculate();
        var cells = Totals.Cells ?? [];
        if (cells.Length < 9)
        {
            Array.Resize(ref cells, 9);
            Totals.Cells = cells;
        }
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Totals = Totals });
    }

    [HttpPost("/highest-lowest")]
    public IActionResult Extremes(PICARDOCHRISTOPHERJOHN_24_1635_MatrixExtremesModel Extremes)
    {
        if (ModelState.IsValid)
            Extremes.Calculate();
        var cells = Extremes.Cells ?? [];
        if (cells.Length < 4)
        {
            Array.Resize(ref cells, 4);
            Extremes.Cells = cells;
        }
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Extremes = Extremes });
    }

    [HttpPost("/multiplication-grid")]
    public IActionResult Grid(PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationGridModel Grid)
    {
        if (ModelState.IsValid)
            Grid.Calculate();
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Grid = Grid });
    }

}
