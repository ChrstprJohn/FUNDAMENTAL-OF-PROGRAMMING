# Start here: how the website works

[Choose an example](README.md)

Read this once, then follow any example guide. The examples all use the same web flow. This guide describes the saved code on 2026-11-05.

## Three jobs: MVC

| Part | Job | Similar idea in Express |
| --- | --- | --- |
| Model | Hold inputs, input rules, and our calculation method. | A JavaScript object plus validation and calculation code. |
| View | Use the data to build HTML with boxes, buttons, and output. | An EJS, Pug, or another server template. |
| Controller | Receive a request, check input, call the calculation, choose a response. | A route handler such as `(req, res) => { ... }`. |

The browser receives HTML, CSS, and JavaScript. C# controllers, models, and Razor views run on the server. A model is not a page and does not contain the lesson HTML. A page model simply groups five example models for one View.

## 1. Start the server

Open [Program.cs, line 1](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Program.cs:1).

| Line | Code or name | Meaning | Who provides it? |
| --- | --- | --- | --- |
| 1 | `WebApplication.CreateBuilder(args)` | Prepare the app and its settings. | ASP.NET method. `args` holds startup arguments. |
| 1 | `var builder = ...` | Save the returned object in a variable. | C# syntax; builder is our variable name. |
| 3 | `AddControllersWithViews()` | Enable MVC controllers and views. | ASP.NET method. |
| 5 | `builder.Build()` | Create the app from that setup. | ASP.NET method. |
| 7–11 | environment check and error setup | Outside Development, send unhandled errors to /error and enable HSTS. | C# if plus ASP.NET methods. |
| 13 | `UseHttpsRedirection()` | Redirect HTTP to HTTPS when configured. | ASP.NET method. |
| 14 | `UseRouting()` | Enable matching incoming requests to handlers. | ASP.NET method. |
| 16 | `UseAuthorization()` | Add authorization support; this app has no login system. | ASP.NET method. |
| 18 | `MapStaticAssets()` | Serve assets such as CSS and JavaScript. | ASP.NET method. |
| 20–23 | `MapControllerRoute(...)` | Set a default controller and action for conventional URLs. | ASP.NET method; the controller name is ours. |
| 25 | `app.Run()` | Start serving requests and wait. | ASP.NET method, similar in purpose to Express app.listen(). |

These are startup steps. They do not repeat from line 1 every time you press Calculate. Once running, the app handles each incoming request.

## 2. What happens when you open the home address?

Program.cs line 22 chooses BasicIO as the default controller and Index as the default action.

Follow [BasicIOController.cs, line 10](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs:10):

```csharp
public IActionResult Index()
{
    return RedirectToAction(nameof(BasicIO));
}
```

An action is a controller method that ASP.NET can use to handle a request. Index and BasicIO are names we chose.

`RedirectToAction(nameof(BasicIO))` means: tell the browser to request the address of our BasicIO action. It does not open a folder or render a View. `nameof(BasicIO)` is C# syntax producing the string `"BasicIO"`.

Like Express:

```js
app.get("/", (req, res) => {
    res.redirect("/basic-io");
});
```

This redirect causes a second browser request: GET /basic-io. Opening /basic-io directly skips the home redirect.

## 3. GET asks for the page

Follow [BasicIOController.cs, line 15](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Controllers/PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs:15).

`[HttpGet("/basic-io")]` connects this URL and request type to the action below it. Compare it with `app.get("/basic-io", handler)`.

The GET action returns `View("..._basicio", new ...BasicIOPageModel())`:

1. `new` creates fresh page data. It does not run Calculate().
2. `View(...)` chooses the Razor template and passes it the data.
3. ASP.NET renders the template into HTML.
4. The browser displays that HTML.

The full class and filename include the student prefix. The short names here are only for explaining the idea. Files use 24-1635; C# names use 24_1635 because a hyphen is not allowed inside an identifier.

## 4. Where are the layout and page content?

