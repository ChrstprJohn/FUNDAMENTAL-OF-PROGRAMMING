using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Controllers;

public class PICARDOCHRISTOPHERJOHN_24_1635_HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction(nameof(BasicIO));
    }

    [HttpGet("/basic-io")]
    public IActionResult BasicIO()
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio");
    }

    [HttpGet("/nested-if-else")]
    public IActionResult NestedIfElse()
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse");
    }

    [HttpGet("/loops")]
    public IActionResult Loops()
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops");
    }

    [HttpGet("/arrays")]
    public IActionResult Arrays()
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays");
    }

    [Route("/error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var model = new PICARDOCHRISTOPHERJOHN_24_1635_ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };

        return View("PICARDOCHRISTOPHERJOHN_24-1635_error", model);
    }
}
