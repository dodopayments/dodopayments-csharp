using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.SubscriptionProperties.IntersectionMember1Properties;

[JsonConverter(typeof(PayloadTypeConverter))]
public enum PayloadType
{
    Subscription,
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
            "Subscription" => PayloadType.Subscription,
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
                PayloadType.Subscription => "Subscription",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
