# Sum of Five Numbers: follow the data

[All guides](../README.md) · [Topic guides](README.md) · [Start here: app startup and word guide](../00-start-here.md)

This is a reading guide for the saved code on 2026-11-05. Line numbers can move when you edit a source file. Use the method name shown if a line moves.

## 1. Start the app, then open the topic

Start at [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1). Line 3 enables controllers and views. Line 25, `app.Run()`, waits for requests. See the start-here guide for the full startup trace.

Open `/arrays` in your browser. That sends `GET /arrays` to [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:8). ASP.NET chooses our `Index()` action below it. An action is simply a controller method that handles a request.

The action calls `View(...)` with the topic's view name and `new ArraysPageModel()`. The actual class has the student prefix; this paragraph shortens it.

Like Express: `app.get("/arrays", (req, res) => res.render("arrays", pageData));`.

## 2. Give the View fresh data

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysPageModel.cs, line 5](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_ArraysPageModel.cs:5). Its `Sum` property holds this example's model. The page model groups all five examples. It does not run Calculate().

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:1). `@model` tells Razor which kind of data the View expects. `Model` is the View's access to the object passed by the controller. The model holds values; the View holds the HTML and lesson text.

ASP.NET renders that View inside the shared layout and sends HTML to the browser. At first, Result is null (no answer), so the result block is hidden. Some array inputs have starting values, but those values do not calculate themselves.

## 3. Find this form and enter the sample

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 25](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:25).

```html
<form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_Arrays"
      asp-action="Sum"
      asp-fragment="sum"
      method="post"
      asp-antiforgery="false">
```

This is a shortened copy without the styling classes.

| Part | Simple meaning |
| --- | --- |
| `asp-controller` | Select our controller class without its Controller ending. It is not a View filename. |
| `asp-action="Sum"` | Select our `Sum(...)` method in that controller. |
| `asp-fragment="sum"` | Add `#sum` so the browser jumps to that page section. |
| `method="post"` | Send the form values. This is normal HTML. |
| `asp-antiforgery="false"` | Do not generate a form token in this local learning version. |

The asp- helpers are provided by ASP.NET. They produce ordinary HTML with `action="/array-sum#sum"`. The browser sends the request to `/array-sum`; the part after # stays in the browser.

Enter this sample:

| Submitted field name | Sample value | Find it |
| --- | --- | --- |
| `Sum.Numbers[0]` | `1` | [View line 27](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:27) |
| `Sum.Numbers[1]` | `2` | [View line 28](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:28) |
| `Sum.Numbers[2]` | `3` | [View line 29](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:29) |
| `Sum.Numbers[3]` | `4` | [View line 30](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:30) |
| `Sum.Numbers[4]` | `5` | [View line 31](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:31) |

`asp-for="Sum.Numbers[0]"` creates an input name matching that model path. Clicking the submit button sends this form's fields. It does not submit the other four forms.

## 4. POST reaches the controller

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 14](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:14):

```csharp
    [HttpPost("/array-sum")]
    public IActionResult Sum(PICARDOCHRISTOPHERJOHN_24_1635_ArraySumModel Sum)
```

`[HttpPost("/array-sum")]` is an ASP.NET route attribute. Like `app.post("/array-sum", handler)` in Express, it selects the handler for this address and request type.

The first `Sum` is our action's name. The last `Sum` is the variable holding this form's data. The long model name between them is the type of that variable.

ASP.NET automatically reads the form values into that variable before the method body runs. There is no `[Bind]` attribute. The input names start with `Sum.`, and the parameter is named `Sum`, so the names match. Changing the URL alone would not change the field names.

For example, `Sum.Numbers[0]` arrives as `1`. Numeric text is converted into the model's number type. Bad number text adds an input error.

## 5. Check the input

Open [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 17](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:17): `if (ModelState.IsValid)` means "only calculate if the input checks passed." `if` is C# syntax; ModelState and IsValid are provided by ASP.NET.

The model's input properties and rules are at [PICARDOCHRISTOPHERJOHN_24-1635_ArraySumModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_ArraySumModel.cs:7):

