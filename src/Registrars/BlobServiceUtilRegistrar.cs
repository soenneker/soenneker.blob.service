using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blob.Service.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Blob.Service.Registrars;

/// <summary>
/// A utility library for Azure Blob storage copy operations
/// </summary>
public static class BlobServiceUtilRegistrar
{
    public static void AddBlobServiceUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddSingleton<IBlobServiceUtil, BlobServiceUtil>();
    }

    public static void AddBlobServiceUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddScoped<IBlobServiceUtil, BlobServiceUtil>();
    }
}