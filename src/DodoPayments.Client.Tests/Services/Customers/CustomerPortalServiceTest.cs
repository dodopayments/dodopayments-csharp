using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Customers;

public class CustomerPortalServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customerPortalSession = await this.client.Customers.CustomerPortal.Create(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new(),
            TestContext.Current.CancellationToken
        );
        customerPortalSession.Validate();
    }
}
