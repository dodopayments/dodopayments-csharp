using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Customers.Wallets;

public class WalletServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var wallets = await this.client.Customers.Wallets.List(
            new() { CustomerID = "customer_id" }
        );
        wallets.Validate();
    }
}
