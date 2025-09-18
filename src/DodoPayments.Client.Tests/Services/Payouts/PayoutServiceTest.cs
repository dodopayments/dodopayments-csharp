using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Payouts;

public class PayoutServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Payouts.List();
        page.Validate();
    }
}
