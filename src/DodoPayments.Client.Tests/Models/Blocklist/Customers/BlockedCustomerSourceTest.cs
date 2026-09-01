using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class BlockedCustomerSourceTest : TestBase
{
    [Theory]
    [InlineData(BlockedCustomerSource.BlocklistPage)]
    [InlineData(BlockedCustomerSource.CustomerPage)]
    [InlineData(BlockedCustomerSource.PaymentPage)]
    [InlineData(BlockedCustomerSource.DisputePage)]
    [InlineData(BlockedCustomerSource.Api)]
    public void Validation_Works(BlockedCustomerSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockedCustomerSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockedCustomerSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockedCustomerSource.BlocklistPage)]
    [InlineData(BlockedCustomerSource.CustomerPage)]
    [InlineData(BlockedCustomerSource.PaymentPage)]
    [InlineData(BlockedCustomerSource.DisputePage)]
    [InlineData(BlockedCustomerSource.Api)]
    public void SerializationRoundtrip_Works(BlockedCustomerSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockedCustomerSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockedCustomerSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockedCustomerSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockedCustomerSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
