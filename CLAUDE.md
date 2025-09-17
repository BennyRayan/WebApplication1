# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

### Build and Run
```bash
# Build the project
dotnet build

# Run the application (HTTP)
dotnet run --project WebApplication1

# Run with HTTPS
dotnet run --project WebApplication1 --launch-profile https
```

### Testing and Development
```bash
# Test the API endpoint
curl http://localhost:5240/weatherforecast

# Or use the included .http file with an HTTP client
# WebApplication1/WebApplication1.http
```

## Architecture

This is a minimal ASP.NET Core 9.0 web API application with:

- **Framework**: .NET 9.0 with minimal API pattern
- **Entry Point**: `WebApplication1/Program.cs` - Contains all application setup and endpoint definitions
- **API Documentation**: OpenAPI/Swagger enabled in development mode at `/openapi`
- **Endpoints**: 
  - `/weatherforecast` - GET endpoint returning weather forecast data

The application uses the minimal hosting model introduced in .NET 6+, where all startup configuration and endpoint mapping is consolidated in Program.cs rather than using separate Startup and Controller classes.