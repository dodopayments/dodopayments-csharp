using System;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrievePayoutParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrievePayoutParams { PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T" };

        string expectedPayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T";

        Assert.Equal(expectedPayoutID, parameters.PayoutID);
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrievePayoutParams parameters = new() { PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/invoices/payouts/pyt_zFTrrn4sk3x3y2vjDBW3T"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrievePayoutParams { PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T" };

        PaymentRetrievePayoutParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
