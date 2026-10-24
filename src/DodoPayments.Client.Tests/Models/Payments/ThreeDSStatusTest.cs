using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class ThreeDSStatusTest : TestBase
{
    [Theory]
    [InlineData(ThreeDSStatus.Authenticated)]
    [InlineData(ThreeDSStatus.AttemptAcknowledged)]
    [InlineData(ThreeDSStatus.Exempted)]
    [InlineData(ThreeDSStatus.Failed)]
    [InlineData(ThreeDSStatus.NotSupported)]
    [InlineData(ThreeDSStatus.ProcessingError)]
    public void Validation_Works(ThreeDSStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThreeDSStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThreeDSStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThreeDSStatus.Authenticated)]
    [InlineData(ThreeDSStatus.AttemptAcknowledged)]
    [InlineData(ThreeDSStatus.Exempted)]
    [InlineData(ThreeDSStatus.Failed)]
    [InlineData(ThreeDSStatus.NotSupported)]
    [InlineData(ThreeDSStatus.ProcessingError)]
    public void SerializationRoundtrip_Works(ThreeDSStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThreeDSStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThreeDSStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThreeDSStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThreeDSStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
