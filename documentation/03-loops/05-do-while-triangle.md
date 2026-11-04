# Star Triangle — Do While Loop: follow the data

[All guides](../README.md) · [Topic guides](README.md) · [Start here: app startup and word guide](../00-start-here.md)

This is a reading guide for the saved code on 2026-11-05. Line numbers can move when you edit a source file. Use the method name shown if a line moves.

## 1. Start the app, then open the topic

Start at [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1). Line 3 enables controllers and views. Line 25, `app.Run()`, waits for requests. See the start-here guide for the full startup trace.

Open `/loops` in your browser. That sends `GET /loops` to [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:8). ASP.NET chooses our `Index()` action below it. An action is simply a controller method that handles a request.

The action calls `View(...)` with the topic's view name and `new LoopsPageModel()`. The actual class has the student prefix; this paragraph shortens it.

Like Express: `app.get("/loops", (req, res) => res.render("loops", pageData));`.

## 2. Give the View fresh data

Open [PICARDOCHRISTOPHERJOHN_24-1635_LoopsPageModel.cs, line 9](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Loops/PICARDOCHRISTOPHERJOHN_24-1635_LoopsPageModel.cs:9). Its `StarTriangle` property holds this example's model. The page model groups all five examples. It does not run Calculate().

Open [PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:1). `@model` tells Razor which kind of data the View expects. `Model` is the View's access to the object passed by the controller. The model holds values; the View holds the HTML and lesson text.

ASP.NET renders that View inside the shared layout and sends HTML to the browser. At first, Result is null (no answer), so the result block is hidden. Some array inputs have starting values, but those values do not calculate themselves.

## 3. Find this form and enter the sample

Open [PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml, line 137](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:137).

```html
<form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_Loops"
      asp-action="StarTriangle"
      asp-fragment="star-triangle"
      method="post"
      asp-antiforgery="false">
```

This is a shortened copy without the styling classes.

| Part | Simple meaning |
| --- | --- |
| `asp-controller` | Select our controller class without its Controller ending. It is not a View filename. |
| `asp-action="StarTriangle"` | Select our `StarTriangle(...)` method in that controller. |
| `asp-fragment="star-triangle"` | Add `#star-triangle` so the browser jumps to that page section. |
| `method="post"` | Send the form values. This is normal HTML. |
| `asp-antiforgery="false"` | Do not generate a form token in this local learning version. |

The asp- helpers are provided by ASP.NET. They produce ordinary HTML with `action="/star-triangle#star-triangle"`. The browser sends the request to `/star-triangle`; the part after # stays in the browser.

Enter this sample:

| Submitted field name | Sample value | Find it |
| --- | --- | --- |
| `StarTriangle.Rows` | `3` | [View line 139](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:139) |

`asp-for="StarTriangle.Rows"` creates an input name matching that model path. Clicking the submit button sends this form's fields. It does not submit the other four forms.

## 4. POST reaches the controller

Open [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 50](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:50):

```csharp
    [HttpPost("/star-triangle")]
    public IActionResult StarTriangle(PICARDOCHRISTOPHERJOHN_24_1635_StarTriangleModel StarTriangle)
```

`[HttpPost("/star-triangle")]` is an ASP.NET route attribute. Like `app.post("/star-triangle", handler)` in Express, it selects the handler for this address and request type.

The first `StarTriangle` is our action's name. The last `StarTriangle` is the variable holding this form's data. The long model name between them is the type of that variable.

ASP.NET automatically reads the form values into that variable before the method body runs. There is no `[Bind]` attribute. The input names start with `StarTriangle.`, and the parameter is named `StarTriangle`, so the names match. Changing the URL alone would not change the field names.

For example, `StarTriangle.Rows` arrives as `3`. Numeric text is converted into the model's number type. Bad number text adds an input error.

## 5. Check the input

Open [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 53](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:53): `if (ModelState.IsValid)` means "only calculate if the input checks passed." `if` is C# syntax; ModelState and IsValid are provided by ASP.NET.

