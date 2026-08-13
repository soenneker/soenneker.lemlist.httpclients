using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Lemlist.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Lemlist.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class LemlistOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="LemlistOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddLemlistOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ILemlistOpenApiHttpClient, LemlistOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="LemlistOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddLemlistOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ILemlistOpenApiHttpClient, LemlistOpenApiHttpClient>();

        return services;
    }
}
