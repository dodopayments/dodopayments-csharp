using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class BalanceServiceTest : TestBase
{
    [Fact]
    public async Task RetrieveLedger_Works()
    {
        var page = await this.client.Balances.RetrieveLedger(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
