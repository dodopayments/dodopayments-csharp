using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.LicenseKeys.LicenseKeyListParamsProperties;

/// <summary>
/// Filter by license key status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Expired,
    Disabled,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "expired" => Status.Expired,
            "disabled" => Status.Disabled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Expired => "expired",
                Status.Disabled => "disabled",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
