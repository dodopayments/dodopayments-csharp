using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Customers;

public class CustomerPortalServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customerPortalSession = await this.client.Customers.CustomerPortal.Create(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        customerPortalSession.Validate();
    }
}
