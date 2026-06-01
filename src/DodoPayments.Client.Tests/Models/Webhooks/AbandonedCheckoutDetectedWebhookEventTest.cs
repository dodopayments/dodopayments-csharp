using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class AbandonedCheckoutDetectedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBusinessID = "business_id";
        Data expectedData = new()
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("abandoned_checkout.detected");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AbandonedCheckoutDetectedWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AbandonedCheckoutDetectedWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        Data expectedData = new()
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("abandoned_checkout.detected");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        AbandonedCheckoutDetectedWebhookEvent copied = new(model);

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
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        DateTimeOffset expectedAbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AbandonmentReason> expectedAbandonmentReason =
            AbandonmentReason.PaymentFailed;
        string expectedCustomerID = "customer_id";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, Status> expectedStatus = Status.Abandoned;
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
        var model = new Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
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
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AbandonmentReason> expectedAbandonmentReason =
            AbandonmentReason.PaymentFailed;
        string expectedCustomerID = "customer_id";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, Status> expectedStatus = Status.Abandoned;
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
        var model = new Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
        };

        Assert.Null(model.RecoveredPaymentID);
        Assert.False(model.RawData.ContainsKey("recovered_payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,

            RecoveredPaymentID = null,
        };

        Assert.Null(model.RecoveredPaymentID);
        Assert.True(model.RawData.ContainsKey("recovered_payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,

            RecoveredPaymentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AbandonmentReasonTest : TestBase
{
    [Theory]
    [InlineData(AbandonmentReason.PaymentFailed)]
    [InlineData(AbandonmentReason.CheckoutIncomplete)]
    public void Validation_Works(AbandonmentReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonmentReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AbandonmentReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AbandonmentReason.PaymentFailed)]
    [InlineData(AbandonmentReason.CheckoutIncomplete)]
    public void SerializationRoundtrip_Works(AbandonmentReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonmentReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AbandonmentReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AbandonmentReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AbandonmentReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Abandoned)]
    [InlineData(Status.Recovering)]
    [InlineData(Status.Recovered)]
    [InlineData(Status.Exhausted)]
    [InlineData(Status.OptedOut)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Abandoned)]
    [InlineData(Status.Recovering)]
    [InlineData(Status.Recovered)]
    [InlineData(Status.Exhausted)]
    [InlineData(Status.OptedOut)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
