using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Moderation;

namespace DodoPayments.Client.Tests.Models.Moderation;

public class ModerationDecisionTest : TestBase
{
    [Theory]
    [InlineData(ModerationDecision.Allow)]
    [InlineData(ModerationDecision.Flag)]
    [InlineData(ModerationDecision.Deny)]
    public void Validation_Works(ModerationDecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModerationDecision> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModerationDecision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModerationDecision.Allow)]
    [InlineData(ModerationDecision.Flag)]
    [InlineData(ModerationDecision.Deny)]
    public void SerializationRoundtrip_Works(ModerationDecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModerationDecision> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModerationDecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModerationDecision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModerationDecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
