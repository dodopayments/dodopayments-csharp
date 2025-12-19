using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class TimeIntervalTest : TestBase
{
    [Theory]
    [InlineData(TimeInterval.Day)]
    [InlineData(TimeInterval.Week)]
    [InlineData(TimeInterval.Month)]
    [InlineData(TimeInterval.Year)]
    public void Validation_Works(TimeInterval rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TimeInterval> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TimeInterval.Day)]
    [InlineData(TimeInterval.Week)]
    [InlineData(TimeInterval.Month)]
    [InlineData(TimeInterval.Year)]
    public void SerializationRoundtrip_Works(TimeInterval rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TimeInterval> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
