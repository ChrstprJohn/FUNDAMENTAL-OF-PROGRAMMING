# Multiplication Table Grid: follow the data

[All guides](../README.md) · [Topic guides](README.md) · [Start here: app startup and word guide](../00-start-here.md)

This is a reading guide for the saved code on 2026-11-05. Line numbers can move when you edit a source file. Use the method name shown if a line moves.

## 1. Start the app, then open the topic

Start at [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1). Line 3 enables controllers and views. Line 25, `app.Run()`, waits for requests. See the start-here guide for the full startup trace.

Open `/arrays` in your browser. That sends `GET /arrays` to [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:8). ASP.NET chooses our `Index()` action below it. An action is simply a controller method that handles a request.

The action calls `View(...)` with the topic's view name and `new ArraysPageModel()`. The actual class has the student prefix; this paragraph shortens it.

Like Express: `app.get("/arrays", (req, res) => res.render("arrays", pageData));`.

## 2. Give the View fresh data

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysPageModel.cs, line 9](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_ArraysPageModel.cs:9). Its `Grid` property holds this example's model. The page model groups all five examples. It does not run Calculate().

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:1). `@model` tells Razor which kind of data the View expects. `Model` is the View's access to the object passed by the controller. The model holds values; the View holds the HTML and lesson text.

ASP.NET renders that View inside the shared layout and sends HTML to the browser. At first, Result is null (no answer), so the result block is hidden. Some array inputs have starting values, but those values do not calculate themselves.

## 3. Find this form and enter the sample

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 180](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:180).

```html
<form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_Arrays"
      asp-action="Grid"
      asp-fragment="grid"
      method="post"
      asp-antiforgery="false">
```

This is a shortened copy without the styling classes.

| Part | Simple meaning |
| --- | --- |
| `asp-controller` | Select our controller class without its Controller ending. It is not a View filename. |
| `asp-action="Grid"` | Select our `Grid(...)` method in that controller. |
| `asp-fragment="grid"` | Add `#grid` so the browser jumps to that page section. |
| `method="post"` | Send the form values. This is normal HTML. |
| `asp-antiforgery="false"` | Do not generate a form token in this local learning version. |

The asp- helpers are provided by ASP.NET. They produce ordinary HTML with `action="/multiplication-grid#grid"`. The browser sends the request to `/multiplication-grid`; the part after # stays in the browser.

Enter this sample:

| Submitted field name | Sample value | Find it |
| --- | --- | --- |
| `Grid.Rows` | `2` | [View line 182](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:182) |
| `Grid.Columns` | `3` | [View line 183](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:183) |

`asp-for="Grid.Rows"` creates an input name matching that model path. Clicking the submit button sends this form's fields. It does not submit the other four forms.

## 4. POST reaches the controller

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 74](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:74):

```csharp
    [HttpPost("/multiplication-grid")]
    public IActionResult Grid(PICARDOCHRISTOPHERJOHN_24_1635_MultiplicationGridModel Grid)
```

`[HttpPost("/multiplication-grid")]` is an ASP.NET route attribute. Like `app.post("/multiplication-grid", handler)` in Express, it selects the handler for this address and request type.

The first `Grid` is our action's name. The last `Grid` is the variable holding this form's data. The long model name between them is the type of that variable.

ASP.NET automatically reads the form values into that variable before the method body runs. There is no `[Bind]` attribute. The input names start with `Grid.`, and the parameter is named `Grid`, so the names match. Changing the URL alone would not change the field names.

For example, `Grid.Rows` arrives as `2`. Numeric text is converted into the model's number type. Bad number text adds an input error.

## 5. Check the input

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 77](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:77): `if (ModelState.IsValid)` means "only calculate if the input checks passed." `if` is C# syntax; ModelState and IsValid are provided by ASP.NET.

The model's input properties and rules are at [PICARDOCHRISTOPHERJOHN_24-1635_MultiplicationGridModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MultiplicationGridModel.cs:7):

```csharp
[Required]
    [Range(1, 10)]
    public int? Rows { get; set; } = 10;
    [Required]
    [Range(1, 10)]
    public int? Columns { get; set; } = 10;
    public string? ArrayContents { get; private set; }
    public string? Result { get; private set; }
```

`[Required]`, `[Range]`, and similar rules are provided by .NET. The property names are ours. `get; set;` allows a value to be read and assigned. `private set` means only code inside this model can assign that output. A `?` after a number type allows an empty value.

