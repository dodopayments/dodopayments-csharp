using System;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveParams { PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU" };

        string expectedPaymentID = "pay_gr4RizvMOXFJ6xca3y2tU";

        Assert.Equal(expectedPaymentID, parameters.PaymentID);
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveParams parameters = new() { PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/invoices/payments/pay_gr4RizvMOXFJ6xca3y2tU"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrieveParams { PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU" };

        PaymentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
