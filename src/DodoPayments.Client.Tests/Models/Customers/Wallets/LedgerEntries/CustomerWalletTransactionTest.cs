using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Customers.Wallets.LedgerEntries;

public class CustomerWalletTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,
            Reason = "reason",
            ReferenceObjectID = "reference_object_id",
        };

        string expectedID = "id";
        long expectedAfterBalance = 0;
        long expectedAmount = 0;
        long expectedBeforeBalance = 0;
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedCustomerID = "customer_id";
        ApiEnum<string, EventType> expectedEventType = EventType.Payment;
        bool expectedIsCredit = true;
        string expectedReason = "reason";
        string expectedReferenceObjectID = "reference_object_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAfterBalance, model.AfterBalance);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBeforeBalance, model.BeforeBalance);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedIsCredit, model.IsCredit);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReferenceObjectID, model.ReferenceObjectID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,
            Reason = "reason",
            ReferenceObjectID = "reference_object_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerWalletTransaction>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,
            Reason = "reason",
            ReferenceObjectID = "reference_object_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerWalletTransaction>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAfterBalance = 0;
        long expectedAmount = 0;
        long expectedBeforeBalance = 0;
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedCustomerID = "customer_id";
        ApiEnum<string, EventType> expectedEventType = EventType.Payment;
        bool expectedIsCredit = true;
        string expectedReason = "reason";
        string expectedReferenceObjectID = "reference_object_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAfterBalance, deserialized.AfterBalance);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBeforeBalance, deserialized.BeforeBalance);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedIsCredit, deserialized.IsCredit);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReferenceObjectID, deserialized.ReferenceObjectID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,
            Reason = "reason",
            ReferenceObjectID = "reference_object_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReferenceObjectID);
        Assert.False(model.RawData.ContainsKey("reference_object_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,

            Reason = null,
            ReferenceObjectID = null,
        };

        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReferenceObjectID);
        Assert.True(model.RawData.ContainsKey("reference_object_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,

            Reason = null,
            ReferenceObjectID = null,
        };

        model.Validate();
    }
}

public class EventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventType.Payment)]
    [InlineData(EventType.PaymentReversal)]
    [InlineData(EventType.Refund)]
    [InlineData(EventType.RefundReversal)]
    [InlineData(EventType.Dispute)]
    [InlineData(EventType.DisputeReversal)]
    [InlineData(EventType.MerchantAdjustment)]
    public void Validation_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventType.Payment)]
    [InlineData(EventType.PaymentReversal)]
    [InlineData(EventType.Refund)]
    [InlineData(EventType.RefundReversal)]
    [InlineData(EventType.Dispute)]
    [InlineData(EventType.DisputeReversal)]
    [InlineData(EventType.MerchantAdjustment)]
    public void SerializationRoundtrip_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
