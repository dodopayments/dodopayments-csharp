using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class DisputeExpiredWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeExpiredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
                PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeExpiredWebhookEventType.DisputeExpired,
        };

        string expectedBusinessID = "business_id";
        DisputeExpiredWebhookEventData expectedData = new()
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DisputeExpiredWebhookEventType> expectedType =
            DisputeExpiredWebhookEventType.DisputeExpired;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DisputeExpiredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
                PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeExpiredWebhookEventType.DisputeExpired,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DisputeExpiredWebhookEvent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DisputeExpiredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
                PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeExpiredWebhookEventType.DisputeExpired,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DisputeExpiredWebhookEvent>(element);
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        DisputeExpiredWebhookEventData expectedData = new()
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DisputeExpiredWebhookEventType> expectedType =
            DisputeExpiredWebhookEventType.DisputeExpired;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DisputeExpiredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
                PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeExpiredWebhookEventType.DisputeExpired,
        };

        model.Validate();
    }
}

public class DisputeExpiredWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        string expectedAmount = "amount";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedDisputeID = "dispute_id";
        ApiEnum<string, DisputeDisputeStage> expectedDisputeStage = DisputeDisputeStage.PreDispute;
        ApiEnum<string, DisputeDisputeStatus> expectedDisputeStatus =
            DisputeDisputeStatus.DisputeOpened;
        string expectedPaymentID = "payment_id";
        string expectedRemarks = "remarks";
        ApiEnum<
            string,
            DisputeExpiredWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDisputeID, model.DisputeID);
        Assert.Equal(expectedDisputeStage, model.DisputeStage);
        Assert.Equal(expectedDisputeStatus, model.DisputeStatus);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRemarks, model.Remarks);
        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DisputeExpiredWebhookEventData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DisputeExpiredWebhookEventData>(element);
        Assert.NotNull(deserialized);

        string expectedAmount = "amount";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedDisputeID = "dispute_id";
        ApiEnum<string, DisputeDisputeStage> expectedDisputeStage = DisputeDisputeStage.PreDispute;
        ApiEnum<string, DisputeDisputeStatus> expectedDisputeStatus =
            DisputeDisputeStatus.DisputeOpened;
        string expectedPaymentID = "payment_id";
        string expectedRemarks = "remarks";
        ApiEnum<
            string,
            DisputeExpiredWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDisputeID, deserialized.DisputeID);
        Assert.Equal(expectedDisputeStage, deserialized.DisputeStage);
        Assert.Equal(expectedDisputeStatus, deserialized.DisputeStatus);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRemarks, deserialized.Remarks);
        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
        };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",

            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",

            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        Assert.Null(model.Remarks);
        Assert.False(model.RawData.ContainsKey("remarks"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,

            Remarks = null,
        };

        Assert.Null(model.Remarks);
        Assert.True(model.RawData.ContainsKey("remarks"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DisputeExpiredWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,

            Remarks = null,
        };

        model.Validate();
    }
}

public class DisputeExpiredWebhookEventDataIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeExpiredWebhookEventDataIntersectionMember1
        {
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        ApiEnum<
            string,
            DisputeExpiredWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DisputeExpiredWebhookEventDataIntersectionMember1
        {
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<DisputeExpiredWebhookEventDataIntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DisputeExpiredWebhookEventDataIntersectionMember1
        {
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<DisputeExpiredWebhookEventDataIntersectionMember1>(element);
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            DisputeExpiredWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DisputeExpiredWebhookEventDataIntersectionMember1
        {
            PayloadType = DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DisputeExpiredWebhookEventDataIntersectionMember1 { };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DisputeExpiredWebhookEventDataIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DisputeExpiredWebhookEventDataIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DisputeExpiredWebhookEventDataIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        model.Validate();
    }
}

public class DisputeExpiredWebhookEventDataIntersectionMember1PayloadTypeTest : TestBase
{
    [Theory]
    [InlineData(DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute)]
    public void Validation_Works(
        DisputeExpiredWebhookEventDataIntersectionMember1PayloadType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeExpiredWebhookEventDataIntersectionMember1PayloadType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeExpiredWebhookEventDataIntersectionMember1PayloadType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute)]
    public void SerializationRoundtrip_Works(
        DisputeExpiredWebhookEventDataIntersectionMember1PayloadType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeExpiredWebhookEventDataIntersectionMember1PayloadType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeExpiredWebhookEventDataIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeExpiredWebhookEventDataIntersectionMember1PayloadType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeExpiredWebhookEventDataIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DisputeExpiredWebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(DisputeExpiredWebhookEventType.DisputeExpired)]
    public void Validation_Works(DisputeExpiredWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeExpiredWebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeExpiredWebhookEventType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeExpiredWebhookEventType.DisputeExpired)]
    public void SerializationRoundtrip_Works(DisputeExpiredWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeExpiredWebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeExpiredWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeExpiredWebhookEventType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeExpiredWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
