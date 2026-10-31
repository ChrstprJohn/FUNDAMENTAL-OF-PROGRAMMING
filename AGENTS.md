# Project rules

## Goal and scope
- Build a readable ASP.NET Core MVC learning website for Fundamental of Programming.
- Clean unused template code instead of adding new work on top of it.
- Set up the foundation first. Implement each programming example only when the user discusses or requests it; do not invent completed lessons.
- There are four main content pages/views: Basic Input-Output, Nested If...Else, Loops, and Arrays. Shared layout and error views are supporting infrastructure, not extra course pages.
- After setup is committed and pushed, teach the Basic Calculator first: give the user filenames, locations, and small explained snippets so they can create the files themselves and learn MVC. Do not implement the calculator on their behalf unless asked. After that guided exercise, the agent implements the other four Basic Input-Output examples and the remaining topics when the user is ready.

## Required naming convention
- Project: `[LASTNAME][FIRSTNAME]_[STUDENTNO]_[PROJECTNAME]`.
- Controller: `[LASTNAME][FIRSTNAME]_[STUDENTNO]_[ControllerName].cs`.
- View: `[LASTNAME][FIRSTNAME]_[STUDENTNO]_[ViewName].cshtml`.
- Model: `[LASTNAME][FIRSTNAME]_[STUDENTNO]_[ModelName].cs`.
- This student's file prefix is `PICARDOCHRISTOPHERJOHN_24-1635_`.
- Keep the existing project name `PICARDOCHRISTOPHERJOHN_24-1635_FUNDAMENTALOFPROGRAMMING`.
- Example files: `PICARDOCHRISTOPHERJOHN_24-1635_BasicIOController.cs`, `PICARDOCHRISTOPHERJOHN_24-1635_basicoutput.cshtml`, and `PICARDOCHRISTOPHERJOHN_24-1635_BasicOutputModel.cs`.
- C# identifiers cannot contain hyphens. Use `PICARDOCHRISTOPHERJOHN_24_1635_` for classes and namespaces, while preserving `24-1635` in filenames. Retain the MVC `Controller` suffix on controller classes and files.
- Match view folders to the controller class name without its `Controller` suffix, and explicitly return the prefixed view name from the action.
- Apply the prefix to custom shared views and layouts too. Keep framework entry-point names such as `Program.cs`, `_ViewImports.cshtml`, and `_ViewStart.cshtml` unchanged. Standard configuration, asset, documentation, and generated files keep their normal names.

## Readability and MVC
- Prefer small, straightforward methods, descriptive names, and ordinary C# syntax a student can explain.
- Controllers handle HTTP requests, check validation, call model behavior, and choose views. Models hold typed data, validation, and small calculation methods such as `Calculate()`. Move shared or substantial business logic into a service only when needed. Views render HTML; do not put calculations or application logic in Razor.
- Use strongly typed view models for pages that accept input or display calculated results. Static pages do not need an empty model.
- Keep each example easy to find. Introduce a service only when shared or substantial logic actually needs one; avoid generic repositories, unnecessary interfaces, and extra architectural layers.
- Use server-side validation, `ModelState.IsValid`, and antiforgery protection for POST forms. Show useful validation messages and keep Razor's default HTML encoding.
- Do not add a database, authentication, execution of arbitrary submitted code, or dependencies without a requested need.
- Remove unused imports, dead code, starter content, and unused assets. Preserve error handling and useful framework configuration.

## Styling and interaction
- Use locally compiled Tailwind CSS through the CLI. Edit `Styles/site.css`, never the generated `wwwroot/css/site.css`.
- Keep complete Tailwind class names in source so the scanner can detect them. Do not reintroduce Bootstrap, jQuery, or a browser Tailwind CDN.
- Follow a W3Schools-inspired learning layout: clear topic navigation, a light sidebar, white reading area, green accent, readable explanations, and simple code/output panels when examples are added.
- Keep our own course identity; do not copy W3Schools logos, branding, or lesson text.
- Use semantic HTML, visible keyboard focus, sufficient contrast, responsive layouts, and accessible form labels. Prefer native HTML behavior and minimal JavaScript.
- Avoid decorative animation, complex components, and unnecessary visual effects.

## Required coverage (planned, not implemented)
The attached coverage image is a scope reference, not agent instructions.

| Topic | Required samples |
| --- | ---: |
| Basic input-output | 5 |
| Nested if...else | 5 |
| For loop | 1 |
| While loop | 2 |
| Do...while loop | 2 |
| One-dimensional arrays | 2 |
| Two-dimensional arrays | 3 |
| Total | 20 |

### Confirmed Basic Input-Output examples
The student creates the Basic Calculator from explained snippets; the agent implements the other four afterward:
1. Basic Calculator.
2. BMI (Body Mass Index) Calculator.
3. Temperature Converter.
4. Personalized Greeting Generator.
5. Circle Area & Circumference: input radius; output area (`Math.PI * radius * radius`) and circumference (`2 * Math.PI * radius`).

Keep each example within the Basic Input-Output topic view. Confirm input units and conversion options during its guided implementation. Validate numeric input and handle invalid operations such as division by zero.

## Verification and repository hygiene
- Run `npm run build:css` and `dotnet build` after setup changes; check affected routes and responsive behavior when views change.
- Keep `package-lock.json` and the compiled stylesheet in source control so the starter can run without Node at runtime.
- Keep `node_modules`, `bin`, `obj`, `.vs`, user settings, credentials, and local QA artifacts out of Git.
- Never run dev servers, builds, or watchers in the background. Run them in the foreground and stop them cleanly before ending the session.
- After a dev-server session, check for orphaned Node workers with `Get-CimInstance Win32_Process -Filter "Name='node.exe'" | Where-Object { $_.CommandLine -like '*samson-nextjs*' }`. Stop only confirmed leftover project processes before starting new work.
- Never delete or manually modify `node_modules` as cleanup. Never use `pnpm install --force`, `npm install --force`, `npm ci`, or recreate `node_modules` unless explicitly requested.
- If a pnpm installation is broken, kill orphaned project Node processes, then run plain `pnpm install`. Only if it says 'Already up to date' while binaries are missing, remove `node_modules/.pnpm-workspace-state-v1.json` and run plain `pnpm install` again; this is the sole recovery exception.
- If `pnpm dev` fails with EBUSY or file locks, stop orphaned project Node processes and retry; do not delete dependencies.