- [_ViewStart.cshtml](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/_ViewStart.cshtml:1) selects the shared layout.
- [The shared layout](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/Shared/PICARDOCHRISTOPHERJOHN_24-1635_layout.cshtml:1) contains the common page frame and navigation. `RenderBody()` places the selected topic View inside it.
- [_ViewImports.cshtml](C:/Users/picar/Desktop/ipt_project/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING/Views/_ViewImports.cshtml:1) makes shared names and Tag Helpers available to the views.
- The topic .cshtml file contains the topic headings, forms, and output blocks.
- The page model holds the values those forms display.

Example: BasicIOPageModel has Calculator, Bmi, Temperature, Greeting, and Circle properties. Each property starts with its own example model. It is a group of data objects, not one model calling all the other calculations.

## 5. Read a form without guessing

```html
<form asp-controller="..._BasicIO"
      asp-action="Calculator"
      asp-fragment="calculator"
      method="post"
      asp-antiforgery="false">
```

| Part | Meaning |
| --- | --- |
| `asp-controller` | Pick the controller class, leaving off Controller. It is not the View's filename. |
| `asp-action` | Pick a method/action in that controller. Calculator is our method name. |
| `asp-fragment` | Add #calculator to the generated address so the browser can jump to that section. |
| `method="post"` | Submit input using POST. Ordinary HTML. |
| `asp-antiforgery="false"` | Do not generate a token. The local learning app also has no antiforgery validation attributes, as requested. |
| `class="..."` | Choose styling classes. It does not choose the C# class. |

ASP.NET's form helper generates the address `/calculator#calculator`. The browser requests `/calculator`; the fragment is only used by the browser.

The URL, method name, controller name, and View filename are separate names. They can be different. `[HttpPost("/calculator")]` is what gives our Calculator action its explicit route.

## 6. Read an input

```html
<input asp-for="Calculator.FirstNumber" type="number" required>
```

ASP.NET creates an HTML input with `name="Calculator.FirstNumber"` and usually `id="Calculator_FirstNumber"`.

- name identifies the value submitted to the server.
- id identifies the element in the page, such as for a label or an error link.
- asp-for connects this field to a model property and its current value.
- type="number" and required are normal browser features.

An array field such as `Sum.Numbers[0]` means the first submitted number. Arrays start at index 0. A field such as `Totals.Cells[3]` holds one cell in the submitted list; PopulateArray later places it in the correct row and column.

## 7. POST sends values

```text
POST /calculator
Calculator.FirstNumber=5
Calculator.SecondNumber=3
Calculator.Operation=add
```

Only that form's fields are sent. The other four forms do not become inputs to this action.

ASP.NET reads the fields into the action's parameter. The parameter name Calculator matches the start of Calculator.FirstNumber. There are no explicit Bind or BindNever attributes. Automatic form reading is still part of MVC; removing an attribute does not remove that framework feature.

An Express comparison with flat field names:

```js
app.use(express.urlencoded({ extended: false }));

app.post("/calculator", (req, res) => {
    const first = Number(req.body["Calculator.FirstNumber"]);
    const second = Number(req.body["Calculator.SecondNumber"]);
    const operation = req.body["Calculator.Operation"];
    // Check input, calculate, then render the page.
});
```

This is a comparison only. The C# project does not use Express.

## 8. Check input, calculate, and return HTML

1. ASP.NET converts submitted values and runs the model's input rules.
2. Our controller checks ModelState.IsValid.
3. If valid, it calls our Calculate() method.
4. Calculate() changes Result inside that model.
5. The controller creates page data with that model in the correct slot.
6. The View checks Result, then writes it into HTML.
7. The browser displays the returned page.

If input is invalid, the controller skips Calculate() and returns the page with messages. The browser may also stop an empty required input before sending, but server checks still matter.

`return View(...)` returns HTML for the current request. It does not redirect or start another GET. After a POST to /calculator, that address remains in the browser, even though the response uses the BasicIO View. Refreshing can ask to submit again.

In the returned page model:

```csharp
new BasicIOPageModel { Calculator = Calculator }
```

The left Calculator names the page model's property. The right Calculator is the variable from the action. Like JavaScript `{ Calculator: Calculator }`.

The other four models are fresh. This app does not save previous answers in a database. Typing a number in a box does not save it to a server model until you submit it.

## Small word guide

