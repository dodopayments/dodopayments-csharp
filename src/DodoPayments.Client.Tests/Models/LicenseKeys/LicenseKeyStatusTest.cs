using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Tests.Models.LicenseKeys;

public class LicenseKeyStatusTest : TestBase
{
    [Theory]
    [InlineData(LicenseKeyStatus.Active)]
    [InlineData(LicenseKeyStatus.Expired)]
    [InlineData(LicenseKeyStatus.Disabled)]
    public void Validation_Works(LicenseKeyStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LicenseKeyStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LicenseKeyStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LicenseKeyStatus.Active)]
    [InlineData(LicenseKeyStatus.Expired)]
    [InlineData(LicenseKeyStatus.Disabled)]
    public void SerializationRoundtrip_Works(LicenseKeyStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LicenseKeyStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LicenseKeyStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LicenseKeyStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LicenseKeyStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
