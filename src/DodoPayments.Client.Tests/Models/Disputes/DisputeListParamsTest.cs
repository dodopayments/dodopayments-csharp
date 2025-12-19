using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Tests.Models.Disputes;

public class DisputeStageTest : TestBase
{
    [Theory]
    [InlineData(DisputeStage.PreDispute)]
    [InlineData(DisputeStage.Dispute)]
    [InlineData(DisputeStage.PreArbitration)]
    public void Validation_Works(DisputeStage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeStage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeStage.PreDispute)]
    [InlineData(DisputeStage.Dispute)]
    [InlineData(DisputeStage.PreArbitration)]
    public void SerializationRoundtrip_Works(DisputeStage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeStage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DisputeStatusTest : TestBase
{
    [Theory]
    [InlineData(DisputeStatus.DisputeOpened)]
    [InlineData(DisputeStatus.DisputeExpired)]
    [InlineData(DisputeStatus.DisputeAccepted)]
    [InlineData(DisputeStatus.DisputeCancelled)]
    [InlineData(DisputeStatus.DisputeChallenged)]
    [InlineData(DisputeStatus.DisputeWon)]
    [InlineData(DisputeStatus.DisputeLost)]
    public void Validation_Works(DisputeStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeStatus.DisputeOpened)]
    [InlineData(DisputeStatus.DisputeExpired)]
    [InlineData(DisputeStatus.DisputeAccepted)]
    [InlineData(DisputeStatus.DisputeCancelled)]
    [InlineData(DisputeStatus.DisputeChallenged)]
    [InlineData(DisputeStatus.DisputeWon)]
    [InlineData(DisputeStatus.DisputeLost)]
    public void SerializationRoundtrip_Works(DisputeStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
