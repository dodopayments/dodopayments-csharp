using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Payouts;

public class BreakupServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var breakups = await this.client.Payouts.Breakup.Retrieve(
            "payout_id",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in breakups)
        {
            item.Validate();
        }
    }
}
