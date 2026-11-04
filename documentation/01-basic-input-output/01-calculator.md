# Basic Calculator: follow the data

[All guides](../README.md) · [Topic guides](README.md) · [Start here: app startup and word guide](../00-start-here.md)

This is a reading guide for the saved code on 2026-11-05. Line numbers can move when you edit a source file. Use the method name shown if a line moves.

## 1. Start the app, then open the topic

Start at [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1). Line 3 enables controllers and views. Line 25, `app.Run()`, waits for requests. See the start-here guide for the full startup trace.

Open `/basic-io` in your browser. That sends `GET /basic-io` to [PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs, line 15](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs:15). ASP.NET chooses our `BasicIO()` action below it. An action is simply a controller method that handles a request.

The action calls `View(...)` with the topic's view name and `new BasicIOPageModel()`. The actual class has the student prefix; this paragraph shortens it.

Like Express: `app.get("/basic-io", (req, res) => res.render("basicio", pageData));`.

## 2. Give the View fresh data

Open [PICARDOCHRISTOPHERJOHN_24-1635_BasicIOPageModel.cs, line 5](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOPageModel.cs:5). Its `Calculator` property holds this example's model. The page model groups all five examples. It does not run Calculate().

Open [PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml:1). `@model` tells Razor which kind of data the View expects. `Model` is the View's access to the object passed by the controller. The model holds values; the View holds the HTML and lesson text.

ASP.NET renders that View inside the shared layout and sends HTML to the browser. At first, Result is null (no answer), so the result block is hidden. Some array inputs have starting values, but those values do not calculate themselves.

## 3. Find this form and enter the sample

Open [PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml, line 25](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml:25).

```html
<form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_BasicIO"
      asp-action="Calculator"
      asp-fragment="calculator"
      method="post"
      asp-antiforgery="false">
```

This is a shortened copy without the styling classes.

| Part | Simple meaning |
| --- | --- |
| `asp-controller` | Select our controller class without its Controller ending. It is not a View filename. |
| `asp-action="Calculator"` | Select our `Calculator(...)` method in that controller. |
| `asp-fragment="calculator"` | Add `#calculator` so the browser jumps to that page section. |
| `method="post"` | Send the form values. This is normal HTML. |
| `asp-antiforgery="false"` | Do not generate a form token in this local learning version. |

The asp- helpers are provided by ASP.NET. They produce ordinary HTML with `action="/calculator#calculator"`. The browser sends the request to `/calculator`; the part after # stays in the browser.

Enter this sample:

| Submitted field name | Sample value | Find it |
| --- | --- | --- |
| `Calculator.FirstNumber` | `5` | [View line 27](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml:27) |
| `Calculator.SecondNumber` | `3` | [View line 42](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml:42) |
| `Calculator.Operation` | `add` | [View line 32](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml:32) |

`asp-for="Calculator.FirstNumber"` creates an input name matching that model path. Clicking the submit button sends this form's fields. It does not submit the other four forms.

## 4. POST reaches the controller

Open [PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs, line 21](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs:21):

```csharp
    [HttpPost("/calculator")]
    public IActionResult Calculator(PICARDOCHRISTOPHERJOHN_24_1635_CalculatorModel Calculator)
```

`[HttpPost("/calculator")]` is an ASP.NET route attribute. Like `app.post("/calculator", handler)` in Express, it selects the handler for this address and request type.

The first `Calculator` is our action's name. The last `Calculator` is the variable holding this form's data. The long model name between them is the type of that variable.

ASP.NET automatically reads the form values into that variable before the method body runs. There is no `[Bind]` attribute. The input names start with `Calculator.`, and the parameter is named `Calculator`, so the names match. Changing the URL alone would not change the field names.

For example, `Calculator.FirstNumber` arrives as `5`. Numeric text is converted into the model's number type. Bad number text adds an input error.

## 5. Check the input

Open [PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs, line 24](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs:24): `if (ModelState.IsValid)` means "only calculate if the input checks passed." `if` is C# syntax; ModelState and IsValid are provided by ASP.NET.

The model's input properties and rules are at [PICARDOCHRISTOPHERJOHN_24-1635_CalculatorModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_CalculatorModel.cs:7):

```csharp
[Required(ErrorMessage = "Enter the first number.")]
    public decimal? FirstNumber { get; set; }

    [Required(ErrorMessage = "Enter the second number.")]
    public decimal? SecondNumber { get; set; }

    [Required]
    [RegularExpression("^(add|subtract|multiply|divide)$",
        ErrorMessage = "Choose a valid operation.")]
    public string Operation { get; set; } = "add";

    public decimal? Result { get; private set; }
```

