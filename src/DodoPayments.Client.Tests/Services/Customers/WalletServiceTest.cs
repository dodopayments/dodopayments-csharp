using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Customers;

public class WalletServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var wallets = await this.client.Customers.Wallets.List(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        wallets.Validate();
    }
}
