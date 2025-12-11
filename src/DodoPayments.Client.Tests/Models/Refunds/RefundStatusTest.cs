using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Refunds;

public class RefundStatusTest : TestBase
{
    [Theory]
    [InlineData(RefundStatus.Succeeded)]
    [InlineData(RefundStatus.Failed)]
    [InlineData(RefundStatus.Pending)]
    [InlineData(RefundStatus.Review)]
    public void Validation_Works(RefundStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RefundStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RefundStatus.Succeeded)]
    [InlineData(RefundStatus.Failed)]
    [InlineData(RefundStatus.Pending)]
    [InlineData(RefundStatus.Review)]
    public void SerializationRoundtrip_Works(RefundStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RefundStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RefundStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RefundStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
