using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrieveRefundParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveRefundParams { RefundID = "refund_id" };

        string expectedRefundID = "refund_id";

        Assert.Equal(expectedRefundID, parameters.RefundID);
    }
}
