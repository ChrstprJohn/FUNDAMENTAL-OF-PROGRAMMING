# Largest of Three Numbers: follow the data

[All guides](../README.md) · [Topic guides](README.md) · [Start here: app startup and word guide](../00-start-here.md)

This is a reading guide for the saved code on 2026-11-05. Line numbers can move when you edit a source file. Use the method name shown if a line moves.

## 1. Start the app, then open the topic

Start at [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1). Line 3 enables controllers and views. Line 25, `app.Run()`, waits for requests. See the start-here guide for the full startup trace.

Open `/nested-if-else` in your browser. That sends `GET /nested-if-else` to [PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs:8). ASP.NET chooses our `Index()` action below it. An action is simply a controller method that handles a request.

The action calls `View(...)` with the topic's view name and `new NestedIfElsePageModel()`. The actual class has the student prefix; this paragraph shortens it.

Like Express: `app.get("/nested-if-else", (req, res) => res.render("nestedifelse", pageData));`.

## 2. Give the View fresh data

Open [PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElsePageModel.cs, line 8](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElsePageModel.cs:8). Its `Largest` property holds this example's model. The page model groups all five examples. It does not run Calculate().

Open [PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml:1). `@model` tells Razor which kind of data the View expects. `Model` is the View's access to the object passed by the controller. The model holds values; the View holds the HTML and lesson text.

ASP.NET renders that View inside the shared layout and sends HTML to the browser. At first, Result is null (no answer), so the result block is hidden. Some array inputs have starting values, but those values do not calculate themselves.

## 3. Find this form and enter the sample

Open [PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml, line 127](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml:127).

```html
<form asp-controller="PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElse"
      asp-action="Largest"
      asp-fragment="largest"
      method="post"
      asp-antiforgery="false">
```

This is a shortened copy without the styling classes.

| Part | Simple meaning |
| --- | --- |
| `asp-controller` | Select our controller class without its Controller ending. It is not a View filename. |
| `asp-action="Largest"` | Select our `Largest(...)` method in that controller. |
| `asp-fragment="largest"` | Add `#largest` so the browser jumps to that page section. |
| `method="post"` | Send the form values. This is normal HTML. |
| `asp-antiforgery="false"` | Do not generate a form token in this local learning version. |

The asp- helpers are provided by ASP.NET. They produce ordinary HTML with `action="/largest-of-three#largest"`. The browser sends the request to `/largest-of-three`; the part after # stays in the browser.

Enter this sample:

| Submitted field name | Sample value | Find it |
| --- | --- | --- |
| `Largest.First` | `-3` | [View line 129](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml:129) |
| `Largest.Second` | `-1` | [View line 134](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml:134) |
| `Largest.Third` | `-2` | [View line 139](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml:139) |

`asp-for="Largest.First"` creates an input name matching that model path. Clicking the submit button sends this form's fields. It does not submit the other four forms.

## 4. POST reaches the controller

Open [PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs, line 41](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs:41):

```csharp
    [HttpPost("/largest-of-three")]
    public IActionResult Largest(PICARDOCHRISTOPHERJOHN_24_1635_LargestNumberModel Largest)
```

`[HttpPost("/largest-of-three")]` is an ASP.NET route attribute. Like `app.post("/largest-of-three", handler)` in Express, it selects the handler for this address and request type.

The first `Largest` is our action's name. The last `Largest` is the variable holding this form's data. The long model name between them is the type of that variable.

ASP.NET automatically reads the form values into that variable before the method body runs. There is no `[Bind]` attribute. The input names start with `Largest.`, and the parameter is named `Largest`, so the names match. Changing the URL alone would not change the field names.

For example, `Largest.First` arrives as `-3`. Numeric text is converted into the model's number type. Bad number text adds an input error.

## 5. Check the input

Open [PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs, line 44](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs:44): `if (ModelState.IsValid)` means "only calculate if the input checks passed." `if` is C# syntax; ModelState and IsValid are provided by ASP.NET.

The model's input properties and rules are at [PICARDOCHRISTOPHERJOHN_24-1635_LargestNumberModel.cs, line 7](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_LargestNumberModel.cs:7):

```csharp
[Required]
    [Range(-1000000, 1000000)]
    public int? First { get; set; }

    [Required]
    [Range(-1000000, 1000000)]
    public int? Second { get; set; }

    [Required]
    [Range(-1000000, 1000000)]
    public int? Third { get; set; }

    public string? Result { get; private set; }
```

