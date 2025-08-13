using System.Threading.Tasks;

namespace DodoPayments.Tests.Services.Payouts;

public class PayoutServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Payouts.List(new());
        page.Validate();
    }
}
