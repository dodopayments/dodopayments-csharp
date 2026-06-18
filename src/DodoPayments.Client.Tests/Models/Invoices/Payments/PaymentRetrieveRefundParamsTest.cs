using System;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrieveRefundParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveRefundParams { RefundID = "ref_F0gZetLvTxxBrMU2CZcmy" };

        string expectedRefundID = "ref_F0gZetLvTxxBrMU2CZcmy";

        Assert.Equal(expectedRefundID, parameters.RefundID);
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveRefundParams parameters = new() { RefundID = "ref_F0gZetLvTxxBrMU2CZcmy" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/invoices/refunds/ref_F0gZetLvTxxBrMU2CZcmy"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrieveRefundParams { RefundID = "ref_F0gZetLvTxxBrMU2CZcmy" };

        PaymentRetrieveRefundParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
