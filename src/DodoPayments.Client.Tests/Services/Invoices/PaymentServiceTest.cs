using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Invoices;

public class PaymentServiceTest : TestBase
{
    [Fact(Skip = "Prism doesn't support application/pdf responses")]
    public async Task Retrieve_Works()
    {
        await this.client.Invoices.Payments.Retrieve(new() { PaymentID = "payment_id" });
    }

    [Fact(Skip = "Prism doesn't support application/pdf responses")]
    public async Task RetrieveRefund_Works()
    {
        await this.client.Invoices.Payments.RetrieveRefund(new() { RefundID = "refund_id" });
    }
}
