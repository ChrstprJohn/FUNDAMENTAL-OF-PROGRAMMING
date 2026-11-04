# Build your Basic Calculator

This is the original standalone learning exercise the student followed. The calculator is now implemented and grouped with four other forms in `BasicIOPageModel`. Keep this guide as a learning reference; replacing the current integrated controller or view with these original snippets would remove the newer forms.

All paths below start inside the inner project folder:
`PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/` (the folder containing `Program.cs`).

The flow is: browser form → controller checks validation → model calculates → controller returns the view → view displays the result.

## 1. Create the model

In `Models/BasicIO`, create **`PICARDOCHRISTOPHERJOHN_24-1635_CalculatorModel.cs`**. Paste:

```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.BasicIO;

public class PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel
{
    [Required(ErrorMessage = "Enter the first number.")]
    public decimal? FirstNumber { get; set; }

    [Required(ErrorMessage = "Enter the second number.")]
    public decimal? SecondNumber { get; set; }

    [Required(ErrorMessage = "Choose an operation.")]
    [RegularExpression("^(add|subtract|multiply|divide)$",
        ErrorMessage = "Choose a valid operation.")]
    public string Operation { get; set; } = "add";

    [BindNever]
    public decimal? Result { get; set; }

    public void Calculate()
    {
        decimal first = FirstNumber.GetValueOrDefault();
        decimal second = SecondNumber.GetValueOrDefault();

        switch (Operation)
        {
            case "add":
                Result = first + second;
                break;
            case "subtract":
                Result = first - second;
                break;
            case "multiply":
                Result = first * second;
                break;
            case "divide":
                Result = first / second;
                break;
        }
    }
}
```

The model holds the form values, validation rules, and calculation logic. `decimal?` allows an empty number to be caught by `[Required]`. `[BindNever]` ensures the browser cannot submit its own calculated result. `Calculate()` handles the arithmetic after validation succeeds.

The filename keeps `24-1635`; the class and namespace use `24_1635` because C# identifiers cannot contain hyphens.

## 2. Update the controller

Open **`Controllers/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs`**.

Find the current `[HttpGet("/basic-io")]` attribute and `BasicIO()` method. Replace only that attribute and method with both methods below. Keep the namespace, class, imports, and all other actions. The existing `using ...Models.BasicIO;` import already makes the new model available.

```csharp
[HttpGet("/basic-io")]
public IActionResult BasicIO()
{
    var model = new PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel();
    return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", model);
}

[HttpPost("/calculator")]
public IActionResult Calculator(PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel model)
{
    if (!ModelState.IsValid)
    {
        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", model);
    }

    try
    {
        model.Calculate();
    }
    catch (DivideByZeroException)
    {
        ModelState.AddModelError(nameof(model.SecondNumber), "Cannot divide by zero.");
    }
    catch (OverflowException)
    {
        ModelState.AddModelError(string.Empty, "The result is too large. Try smaller numbers.");
    }

    return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", model);
}
```

GET opens the form. POST receives its values, checks validation, asks the model to calculate, and returns the same view. The controller turns division-by-zero and overflow errors into readable form messages. Arithmetic stays in the model; Razor only renders the result.

This local learning version does not validate antiforgery tokens on POST requests.

## 3. Update the view

Open **`Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml`**.

Replace that file's contents with:

```cshtml
@model PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel
@{
    ViewData["Title"] = "Basic Input-Output";
    ViewData["Topic"] = "BasicIO";
}

<h1 class="text-3xl font-semibold tracking-tight sm:text-4xl">Basic Input-Output</h1>
<p class="mt-5 text-lg leading-relaxed text-stone-700">Enter two numbers and choose an operation.</p>

<section aria-labelledby="calculator-title" class="mt-8 bg-course-light p-6 sm:p-8">
    <h2 id="calculator-title" class="text-2xl font-semibold">Basic Calculator</h2>

    <form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_BasicIO"
          asp-action="Calculator" method="post" class="mt-6 max-w-lg space-y-5">
        <div asp-validation-summary="ModelOnly" class="text-red-800" role="alert"></div>

        <div>
            <label asp-for="FirstNumber" class="block font-semibold">First number</label>
            <input asp-for="FirstNumber" type="number" step="any" required
                   class="mt-2 min-h-11 w-full border border-stone-500 bg-white px-3 py-2" />
            <span asp-validation-for="FirstNumber" class="mt-1 block text-sm text-red-800"></span>
        </div>

        <div>
            <label asp-for="Operation" class="block font-semibold">Operation</label>
            <select asp-for="Operation" required
                    class="mt-2 min-h-11 w-full border border-stone-500 bg-white px-3 py-2">
                <option value="add">Add (+)</option>
                <option value="subtract">Subtract (-)</option>
                <option value="multiply">Multiply (×)</option>
                <option value="divide">Divide (÷)</option>
            </select>
            <span asp-validation-for="Operation" class="mt-1 block text-sm text-red-800"></span>
        </div>

        <div>
            <label asp-for="SecondNumber" class="block font-semibold">Second number</label>
            <input asp-for="SecondNumber" type="number" step="any" required
                   class="mt-2 min-h-11 w-full border border-stone-500 bg-white px-3 py-2" />
            <span asp-validation-for="SecondNumber" class="mt-1 block text-sm text-red-800"></span>
        </div>

        <button type="submit" class="min-h-11 bg-course-green px-5 py-2 font-semibold text-white hover:bg-course-dark">
            Calculate
        </button>
    </form>

    @if (Model.Result.HasValue)
    {
        <p class="mt-6 text-xl font-semibold" role="status">
            Result: <output>@Model.Result.Value.ToString("G29")</output>
        </p>
    }
</section>
```

`@model` connects the page to the model. `asp-for` binds each input to a property. `asp-validation-for` displays its server validation message. No calculation belongs in this Razor file.

You do not need to change `Program.cs`, `_ViewImports.cshtml`, or the shared layout. There are still four topic views; the calculator lives inside Basic Input-Output.

## 4. Build and check

In the inner project folder, run:

```powershell
npm run build:css
dotnet build
dotnet run --launch-profile http
```

Open `http://localhost:5291/basic-io`.

| First number | Operation | Second number | Expected |
| ---: | --- | ---: | --- |
| 10 | Add | 5 | 15 |
| 10 | Subtract | 5 | 5 |
| 10 | Multiply | 5 | 50 |
| 10 | Divide | 4 | 2.5 |
| 10 | Divide | 0 | Cannot divide by zero |
| -2.5 | Add | 1 | -1.5 |

Also try leaving a number blank: the browser should require it. Server validation still protects requests that bypass the browser. Invalid operations and out-of-range decimal values must not produce a result.

Stop the server with Ctrl+C. Once this calculator is working, the agent can add BMI, Temperature Converter, Personalized Greeting Generator, and Circle Area & Circumference to this same topic page.
