using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;
using Misc = DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentRetrieveLineItemsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveLineItemsParams
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
            Currency = Misc::Currency.Aed,
        };

        string expectedPaymentID = "pay_gr4RizvMOXFJ6xca3y2tU";
        ApiEnum<string, Misc::Currency> expectedCurrency = Misc::Currency.Aed;

        Assert.Equal(expectedPaymentID, parameters.PaymentID);
        Assert.Equal(expectedCurrency, parameters.Currency);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PaymentRetrieveLineItemsParams
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PaymentRetrieveLineItemsParams
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",

            // Null should be interpreted as omitted for these properties
            Currency = null,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveLineItemsParams parameters = new()
        {
            PaymentID = "pay_gr4RizvMOXFJ6xca3y2tU",
            Currency = Misc::Currency.Aed,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/payments/pay_gr4RizvMOXFJ6xca3y2tU/line-items?currency=AED"
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
            Currency = Misc::Currency.Aed,
        };

        PaymentRetrieveLineItemsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
