# Row and Column Totals: follow the data

[All guides](../README.md) · [Topic guides](README.md) · [Start here: app startup and word guide](../00-start-here.md)

This is a reading guide for the saved code on 2026-11-05. Line numbers can move when you edit a source file. Use the method name shown if a line moves.

## 1. Start the app, then open the topic

Start at [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1). Line 3 enables controllers and views. Line 25, `app.Run()`, waits for requests. See the start-here guide for the full startup trace.

Open `/arrays` in your browser. That sends `GET /arrays` to [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:8). ASP.NET chooses our `Index()` action below it. An action is simply a controller method that handles a request.

The action calls `View(...)` with the topic's view name and `new ArraysPageModel()`. The actual class has the student prefix; this paragraph shortens it.

Like Express: `app.get("/arrays", (req, res) => res.render("arrays", pageData));`.

## 2. Give the View fresh data

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysPageModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_ArraysPageModel.cs:7). Its `Totals` property holds this example's model. The page model groups all five examples. It does not run Calculate().

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:1). `@model` tells Razor which kind of data the View expects. `Model` is the View's access to the object passed by the controller. The model holds values; the View holds the HTML and lesson text.

ASP.NET renders that View inside the shared layout and sends HTML to the browser. At first, Result is null (no answer), so the result block is hidden. Some array inputs have starting values, but those values do not calculate themselves.

## 3. Find this form and enter the sample

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 92](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:92).

```html
<form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_Arrays"
      asp-action="Totals"
      asp-fragment="totals"
      method="post"
      asp-antiforgery="false">
```

This is a shortened copy without the styling classes.

| Part | Simple meaning |
| --- | --- |
| `asp-controller` | Select our controller class without its Controller ending. It is not a View filename. |
| `asp-action="Totals"` | Select our `Totals(...)` method in that controller. |
| `asp-fragment="totals"` | Add `#totals` so the browser jumps to that page section. |
| `method="post"` | Send the form values. This is normal HTML. |
| `asp-antiforgery="false"` | Do not generate a form token in this local learning version. |

The asp- helpers are provided by ASP.NET. They produce ordinary HTML with `action="/row-column-totals#totals"`. The browser sends the request to `/row-column-totals`; the part after # stays in the browser.

Enter this sample:

| Submitted field name | Sample value | Find it |
| --- | --- | --- |
| `Totals.Cells[0]` | `10` | [View line 94](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:94) |
| `Totals.Cells[1]` | `20` | [View line 95](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:95) |
| `Totals.Cells[2]` | `30` | [View line 96](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:96) |
| `Totals.Cells[3]` | `40` | [View line 97](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:97) |
| `Totals.Cells[4]` | `50` | [View line 98](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:98) |
| `Totals.Cells[5]` | `60` | [View line 99](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:99) |
| `Totals.Cells[6]` | `70` | [View line 100](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:100) |
| `Totals.Cells[7]` | `80` | [View line 101](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:101) |
| `Totals.Cells[8]` | `90` | [View line 102](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:102) |

`asp-for="Totals.Cells[0]"` creates an input name matching that model path. Clicking the submit button sends this form's fields. It does not submit the other four forms.

## 4. POST reaches the controller

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 46](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:46):

```csharp
    [HttpPost("/row-column-totals")]
    public IActionResult Totals(PICARDOCHRISTOPHERJOHN_24_1635_MatrixTotalsModel Totals)
```

`[HttpPost("/row-column-totals")]` is an ASP.NET route attribute. Like `app.post("/row-column-totals", handler)` in Express, it selects the handler for this address and request type.

The first `Totals` is our action's name. The last `Totals` is the variable holding this form's data. The long model name between them is the type of that variable.

ASP.NET automatically reads the form values into that variable before the method body runs. There is no `[Bind]` attribute. The input names start with `Totals.`, and the parameter is named `Totals`, so the names match. Changing the URL alone would not change the field names.

For example, `Totals.Cells[0]` arrives as `10`. Numeric text is converted into the model's number type. Bad number text adds an input error.

## 5. Check the input

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 49](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:49): `if (ModelState.IsValid)` means "only calculate if the input checks passed." `if` is C# syntax; ModelState and IsValid are provided by ASP.NET.

The model's input properties and rules are at [PICARDOCHRISTOPHERJOHN_24-1635_MatrixTotalsModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MatrixTotalsModel.cs:7):

```csharp
public int?[] Cells { get; set; } = [10, 20, 30, 40, 50, 60, 70, 80, 90];
    public string? ArrayContents { get; private set; }
    public string? Result { get; private set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (Cells == null || Cells.Length != 9)
        {
            yield return new ValidationResult("Fill all nine array cells.", ["Cells[0]"]);
            yield break;
        }
        for (int index = 0; index < Cells.Length; index++)
        {
            if (!Cells[index].HasValue || Cells[index] < -1000 || Cells[index] > 1000)
                yield return new ValidationResult("Enter a whole number from -1000 to 1000.", [$"Cells[{index}]"]);
        }
    }

    private int[,] PopulateArray()
    {
        int[,] numbers = new int[3, 3];
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
                numbers[row, column] = Cells[row * 3 + column].GetValueOrDefault();
        }
        ArrayContents = "int[,] numbers = { { " + numbers[0, 0] + ", " + numbers[0, 1] + ", " + numbers[0, 2]
            + " }, { " + numbers[1, 0] + ", " + numbers[1, 1] + ", " + numbers[1, 2]
            + " }, { " + numbers[2, 0] + ", " + numbers[2, 1] + ", " + numbers[2, 2] + " } };";
        return numbers;
    }
```

