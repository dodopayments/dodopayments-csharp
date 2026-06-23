using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products.LocalizedPrices;

namespace DodoPayments.Client.Tests.Models.Products.LocalizedPrices;

public class LocalizedPriceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LocalizedPriceCreateParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            Amount = 0,
            Currency = Currency.Aed,
            CountryCode = CountryCode.Af,
        };

        string expectedProductID = "pdt_R8AWMPiV8RyJElcCKvAID";
        int expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        ApiEnum<string, CountryCode> expectedCountryCode = CountryCode.Af;

        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedCountryCode, parameters.CountryCode);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LocalizedPriceCreateParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            Amount = 0,
            Currency = Currency.Aed,
        };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("country_code"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LocalizedPriceCreateParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            Amount = 0,
            Currency = Currency.Aed,

            CountryCode = null,
        };

        Assert.Null(parameters.CountryCode);
        Assert.True(parameters.RawBodyData.ContainsKey("country_code"));
    }

    [Fact]
    public void Url_Works()
    {
        LocalizedPriceCreateParams parameters = new()
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            Amount = 0,
            Currency = Currency.Aed,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/products/pdt_R8AWMPiV8RyJElcCKvAID/localized-prices"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LocalizedPriceCreateParams
        {
            ProductID = "pdt_R8AWMPiV8RyJElcCKvAID",
            Amount = 0,
            Currency = Currency.Aed,
            CountryCode = CountryCode.Af,
        };

        LocalizedPriceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
