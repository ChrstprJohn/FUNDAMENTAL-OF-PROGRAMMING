# Countdown — Do While Loop: follow the data

[All guides](../README.md) · [Topic guides](README.md) · [Start here: app startup and word guide](../00-start-here.md)

This is a reading guide for the saved code on 2026-11-05. Line numbers can move when you edit a source file. Use the method name shown if a line moves.

## 1. Start the app, then open the topic

Start at [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1). Line 3 enables controllers and views. Line 25, `app.Run()`, waits for requests. See the start-here guide for the full startup trace.

Open `/loops` in your browser. That sends `GET /loops` to [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:8). ASP.NET chooses our `Index()` action below it. An action is simply a controller method that handles a request.

The action calls `View(...)` with the topic's view name and `new LoopsPageModel()`. The actual class has the student prefix; this paragraph shortens it.

Like Express: `app.get("/loops", (req, res) => res.render("loops", pageData));`.

## 2. Give the View fresh data

Open [PICARDOCHRISTOPHERJOHN_24-1635_LoopsPageModel.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Loops/PICARDOCHRISTOPHERJOHN_24-1635_LoopsPageModel.cs:8). Its `Countdown` property holds this example's model. The page model groups all five examples. It does not run Calculate().

Open [PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:1). `@model` tells Razor which kind of data the View expects. `Model` is the View's access to the object passed by the controller. The model holds values; the View holds the HTML and lesson text.

ASP.NET renders that View inside the shared layout and sends HTML to the browser. At first, Result is null (no answer), so the result block is hidden. Some array inputs have starting values, but those values do not calculate themselves.

## 3. Find this form and enter the sample

Open [PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml, line 108](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:108).

```html
<form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_Loops"
      asp-action="Countdown"
      asp-fragment="countdown"
      method="post"
      asp-antiforgery="false">
```

This is a shortened copy without the styling classes.

| Part | Simple meaning |
| --- | --- |
| `asp-controller` | Select our controller class without its Controller ending. It is not a View filename. |
| `asp-action="Countdown"` | Select our `Countdown(...)` method in that controller. |
| `asp-fragment="countdown"` | Add `#countdown` so the browser jumps to that page section. |
| `method="post"` | Send the form values. This is normal HTML. |
| `asp-antiforgery="false"` | Do not generate a form token in this local learning version. |

The asp- helpers are provided by ASP.NET. They produce ordinary HTML with `action="/countdown#countdown"`. The browser sends the request to `/countdown`; the part after # stays in the browser.

Enter this sample:

| Submitted field name | Sample value | Find it |
| --- | --- | --- |
| `Countdown.Start` | `3` | [View line 110](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:110) |

`asp-for="Countdown.Start"` creates an input name matching that model path. Clicking the submit button sends this form's fields. It does not submit the other four forms.

## 4. POST reaches the controller

Open [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 41](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:41):

```csharp
    [HttpPost("/countdown")]
    public IActionResult Countdown(PICARDOCHRISTOPHERJOHN_24_1635_CountdownModel Countdown)
```

`[HttpPost("/countdown")]` is an ASP.NET route attribute. Like `app.post("/countdown", handler)` in Express, it selects the handler for this address and request type.

The first `Countdown` is our action's name. The last `Countdown` is the variable holding this form's data. The long model name between them is the type of that variable.

ASP.NET automatically reads the form values into that variable before the method body runs. There is no `[Bind]` attribute. The input names start with `Countdown.`, and the parameter is named `Countdown`, so the names match. Changing the URL alone would not change the field names.

For example, `Countdown.Start` arrives as `3`. Numeric text is converted into the model's number type. Bad number text adds an input error.

## 5. Check the input

Open [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 44](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:44): `if (ModelState.IsValid)` means "only calculate if the input checks passed." `if` is C# syntax; ModelState and IsValid are provided by ASP.NET.

The model's input properties and rules are at [PICARDOCHRISTOPHERJOHN_24-1635_CountdownModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Loops/PICARDOCHRISTOPHERJOHN_24-1635_CountdownModel.cs:7):

```csharp
[Required]
    [Range(1, 20)]
    public int? Start { get; set; }

    public string? Result { get; private set; }
```

