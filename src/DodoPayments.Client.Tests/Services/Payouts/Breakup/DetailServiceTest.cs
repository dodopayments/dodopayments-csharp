using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Payouts.Breakup;

public class DetailServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Payouts.Breakup.Details.List(
            "payout_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task DownloadCsv_Works()
    {
        await this.client.Payouts.Breakup.Details.DownloadCsv(
            "payout_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
