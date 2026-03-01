using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
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
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditBalanceLowWebhookEventType.CreditBalanceLow,
        };

        string expectedBusinessID = "business_id";
        Data expectedData = new()
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CreditBalanceLowWebhookEventType> expectedType =
            CreditBalanceLowWebhookEventType.CreditBalanceLow;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
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
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditBalanceLowWebhookEventType.CreditBalanceLow,
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
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditBalanceLowWebhookEventType.CreditBalanceLow,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBalanceLowWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        Data expectedData = new()
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CreditBalanceLowWebhookEventType> expectedType =
            CreditBalanceLowWebhookEventType.CreditBalanceLow;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
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
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditBalanceLowWebhookEventType.CreditBalanceLow,
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
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditBalanceLowWebhookEventType.CreditBalanceLow,
        };

        CreditBalanceLowWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string expectedAvailableBalance = "available_balance";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCustomerID = "customer_id";
        string expectedSubscriptionCreditsAmount = "subscription_credits_amount";
        string expectedSubscriptionID = "subscription_id";
        string expectedThresholdAmount = "threshold_amount";
        int expectedThresholdPercent = 0;

        Assert.Equal(expectedAvailableBalance, model.AvailableBalance);
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
        var model = new Data
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAvailableBalance = "available_balance";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCustomerID = "customer_id";
        string expectedSubscriptionCreditsAmount = "subscription_credits_amount";
        string expectedSubscriptionID = "subscription_id";
        string expectedThresholdAmount = "threshold_amount";
        int expectedThresholdPercent = 0;

        Assert.Equal(expectedAvailableBalance, deserialized.AvailableBalance);
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
        var model = new Data
        {
            AvailableBalance = "available_balance",
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
        var model = new Data
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditBalanceLowWebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(CreditBalanceLowWebhookEventType.CreditBalanceLow)]
    public void Validation_Works(CreditBalanceLowWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditBalanceLowWebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditBalanceLowWebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditBalanceLowWebhookEventType.CreditBalanceLow)]
    public void SerializationRoundtrip_Works(CreditBalanceLowWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditBalanceLowWebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditBalanceLowWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditBalanceLowWebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditBalanceLowWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
