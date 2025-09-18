using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.RefundProperties.IntersectionMember1Properties;

[JsonConverter(typeof(PayloadTypeConverter))]
public enum PayloadType
{
    Refund,
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
            "Refund" => PayloadType.Refund,
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
                PayloadType.Refund => "Refund",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
