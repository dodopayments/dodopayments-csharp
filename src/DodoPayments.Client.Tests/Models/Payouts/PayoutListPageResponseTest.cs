using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Tests.Models.Payouts;

public class PayoutListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayoutListPageResponse
        {
            Items =
            [
                new()
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
                    Status = Status.NotInitiated,
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PayoutDocumentURL = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
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
                Status = Status.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentURL = "payout_document_url",
                Remarks = "remarks",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PayoutListPageResponse
        {
            Items =
            [
                new()
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
                    Status = Status.NotInitiated,
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PayoutDocumentURL = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PayoutListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PayoutListPageResponse
        {
            Items =
            [
                new()
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
                    Status = Status.NotInitiated,
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PayoutDocumentURL = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PayoutListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
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
                Status = Status.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentURL = "payout_document_url",
                Remarks = "remarks",
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PayoutListPageResponse
        {
            Items =
            [
                new()
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
                    Status = Status.NotInitiated,
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PayoutDocumentURL = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        model.Validate();
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
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
            Status = Status.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentURL = "payout_document_url",
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
        ApiEnum<string, Status> expectedStatus = Status.NotInitiated;
        long expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedPayoutDocumentURL = "payout_document_url";
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
        Assert.Equal(expectedPayoutDocumentURL, model.PayoutDocumentURL);
        Assert.Equal(expectedRemarks, model.Remarks);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
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
            Status = Status.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentURL = "payout_document_url",
            Remarks = "remarks",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
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
            Status = Status.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentURL = "payout_document_url",
            Remarks = "remarks",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(element);
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
        ApiEnum<string, Status> expectedStatus = Status.NotInitiated;
        long expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedPayoutDocumentURL = "payout_document_url";
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
        Assert.Equal(expectedPayoutDocumentURL, deserialized.PayoutDocumentURL);
        Assert.Equal(expectedRemarks, deserialized.Remarks);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
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
            Status = Status.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PayoutDocumentURL = "payout_document_url",
            Remarks = "remarks",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
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
            Status = Status.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PayoutDocumentURL);
        Assert.False(model.RawData.ContainsKey("payout_document_url"));
        Assert.Null(model.Remarks);
        Assert.False(model.RawData.ContainsKey("remarks"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
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
            Status = Status.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
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
            Status = Status.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Name = null,
            PayoutDocumentURL = null,
            Remarks = null,
        };

        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.PayoutDocumentURL);
        Assert.True(model.RawData.ContainsKey("payout_document_url"));
        Assert.Null(model.Remarks);
        Assert.True(model.RawData.ContainsKey("remarks"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
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
            Status = Status.NotInitiated,
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Name = null,
            PayoutDocumentURL = null,
            Remarks = null,
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.NotInitiated)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.OnHold)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Success)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.NotInitiated)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.OnHold)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Success)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
