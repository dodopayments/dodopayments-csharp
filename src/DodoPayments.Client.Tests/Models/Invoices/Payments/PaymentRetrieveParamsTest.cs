using System;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveParams
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
            Token = "token",
        };

        string expectedPaymentID = "pay_gr4RizvMOXFJ6xca3y2tU";
        string expectedToken = "token";

        Assert.Equal(expectedPaymentID, parameters.PaymentID);
        Assert.Equal(expectedToken, parameters.Token);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PaymentRetrieveParams { PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU" };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawQueryData.ContainsKey("token"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PaymentRetrieveParams
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",

            // Null should be interpreted as omitted for these properties
            Token = null,
        };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawQueryData.ContainsKey("token"));
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveParams parameters = new()
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
            Token = "token",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/invoices/payments/pay_gr4RizvMOXFJ6xca3y2tU?token=token"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrieveParams
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
            Token = "token",
        };

        PaymentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
