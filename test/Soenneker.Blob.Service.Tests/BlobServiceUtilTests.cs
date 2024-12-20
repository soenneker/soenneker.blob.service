using Soenneker.Blob.Service.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Blob.Service.Tests;

[Collection("Collection")]
public class BlobServiceUtilTests : FixturedUnitTest
{
    private readonly IBlobServiceUtil _util;

    public BlobServiceUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IBlobServiceUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
