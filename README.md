[![](https://img.shields.io/nuget/v/soenneker.lemlist.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.httpclients/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.httpclients/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.lemlist.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.httpclients/actions/workflows/codeql.yml)

# Soenneker.Lemlist.HttpClients

A cached `HttpClient` configured for Lemlist's API and API-key authentication.

## Install

```bash
dotnet add package Soenneker.Lemlist.HttpClients
```

## Configuration

```json
{
  "Lemlist": {
    "ApiKey": "your-api-key"
  }
}
```

Set `Lemlist:ClientBaseUrl` to override the default Lemlist API URL, such as when using a test server.

## Usage

```csharp
using Soenneker.Lemlist.HttpClients.Abstract;
using Soenneker.Lemlist.HttpClients.Registrars;

services.AddLemlistOpenApiHttpClientAsSingleton();

ILemlistOpenApiHttpClient lemlist =
    serviceProvider.GetRequiredService<ILemlistOpenApiHttpClient>();

HttpClient client = await lemlist.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync("campaigns", cancellationToken);
```

`Get()` reuses the cached client and applies Lemlist's Basic authentication format. The API key is the password and the username is empty.

The singleton registration shares one client for the application. The scoped registration keeps both the wrapper and its cache within the scope, so disposing one scope cannot evict another scope's client.
