# Fundamental of Programming

Christopher John Picardo · Student no. 24-1635

A simple ASP.NET Core MVC course project with locally compiled Tailwind CSS. The interface uses a W3Schools-inspired topic sidebar and a readable content area.

## Current setup

Four course pages are ready as empty lesson shells:

| Page | URL | Required examples |
| --- | --- | --- |
| Basic Input-Output | `/basic-io` | 5 |
| Nested If...Else | `/nested-if-else` | 5 |
| Loops | `/loops` | 1 for, 2 while, 2 do...while |
| Arrays | `/arrays` | 2 one-dimensional, 3 two-dimensional |

The root URL redirects to Basic Input-Output. The 20 examples are not implemented yet. Next, the student builds only the Basic Calculator using [the step-by-step guide](BASIC-CALCULATOR-GUIDE.md). The agent implements the other four Basic Input-Output examples and the remaining topics afterward.

The five chosen Basic Input-Output examples are Basic Calculator, BMI Calculator, Temperature Converter, Personalized Greeting Generator, and Circle Area & Circumference (radius input; area and circumference output).

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

- `Controllers/`: request handling and view selection. The home controller currently provides the four topic actions and the error action.
- `Models/`: typed input/output data and validation. Only the error model is needed for the static setup.
- `Views/`: the four topic views, a shared layout, and an error view.
- `Styles/site.css`: Tailwind input and small shared styles.
- `wwwroot/css/site.css`: generated stylesheet; rebuild instead of editing it.

Custom controller, model, and view filenames start with `PICARDOCHRISTOPHERJOHN_24-1635_`. C# class and namespace identifiers use `24_1635` because hyphens are not valid in identifiers. View folders match the controller class name without `Controller`. Framework entry points keep their required names.

Read [AGENTS.md](AGENTS.md) before changing the project. It records naming, MVC, readability, design, planned coverage, and the guided Basic Input-Output workflow.

## Windows generated-file path fix

The default generated EditorConfig path is 262 characters in this workspace, which can fail in Windows tooling. The project sets `GeneratedMSBuildEditorConfigFile` to `obj/$(Configuration)/$(TargetFramework)/Generated.editorconfig`, preserving the required project name. If Visual Studio still shows the old path after reloading the project, rebuild the solution so it refreshes its generated-file references.
