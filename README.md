[![](https://img.shields.io/nuget/v/Soenneker.Blob.Service.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Service/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.service/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blob.service/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Blob.Service.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Service/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.service/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blob.service/actions/workflows/codeql.yml)

# Soenneker.Blob.Service

A utility library for Azure Blob storage copy operations.

## Install

```bash
dotnet add package Soenneker.Blob.Service
```

## Quick start

```csharp
using Soenneker.Blob.Service.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddBlobServiceUtilAsSingleton();
```

Registers Blob Service Util with a singleton lifetime.

## What you get

- `BlobServiceUtilRegistrar` — A utility library for Azure Blob storage copy operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `BlobServiceUtilRegistrar.AddBlobServiceUtilAsSingleton(services)` | Registers Blob Service Util with a singleton lifetime. | The same service collection, so additional registrations can be chained. |
| `BlobServiceUtilRegistrar.AddBlobServiceUtilAsScoped(services)` | Registers Blob Service Util with a scoped lifetime. | The same service collection, so additional registrations can be chained. |
