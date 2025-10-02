using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.LicenseKeys;

[JsonConverter(typeof(LicenseKeyStatusConverter))]
public enum LicenseKeyStatus
{
    Active,
    Expired,
    Disabled,
}

sealed class LicenseKeyStatusConverter : JsonConverter<LicenseKeyStatus>
{
    public override LicenseKeyStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => LicenseKeyStatus.Active,
            "expired" => LicenseKeyStatus.Expired,
            "disabled" => LicenseKeyStatus.Disabled,
            _ => (LicenseKeyStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LicenseKeyStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LicenseKeyStatus.Active => "active",
                LicenseKeyStatus.Expired => "expired",
                LicenseKeyStatus.Disabled => "disabled",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
