using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class ChargeTypeTest : TestBase
{
    [Theory]
    [InlineData(ChargeType.New)]
    [InlineData(ChargeType.Renewal)]
    [InlineData(ChargeType.PlanChange)]
    [InlineData(ChargeType.OnDemand)]
    public void Validation_Works(ChargeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeType.New)]
    [InlineData(ChargeType.Renewal)]
    [InlineData(ChargeType.PlanChange)]
    [InlineData(ChargeType.OnDemand)]
    public void SerializationRoundtrip_Works(ChargeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