`[Required]`, `[Range]`, and similar rules are provided by .NET. The property names are ours. `get; set;` allows a value to be read and assigned. `private set` means only code inside this model can assign that output. A `?` after a number type allows an empty value.

The controller catches division by zero and an answer too large for decimal. `try` and `catch` are C# syntax. `ModelState.AddModelError(...)` is an ASP.NET method that adds a message for the View to show.

If a browser catches an empty required field, it can stop the submit immediately. The server also checks input, since browser checks can be bypassed. If server validation fails, Calculate() is skipped and the same topic view shows error messages.

## 6. Call our calculation method

At [PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs, line 28](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs:28), `Calculator.Calculate()` calls our method in [PICARDOCHRISTOPHERJOHN_24-1635_CalculatorModel.cs, line 20](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_CalculatorModel.cs:20). Calculate is a method we wrote, not a built-in ASP.NET function.

Follow this sample:

1. Read 5 and 3 into first and second.
2. The switch checks Operation. It matches add.
3. Set Result to 5 + 3, which is 8. Subtract, multiply and divide have their own cases.

Here is the actual Calculate() code and the closing class brace:

```csharp
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

Useful words: `GetValueOrDefault()` is a .NET method that reads a nullable number (zero if empty). Validation is checked first here. `if`, `else`, `switch`, `for`, `while`, `do`, and `foreach` are C# syntax when they appear. `List<T>`, `Add`, `string.Join`, `Math.PI`, `Trim`, and `PadLeft` are .NET types or members when they appear. `Result`, `PopulateArray`, and this example's input names are ours. See the shared word guide for details.

## 7. Return to the controller, then the View

After Calculate() finishes, execution continues in the controller. At [PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs, line 40](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs:40):

```csharp
        return View("PICARDOCHRISTOPHERJOHN_24-1635_basicio", new PICARDOCHRISTOPHERJOHN_24_1635_BasicIOPageModel { Calculator = Calculator });
```

Inside `{ Calculator = Calculator }`, the left name is the page model's property. The right name is the controller variable containing the submitted values and answer. This is C# object setup syntax, similar to JavaScript `{ Calculator: Calculator }`.

The controller returns the whole topic view with this updated model. The other four example models are fresh. No database is involved. This is a direct View response, not a redirect; the browser address stays on `/calculator` (with its section fragment).

## 8. Display the answer

Open [PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml, line 48](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml:48). The condition checks whether this example has a Result. At [PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml, line 50](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/PICARDOCHRISTOPHERJOHN_24-1635_basicio.cshtml:50), Razor writes that answer into the HTML.

Expected output for this sample:

```text
Result: 8
```

The server sends the finished HTML back. Your browser displays it. It does not run the C# calculation itself. The expandable "See the C# logic" block is displayed sample text, not the code that processes the form.

## The same idea in Express

This is a comparison, not code used by the project. It assumes `express.urlencoded({ extended: false })` and a configured view engine. The calculate and validation functions below would be functions you write.

```js
app.get("/basic-io", (req, res) => {
    res.render("basicio", makeFreshPageData());
});

// Example of the form's flat field names in req.body:
const sampleBody = {
    "Calculator.FirstNumber": "5",
    "Calculator.SecondNumber": "3",
    "Calculator.Operation": "add"
};

app.post("/calculator", (req, res) => {
    // Read the relevant keys from req.body and convert number text.
    const input = readAndCheckInputs(req.body);
    const pageData = makeFreshPageData();
    if (input.isValid) {
        pageData.Calculator = calculateExample(input.values);
    } else {
        pageData.Calculator = input.values;
        pageData.errors = input.errors;
    }
    res.render("basicio", pageData);
});
```

ASP.NET handles the form-to-object reading and model validation for you. Our controller still decides when to calculate and which view to return.

## Trace to remember

```text
Program.cs starts the server
  -> GET /basic-io
  -> controller chooses View + fresh page model
  -> View becomes HTML -> browser shows form
  -> enter this example's values -> submit
  -> POST /calculator
  -> ASP.NET fills the Calculator parameter and checks input
  -> controller checks ModelState.IsValid
  -> Calculator.Calculate() -> Result
  -> controller returns View + updated page model
  -> Razor writes Result into HTML
  -> browser shows the answer
```
