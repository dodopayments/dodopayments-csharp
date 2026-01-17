using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Addons;

public class AddonUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonUpdateParams
        {
            ID = "id",
            Currency = Currency.Aed,
            Description = "description",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            Price = 0,
            TaxCategory = TaxCategory.DigitalProducts,
        };

        string expectedID = "id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedDescription = "description";
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "name";
        int expectedPrice = 0;
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedImageID, parameters.ImageID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPrice, parameters.Price);
        Assert.Equal(expectedTaxCategory, parameters.TaxCategory);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddonUpdateParams { ID = "id" };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ImageID);
        Assert.False(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Price);
        Assert.False(parameters.RawBodyData.ContainsKey("price"));
        Assert.Null(parameters.TaxCategory);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_category"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AddonUpdateParams
        {
            ID = "id",

            Currency = null,
            Description = null,
            ImageID = null,
            Name = null,
            Price = null,
            TaxCategory = null,
        };

        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ImageID);
        Assert.True(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Price);
        Assert.True(parameters.RawBodyData.ContainsKey("price"));
        Assert.Null(parameters.TaxCategory);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_category"));
    }

    [Fact]
    public void Url_Works()
    {
        AddonUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/addons/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonUpdateParams
        {
            ID = "id",
            Currency = Currency.Aed,
            Description = "description",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            Price = 0,
            TaxCategory = TaxCategory.DigitalProducts,
        };

        AddonUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
