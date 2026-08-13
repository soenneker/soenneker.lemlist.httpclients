using Soenneker.Lemlist.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

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
}
