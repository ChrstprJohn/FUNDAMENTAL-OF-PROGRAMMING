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

    [HttpPost("/loops/digits")]
    [ValidateAntiForgeryToken]
    public IActionResult Digits([Bind(Prefix = "Digits")] PICARDOCHRISTOPHERJOHN_24_1635_DigitSumModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Digits = model });
    }

    [HttpPost("/loops/countdown")]
    [ValidateAntiForgeryToken]
    public IActionResult Countdown([Bind(Prefix = "Countdown")] PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Countdown = model });
    }

    [HttpPost("/loops/sum")]
    [ValidateAntiForgeryToken]
    public IActionResult Sum([Bind(Prefix = "Sum")] PICARDOCHRISTOPHERJOHN_24_1635_NumberSumModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Sum = model });
    }
}