```csharp
public int?[] Numbers { get; set; } = [1, 2, 3, 4, 5];

    public string? ArrayContents { get; private set; }

    public string? Result { get; private set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (Numbers == null || Numbers.Length != 5)
        {
            yield return new ValidationResult("Fill all five array elements.", ["Numbers[0]"]);
            yield break;
        }
        for (int index = 0; index < Numbers.Length; index++)
        {
            if (!Numbers[index].HasValue || Numbers[index] < -1000 || Numbers[index] > 1000)
                yield return new ValidationResult("Enter a whole number from -1000 to 1000.", [$"Numbers[{index}]"]);
        }
    }

    private int[] PopulateArray()
    {
        int[] numbers = new int[5];
        for (int index = 0; index < numbers.Length; index++)
            numbers[index] = Numbers[index].GetValueOrDefault();

        ArrayContents = "int[] numbers = { " + string.Join(", ", numbers) + " };";
        return numbers;
    }
```

`[Required]`, `[Range]`, and similar rules are provided by .NET. The property names are ours. `get; set;` allows a value to be read and assigned. `private set` means only code inside this model can assign that output. A `?` after a number type allows an empty value.

The model also has our own [PopulateArray() method](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_ArraySumModel.cs:27), which copies the submitted values into the array used by Calculate(). ASP.NET calls our [Validate() method](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_ArraySumModel.cs:13) as part of checking the inputs. It checks the number of cells and that each is a whole number from -1000 to 1000.

After an invalid submission, the controller fills missing array slots so the View can still show all its input boxes. It does not calculate an answer for invalid input.

If a browser catches an empty required field, it can stop the submit immediately. The server also checks input, since browser checks can be bypassed. If server validation fails, Calculate() is skipped and the same topic view shows error messages.

## 6. Call our calculation method

At [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 18](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:18), `Sum.Calculate()` calls our method in [PICARDOCHRISTOPHERJOHN_24-1635_ArraySumModel.cs, line 37](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/Arrays/PICARDOCHRISTOPHERJOHN_24-1635_ArraySumModel.cs:37). Calculate is a method we wrote, not a built-in ASP.NET function.

Follow this sample:

1. PopulateArray copies the five submitted numbers into a plain int[] array.
2. Start total at 0. The foreach visits each value: totals become 1, 3, 6, 10, 15.
3. Store Sum: 15 in Result. ArrayContents holds text showing the populated array.

Here is the actual Calculate() code and the closing class brace:

```csharp
    public void Calculate()
    {
        int[] numbers = PopulateArray();
        int total = 0;
        foreach (int number in numbers)
            total += number;
        Result = $"Sum: {total}";
    }
}
```

Useful words: `GetValueOrDefault()` is a .NET method that reads a nullable number (zero if empty). Validation is checked first here. `if`, `else`, `switch`, `for`, `while`, `do`, and `foreach` are C# syntax when they appear. `List<T>`, `Add`, `string.Join`, `Math.PI`, `Trim`, and `PadLeft` are .NET types or members when they appear. `Result`, `PopulateArray`, and this example's input names are ours. See the shared word guide for details.

## 7. Return to the controller, then the View

After Calculate() finishes, execution continues in the controller. At [PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs, line 27](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_ArraysController.cs:27):

```csharp
        return View("PICARDOCHRISTOPHERJOHN_24-1635_arrays", new PICARDOCHRISTOPHERJOHN_24_1635_ArraysPageModel { Sum = Sum });
```

Inside `{ Sum = Sum }`, the left name is the page model's property. The right name is the controller variable containing the submitted values and answer. This is C# object setup syntax, similar to JavaScript `{ Sum: Sum }`.

The controller returns the whole topic view with this updated model. The other four example models are fresh. No database is involved. This is a direct View response, not a redirect; the browser address stays on `/array-sum` (with its section fragment).

## 8. Display the answer

Open [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 35](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:35). The condition checks whether this example has a Result. At [PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml, line 38](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_Arrays/PICARDOCHRISTOPHERJOHN_24-1635_arrays.cshtml:38), Razor writes that answer into the HTML.

Expected output for this sample:

```text
Sum: 15
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
    "Sum.Numbers[0]": "1",
    "Sum.Numbers[1]": "2",
    "Sum.Numbers[2]": "3",
    "Sum.Numbers[3]": "4",
    "Sum.Numbers[4]": "5"
};

app.post("/array-sum", (req, res) => {
    // Read the relevant keys from req.body and convert number text.
    const input = readAndCheckInputs(req.body);
    const pageData = makeFreshPageData();
    if (input.isValid) {
        pageData.Sum = calculateExample(input.values);
    } else {
        pageData.Sum = input.values;
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
  -> POST /array-sum
  -> ASP.NET fills the Sum parameter and checks input
  -> controller checks ModelState.IsValid
  -> Sum.Calculate() -> Result
  -> controller returns View + updated page model
  -> Razor writes Result into HTML
  -> browser shows the answer
```
