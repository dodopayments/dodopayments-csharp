using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Refunds;

public class RefundRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RefundRetrieveParams { RefundID = "refund_id" };

        string expectedRefundID = "refund_id";

        Assert.Equal(expectedRefundID, parameters.RefundID);
    }
}
