using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
namespace Soenneker.Lemlist.HttpClients.Abstract;

/// <summary>
/// Provides a cached HTTP client configured for the Lemlist API.
/// </summary>
public interface ILemlistOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured HTTP client used by the Lemlist OpenAPI HTTP Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
