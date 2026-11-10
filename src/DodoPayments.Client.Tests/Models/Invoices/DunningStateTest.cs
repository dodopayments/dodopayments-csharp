using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class DunningStateTest : TestBase
{
    [Theory]
    [InlineData(DunningState.NotStarted)]
    [InlineData(DunningState.Active)]
    [InlineData(DunningState.Paused)]
    [InlineData(DunningState.Exhausted)]
    public void Validation_Works(DunningState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DunningState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DunningState.NotStarted)]
    [InlineData(DunningState.Active)]
    [InlineData(DunningState.Paused)]
    [InlineData(DunningState.Exhausted)]
    public void SerializationRoundtrip_Works(DunningState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DunningState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DunningState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DunningState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
