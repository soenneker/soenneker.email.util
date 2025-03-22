using Soenneker.Email.Util.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Email.Util.Tests;

[Collection("Collection")]
public class EmailUtilTests : FixturedUnitTest
{
    private readonly IEmailUtil _util;

    public EmailUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IEmailUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
