using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class CreditBalanceLowWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditBalanceLowWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                BrandID = "brand_id",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBusinessID = "business_id";
        CreditBalanceLowWebhookEventData expectedData = new()
        {
            AvailableBalance = "available_balance",
            BrandID = "brand_id",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("credit.balance_low");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditBalanceLowWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                BrandID = "brand_id",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBalanceLowWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditBalanceLowWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                BrandID = "brand_id",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBalanceLowWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        CreditBalanceLowWebhookEventData expectedData = new()
        {
            AvailableBalance = "available_balance",
            BrandID = "brand_id",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("credit.balance_low");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditBalanceLowWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                BrandID = "brand_id",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditBalanceLowWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                BrandID = "brand_id",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreditBalanceLowWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditBalanceLowWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditBalanceLowWebhookEventData
        {
            AvailableBalance = "available_balance",
            BrandID = "brand_id",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string expectedAvailableBalance = "available_balance";
        string expectedBrandID = "brand_id";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCustomerID = "customer_id";
        string expectedSubscriptionCreditsAmount = "subscription_credits_amount";
        string expectedSubscriptionID = "subscription_id";
        string expectedThresholdAmount = "threshold_amount";
        int expectedThresholdPercent = 0;

        Assert.Equal(expectedAvailableBalance, model.AvailableBalance);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, model.CreditEntitlementName);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedSubscriptionCreditsAmount, model.SubscriptionCreditsAmount);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedThresholdAmount, model.ThresholdAmount);
        Assert.Equal(expectedThresholdPercent, model.ThresholdPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditBalanceLowWebhookEventData
        {
            AvailableBalance = "available_balance",
            BrandID = "brand_id",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBalanceLowWebhookEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditBalanceLowWebhookEventData
        {
            AvailableBalance = "available_balance",
            BrandID = "brand_id",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBalanceLowWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAvailableBalance = "available_balance";
        string expectedBrandID = "brand_id";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCustomerID = "customer_id";
        string expectedSubscriptionCreditsAmount = "subscription_credits_amount";
        string expectedSubscriptionID = "subscription_id";
        string expectedThresholdAmount = "threshold_amount";
        int expectedThresholdPercent = 0;

        Assert.Equal(expectedAvailableBalance, deserialized.AvailableBalance);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, deserialized.CreditEntitlementName);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedSubscriptionCreditsAmount, deserialized.SubscriptionCreditsAmount);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedThresholdAmount, deserialized.ThresholdAmount);
        Assert.Equal(expectedThresholdPercent, deserialized.ThresholdPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditBalanceLowWebhookEventData
        {
            AvailableBalance = "available_balance",
            BrandID = "brand_id",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditBalanceLowWebhookEventData
        {
            AvailableBalance = "available_balance",
            BrandID = "brand_id",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        CreditBalanceLowWebhookEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
