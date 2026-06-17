using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Payouts.Breakup;

public class DetailServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Payouts.Breakup.Details.List(
            "pyt_zFTrrn4sk3x3y2vjDBW3T",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task DownloadCsv_Works()
    {
        await this.client.Payouts.Breakup.Details.DownloadCsv(
            "pyt_zFTrrn4sk3x3y2vjDBW3T",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
