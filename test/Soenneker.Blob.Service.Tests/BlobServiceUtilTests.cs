using Soenneker.Blob.Service.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blob.Service.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class BlobServiceUtilTests : HostedUnitTest
{
    private readonly IBlobServiceUtil _util;

    public BlobServiceUtilTests(Host host) : base(host)
    {
        _util = Resolve<IBlobServiceUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
