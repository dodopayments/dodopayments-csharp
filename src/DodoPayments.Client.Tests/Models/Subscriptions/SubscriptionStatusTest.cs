using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionStatus.Pending)]
    [InlineData(SubscriptionStatus.Active)]
    [InlineData(SubscriptionStatus.OnHold)]
    [InlineData(SubscriptionStatus.Cancelled)]
    [InlineData(SubscriptionStatus.Failed)]
    [InlineData(SubscriptionStatus.Expired)]
    public void Validation_Works(SubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionStatus.Pending)]
    [InlineData(SubscriptionStatus.Active)]
    [InlineData(SubscriptionStatus.OnHold)]
    [InlineData(SubscriptionStatus.Cancelled)]
    [InlineData(SubscriptionStatus.Failed)]
    [InlineData(SubscriptionStatus.Expired)]
    public void SerializationRoundtrip_Works(SubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
