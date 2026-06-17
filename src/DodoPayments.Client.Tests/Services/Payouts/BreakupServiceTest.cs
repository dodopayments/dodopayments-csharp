using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Payouts;

public class BreakupServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var breakups = await this.client.Payouts.Breakup.Retrieve(
            "pyt_zFTrrn4sk3x3y2vjDBW3T",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in breakups)
        {
            item.Validate();
        }
    }
}
