using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks.SubscriptionPlanChangedWebhookEventProperties;

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(TypeModelConverter))]
public enum TypeModel
{
    SubscriptionPlanChanged,
}

sealed class TypeModelConverter : JsonConverter<TypeModel>
{
    public override TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.plan_changed" => SubscriptionPlanChangedWebhookEventProperties
                .TypeModel
                .SubscriptionPlanChanged,
            _ => (TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPlanChangedWebhookEventProperties.TypeModel.SubscriptionPlanChanged =>
                    "subscription.plan_changed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
