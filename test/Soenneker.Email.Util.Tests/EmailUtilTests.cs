using Soenneker.Email.Util.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Email.Util.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class EmailUtilTests : HostedUnitTest
{
    private readonly IEmailUtil _util;

    public EmailUtilTests(Host host) : base(host)
    {
        _util = Resolve<IEmailUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
