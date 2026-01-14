using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class OnDemandSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnDemandSubscription
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };

        bool expectedMandateOnly = true;
        bool expectedAdaptiveCurrencyFeesInclusive = true;
        ApiEnum<string, Currency> expectedProductCurrency = Currency.Aed;
        string expectedProductDescription = "product_description";
        int expectedProductPrice = 0;

        Assert.Equal(expectedMandateOnly, model.MandateOnly);
        Assert.Equal(expectedAdaptiveCurrencyFeesInclusive, model.AdaptiveCurrencyFeesInclusive);
        Assert.Equal(expectedProductCurrency, model.ProductCurrency);
        Assert.Equal(expectedProductDescription, model.ProductDescription);
        Assert.Equal(expectedProductPrice, model.ProductPrice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OnDemandSubscription
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnDemandSubscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OnDemandSubscription
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnDemandSubscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedMandateOnly = true;
        bool expectedAdaptiveCurrencyFeesInclusive = true;
        ApiEnum<string, Currency> expectedProductCurrency = Currency.Aed;
        string expectedProductDescription = "product_description";
        int expectedProductPrice = 0;

        Assert.Equal(expectedMandateOnly, deserialized.MandateOnly);
        Assert.Equal(
            expectedAdaptiveCurrencyFeesInclusive,
            deserialized.AdaptiveCurrencyFeesInclusive
        );
        Assert.Equal(expectedProductCurrency, deserialized.ProductCurrency);
        Assert.Equal(expectedProductDescription, deserialized.ProductDescription);
        Assert.Equal(expectedProductPrice, deserialized.ProductPrice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OnDemandSubscription
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OnDemandSubscription { MandateOnly = true };

        Assert.Null(model.AdaptiveCurrencyFeesInclusive);
        Assert.False(model.RawData.ContainsKey("adaptive_currency_fees_inclusive"));
        Assert.Null(model.ProductCurrency);
        Assert.False(model.RawData.ContainsKey("product_currency"));
        Assert.Null(model.ProductDescription);
        Assert.False(model.RawData.ContainsKey("product_description"));
        Assert.Null(model.ProductPrice);
        Assert.False(model.RawData.ContainsKey("product_price"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new OnDemandSubscription { MandateOnly = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OnDemandSubscription
        {
            MandateOnly = true,

            AdaptiveCurrencyFeesInclusive = null,
            ProductCurrency = null,
            ProductDescription = null,
            ProductPrice = null,
        };

        Assert.Null(model.AdaptiveCurrencyFeesInclusive);
        Assert.True(model.RawData.ContainsKey("adaptive_currency_fees_inclusive"));
        Assert.Null(model.ProductCurrency);
        Assert.True(model.RawData.ContainsKey("product_currency"));
        Assert.Null(model.ProductDescription);
        Assert.True(model.RawData.ContainsKey("product_description"));
        Assert.Null(model.ProductPrice);
        Assert.True(model.RawData.ContainsKey("product_price"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OnDemandSubscription
        {
            MandateOnly = true,

            AdaptiveCurrencyFeesInclusive = null,
            ProductCurrency = null,
            ProductDescription = null,
            ProductPrice = null,
        };

        model.Validate();
    }
}
