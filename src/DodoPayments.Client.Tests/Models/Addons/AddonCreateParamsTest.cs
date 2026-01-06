using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Addons;

public class AddonCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonCreateParams
        {
            Currency = Currency.Aed,
            Name = "name",
            Price = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            Description = "description",
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedName = "name";
        int expectedPrice = 0;
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        string expectedDescription = "description";

        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPrice, parameters.Price);
        Assert.Equal(expectedTaxCategory, parameters.TaxCategory);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddonCreateParams
        {
            Currency = Currency.Aed,
            Name = "name",
            Price = 0,
            TaxCategory = TaxCategory.DigitalProducts,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AddonCreateParams
        {
            Currency = Currency.Aed,
            Name = "name",
            Price = 0,
            TaxCategory = TaxCategory.DigitalProducts,

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        AddonCreateParams parameters = new()
        {
            Currency = Currency.Aed,
            Name = "name",
            Price = 0,
            TaxCategory = TaxCategory.DigitalProducts,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/addons"), url);
    }
}