| Code | Kind | Simple meaning |
| --- | --- | --- |
| `public`, `private` | C# keywords | Control where a member can be used. |
| `class` | C# syntax | Define the shape and behavior of an object. |
| `IActionResult` | ASP.NET type | A kind of web response an action can return. |
| `void` | C# keyword | The method does not return a value; Calculate updates Result instead. |
| `return` | C# keyword | Finish a method and give a value back when there is one. |
| `new` | C# syntax | Create an object. |
| `var` | C# syntax | Let C# work out the variable's type. |
| `get; set;` | C# property syntax | Allow reading and assigning a value. |
| `get; private set;` | C# property syntax | Other code can read it; only this class can assign it. |
| `int`, `double`, `decimal`, `string` | C# type keywords | Whole number, decimal-number types, and text. |
| `int?`, `double?`, `decimal?` | C# nullable types | A number that can also be empty (null). |
| `GetValueOrDefault()` | .NET method | Read the nullable number; return zero if empty. Our controller checks validation first. |
| `HasValue` | .NET property | Is this nullable value filled in? |
| `[HttpGet]`, `[HttpPost]` | ASP.NET attributes | Choose the HTTP request type and, when supplied, the route. |
| `[Required]`, `[Range]`, `[StringLength]` | .NET validation attributes | Set input requirements. |
| `[RegularExpression]` | .NET validation attribute | Check text against a pattern, such as the four operation names. |
| `ModelState.IsValid` | ASP.NET property | Did input conversion and validation pass? |
| `ModelState.AddModelError(...)` | ASP.NET method | Add a message for the View to show. |
| `View(...)`, `RedirectToAction(...)` | ASP.NET methods | Render a View, or tell the browser to visit another action. |
| `Calculate()`, `PopulateArray()` | Methods we wrote | Do an example's work or copy input into an array. |
| `Validate(...)` in the array models | Method we wrote for a .NET interface | Give ASP.NET custom input checks using IValidatableObject. |
| `if`, `else`, `switch`, `case` | C# syntax | Choose which code runs. Similar ideas exist in JavaScript. |
| `for`, `while`, `do`, `foreach` | C# syntax | Repeat steps. foreach visits values in a collection. |
| `++`, `--`, `+=` | C# operators | Increase by one, decrease by one, or add to the current value. |
| `%` | C# operator | Get a division remainder; used to test even/odd. |
| `==` | C# operator | Compare values. A single = assigns a value. |
| `int[]`, `int[,]` | C# array types | A one-dimensional list or a two-dimensional grid of whole numbers. |
| `List<int>`, `List<string>` | .NET types | Lists that can grow. Add(...) appends an item. |
| `string.Join(...)` | .NET method | Combine values into text with a separator. |
| `Math.PI` | .NET member | The value of pi. |
| `Trim()`, `PadLeft(...)` | .NET string methods | Remove edge spaces, or add spaces on the left. |
| `$"Hello, {Name}"` | C# string syntax | Place a value inside text. Similar to JS template strings. |
| `F2` inside a formatted value | .NET number format | Show two decimal places. |
| `?? []` | C# syntax | If the left value is null, use an empty collection. |
| `yield return`, `yield break` | C# syntax | Produce an item from an iterator, or finish that iterator; array validation uses this. |
| `@model`, `@if`, `@Model` | Razor syntax/features | Set the data type, run a condition, or read the data inside a View. |
| `asp-for`, `asp-action`, `asp-validation-for` | ASP.NET Tag Helpers | Generate fields, form destinations, and error displays. |
| `FirstNumber`, `Result`, `Calculator`, `Bmi` | Names we chose | Properties, variables, or actions, depending on their position. |

## A trace you can say out loud

```text
The app starts in Program.cs.
The browser asks for a topic with GET.
The controller gives the View fresh data.
The View becomes HTML and the browser shows the form.
I enter input and click the submit button.
The browser sends a POST to that example's route.
ASP.NET reads and checks the fields.
The controller calls the model's Calculate method if input is valid.
The model stores the answer in Result.
The controller returns the View with updated data.
The View puts Result into HTML.
The browser shows the answer.
```

Now choose any of the [20 example walkthroughs](README.md) to follow exact files, lines, and sample values.
