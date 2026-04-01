using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class DunningRecoveredWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DunningRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningRecoveredWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = TriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DunningRecoveredWebhookEventType.DunningRecovered,
        };

        string expectedBusinessID = "business_id";
        DunningRecoveredWebhookEventData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DunningRecoveredWebhookEventType> expectedType =
            DunningRecoveredWebhookEventType.DunningRecovered;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DunningRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningRecoveredWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = TriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DunningRecoveredWebhookEventType.DunningRecovered,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningRecoveredWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DunningRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningRecoveredWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = TriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DunningRecoveredWebhookEventType.DunningRecovered,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningRecoveredWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        DunningRecoveredWebhookEventData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DunningRecoveredWebhookEventType> expectedType =
            DunningRecoveredWebhookEventType.DunningRecovered;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DunningRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningRecoveredWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = TriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DunningRecoveredWebhookEventType.DunningRecovered,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DunningRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningRecoveredWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = TriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DunningRecoveredWebhookEventType.DunningRecovered,
        };

        DunningRecoveredWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DunningRecoveredWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        ApiEnum<string, DunningRecoveredWebhookEventDataStatus> expectedStatus =
            DunningRecoveredWebhookEventDataStatus.Recovering;
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, TriggerState> expectedTriggerState = TriggerState.OnHold;
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
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningRecoveredWebhookEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningRecoveredWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        ApiEnum<string, DunningRecoveredWebhookEventDataStatus> expectedStatus =
            DunningRecoveredWebhookEventDataStatus.Recovering;
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, TriggerState> expectedTriggerState = TriggerState.OnHold;
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
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
        };

        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,

            PaymentID = null,
        };

        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,

            PaymentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DunningRecoveredWebhookEventData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningRecoveredWebhookEventDataStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        DunningRecoveredWebhookEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DunningRecoveredWebhookEventDataStatusTest : TestBase
{
    [Theory]
    [InlineData(DunningRecoveredWebhookEventDataStatus.Recovering)]
    [InlineData(DunningRecoveredWebhookEventDataStatus.Recovered)]
    [InlineData(DunningRecoveredWebhookEventDataStatus.Exhausted)]
    public void Validation_Works(DunningRecoveredWebhookEventDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningRecoveredWebhookEventDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DunningRecoveredWebhookEventDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DunningRecoveredWebhookEventDataStatus.Recovering)]
    [InlineData(DunningRecoveredWebhookEventDataStatus.Recovered)]
    [InlineData(DunningRecoveredWebhookEventDataStatus.Exhausted)]
    public void SerializationRoundtrip_Works(DunningRecoveredWebhookEventDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningRecoveredWebhookEventDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DunningRecoveredWebhookEventDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DunningRecoveredWebhookEventDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DunningRecoveredWebhookEventDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TriggerStateTest : TestBase
{
    [Theory]
    [InlineData(TriggerState.OnHold)]
    [InlineData(TriggerState.Cancelled)]
    public void Validation_Works(TriggerState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TriggerState.OnHold)]
    [InlineData(TriggerState.Cancelled)]
    public void SerializationRoundtrip_Works(TriggerState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DunningRecoveredWebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(DunningRecoveredWebhookEventType.DunningRecovered)]
    public void Validation_Works(DunningRecoveredWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningRecoveredWebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DunningRecoveredWebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DunningRecoveredWebhookEventType.DunningRecovered)]
    public void SerializationRoundtrip_Works(DunningRecoveredWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningRecoveredWebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DunningRecoveredWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DunningRecoveredWebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DunningRecoveredWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
