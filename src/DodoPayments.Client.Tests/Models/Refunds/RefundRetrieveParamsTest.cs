using System;
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

    [Fact]
    public void Url_Works()
    {
        RefundRetrieveParams parameters = new() { RefundID = "refund_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/refunds/refund_id"), url);
    }
}
