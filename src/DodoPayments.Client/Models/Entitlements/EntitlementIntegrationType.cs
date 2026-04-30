using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Entitlements;

[JsonConverter(typeof(EntitlementIntegrationTypeConverter))]
public enum EntitlementIntegrationType
{
    Discord,
    Telegram,
    GitHub,
    Figma,
    Framer,
    Notion,
    DigitalFiles,
    LicenseKey,
}

sealed class EntitlementIntegrationTypeConverter : JsonConverter<EntitlementIntegrationType>
{
    public override EntitlementIntegrationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => EntitlementIntegrationType.Discord,
            "telegram" => EntitlementIntegrationType.Telegram,
            "github" => EntitlementIntegrationType.GitHub,
            "figma" => EntitlementIntegrationType.Figma,
            "framer" => EntitlementIntegrationType.Framer,
            "notion" => EntitlementIntegrationType.Notion,
            "digital_files" => EntitlementIntegrationType.DigitalFiles,
            "license_key" => EntitlementIntegrationType.LicenseKey,
            _ => (EntitlementIntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementIntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementIntegrationType.Discord => "discord",
                EntitlementIntegrationType.Telegram => "telegram",
                EntitlementIntegrationType.GitHub => "github",
                EntitlementIntegrationType.Figma => "figma",
                EntitlementIntegrationType.Framer => "framer",
                EntitlementIntegrationType.Notion => "notion",
                EntitlementIntegrationType.DigitalFiles => "digital_files",
                EntitlementIntegrationType.LicenseKey => "license_key",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
