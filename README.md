# Fundamental of Programming

Christopher John Picardo · Student no. 24-1635

A simple ASP.NET Core MVC course project with locally compiled Tailwind CSS. The interface uses a W3Schools-inspired topic sidebar and a readable content area.

## Current setup

Four course pages contain 20 working examples:

| Page | URL | Required examples |
| --- | --- | --- |
| Basic Input-Output | `/basic-io` | 5 |
| Nested If...Else | `/nested-if-else` | 5 |
| Loops | `/loops` | 1 for, 2 while, 2 do...while |
| Arrays | `/arrays` | 2 one-dimensional, 3 two-dimensional |

The root URL redirects to Basic Input-Output. Each example has its own validated form, result, and expandable C# logic. Calculation logic lives in the models; controllers receive requests and choose the view.

The five chosen Basic Input-Output examples are Basic Calculator, BMI Calculator, Temperature Converter, Personalized Greeting Generator, and Circle Area & Circumference (radius input; area and circumference output).

BMI accepts kilograms and centimetres and displays only the calculated value. Temperature conversion supports Celsius to Fahrenheit and Fahrenheit to Celsius.

The other examples use simple practice rules:

- **Nested If...Else:** number sign, grade checker, age group, largest of three numbers, and number sign and parity.
- **For:** multiplication table from 1 to 10.
- **While:** counting from 1 to N and printing a star line.
- **Do...while:** countdown to zero and a star triangle.
- **One-dimensional arrays:** sum and largest value of five numbers.
- **Two-dimensional arrays:** Row & Column Totals, Highest & Lowest + Coordinates, and Multiplication Table Grid (1 to 10).

Array inputs are editable, indexed cells containing whole numbers from -1000 to 1000. The 1D examples use five indexed inputs. The 2D examples use editable 2×2 grids or a generated multiplication grid. Loop limits are bounded and shown on their fields. The grade and age classifications are exercise rules, not institutional policies.

## Run locally

Install the .NET 10 SDK and Node.js 22 or newer. In PowerShell, enter the project folder:

```powershell
cd .\PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING
npm install
npm run build:css
dotnet build
dotnet run --launch-profile http
```

Open `http://localhost:5291`. Stop the foreground server with Ctrl+C when finished. The compiled stylesheet is committed, so `dotnet run` also works without Node when no styling changes are needed.

After editing Razor classes or `Styles/site.css`, run `npm run build:css` before building or running .NET. An optional `npm run watch:css` runs in a separate foreground terminal; stop it with Ctrl+C when finished. For publishing, run the CSS build before `dotnet publish`.

Tailwind uses the [official CLI installation](https://tailwindcss.com/docs/installation/tailwind-cli) and scans the Razor views. No Bootstrap, jQuery, runtime CSS CDN, or JavaScript framework is required.

## MVC structure

- `Controllers/`: BasicIO, NestedIfElse, Loops, and Arrays each have a topic controller.
- `Models/`: typed form data, validation, and calculations, organized into BasicIO, NestedIfElse, Loops, Arrays, and Shared folders. Each topic's page model lives beside its form models.
- `Views/`: four topic views, a shared layout, a validation summary, and an error view.
- `Styles/site.css`: Tailwind input and small shared styles.
- `wwwroot/css/site.css`: generated stylesheet; rebuild instead of editing it.

Custom controller, model, and view filenames start with `PICARDOCHRISTOPHERJOHN_24-1635_`. C# class and namespace identifiers use `24_1635` because hyphens are not valid in identifiers. View folders match the controller class name without `Controller`. Framework entry points keep their required names.

The Basic Input-Output view is in `Views/PICARDOCHRISTOPHERJOHN_24_1635_BasicIO/`. Its models are in `Models/BasicIO/`; model namespaces include the topic folder name.

Read [AGENTS.md](AGENTS.md) before changing the project. It records naming, MVC, readability, design, and coverage. The [calculator guide](BASIC-CALCULATOR-GUIDE.md) is the original standalone learning exercise; the current page wraps it alongside the other four forms.

## Verification

From the repository's outer folder, run the dependency-free model checks:

```powershell
dotnet run --project .\tests\Examples\Examples.csproj
```

With the application running in a foreground terminal, use another PowerShell 7 terminal at the outer folder to check all 20 forms, validation, encoding, and antiforgery:

```powershell
.\tests\Test-WebExamples.ps1
```

Each form submits independently and returns the same topic page. There is no database or saved submission history.

## Windows generated-file path fix

The default generated EditorConfig path is 262 characters in this workspace, which can fail in Windows tooling. The project sets `GeneratedMSBuildEditorConfigFile` to `obj/$(Configuration)/$(TargetFramework)/Generated.editorconfig`, preserving the required project name. If Visual Studio still shows the old path after reloading the project, rebuild the solution so it refreshes its generated-file references.

## Learning documentation

Open [the documentation index](documentation/README.md) for the app-startup guide and 20 step-by-step MVC walkthroughs, grouped by topic. Each guide includes source line links, sample input/output, and simple Express comparisons.
