using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionChargeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionChargeParams
        {
            SubscriptionID = "subscription_id",
            ProductPrice = 0,
            AdaptiveCurrencyFeesInclusive = true,
            CustomerBalanceConfig = new()
            {
                AllowCustomerCreditsPurchase = true,
                AllowCustomerCreditsUsage = true,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
        };

        string expectedSubscriptionID = "subscription_id";
        int expectedProductPrice = 0;
        bool expectedAdaptiveCurrencyFeesInclusive = true;
        CustomerBalanceConfig expectedCustomerBalanceConfig = new()
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Currency> expectedProductCurrency = Currency.Aed;
        string expectedProductDescription = "product_description";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedProductPrice, parameters.ProductPrice);
        Assert.Equal(
            expectedAdaptiveCurrencyFeesInclusive,
            parameters.AdaptiveCurrencyFeesInclusive
        );
        Assert.Equal(expectedCustomerBalanceConfig, parameters.CustomerBalanceConfig);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedProductCurrency, parameters.ProductCurrency);
        Assert.Equal(expectedProductDescription, parameters.ProductDescription);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionChargeParams
        {
            SubscriptionID = "subscription_id",
            ProductPrice = 0,
        };

        Assert.Null(parameters.AdaptiveCurrencyFeesInclusive);
        Assert.False(parameters.RawBodyData.ContainsKey("adaptive_currency_fees_inclusive"));
        Assert.Null(parameters.CustomerBalanceConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_balance_config"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ProductCurrency);
        Assert.False(parameters.RawBodyData.ContainsKey("product_currency"));
        Assert.Null(parameters.ProductDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("product_description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionChargeParams
        {
            SubscriptionID = "subscription_id",
            ProductPrice = 0,

            AdaptiveCurrencyFeesInclusive = null,
            CustomerBalanceConfig = null,
            Metadata = null,
            ProductCurrency = null,
            ProductDescription = null,
        };

        Assert.Null(parameters.AdaptiveCurrencyFeesInclusive);
        Assert.True(parameters.RawBodyData.ContainsKey("adaptive_currency_fees_inclusive"));
        Assert.Null(parameters.CustomerBalanceConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_balance_config"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ProductCurrency);
        Assert.True(parameters.RawBodyData.ContainsKey("product_currency"));
        Assert.Null(parameters.ProductDescription);
        Assert.True(parameters.RawBodyData.ContainsKey("product_description"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionChargeParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            ProductPrice = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri("https://live.dodopayments.com/subscriptions/subscription_id/charge"),
            url
        );
    }
}

public class CustomerBalanceConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        bool expectedAllowCustomerCreditsPurchase = true;
        bool expectedAllowCustomerCreditsUsage = true;

        Assert.Equal(expectedAllowCustomerCreditsPurchase, model.AllowCustomerCreditsPurchase);
        Assert.Equal(expectedAllowCustomerCreditsUsage, model.AllowCustomerCreditsUsage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerBalanceConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerBalanceConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAllowCustomerCreditsPurchase = true;
        bool expectedAllowCustomerCreditsUsage = true;

        Assert.Equal(
            expectedAllowCustomerCreditsPurchase,
            deserialized.AllowCustomerCreditsPurchase
        );
        Assert.Equal(expectedAllowCustomerCreditsUsage, deserialized.AllowCustomerCreditsUsage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerBalanceConfig { };

        Assert.Null(model.AllowCustomerCreditsPurchase);
        Assert.False(model.RawData.ContainsKey("allow_customer_credits_purchase"));
        Assert.Null(model.AllowCustomerCreditsUsage);
        Assert.False(model.RawData.ContainsKey("allow_customer_credits_usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerBalanceConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = null,
            AllowCustomerCreditsUsage = null,
        };

        Assert.Null(model.AllowCustomerCreditsPurchase);
        Assert.True(model.RawData.ContainsKey("allow_customer_credits_purchase"));
        Assert.Null(model.AllowCustomerCreditsUsage);
        Assert.True(model.RawData.ContainsKey("allow_customer_credits_usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = null,
            AllowCustomerCreditsUsage = null,
        };

        model.Validate();
    }
}
