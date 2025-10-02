using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.LicenseKeyProperties.IntersectionMember1Properties;

[JsonConverter(typeof(PayloadTypeConverter))]
public enum PayloadType
{
    LicenseKey,
}

sealed class PayloadTypeConverter : JsonConverter<PayloadType>
{
    public override PayloadType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LicenseKey" => PayloadType.LicenseKey,
            _ => (PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayloadType.LicenseKey => "LicenseKey",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
