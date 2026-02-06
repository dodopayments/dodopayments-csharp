using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Balances;
using Misc = DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Balances;

public class BalanceLedgerEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,
            AfterBalance = 0,
            BeforeBalance = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        string expectedID = "id";
        long expectedAmount = 0;
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Misc::Currency> expectedCurrency = Misc::Currency.Aed;
        ApiEnum<string, BalanceLedgerEntryEventType> expectedEventType =
            BalanceLedgerEntryEventType.Payment;
        bool expectedIsCredit = true;
        long expectedUsdEquivalentAmount = 0;
        long expectedAfterBalance = 0;
        long expectedBeforeBalance = 0;
        string expectedDescription = "description";
        string expectedReferenceObjectID = "reference_object_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedIsCredit, model.IsCredit);
        Assert.Equal(expectedUsdEquivalentAmount, model.UsdEquivalentAmount);
        Assert.Equal(expectedAfterBalance, model.AfterBalance);
        Assert.Equal(expectedBeforeBalance, model.BeforeBalance);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedReferenceObjectID, model.ReferenceObjectID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,
            AfterBalance = 0,
            BeforeBalance = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceLedgerEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,
            AfterBalance = 0,
            BeforeBalance = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceLedgerEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAmount = 0;
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Misc::Currency> expectedCurrency = Misc::Currency.Aed;
        ApiEnum<string, BalanceLedgerEntryEventType> expectedEventType =
            BalanceLedgerEntryEventType.Payment;
        bool expectedIsCredit = true;
        long expectedUsdEquivalentAmount = 0;
        long expectedAfterBalance = 0;
        long expectedBeforeBalance = 0;
        string expectedDescription = "description";
        string expectedReferenceObjectID = "reference_object_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedIsCredit, deserialized.IsCredit);
        Assert.Equal(expectedUsdEquivalentAmount, deserialized.UsdEquivalentAmount);
        Assert.Equal(expectedAfterBalance, deserialized.AfterBalance);
        Assert.Equal(expectedBeforeBalance, deserialized.BeforeBalance);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedReferenceObjectID, deserialized.ReferenceObjectID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,
            AfterBalance = 0,
            BeforeBalance = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,
        };

        Assert.Null(model.AfterBalance);
        Assert.False(model.RawData.ContainsKey("after_balance"));
        Assert.Null(model.BeforeBalance);
        Assert.False(model.RawData.ContainsKey("before_balance"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ReferenceObjectID);
        Assert.False(model.RawData.ContainsKey("reference_object_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,

            AfterBalance = null,
            BeforeBalance = null,
            Description = null,
            ReferenceObjectID = null,
        };

        Assert.Null(model.AfterBalance);
        Assert.True(model.RawData.ContainsKey("after_balance"));
        Assert.Null(model.BeforeBalance);
        Assert.True(model.RawData.ContainsKey("before_balance"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.ReferenceObjectID);
        Assert.True(model.RawData.ContainsKey("reference_object_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,

            AfterBalance = null,
            BeforeBalance = null,
            Description = null,
            ReferenceObjectID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceLedgerEntry
        {
            ID = "id",
            Amount = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Misc::Currency.Aed,
            EventType = BalanceLedgerEntryEventType.Payment,
            IsCredit = true,
            UsdEquivalentAmount = 0,
            AfterBalance = 0,
            BeforeBalance = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        BalanceLedgerEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BalanceLedgerEntryEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BalanceLedgerEntryEventType.Payment)]
    [InlineData(BalanceLedgerEntryEventType.Refund)]
    [InlineData(BalanceLedgerEntryEventType.RefundReversal)]
    [InlineData(BalanceLedgerEntryEventType.Dispute)]
    [InlineData(BalanceLedgerEntryEventType.DisputeReversal)]
    [InlineData(BalanceLedgerEntryEventType.Tax)]
    [InlineData(BalanceLedgerEntryEventType.TaxReversal)]
    [InlineData(BalanceLedgerEntryEventType.PaymentFees)]
    [InlineData(BalanceLedgerEntryEventType.RefundFees)]
    [InlineData(BalanceLedgerEntryEventType.RefundFeesReversal)]
    [InlineData(BalanceLedgerEntryEventType.DisputeFees)]
    [InlineData(BalanceLedgerEntryEventType.Payout)]
    [InlineData(BalanceLedgerEntryEventType.PayoutFees)]
    [InlineData(BalanceLedgerEntryEventType.PayoutReversal)]
    [InlineData(BalanceLedgerEntryEventType.PayoutFeesReversal)]
    [InlineData(BalanceLedgerEntryEventType.DodoCredits)]
    [InlineData(BalanceLedgerEntryEventType.Adjustment)]
    [InlineData(BalanceLedgerEntryEventType.CurrencyConversion)]
    public void Validation_Works(BalanceLedgerEntryEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceLedgerEntryEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceLedgerEntryEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BalanceLedgerEntryEventType.Payment)]
    [InlineData(BalanceLedgerEntryEventType.Refund)]
    [InlineData(BalanceLedgerEntryEventType.RefundReversal)]
    [InlineData(BalanceLedgerEntryEventType.Dispute)]
    [InlineData(BalanceLedgerEntryEventType.DisputeReversal)]
    [InlineData(BalanceLedgerEntryEventType.Tax)]
    [InlineData(BalanceLedgerEntryEventType.TaxReversal)]
    [InlineData(BalanceLedgerEntryEventType.PaymentFees)]
    [InlineData(BalanceLedgerEntryEventType.RefundFees)]
    [InlineData(BalanceLedgerEntryEventType.RefundFeesReversal)]
    [InlineData(BalanceLedgerEntryEventType.DisputeFees)]
    [InlineData(BalanceLedgerEntryEventType.Payout)]
    [InlineData(BalanceLedgerEntryEventType.PayoutFees)]
    [InlineData(BalanceLedgerEntryEventType.PayoutReversal)]
    [InlineData(BalanceLedgerEntryEventType.PayoutFeesReversal)]
    [InlineData(BalanceLedgerEntryEventType.DodoCredits)]
    [InlineData(BalanceLedgerEntryEventType.Adjustment)]
    [InlineData(BalanceLedgerEntryEventType.CurrencyConversion)]
    public void SerializationRoundtrip_Works(BalanceLedgerEntryEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceLedgerEntryEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceLedgerEntryEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceLedgerEntryEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceLedgerEntryEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
