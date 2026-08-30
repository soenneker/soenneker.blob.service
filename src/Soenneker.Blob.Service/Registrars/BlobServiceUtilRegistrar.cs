using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blob.Service.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Blob.Service.Registrars;

/// <summary>
/// Registers the Azure Blob service client utility.
/// </summary>
public static class BlobServiceUtilRegistrar
{
    /// <summary>
    /// Registers Blob Service Util with a singleton lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddBlobServiceUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IBlobServiceUtil, BlobServiceUtil>();

        return services;
    }

    /// <summary>
    /// Registers Blob Service Util with a scoped lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddBlobServiceUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IBlobServiceUtil, BlobServiceUtil>();

        return services;
    }
}
