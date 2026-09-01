using System;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentRetrieveRetryStateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveRetryStateParams { PaymentID = "payment_id" };

        string expectedPaymentID = "payment_id";

        Assert.Equal(expectedPaymentID, parameters.PaymentID);
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveRetryStateParams parameters = new() { PaymentID = "payment_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/payments/payment_id/retry"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrieveRetryStateParams { PaymentID = "payment_id" };

        PaymentRetrieveRetryStateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
