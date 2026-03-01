using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class ConjunctionTest : TestBase
{
    [Theory]
    [InlineData(Conjunction.And)]
    [InlineData(Conjunction.Or)]
    public void Validation_Works(Conjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Conjunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Conjunction.And)]
    [InlineData(Conjunction.Or)]
    public void SerializationRoundtrip_Works(Conjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Conjunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
