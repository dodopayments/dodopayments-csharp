using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class PayoutInProgressWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayoutInProgressWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Chargebacks = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Fee = 0,
                PaymentMethod = "payment_method",
                PayoutID = "payout_id",
                Refunds = 0,
                Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentUrl = "payout_document_url",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBusinessID = "business_id";
        PayoutInProgressWebhookEventData expectedData = new()
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentUrl = "payout_document_url",
            Remarks = "remarks",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("payout.in_progress");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PayoutInProgressWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Chargebacks = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Fee = 0,
                PaymentMethod = "payment_method",
                PayoutID = "payout_id",
                Refunds = 0,
                Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentUrl = "payout_document_url",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayoutInProgressWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PayoutInProgressWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Chargebacks = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Fee = 0,
                PaymentMethod = "payment_method",
                PayoutID = "payout_id",
                Refunds = 0,
                Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentUrl = "payout_document_url",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayoutInProgressWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        PayoutInProgressWebhookEventData expectedData = new()
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentUrl = "payout_document_url",
            Remarks = "remarks",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("payout.in_progress");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PayoutInProgressWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Chargebacks = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Fee = 0,
                PaymentMethod = "payment_method",
                PayoutID = "payout_id",
                Refunds = 0,
                Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentUrl = "payout_document_url",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PayoutInProgressWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Chargebacks = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Fee = 0,
                PaymentMethod = "payment_method",
                PayoutID = "payout_id",
                Refunds = 0,
                Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentUrl = "payout_document_url",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        PayoutInProgressWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PayoutInProgressWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentUrl = "payout_document_url",
            Remarks = "remarks",
        };

        long expectedAmount = 0;
        string expectedBusinessID = "business_id";
        long expectedChargebacks = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFee = 0;
        string expectedPaymentMethod = "payment_method";
        string expectedPayoutID = "payout_id";
        long expectedRefunds = 0;
        ApiEnum<string, PayoutInProgressWebhookEventDataStatus> expectedStatus =
            PayoutInProgressWebhookEventDataStatus.NotInitiated;
        long expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedPayoutDocumentUrl = "payout_document_url";
        string expectedRemarks = "remarks";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedChargebacks, model.Chargebacks);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFee, model.Fee);
        Assert.Equal(expectedPaymentMethod, model.PaymentMethod);
        Assert.Equal(expectedPayoutID, model.PayoutID);
        Assert.Equal(expectedRefunds, model.Refunds);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPayoutDocumentUrl, model.PayoutDocumentUrl);
        Assert.Equal(expectedRemarks, model.Remarks);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentUrl = "payout_document_url",
            Remarks = "remarks",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayoutInProgressWebhookEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentUrl = "payout_document_url",
            Remarks = "remarks",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayoutInProgressWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedBusinessID = "business_id";
        long expectedChargebacks = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFee = 0;
        string expectedPaymentMethod = "payment_method";
        string expectedPayoutID = "payout_id";
        long expectedRefunds = 0;
        ApiEnum<string, PayoutInProgressWebhookEventDataStatus> expectedStatus =
            PayoutInProgressWebhookEventDataStatus.NotInitiated;
        long expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedPayoutDocumentUrl = "payout_document_url";
        string expectedRemarks = "remarks";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedChargebacks, deserialized.Chargebacks);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFee, deserialized.Fee);
        Assert.Equal(expectedPaymentMethod, deserialized.PaymentMethod);
        Assert.Equal(expectedPayoutID, deserialized.PayoutID);
        Assert.Equal(expectedRefunds, deserialized.Refunds);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPayoutDocumentUrl, deserialized.PayoutDocumentUrl);
        Assert.Equal(expectedRemarks, deserialized.Remarks);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentUrl = "payout_document_url",
            Remarks = "remarks",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PayoutDocumentUrl);
        Assert.False(model.RawData.ContainsKey("payout_document_url"));
        Assert.Null(model.Remarks);
        Assert.False(model.RawData.ContainsKey("remarks"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Name = null,
            PayoutDocumentUrl = null,
            Remarks = null,
        };

        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.PayoutDocumentUrl);
        Assert.True(model.RawData.ContainsKey("payout_document_url"));
        Assert.Null(model.Remarks);
        Assert.True(model.RawData.ContainsKey("remarks"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Name = null,
            PayoutDocumentUrl = null,
            Remarks = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PayoutInProgressWebhookEventData
        {
            Amount = 0,
            BusinessID = "business_id",
            Chargebacks = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Fee = 0,
            PaymentMethod = "payment_method",
            PayoutID = "payout_id",
            Refunds = 0,
            Status = PayoutInProgressWebhookEventDataStatus.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentUrl = "payout_document_url",
            Remarks = "remarks",
        };

        PayoutInProgressWebhookEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PayoutInProgressWebhookEventDataStatusTest : TestBase
{
    [Theory]
    [InlineData(PayoutInProgressWebhookEventDataStatus.NotInitiated)]
    [InlineData(PayoutInProgressWebhookEventDataStatus.InProgress)]
    [InlineData(PayoutInProgressWebhookEventDataStatus.OnHold)]
    [InlineData(PayoutInProgressWebhookEventDataStatus.Failed)]
    [InlineData(PayoutInProgressWebhookEventDataStatus.Success)]
    public void Validation_Works(PayoutInProgressWebhookEventDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PayoutInProgressWebhookEventDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PayoutInProgressWebhookEventDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PayoutInProgressWebhookEventDataStatus.NotInitiated)]
    [InlineData(PayoutInProgressWebhookEventDataStatus.InProgress)]
    [InlineData(PayoutInProgressWebhookEventDataStatus.OnHold)]
    [InlineData(PayoutInProgressWebhookEventDataStatus.Failed)]
    [InlineData(PayoutInProgressWebhookEventDataStatus.Success)]
    public void SerializationRoundtrip_Works(PayoutInProgressWebhookEventDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PayoutInProgressWebhookEventDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PayoutInProgressWebhookEventDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PayoutInProgressWebhookEventDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PayoutInProgressWebhookEventDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
