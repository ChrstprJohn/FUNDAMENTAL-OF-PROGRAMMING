using Microsoft.AspNetCore.Mvc;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Loops;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Controllers;

public class PICARDOCHRISTOPHERJOHN_24_1635_LoopsController : Controller
{
    [HttpGet("/loops")]
    public IActionResult Index()
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel());
    }

    [HttpPost("/loops/table")]
    [ValidateAntiForgeryToken]
    public IActionResult Table([Bind(Prefix = "Table")] PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Table = model });
    }

    [HttpPost("/loops/count")]
    [ValidateAntiForgeryToken]
    public IActionResult Count([Bind(Prefix = "Count")] PICARDOCHRISTOPHERJOHN_24_1635_CountModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Count = model });
    }

    [HttpPost("/loops/star-line")]
    [ValidateAntiForgeryToken]
    public IActionResult StarLine([Bind(Prefix = "StarLine")] PICARDOCHRISTOPHERJOHN_24_1635_StarLineModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { StarLine = model });
    }

    [HttpPost("/loops/countdown")]
    [ValidateAntiForgeryToken]
    public IActionResult Countdown([Bind(Prefix = "Countdown")] PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Countdown = model });
    }

    [HttpPost("/loops/star-triangle")]
    [ValidateAntiForgeryToken]
    public IActionResult StarTriangle([Bind(Prefix = "StarTriangle")] PICARDOCHRISTOPHERJOHN_24_1635_StarTriangleModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { StarTriangle = model });
    }
}
