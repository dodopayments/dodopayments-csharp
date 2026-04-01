using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Webhooks = DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class AbandonedCheckoutDetectedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Webhooks::Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Webhooks::Type.AbandonedCheckoutDetected,
        };

        string expectedBusinessID = "business_id";
        Webhooks::Data expectedData = new()
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Webhooks::Type> expectedType = Webhooks::Type.AbandonedCheckoutDetected;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Webhooks::Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Webhooks::Type.AbandonedCheckoutDetected,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Webhooks::AbandonedCheckoutDetectedWebhookEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Webhooks::Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Webhooks::Type.AbandonedCheckoutDetected,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Webhooks::AbandonedCheckoutDetectedWebhookEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        Webhooks::Data expectedData = new()
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Webhooks::Type> expectedType = Webhooks::Type.AbandonedCheckoutDetected;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhooks::AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Webhooks::Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Webhooks::Type.AbandonedCheckoutDetected,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::AbandonedCheckoutDetectedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = Webhooks::Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Webhooks::Type.AbandonedCheckoutDetected,
        };

        Webhooks::AbandonedCheckoutDetectedWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        DateTimeOffset expectedAbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Webhooks::AbandonmentReason> expectedAbandonmentReason =
            Webhooks::AbandonmentReason.PaymentFailed;
        string expectedCustomerID = "customer_id";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, Webhooks::Status> expectedStatus = Webhooks::Status.Abandoned;
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
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Data>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Data>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Webhooks::AbandonmentReason> expectedAbandonmentReason =
            Webhooks::AbandonmentReason.PaymentFailed;
        string expectedCustomerID = "customer_id";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, Webhooks::Status> expectedStatus = Webhooks::Status.Abandoned;
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
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
        };

        Assert.Null(model.RecoveredPaymentID);
        Assert.False(model.RawData.ContainsKey("recovered_payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,

            RecoveredPaymentID = null,
        };

        Assert.Null(model.RecoveredPaymentID);
        Assert.True(model.RawData.ContainsKey("recovered_payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,

            RecoveredPaymentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::Data
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = Webhooks::AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Webhooks::Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        Webhooks::Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AbandonmentReasonTest : TestBase
{
    [Theory]
    [InlineData(Webhooks::AbandonmentReason.PaymentFailed)]
    [InlineData(Webhooks::AbandonmentReason.CheckoutIncomplete)]
    public void Validation_Works(Webhooks::AbandonmentReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::AbandonmentReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::AbandonmentReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Webhooks::AbandonmentReason.PaymentFailed)]
    [InlineData(Webhooks::AbandonmentReason.CheckoutIncomplete)]
    public void SerializationRoundtrip_Works(Webhooks::AbandonmentReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::AbandonmentReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::AbandonmentReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::AbandonmentReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::AbandonmentReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Webhooks::Status.Abandoned)]
    [InlineData(Webhooks::Status.Recovering)]
    [InlineData(Webhooks::Status.Recovered)]
    [InlineData(Webhooks::Status.Exhausted)]
    [InlineData(Webhooks::Status.OptedOut)]
    public void Validation_Works(Webhooks::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Webhooks::Status.Abandoned)]
    [InlineData(Webhooks::Status.Recovering)]
    [InlineData(Webhooks::Status.Recovered)]
    [InlineData(Webhooks::Status.Exhausted)]
    [InlineData(Webhooks::Status.OptedOut)]
    public void SerializationRoundtrip_Works(Webhooks::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Webhooks::Type.AbandonedCheckoutDetected)]
    public void Validation_Works(Webhooks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Webhooks::Type.AbandonedCheckoutDetected)]
    public void SerializationRoundtrip_Works(Webhooks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
