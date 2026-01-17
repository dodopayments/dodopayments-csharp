using System;
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

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveParams parameters = new() { PaymentID = "payment_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/invoices/payments/payment_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrieveParams { PaymentID = "payment_id" };

        PaymentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
