using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Customers;

public class WalletServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var wallets = await this.client.Customers.Wallets.List(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new(),
            TestContext.Current.CancellationToken
        );
        wallets.Validate();
    }
}
