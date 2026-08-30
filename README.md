[![](https://img.shields.io/nuget/v/Soenneker.Blob.Service.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Service/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.service/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blob.service/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Blob.Service.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Service/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.service/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blob.service/actions/workflows/codeql.yml)

# Soenneker.Blob.Service

Provides a lazily created, reusable Azure `BlobServiceClient` through dependency injection.

## Installation

```bash
dotnet add package Soenneker.Blob.Service
```

## Configuration

```json
{
  "Azure": {
    "Storage": {
      "Blob": {
        "ConnectionString": "<connection string>"
      }
    }
  }
}
```

## Registration

Register one shared service client for the application:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Blob.Service.Registrars;

services.AddBlobServiceUtilAsSingleton();
```

`AddBlobServiceUtilAsScoped()` creates one utility and client per dependency-injection scope.

## Usage

```csharp
using Azure.Storage.Blobs;
using Soenneker.Blob.Service.Abstract;

public sealed class StorageInventory
{
    private readonly IBlobServiceUtil _service;

    public StorageInventory(IBlobServiceUtil service)
    {
        _service = service;
    }

    public async ValueTask<IReadOnlyList<string>> GetContainerNames(
        CancellationToken cancellationToken)
    {
        BlobServiceClient client = await _service.Get(cancellationToken);
        var names = new List<string>();

        await foreach (var container in client.GetBlobContainersAsync(
                           cancellationToken: cancellationToken))
        {
            names.Add(container.Name);
        }

        return names;
    }
}
```

The returned object is the standard Azure SDK client, so container enumeration, account properties, container clients, and other service-level operations remain available directly through Azure's API.

## Lifecycle

- The first `Get` creates the client from `Azure:Storage:Blob:ConnectionString`; later calls on the same utility return the same instance.
- The cancellation token passed to `Get` applies to lazy initialization. Pass a token separately to each Azure SDK operation.
- The utility owns its cached HTTP transport. Let the dependency-injection container dispose `IBlobServiceUtil`; consumers should not dispose infrastructure obtained from it.
- The singleton registration is appropriate for most applications because Azure SDK clients are designed for reuse.
- A scoped registration owns an isolated HTTP-client cache entry, so disposing one scope does not invalidate another scope's client.
