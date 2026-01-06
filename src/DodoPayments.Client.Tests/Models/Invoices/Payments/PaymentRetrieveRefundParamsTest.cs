using System;
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

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveRefundParams parameters = new() { RefundID = "refund_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/invoices/refunds/refund_id"), url);
    }
}