`[Required]`, `[Range]`, and similar rules are provided by .NET. The property names are ours. `get; set;` allows a value to be read and assigned. `private set` means only code inside this model can assign that output. A `?` after a number type allows an empty value.

The model also has our own [PopulateArray() method](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MatrixTotalsModel.cs:25), which copies the submitted values into the array used by Calculate(). ASP.NET calls our [Validate() method](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MatrixTotalsModel.cs:11) as part of checking the inputs. It checks the number of cells and that each is a whole number from -1000 to 1000.

After an invalid submission, the controller fills missing array slots so the View can still show all its input boxes. It does not calculate an answer for invalid input.

If a browser catches an empty required field, it can stop the submit immediately. The server also checks input, since browser checks can be bypassed. If server validation fails, Calculate() is skipped and the same topic view shows error messages.

## 6. Call our calculation method

At [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 50](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:50), `Totals.Calculate()` calls our method in [PICARDOCHRISTOPHERJOHN_24-1635_MatrixTotalsModel.cs, line 39](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MatrixTotalsModel.cs:39). Calculate is a method we wrote, not a built-in ASP.NET function.

Follow this sample:

1. PopulateArray places the nine inputs into a 3-by-3 array. Cells[row * 3 + column] chooses the matching input.
2. The outer loop selects a row. The inner loop visits every column in that row.
3. Add each cell to its row total and its column total. For example, row 0 is 10 + 20 + 30 = 60; column 0 is 10 + 40 + 70 = 120.
4. Array indexes start at 0, so the rows and columns are numbered 0, 1, 2.

Here is the actual Calculate() code and the closing class brace:

```csharp
    public void Calculate()
    {
        int[,] numbers = PopulateArray();
        int[] rowTotals = new int[3];
        int[] columnTotals = new int[3];
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                rowTotals[row] += numbers[row, column];
                columnTotals[column] += numbers[row, column];
            }
        }
        Result = $"Row index 0: {rowTotals[0]}, Row index 1: {rowTotals[1]}, Row index 2: {rowTotals[2]}\nColumn index 0: {columnTotals[0]}, Column index 1: {columnTotals[1]}, Column index 2: {columnTotals[2]}";
    }
}
```

Useful words: `GetValueOrDefault()` is a .NET method that reads a nullable number (zero if empty). Validation is checked first here. `if`, `else`, `switch`, `for`, `while`, `do`, and `foreach` are C# syntax when they appear. `List<T>`, `Add`, `string.Join`, `Math.PI`, `Trim`, and `PadLeft` are .NET types or members when they appear. `Result`, `PopulateArray`, and this example's input names are ours. See the shared word guide for details.

## 7. Return to the controller, then the View

After Calculate() finishes, execution continues in the controller. At [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 57](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:57):

```csharp
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Totals = Totals });
```

Inside `{ Totals = Totals }`, the left name is the page model's property. The right name is the controller variable containing the submitted values and answer. This is C# object setup syntax, similar to JavaScript `{ Totals: Totals }`.

The controller returns the whole topic view with this updated model. The other four example models are fresh. No database is involved. This is a direct View response, not a redirect; the browser address stays on `/row-column-totals` (with its section fragment).

## 8. Display the answer

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 106](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:106). The condition checks whether this example has a Result. At [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 109](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:109), Razor writes that answer into the HTML.

Expected output for this sample:

```text
Row index 0: 60, Row index 1: 150, Row index 2: 240
Column index 0: 120, Column index 1: 150, Column index 2: 180
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
    "Totals.Cells[0]": "10",
    "Totals.Cells[1]": "20",
    "Totals.Cells[2]": "30",
    "Totals.Cells[3]": "40",
    "Totals.Cells[4]": "50",
    "Totals.Cells[5]": "60",
    "Totals.Cells[6]": "70",
    "Totals.Cells[7]": "80",
    "Totals.Cells[8]": "90"
};

app.post("/row-column-totals", (req, res) => {
    // Read the relevant keys from req.body and convert number text.
    const input = readAndCheckInputs(req.body);
    const pageData = makeFreshPageData();
    if (input.isValid) {
        pageData.Totals = calculateExample(input.values);
    } else {
        pageData.Totals = input.values;
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
  -> POST /row-column-totals
  -> ASP.NET fills the Totals parameter and checks input
  -> controller checks ModelState.IsValid
  -> Totals.Calculate() -> Result
  -> controller returns View + updated page model
  -> Razor writes Result into HTML
  -> browser shows the answer
```
