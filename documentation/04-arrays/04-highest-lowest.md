# Highest and Lowest with Coordinates: follow the data

[All guides](../README.md) · [Topic guides](README.md) · [Start here: app startup and word guide](../00-start-here.md)

This is a reading guide for the saved code on 2026-11-05. Line numbers can move when you edit a source file. Use the method name shown if a line moves.

## 1. Start the app, then open the topic

Start at [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1). Line 3 enables controllers and views. Line 25, `app.Run()`, waits for requests. See the start-here guide for the full startup trace.

Open `/arrays` in your browser. That sends `GET /arrays` to [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:8). ASP.NET chooses our `Index()` action below it. An action is simply a controller method that handles a request.

The action calls `View(...)` with the topic's view name and `new ArraysPageModel()`. The actual class has the student prefix; this paragraph shortens it.

Like Express: `app.get("/arrays", (req, res) => res.render("arrays", pageData));`.

## 2. Give the View fresh data

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysPageModel.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_ArraysPageModel.cs:8). Its `Extremes` property holds this example's model. The page model groups all five examples. It does not run Calculate().

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:1). `@model` tells Razor which kind of data the View expects. `Model` is the View's access to the object passed by the controller. The model holds values; the View holds the HTML and lesson text.

ASP.NET renders that View inside the shared layout and sends HTML to the browser. At first, Result is null (no answer), so the result block is hidden. Some array inputs have starting values, but those values do not calculate themselves.

## 3. Find this form and enter the sample

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 133](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:133).

```html
<form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_Arrays"
      asp-action="Extremes"
      asp-fragment="extremes"
      method="post"
      asp-antiforgery="false">
```

This is a shortened copy without the styling classes.

| Part | Simple meaning |
| --- | --- |
| `asp-controller` | Select our controller class without its Controller ending. It is not a View filename. |
| `asp-action="Extremes"` | Select our `Extremes(...)` method in that controller. |
| `asp-fragment="extremes"` | Add `#extremes` so the browser jumps to that page section. |
| `method="post"` | Send the form values. This is normal HTML. |
| `asp-antiforgery="false"` | Do not generate a form token in this local learning version. |

The asp- helpers are provided by ASP.NET. They produce ordinary HTML with `action="/highest-lowest#extremes"`. The browser sends the request to `/highest-lowest`; the part after # stays in the browser.

Enter this sample:

| Submitted field name | Sample value | Find it |
| --- | --- | --- |
| `Extremes.Cells[0]` | `10` | [View line 135](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:135) |
| `Extremes.Cells[1]` | `20` | [View line 136](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:136) |
| `Extremes.Cells[2]` | `30` | [View line 137](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:137) |
| `Extremes.Cells[3]` | `40` | [View line 138](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:138) |

`asp-for="Extremes.Cells[0]"` creates an input name matching that model path. Clicking the submit button sends this form's fields. It does not submit the other four forms.

## 4. POST reaches the controller

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 60](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:60):

```csharp
    [HttpPost("/highest-lowest")]
    public IActionResult Extremes(PICARDOCHRISTOPHERJOHN_24_1635_MatrixExtremesModel Extremes)
```

`[HttpPost("/highest-lowest")]` is an ASP.NET route attribute. Like `app.post("/highest-lowest", handler)` in Express, it selects the handler for this address and request type.

The first `Extremes` is our action's name. The last `Extremes` is the variable holding this form's data. The long model name between them is the type of that variable.

ASP.NET automatically reads the form values into that variable before the method body runs. There is no `[Bind]` attribute. The input names start with `Extremes.`, and the parameter is named `Extremes`, so the names match. Changing the URL alone would not change the field names.

For example, `Extremes.Cells[0]` arrives as `10`. Numeric text is converted into the model's number type. Bad number text adds an input error.

## 5. Check the input

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 63](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:63): `if (ModelState.IsValid)` means "only calculate if the input checks passed." `if` is C# syntax; ModelState and IsValid are provided by ASP.NET.

The model's input properties and rules are at [PICARDOCHRISTOPHERJOHN_24-1635_MatrixExtremesModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MatrixExtremesModel.cs:7):

```csharp
public int?[] Cells { get; set; } = [10, 20, 30, 40];
    public string? ArrayContents { get; private set; }
    public string? Result { get; private set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (Cells == null || Cells.Length != 4)
        {
            yield return new ValidationResult("Fill all four array cells.", ["Cells[0]"]);
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
        int[,] numbers = new int[2, 2];
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
                numbers[row, column] = Cells[row * 2 + column].GetValueOrDefault();
        }
        ArrayContents = "int[,] numbers = { { " + numbers[0, 0] + ", " + numbers[0, 1]
            + " }, { " + numbers[1, 0] + ", " + numbers[1, 1] + " } };";
        return numbers;
    }
```

