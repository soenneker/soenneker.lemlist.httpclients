using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Lemlist.HttpClients.Abstract;
using Soenneker.Lemlist.HttpClients.Registrars;
using Soenneker.Tests.HostedUnit;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Lemlist.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class LemlistOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ILemlistOpenApiHttpClient _httpclient;

    public LemlistOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ILemlistOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Scoped_client_uses_scoped_cache()
    {
        var services = new ServiceCollection();

        services.AddLemlistOpenApiHttpClientAsScoped();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor client = services.Single(descriptor => descriptor.ServiceType == typeof(ILemlistOpenApiHttpClient));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
        await Assert.That(client.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }

    [Test]
    public async Task Singleton_client_uses_singleton_cache()
    {
        var services = new ServiceCollection();

        services.AddLemlistOpenApiHttpClientAsSingleton();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor client = services.Single(descriptor => descriptor.ServiceType == typeof(ILemlistOpenApiHttpClient));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
        await Assert.That(client.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
    }
}
