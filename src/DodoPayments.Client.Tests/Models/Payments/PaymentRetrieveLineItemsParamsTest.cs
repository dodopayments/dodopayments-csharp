using System;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentRetrieveLineItemsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveLineItemsParams
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
        };

        string expectedPaymentID = "pay_gr4RizvMOXFJ6xca3y2tU";

        Assert.Equal(expectedPaymentID, parameters.PaymentID);
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveLineItemsParams parameters = new()
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/payments/pay_gr4RizvMOXFJ6xca3y2tU/line-items"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrieveLineItemsParams
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
        };

        PaymentRetrieveLineItemsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
