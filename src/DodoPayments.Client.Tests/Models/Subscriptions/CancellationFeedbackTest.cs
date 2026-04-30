using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class CancellationFeedbackTest : TestBase
{
    [Theory]
    [InlineData(CancellationFeedback.TooExpensive)]
    [InlineData(CancellationFeedback.MissingFeatures)]
    [InlineData(CancellationFeedback.SwitchedService)]
    [InlineData(CancellationFeedback.Unused)]
    [InlineData(CancellationFeedback.CustomerService)]
    [InlineData(CancellationFeedback.LowQuality)]
    [InlineData(CancellationFeedback.TooComplex)]
    [InlineData(CancellationFeedback.Other)]
    public void Validation_Works(CancellationFeedback rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationFeedback> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationFeedback>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancellationFeedback.TooExpensive)]
    [InlineData(CancellationFeedback.MissingFeatures)]
    [InlineData(CancellationFeedback.SwitchedService)]
    [InlineData(CancellationFeedback.Unused)]
    [InlineData(CancellationFeedback.CustomerService)]
    [InlineData(CancellationFeedback.LowQuality)]
    [InlineData(CancellationFeedback.TooComplex)]
    [InlineData(CancellationFeedback.Other)]
    public void SerializationRoundtrip_Works(CancellationFeedback rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationFeedback> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationFeedback>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationFeedback>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationFeedback>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
