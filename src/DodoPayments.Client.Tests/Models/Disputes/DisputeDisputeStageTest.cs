using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Tests.Models.Disputes;

public class DisputeDisputeStageTest : TestBase
{
    [Theory]
    [InlineData(DisputeDisputeStage.PreDispute)]
    [InlineData(DisputeDisputeStage.Dispute)]
    [InlineData(DisputeDisputeStage.PreArbitration)]
    public void Validation_Works(DisputeDisputeStage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeDisputeStage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeDisputeStage.PreDispute)]
    [InlineData(DisputeDisputeStage.Dispute)]
    [InlineData(DisputeDisputeStage.PreArbitration)]
    public void SerializationRoundtrip_Works(DisputeDisputeStage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeDisputeStage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
