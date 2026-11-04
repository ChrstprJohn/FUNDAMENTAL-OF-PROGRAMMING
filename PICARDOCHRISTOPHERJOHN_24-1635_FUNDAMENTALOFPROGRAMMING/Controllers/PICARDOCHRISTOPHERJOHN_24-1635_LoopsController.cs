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

    [HttpPost("/multiplication-table")]
    public IActionResult Table(PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationModel Table)
    {
        if (ModelState.IsValid)
            Table.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Table = Table });
    }

    [HttpPost("/count-to-n")]
    public IActionResult Count(PICARDOCHRISTOPHERJOHN_24_1635_CountModel Count)
    {
        if (ModelState.IsValid)
            Count.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Count = Count });
    }

    [HttpPost("/star-line")]
    public IActionResult StarLine(PICARDOCHRISTOPHERJOHN_24_1635_StarLineModel StarLine)
    {
        if (ModelState.IsValid)
            StarLine.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { StarLine = StarLine });
    }

    [HttpPost("/countdown")]
    public IActionResult Countdown(PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel Countdown)
    {
        if (ModelState.IsValid)
            Countdown.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Countdown = Countdown });
    }

    [HttpPost("/star-triangle")]
    public IActionResult StarTriangle(PICARDOCHRISTOPHERJOHN_24_1635_StarTriangleModel StarTriangle)
    {
        if (ModelState.IsValid)
            StarTriangle.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { StarTriangle = StarTriangle });
    }
}
