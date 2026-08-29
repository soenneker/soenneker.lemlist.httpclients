[![](https://img.shields.io/nuget/v/soenneker.lemlist.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.lemlist.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.httpclients/)

# Soenneker.Lemlist.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Lemlist.HttpClients
```

## Quick start

```csharp
using Soenneker.Lemlist.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddLemlistOpenApiHttpClientAsSingleton();
```

Adds `LemlistOpenApiHttpClient` as a singleton service.

## What you get

- `ILemlistOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `LemlistOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `LemlistOpenApiHttpClientRegistrar.AddLemlistOpenApiHttpClientAsSingleton(services)` | Adds `LemlistOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `LemlistOpenApiHttpClientRegistrar.AddLemlistOpenApiHttpClientAsScoped(services)` | Adds `LemlistOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
