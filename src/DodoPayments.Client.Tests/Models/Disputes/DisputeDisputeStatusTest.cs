using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Tests.Models.Disputes;

public class DisputeDisputeStatusTest : TestBase
{
    [Theory]
    [InlineData(DisputeDisputeStatus.DisputeOpened)]
    [InlineData(DisputeDisputeStatus.DisputeExpired)]
    [InlineData(DisputeDisputeStatus.DisputeAccepted)]
    [InlineData(DisputeDisputeStatus.DisputeCancelled)]
    [InlineData(DisputeDisputeStatus.DisputeChallenged)]
    [InlineData(DisputeDisputeStatus.DisputeWon)]
    [InlineData(DisputeDisputeStatus.DisputeLost)]
    public void Validation_Works(DisputeDisputeStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeDisputeStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeDisputeStatus.DisputeOpened)]
    [InlineData(DisputeDisputeStatus.DisputeExpired)]
    [InlineData(DisputeDisputeStatus.DisputeAccepted)]
    [InlineData(DisputeDisputeStatus.DisputeCancelled)]
    [InlineData(DisputeDisputeStatus.DisputeChallenged)]
    [InlineData(DisputeDisputeStatus.DisputeWon)]
    [InlineData(DisputeDisputeStatus.DisputeLost)]
    public void SerializationRoundtrip_Works(DisputeDisputeStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeDisputeStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeDisputeStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
