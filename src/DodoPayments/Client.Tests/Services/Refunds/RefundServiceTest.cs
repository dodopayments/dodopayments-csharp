using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Refunds;

public class RefundServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var refund = await this.client.Refunds.Create(new() { PaymentID = "payment_id" });
        refund.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var refund = await this.client.Refunds.Retrieve(new() { RefundID = "refund_id" });
        refund.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Refunds.List(new());
        page.Validate();
    }
}