If a browser catches an empty required field, it can stop the submit immediately. The server also checks input, since browser checks can be bypassed. If server validation fails, Calculate() is skipped and the same topic view shows error messages.

## 6. Call our calculation method

At [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 78](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:78), `Grid.Calculate()` calls our method in [PICARDOCHRISTOPHERJOHN_24-1635_MultiplicationGridModel.cs, line 16](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MultiplicationGridModel.cs:16). Calculate is a method we wrote, not a built-in ASP.NET function.

Follow this sample:

1. Create an array with 2 rows and 3 columns.
2. For each cell, calculate (row + 1) × (column + 1). Add 1 because indexes begin at zero but the table starts at 1.
3. PadLeft(4) adds spaces so the columns line up. Join the row strings with line breaks.
4. Rows and Columns may each be 1–10. The starting values are 10 and 10.

Here is the actual Calculate() code and the closing class brace:

```csharp
    public void Calculate()
    {
        int rows = Rows.GetValueOrDefault();
        int columns = Columns.GetValueOrDefault();
        int[,] table = new int[rows, columns];
        var lines = new List<string>();
        for (int row = 0; row < rows; row++)
        {
            string line = "";
            for (int column = 0; column < columns; column++)
            {
                table[row, column] = (row + 1) * (column + 1);
                line += table[row, column].ToString().PadLeft(4);
            }
            lines.Add(line);
        }
        Result = string.Join("\n", lines);
        ArrayContents = $"int[,] table = new int[{rows}, {columns}];";
    }
}
```

Useful words: `GetValueOrDefault()` is a .NET method that reads a nullable number (zero if empty). Validation is checked first here. `if`, `else`, `switch`, `for`, `while`, `do`, and `foreach` are C# syntax when they appear. `List<T>`, `Add`, `string.Join`, `Math.PI`, `Trim`, and `PadLeft` are .NET types or members when they appear. `Result`, `PopulateArray`, and this example's input names are ours. See the shared word guide for details.

## 7. Return to the controller, then the View

After Calculate() finishes, execution continues in the controller. At [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 79](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:79):

```csharp
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Grid = Grid });
```

Inside `{ Grid = Grid }`, the left name is the page model's property. The right name is the controller variable containing the submitted values and answer. This is C# object setup syntax, similar to JavaScript `{ Grid: Grid }`.

The controller returns the whole topic view with this updated model. The other four example models are fresh. No database is involved. This is a direct View response, not a redirect; the browser address stays on `/multiplication-grid` (with its section fragment).

## 8. Display the answer

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 187](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:187). The condition checks whether this example has a Result. At [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 190](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:190), Razor writes that answer into the HTML.

Expected output for this sample:

```text
   1   2   3
   2   4   6
```

The server sends the finished HTML back. Your browser displays it. It does not run the C# calculation itself. The expandable "See the C# logic" block is displayed sample text, not the code that processes the form.

## The same idea in Express

This is a comparison, not code used by the project. It assumes `express.urlencoded({ extended: false })` and a configured view engine. The calculate and validation functions below would be functions you write.

```js
app.get("/arrays", (req, res) => {
    res.render("arrays", makeFreshPageData());
});

// Example of the form's flat field names in req.body:
const sampleBody = {
    "Grid.Rows": "2",
    "Grid.Columns": "3"
};

app.post("/multiplication-grid", (req, res) => {
    // Read the relevant keys from req.body and convert number text.
    const input = readAndCheckInputs(req.body);
    const pageData = makeFreshPageData();
    if (input.isValid) {
        pageData.Grid = calculateExample(input.values);
    } else {
        pageData.Grid = input.values;
        pageData.errors = input.errors;
    }
    res.render("arrays", pageData);
});
```

ASP.NET handles the form-to-object reading and model validation for you. Our controller still decides when to calculate and which view to return.

## Trace to remember

```text
Program.cs starts the server
  -> GET /arrays
  -> controller chooses View + fresh page model
  -> View becomes HTML -> browser shows form
  -> enter this example's values -> submit
  -> POST /multiplication-grid
  -> ASP.NET fills the Grid parameter and checks input
  -> controller checks ModelState.IsValid
  -> Grid.Calculate() -> Result
  -> controller returns View + updated page model
  -> Razor writes Result into HTML
  -> browser shows the answer
```
