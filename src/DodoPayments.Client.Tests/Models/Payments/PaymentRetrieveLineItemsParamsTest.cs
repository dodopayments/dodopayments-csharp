using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentRetrieveLineItemsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveLineItemsParams { PaymentID = "payment_id" };

        string expectedPaymentID = "payment_id";

        Assert.Equal(expectedPaymentID, parameters.PaymentID);
    }
}
