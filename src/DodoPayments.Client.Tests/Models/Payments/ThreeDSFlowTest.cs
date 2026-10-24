using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class ThreeDSFlowTest : TestBase
{
    [Theory]
    [InlineData(ThreeDSFlow.Challenge)]
    [InlineData(ThreeDSFlow.Frictionless)]
    public void Validation_Works(ThreeDSFlow rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThreeDSFlow> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThreeDSFlow>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThreeDSFlow.Challenge)]
    [InlineData(ThreeDSFlow.Frictionless)]
    public void SerializationRoundtrip_Works(ThreeDSFlow rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThreeDSFlow> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThreeDSFlow>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThreeDSFlow>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThreeDSFlow>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
