using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveParams { PaymentID = "payment_id" };

        string expectedPaymentID = "payment_id";

        Assert.Equal(expectedPaymentID, parameters.PaymentID);
    }
}
