using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Customers.Wallets.LedgerEntries;

public class LedgerEntryCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LedgerEntryCreateParams
        {
            CustomerID = "customer_id",
            Amount = 0,
            Currency = Currency.Aed,
            EntryType = EntryType.Credit,
            IdempotencyKey = "idempotency_key",
            Reason = "reason",
        };

        string expectedCustomerID = "customer_id";
        long expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        ApiEnum<string, EntryType> expectedEntryType = EntryType.Credit;
        string expectedIdempotencyKey = "idempotency_key";
        string expectedReason = "reason";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedEntryType, parameters.EntryType);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LedgerEntryCreateParams
        {
            CustomerID = "customer_id",
            Amount = 0,
            Currency = Currency.Aed,
            EntryType = EntryType.Credit,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawBodyData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LedgerEntryCreateParams
        {
            CustomerID = "customer_id",
            Amount = 0,
            Currency = Currency.Aed,
            EntryType = EntryType.Credit,

            IdempotencyKey = null,
            Reason = null,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.True(parameters.RawBodyData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Reason);
        Assert.True(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        LedgerEntryCreateParams parameters = new()
        {
            CustomerID = "customer_id",
            Amount = 0,
            Currency = Currency.Aed,
            EntryType = EntryType.Credit,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri("https://live.dodopayments.com/customers/customer_id/wallets/ledger-entries"),
            url
        );
    }
}

public class EntryTypeTest : TestBase
{
    [Theory]
    [InlineData(EntryType.Credit)]
    [InlineData(EntryType.Debit)]
    public void Validation_Works(EntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntryType.Credit)]
    [InlineData(EntryType.Debit)]
    public void SerializationRoundtrip_Works(EntryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