`[Required]`, `[Range]`, and similar rules are provided by .NET. The property names are ours. `get; set;` allows a value to be read and assigned. `private set` means only code inside this model can assign that output. A `?` after a number type allows an empty value.

The model also has our own [PopulateArray() method](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MatrixExtremesModel.cs:25), which copies the submitted values into the array used by Calculate(). ASP.NET calls our [Validate() method](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MatrixExtremesModel.cs:11) as part of checking the inputs. It checks the number of cells and that each is a whole number from -1000 to 1000.

After an invalid submission, the controller fills missing array slots so the View can still show all its input boxes. It does not calculate an answer for invalid input.

If a browser catches an empty required field, it can stop the submit immediately. The server also checks input, since browser checks can be bypassed. If server validation fails, Calculate() is skipped and the same topic view shows error messages.

## 6. Call our calculation method

At [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 64](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:64), `Extremes.Calculate()` calls our method in [PICARDOCHRISTOPHERJOHN_24-1635_MatrixExtremesModel.cs, line 38](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_MatrixExtremesModel.cs:38). Calculate is a method we wrote, not a built-in ASP.NET function.

Follow this sample:

1. PopulateArray makes a 2-by-2 array: first row 10,20; second row 30,40.
2. Start highest and lowest with the first cell. Visit all cells to find 40 and 10.
3. Visit all cells again to record every matching position, including ties.
4. A coordinate is [row,column]. Indexes start at 0, so 40 is at [1,1] and 10 is at [0,0].

Here is the actual Calculate() code and the closing class brace:

```csharp
    public void Calculate()
    {
        int[,] numbers = PopulateArray();
        int highest = numbers[0, 0];
        int lowest = numbers[0, 0];
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
            {
                if (numbers[row, column] > highest) highest = numbers[row, column];
                if (numbers[row, column] < lowest) lowest = numbers[row, column];
            }
        }
        var highPositions = new List<string>();
        var lowPositions = new List<string>();
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
            {
                string position = $"numbers[{row},{column}]";
                if (numbers[row, column] == highest) highPositions.Add(position);
                if (numbers[row, column] == lowest) lowPositions.Add(position);
            }
        }
        Result = $"Highest: {highest} at {string.Join("; ", highPositions)}\nLowest: {lowest} at {string.Join("; ", lowPositions)}";
    }
}
```

Useful words: `GetValueOrDefault()` is a .NET method that reads a nullable number (zero if empty). Validation is checked first here. `if`, `else`, `switch`, `for`, `while`, `do`, and `foreach` are C# syntax when they appear. `List<T>`, `Add`, `string.Join`, `Math.PI`, `Trim`, and `PadLeft` are .NET types or members when they appear. `Result`, `PopulateArray`, and this example's input names are ours. See the shared word guide for details.

## 7. Return to the controller, then the View

After Calculate() finishes, execution continues in the controller. At [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 71](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:71):

```csharp
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Extremes = Extremes });
```

Inside `{ Extremes = Extremes }`, the left name is the page model's property. The right name is the controller variable containing the submitted values and answer. This is C# object setup syntax, similar to JavaScript `{ Extremes: Extremes }`.

The controller returns the whole topic view with this updated model. The other four example models are fresh. No database is involved. This is a direct View response, not a redirect; the browser address stays on `/highest-lowest` (with its section fragment).

## 8. Display the answer

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 142](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:142). The condition checks whether this example has a Result. At [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 145](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:145), Razor writes that answer into the HTML.

Expected output for this sample:

```text
Highest: 40 at numbers[1,1]
Lowest: 10 at numbers[0,0]
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
    "Extremes.Cells[0]": "10",
    "Extremes.Cells[1]": "20",
    "Extremes.Cells[2]": "30",
    "Extremes.Cells[3]": "40"
};

app.post("/highest-lowest", (req, res) => {
    // Read the relevant keys from req.body and convert number text.
    const input = readAndCheckInputs(req.body);
    const pageData = makeFreshPageData();
    if (input.isValid) {
        pageData.Extremes = calculateExample(input.values);
    } else {
        pageData.Extremes = input.values;
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
  -> POST /highest-lowest
  -> ASP.NET fills the Extremes parameter and checks input
  -> controller checks ModelState.IsValid
  -> Extremes.Calculate() -> Result
  -> controller returns View + updated page model
  -> Razor writes Result into HTML
  -> browser shows the answer
```
