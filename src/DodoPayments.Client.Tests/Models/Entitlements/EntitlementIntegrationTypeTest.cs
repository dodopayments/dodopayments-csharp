using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementIntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(EntitlementIntegrationType.Discord)]
    [InlineData(EntitlementIntegrationType.Telegram)]
    [InlineData(EntitlementIntegrationType.GitHub)]
    [InlineData(EntitlementIntegrationType.Figma)]
    [InlineData(EntitlementIntegrationType.Framer)]
    [InlineData(EntitlementIntegrationType.Notion)]
    [InlineData(EntitlementIntegrationType.DigitalFiles)]
    [InlineData(EntitlementIntegrationType.LicenseKey)]
    public void Validation_Works(EntitlementIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementIntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementIntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementIntegrationType.Discord)]
    [InlineData(EntitlementIntegrationType.Telegram)]
    [InlineData(EntitlementIntegrationType.GitHub)]
    [InlineData(EntitlementIntegrationType.Figma)]
    [InlineData(EntitlementIntegrationType.Framer)]
    [InlineData(EntitlementIntegrationType.Notion)]
    [InlineData(EntitlementIntegrationType.DigitalFiles)]
    [InlineData(EntitlementIntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(EntitlementIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementIntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntitlementIntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementIntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntitlementIntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
