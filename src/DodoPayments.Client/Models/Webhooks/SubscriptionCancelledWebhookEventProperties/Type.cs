using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks.SubscriptionCancelledWebhookEventProperties;

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    SubscriptionCancelled,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.cancelled" => SubscriptionCancelledWebhookEventProperties
                .Type
                .SubscriptionCancelled,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionCancelledWebhookEventProperties.Type.SubscriptionCancelled =>
                    "subscription.cancelled",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