The model's input properties and rules are at [PICARDOCHRISTOPHERJOHN_24-1635_StarTriangleModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Loops/PICARDOCHRISTOPHERJOHN_24-1635_StarTriangleModel.cs:7):

```csharp
[Required]
    [Range(1, 20)]
    public int? Rows { get; set; }

    public string? Result { get; private set; }
```

`[Required]`, `[Range]`, and similar rules are provided by .NET. The property names are ours. `get; set;` allows a value to be read and assigned. `private set` means only code inside this model can assign that output. A `?` after a number type allows an empty value.

If a browser catches an empty required field, it can stop the submit immediately. The server also checks input, since browser checks can be bypassed. If server validation fails, Calculate() is skipped and the same topic view shows error messages.

## 6. Call our calculation method

At [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 54](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:54), `StarTriangle.Calculate()` calls our method in [PICARDOCHRISTOPHERJOHN_24-1635_StarTriangleModel.cs, line 13](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Loops/PICARDOCHRISTOPHERJOHN_24-1635_StarTriangleModel.cs:13). Calculate is a method we wrote, not a built-in ASP.NET function.

Follow this sample:

1. Start row at 1 and stars as empty text.
2. Each turn adds one star to the existing stars text and saves that text as a line.
3. The three lines have 1, 2, and 3 stars. Stop after row 3 and join them with line breaks.

Here is the actual Calculate() code and the closing class brace:

```csharp
    public void Calculate()
    {
        int row = 1;
        string stars = "";
        var lines = new List<string>();
        do
        {
            stars += "*";
            lines.Add(stars);
            row++;
        }
        while (row <= Rows.GetValueOrDefault());
        Result = string.Join("\n", lines);
    }
}
```

Useful words: `GetValueOrDefault()` is a .NET method that reads a nullable number (zero if empty). Validation is checked first here. `if`, `else`, `switch`, `for`, `while`, `do`, and `foreach` are C# syntax when they appear. `List<T>`, `Add`, `string.Join`, `Math.PI`, `Trim`, and `PadLeft` are .NET types or members when they appear. `Result`, `PopulateArray`, and this example's input names are ours. See the shared word guide for details.

## 7. Return to the controller, then the View

After Calculate() finishes, execution continues in the controller. At [PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs, line 56](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_LoopsController.cs:56):

```csharp
        return View("PICARDOCHRISTOPHERJOHN_24-1635_loops", new PICARDOCHRISTOPHERJOHN_24_1635_LoopsPageModel { StarTriangle = StarTriangle });
```

Inside `{ StarTriangle = StarTriangle }`, the left name is the page model's property. The right name is the controller variable containing the submitted values and answer. This is C# object setup syntax, similar to JavaScript `{ StarTriangle: StarTriangle }`.

The controller returns the whole topic view with this updated model. The other four example models are fresh. No database is involved. This is a direct View response, not a redirect; the browser address stays on `/star-triangle` (with its section fragment).

## 8. Display the answer

Open [PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml, line 145](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:145). The condition checks whether this example has a Result. At [PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml, line 147](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Loops/PICARDOCHRISTOPHERJOHN_24-1635_loops.cshtml:147), Razor writes that answer into the HTML.

Expected output for this sample:

```text
*
**
***
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
    "StarTriangle.Rows": "3"
};

app.post("/star-triangle", (req, res) => {
    // Read the relevant keys from req.body and convert number text.
    const input = readAndCheckInputs(req.body);
    const pageData = makeFreshPageData();
    if (input.isValid) {
        pageData.StarTriangle = calculateExample(input.values);
    } else {
        pageData.StarTriangle = input.values;
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
  -> POST /star-triangle
  -> ASP.NET fills the StarTriangle parameter and checks input
  -> controller checks ModelState.IsValid
  -> StarTriangle.Calculate() -> Result
  -> controller returns View + updated page model
  -> Razor writes Result into HTML
  -> browser shows the answer
```