`[Required]`, `[Range]`, and similar rules are provided by .NET. The property names are ours. `get; set;` allows a value to be read and assigned. `private set` means only code inside this model can assign that output. A `?` after a number type allows an empty value.

If a browser catches an empty required field, it can stop the submit immediately. The server also checks input, since browser checks can be bypassed. If server validation fails, Calculate() is skipped and the same topic view shows error messages.

## 6. Call our calculation method

At [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 45](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:45), `Countdown.Calculate()` calls our method in [PICARDOCHRISTOPHERJOHN_24-1635_CountdownModel.cs, line 13](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Loops/PICARDOCHRISTOPHERJOHN_24-1635_CountdownModel.cs:13). Calculate is a method we wrote, not a built-in ASP.NET function.

Follow this sample:

1. Start current at 3. Add it to the list, then subtract 1.
2. Check current >= 0 after each turn. This loop runs its body before checking.
3. Add 3, 2, 1, and 0. Stop when current becomes -1, then join the list.

Here is the actual Calculate() code and the closing class brace:

```csharp
    public void Calculate()
    {
        int current = Start.GetValueOrDefault();
        var numbers = new List<int>();
        do
        {
            numbers.Add(current);
            current--;
        }
        while (current >= 0);
        Result = string.Join(", ", numbers);
    }
}
```

Useful words: `GetValueOrDefault()` is a .NET method that reads a nullable number (zero if empty). Validation is checked first here. `if`, `else`, `switch`, `for`, `while`, `do`, and `foreach` are C# syntax when they appear. `List<T>`, `Add`, `string.Join`, `Math.PI`, `Trim`, and `PadLeft` are .NET types or members when they appear. `Result`, `PopulateArray`, and this example's input names are ours. See the shared word guide for details.

## 7. Return to the controller, then the View

After Calculate() finishes, execution continues in the controller. At [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 47](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:47):

```csharp
        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { Countdown = Countdown });
```

Inside `{ Countdown = Countdown }`, the left name is the page model's property. The right name is the controller variable containing the submitted values and answer. This is C# object setup syntax, similar to JavaScript `{ Countdown: Countdown }`.

The controller returns the whole topic view with this updated model. The other four example models are fresh. No database is involved. This is a direct View response, not a redirect; the browser address stays on `/countdown` (with its section fragment).

## 8. Display the answer

Open [PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml, line 116](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:116). The condition checks whether this example has a Result. At [PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml, line 118](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:118), Razor writes that answer into the HTML.

Expected output for this sample:

```text
3, 2, 1, 0
```

The server sends the finished HTML back. Your browser displays it. It does not run the C# calculation itself. The expandable "See the C# logic" block is displayed sample text, not the code that processes the form.

## The same idea in Express

This is a comparison, not code used by the project. It assumes `express.urlencoded({ extended: false })` and a configured view engine. The calculate and validation functions below would be functions you write.

```js
app.get("/loops", (req, res) => {
    res.render("loops", makeFreshPageData());
});

// Example of the form's flat field names in req.body:
const sampleBody = {
    "Countdown.Start": "3"
};

app.post("/countdown", (req, res) => {
    // Read the relevant keys from req.body and convert number text.
    const input = readAndCheckInputs(req.body);
    const pageData = makeFreshPageData();
    if (input.isValid) {
        pageData.Countdown = calculateExample(input.values);
    } else {
        pageData.Countdown = input.values;
        pageData.errors = input.errors;
    }
    res.render("loops", pageData);
});
```

ASP.NET handles the form-to-object reading and model validation for you. Our controller still decides when to calculate and which view to return.

## Trace to remember

```text
Program.cs starts the server
  -> GET /loops
  -> controller chooses View + fresh page model
  -> View becomes HTML -> browser shows form
  -> enter this example's values -> submit
  -> POST /countdown
  -> ASP.NET fills the Countdown parameter and checks input
  -> controller checks ModelState.IsValid
  -> Countdown.Calculate() -> Result
  -> controller returns View + updated page model
  -> Razor writes Result into HTML
  -> browser shows the answer
```