`[Required]`, `[Range]`, and similar rules are provided by .NET. The property names are ours. `get; set;` allows a value to be read and assigned. `private set` means only code inside this model can assign that output. A `?` after a number type allows an empty value.

If a browser catches an empty required field, it can stop the submit immediately. The server also checks input, since browser checks can be bypassed. If server validation fails, Calculate() is skipped and the same topic view shows error messages.

## 6. Call our calculation method

At [PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs, line 45](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs:45), `Largest.Calculate()` calls our method in [PICARDOCHRISTOPHERJOHN_24-1635_LargestNumberModel.cs, line 21](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Models/NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_LargestNumberModel.cs:21). Calculate is a method we wrote, not a built-in ASP.NET function.

Follow this sample:

1. Compare first with second. -3 is smaller than -1, so take the outer else.
2. Compare second with third. -1 is greater than -2, so largest becomes -1.
3. Put largest into the output text.

Here is the actual Calculate() code and the closing class brace:

```csharp
    public void Calculate()
    {
        int first = First.GetValueOrDefault();
        int second = Second.GetValueOrDefault();
        int third = Third.GetValueOrDefault();
        int largest;
        if (first >= second)
        {
            if (first >= third)
                largest = first;
            else
                largest = third;
        }
        else
        {
            if (second >= third)
                largest = second;
            else
                largest = third;
        }
        Result = $"Largest number: {largest}";
    }
}
```

Useful words: `GetValueOrDefault()` is a .NET method that reads a nullable number (zero if empty). Validation is checked first here. `if`, `else`, `switch`, `for`, `while`, `do`, and `foreach` are C# syntax when they appear. `List<T>`, `Add`, `string.Join`, `Math.PI`, `Trim`, and `PadLeft` are .NET types or members when they appear. `Result`, `PopulateArray`, and this example's input names are ours. See the shared word guide for details.

## 7. Return to the controller, then the View

After Calculate() finishes, execution continues in the controller. At [PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs, line 47](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_NestedIfElseController.cs:47):

```csharp
        return View("PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse", new PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElsePageModel { Largest = Largest });
```

Inside `{ Largest = Largest }`, the left name is the page model's property. The right name is the controller variable containing the submitted values and answer. This is C# object setup syntax, similar to JavaScript `{ Largest: Largest }`.

The controller returns the whole topic view with this updated model. The other four example models are fresh. No database is involved. This is a direct View response, not a redirect; the browser address stays on `/largest-of-three` (with its section fragment).

## 8. Display the answer

Open [PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml, line 145](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml:145). The condition checks whether this example has a Result. At [PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml, line 147](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/PICARDOCHRISTOPHERJOHN_24_1635_NestedIfElse/PICARDOCHRISTOPHERJOHN_24-1635_nestedifelse.cshtml:147), Razor writes that answer into the HTML.

Expected output for this sample:

```text
Largest number: -1
```

The server sends the finished HTML back. Your browser displays it. It does not run the C# calculation itself. The expandable "See the C# logic" block is displayed sample text, not the code that processes the form.

## The same idea in Express

This is a comparison, not code used by the project. It assumes `express.urlencoded({ extended: false })` and a configured view engine. The calculate and validation functions below would be functions you write.

```js
app.get("/nested-if-else", (req, res) => {
    res.render("nestedifelse", makeFreshPageData());
});

// Example of the form's flat field names in req.body:
const sampleBody = {
    "Largest.First": "-3",
    "Largest.Second": "-1",
    "Largest.Third": "-2"
};

app.post("/largest-of-three", (req, res) => {
    // Read the relevant keys from req.body and convert number text.
    const input = readAndCheckInputs(req.body);
    const pageData = makeFreshPageData();
    if (input.isValid) {
        pageData.Largest = calculateExample(input.values);
    } else {
        pageData.Largest = input.values;
        pageData.errors = input.errors;
    }
    res.render("nestedifelse", pageData);
});
```

ASP.NET handles the form-to-object reading and model validation for you. Our controller still decides when to calculate and which view to return.

## Trace to remember

```text
Program.cs starts the server
  -> GET /nested-if-else
  -> controller chooses View + fresh page model
  -> View becomes HTML -> browser shows form
  -> enter this example's values -> submit
  -> POST /largest-of-three
  -> ASP.NET fills the Largest parameter and checks input
  -> controller checks ModelState.IsValid
  -> Largest.Calculate() -> Result
  -> controller returns View + updated page model
  -> Razor writes Result into HTML
  -> browser shows the answer
```
