using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class SubscriptionDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        OnDemandSubscription expectedOnDemand = new()
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };
        int expectedTrialPeriodDays = 0;

        Assert.Equal(expectedOnDemand, model.OnDemand);
        Assert.Equal(expectedTrialPeriodDays, model.TrialPeriodDays);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        OnDemandSubscription expectedOnDemand = new()
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };
        int expectedTrialPeriodDays = 0;

        Assert.Equal(expectedOnDemand, deserialized.OnDemand);
        Assert.Equal(expectedTrialPeriodDays, deserialized.TrialPeriodDays);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionData { };

        Assert.Null(model.OnDemand);
        Assert.False(model.RawData.ContainsKey("on_demand"));
        Assert.Null(model.TrialPeriodDays);
        Assert.False(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionData { OnDemand = null, TrialPeriodDays = null };

        Assert.Null(model.OnDemand);
        Assert.True(model.RawData.ContainsKey("on_demand"));
        Assert.Null(model.TrialPeriodDays);
        Assert.True(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionData { OnDemand = null, TrialPeriodDays = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        SubscriptionData copied = new(model);

        Assert.Equal(model, copied);
    }
}
