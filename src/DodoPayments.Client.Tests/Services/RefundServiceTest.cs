using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class RefundServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var refund = await this.client.Refunds.Create(
            new() { PaymentID = "payment_id" },
            TestContext.Current.CancellationToken
        );
        refund.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var refund = await this.client.Refunds.Retrieve(
            "refund_id",
            new(),
            TestContext.Current.CancellationToken
        );
        refund.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Refunds.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
