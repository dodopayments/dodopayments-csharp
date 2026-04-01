using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class AbandonedCheckoutRecoveredWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason =
                    AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered,
        };

        string expectedBusinessID = "business_id";
        AbandonedCheckoutRecoveredWebhookEventData expectedData = new()
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventType> expectedType =
            AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason =
                    AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AbandonedCheckoutRecoveredWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason =
                    AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AbandonedCheckoutRecoveredWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        AbandonedCheckoutRecoveredWebhookEventData expectedData = new()
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventType> expectedType =
            AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason =
                    AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason =
                    AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered,
        };

        AbandonedCheckoutRecoveredWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AbandonedCheckoutRecoveredWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        DateTimeOffset expectedAbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<
            string,
            AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason
        > expectedAbandonmentReason =
            AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed;
        string expectedCustomerID = "customer_id";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus> expectedStatus =
            AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned;
        string expectedRecoveredPaymentID = "recovered_payment_id";

        Assert.Equal(expectedAbandonedAt, model.AbandonedAt);
        Assert.Equal(expectedAbandonmentReason, model.AbandonmentReason);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedRecoveredPaymentID, model.RecoveredPaymentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AbandonedCheckoutRecoveredWebhookEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AbandonedCheckoutRecoveredWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<
            string,
            AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason
        > expectedAbandonmentReason =
            AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed;
        string expectedCustomerID = "customer_id";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus> expectedStatus =
            AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned;
        string expectedRecoveredPaymentID = "recovered_payment_id";

        Assert.Equal(expectedAbandonedAt, deserialized.AbandonedAt);
        Assert.Equal(expectedAbandonmentReason, deserialized.AbandonmentReason);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedRecoveredPaymentID, deserialized.RecoveredPaymentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
        };

        Assert.Null(model.RecoveredPaymentID);
        Assert.False(model.RawData.ContainsKey("recovered_payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,

            RecoveredPaymentID = null,
        };

        Assert.Null(model.RecoveredPaymentID);
        Assert.True(model.RawData.ContainsKey("recovered_payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,

            RecoveredPaymentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AbandonedCheckoutRecoveredWebhookEventData
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason =
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        AbandonedCheckoutRecoveredWebhookEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReasonTest : TestBase
{
    [Theory]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.CheckoutIncomplete)]
    public void Validation_Works(
        AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.CheckoutIncomplete)]
    public void SerializationRoundtrip_Works(
        AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AbandonedCheckoutRecoveredWebhookEventDataStatusTest : TestBase
{
    [Theory]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.Recovering)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.Recovered)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.Exhausted)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.OptedOut)]
    public void Validation_Works(AbandonedCheckoutRecoveredWebhookEventDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.Recovering)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.Recovered)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.Exhausted)]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventDataStatus.OptedOut)]
    public void SerializationRoundtrip_Works(
        AbandonedCheckoutRecoveredWebhookEventDataStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AbandonedCheckoutRecoveredWebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered)]
    public void Validation_Works(AbandonedCheckoutRecoveredWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AbandonedCheckoutRecoveredWebhookEventType.AbandonedCheckoutRecovered)]
    public void SerializationRoundtrip_Works(AbandonedCheckoutRecoveredWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
