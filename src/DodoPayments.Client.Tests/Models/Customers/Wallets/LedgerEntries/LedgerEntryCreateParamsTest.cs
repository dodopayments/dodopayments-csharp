using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Tests.Models.Customers.Wallets.LedgerEntries;

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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
