using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class DunningStartedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DunningStartedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningStartedWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBusinessID = "business_id";
        DunningStartedWebhookEventData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
            PaymentID = "payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("dunning.started");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DunningStartedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningStartedWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningStartedWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DunningStartedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningStartedWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningStartedWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        DunningStartedWebhookEventData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
            PaymentID = "payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("dunning.started");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DunningStartedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningStartedWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DunningStartedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningStartedWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DunningStartedWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DunningStartedWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
            PaymentID = "payment_id",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        ApiEnum<string, DunningStartedWebhookEventDataStatus> expectedStatus =
            DunningStartedWebhookEventDataStatus.Recovering;
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, DunningStartedWebhookEventDataTriggerState> expectedTriggerState =
            DunningStartedWebhookEventDataTriggerState.OnHold;
        string expectedPaymentID = "payment_id";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedTriggerState, model.TriggerState);
        Assert.Equal(expectedPaymentID, model.PaymentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
            PaymentID = "payment_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningStartedWebhookEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
            PaymentID = "payment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningStartedWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        ApiEnum<string, DunningStartedWebhookEventDataStatus> expectedStatus =
            DunningStartedWebhookEventDataStatus.Recovering;
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, DunningStartedWebhookEventDataTriggerState> expectedTriggerState =
            DunningStartedWebhookEventDataTriggerState.OnHold;
        string expectedPaymentID = "payment_id";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedTriggerState, deserialized.TriggerState);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
            PaymentID = "payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
        };

        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,

            PaymentID = null,
        };

        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,

            PaymentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DunningStartedWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningStartedWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
            PaymentID = "payment_id",
        };

        DunningStartedWebhookEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DunningStartedWebhookEventDataStatusTest : TestBase
{
    [Theory]
    [InlineData(DunningStartedWebhookEventDataStatus.Recovering)]
    [InlineData(DunningStartedWebhookEventDataStatus.Recovered)]
    [InlineData(DunningStartedWebhookEventDataStatus.Exhausted)]
    public void Validation_Works(DunningStartedWebhookEventDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningStartedWebhookEventDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DunningStartedWebhookEventDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DunningStartedWebhookEventDataStatus.Recovering)]
    [InlineData(DunningStartedWebhookEventDataStatus.Recovered)]
    [InlineData(DunningStartedWebhookEventDataStatus.Exhausted)]
    public void SerializationRoundtrip_Works(DunningStartedWebhookEventDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningStartedWebhookEventDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DunningStartedWebhookEventDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DunningStartedWebhookEventDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DunningStartedWebhookEventDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DunningStartedWebhookEventDataTriggerStateTest : TestBase
{
    [Theory]
    [InlineData(DunningStartedWebhookEventDataTriggerState.OnHold)]
    [InlineData(DunningStartedWebhookEventDataTriggerState.Cancelled)]
    public void Validation_Works(DunningStartedWebhookEventDataTriggerState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningStartedWebhookEventDataTriggerState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DunningStartedWebhookEventDataTriggerState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DunningStartedWebhookEventDataTriggerState.OnHold)]
    [InlineData(DunningStartedWebhookEventDataTriggerState.Cancelled)]
    public void SerializationRoundtrip_Works(DunningStartedWebhookEventDataTriggerState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningStartedWebhookEventDataTriggerState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DunningStartedWebhookEventDataTriggerState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DunningStartedWebhookEventDataTriggerState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DunningStartedWebhookEventDataTriggerState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
