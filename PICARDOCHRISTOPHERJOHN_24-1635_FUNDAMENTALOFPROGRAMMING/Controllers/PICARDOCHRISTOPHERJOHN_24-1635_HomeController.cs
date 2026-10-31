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
        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel());
    }

    [HttpPost("/basic-io")]
    [ValidateAntiForgeryToken]
    public IActionResult BasicIO([Bind(Prefix = "Calculator")] PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                model.Calculate();
            }
            catch (DivideByZeroException)
            {
                ModelState.AddModelError("Calculator.SecondNumber", "Cannot divide by zero.");
            }
            catch (OverflowException)
            {
                ModelState.AddModelError(string.Empty, "The result is too large. Try smaller numbers.");
            }
        }

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Calculator = model });
    }

    [HttpPost("/basic-io/bmi")]
    [ValidateAntiForgeryToken]
    public IActionResult Bmi([Bind(Prefix = "Bmi")] PICARDOCHRISTOPHERJOHN_24_1635_BmiModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Bmi = model });
    }

    [HttpPost("/basic-io/temperature")]
    [ValidateAntiForgeryToken]
    public IActionResult Temperature([Bind(Prefix = "Temperature")] PICARDOCHRISTOPHERJOHN_24_1635_TemperatureModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Temperature = model });
    }

    [HttpPost("/basic-io/greeting")]
    [ValidateAntiForgeryToken]
    public IActionResult Greeting([Bind(Prefix = "Greeting")] PICARDOCHRISTOPHERJOHN_24_1635_GreetingModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Greeting = model });
    }

    [HttpPost("/basic-io/circle")]
    [ValidateAntiForgeryToken]
    public IActionResult Circle([Bind(Prefix = "Circle")] PICARDOCHRISTOPHERJOHN_24_1635_CircleModel model)
    {
        if (ModelState.IsValid)
            model.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Circle = model });
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
