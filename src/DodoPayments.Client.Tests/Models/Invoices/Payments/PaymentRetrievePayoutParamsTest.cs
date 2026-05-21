using System;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrievePayoutParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrievePayoutParams { PayoutID = "payout_id" };

        string expectedPayoutID = "payout_id";

        Assert.Equal(expectedPayoutID, parameters.PayoutID);
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrievePayoutParams parameters = new() { PayoutID = "payout_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/invoices/payouts/payout_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrievePayoutParams { PayoutID = "payout_id" };

        PaymentRetrievePayoutParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
