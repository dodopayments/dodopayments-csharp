using System.Threading.Tasks;

namespace DodoPayments.Tests.Services.Customers.CustomerPortal;

public class CustomerPortalServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customerPortalSession = await this.client.Customers.CustomerPortal.Create(
            new() { CustomerID = "customer_id" }
        );
        customerPortalSession.Validate();
    }
}
