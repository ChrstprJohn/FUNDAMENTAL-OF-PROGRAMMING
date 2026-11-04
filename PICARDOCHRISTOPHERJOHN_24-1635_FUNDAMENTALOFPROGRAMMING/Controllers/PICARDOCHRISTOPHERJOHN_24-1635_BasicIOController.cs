using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.BasicIO;
using PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Shared;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Controllers;

public class PICARDOCHRISTOPHERJOHN_24_1635_BasicIOController : Controller
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

    [HttpPost("/calculator")]
    public IActionResult Calculator(PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel Calculator)
    {
        if (ModelState.IsValid)
        {
            try
            {
                Calculator.Calculate();
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

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Calculator = Calculator });
    }

    [HttpPost("/bmi")]
    public IActionResult Bmi(PICARDOCHRISTOPHERJOHN_24_1635_BmiModel Bmi)
    {
        if (ModelState.IsValid)
            Bmi.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Bmi = Bmi });
    }

    [HttpPost("/temperature")]
    public IActionResult Temperature(PICARDOCHRISTOPHERJOHN_24_1635_TemperatureModel Temperature)
    {
        if (ModelState.IsValid)
            Temperature.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Temperature = Temperature });
    }

    [HttpPost("/greeting")]
    public IActionResult Greeting(PICARDOCHRISTOPHERJOHN_24_1635_GreetingModel Greeting)
    {
        if (ModelState.IsValid)
            Greeting.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Greeting = Greeting });
    }

    [HttpPost("/circle")]
    public IActionResult Circle(PICARDOCHRISTOPHERJOHN_24_1635_CircleModel Circle)
    {
        if (ModelState.IsValid)
            Circle.Calculate();

        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Circle = Circle });
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
