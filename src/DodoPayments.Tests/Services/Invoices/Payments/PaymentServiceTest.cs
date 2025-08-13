using System.Threading.Tasks;

namespace DodoPayments.Tests.Services.Invoices.Payments;

public class PaymentServiceTest : TestBase
{
    [Fact(Skip = "Prism doesn't support application/pdf responses")]
    public async Task Retrieve_Works()
    {
        var payment = await this.client.Invoices.Payments.Retrieve(
            new() { PaymentID = "payment_id" }
        );
        _ = payment;
    }
}
