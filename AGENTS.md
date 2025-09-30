# Repository Guidelines

## Project Structure & Module Organization
- `WebApplication1/Program.cs` hosts the minimal API entry point and weather sample endpoint.
- Domain models live in `WebApplication1/Patient.cs`, `Therapist.cs`, and `TimeSlot.cs`; keep related logic together to stay within the bounded context.
- Runtime configuration is in `WebApplication1/appsettings*.json`; adjust `appsettings.Development.json` for local overrides only.
- Environment launch profiles reside in `WebApplication1/Properties/launchSettings.json` for Rider/VS debugging.

## Build, Test, and Run
- `dotnet restore` resolves NuGet dependencies before first build.
- `dotnet build WebApplication1/WebApplication1.csproj` compiles the API.
- `dotnet watch run --project WebApplication1` enables hot reload for local development.
- `dotnet test` should target future test projects (e.g., `WebApplication1.Tests`) and blocks merges when failing.

## Coding Style & Naming Conventions
- Follow .NET defaults: four-space indentation, braces on new lines, and expression-bodied members only when readability improves.
- Name classes and records in PascalCase, methods in PascalCase, and locals/parameters in camelCase.
- Guard clauses are preferred for validating constructor arguments, mirroring existing domain classes.
- Run `dotnet format` before committing to enforce C# style and fix whitespace or analyzer issues.

## Testing Guidelines
- Use xUnit for new test projects and locate them under `tests/` (e.g., `tests/WebApplication1.Tests`).
- Name test files after the class under test and individual tests using the pattern `MethodName_ShouldExpectedOutcome`.
- Aim for coverage of domain invariants (age calculations, license validation, scheduling conflicts) and any HTTP endpoints.
- Add integration tests that exercise `Program` via `WebApplicationFactory` when API surface grows.

## Commit & Pull Request Guidelines
- Write commit subjects in imperative mood with <= 72 characters (e.g., `Add therapist availability validation`).
- Group logical changes per commit; avoid mixing refactors and feature work.
- Summarize PR intent, list test evidence (`dotnet build`, `dotnet test`), and link related issue IDs.
- Include screenshots or HTTP request samples when modifying endpoints or response contracts.
