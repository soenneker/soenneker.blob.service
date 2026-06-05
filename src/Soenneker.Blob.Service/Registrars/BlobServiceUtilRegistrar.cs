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
    /// <summary>
    /// Adds blob service util as singleton.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddBlobServiceUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IBlobServiceUtil, BlobServiceUtil>();

        return services;
    }

    /// <summary>
    /// Adds blob service util as scoped.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddBlobServiceUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IBlobServiceUtil, BlobServiceUtil>();

        return services;
    }
}