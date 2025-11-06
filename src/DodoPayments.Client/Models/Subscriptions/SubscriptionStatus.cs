using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(SubscriptionStatusConverter))]
public enum SubscriptionStatus
{
    Pending,
    Active,
    OnHold,
    Cancelled,
    Failed,
    Expired,
}

sealed class SubscriptionStatusConverter : JsonConverter<SubscriptionStatus>
{
    public override SubscriptionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => SubscriptionStatus.Pending,
            "active" => SubscriptionStatus.Active,
            "on_hold" => SubscriptionStatus.OnHold,
            "cancelled" => SubscriptionStatus.Cancelled,
            "failed" => SubscriptionStatus.Failed,
            "expired" => SubscriptionStatus.Expired,
            _ => (SubscriptionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionStatus.Pending => "pending",
                SubscriptionStatus.Active => "active",
                SubscriptionStatus.OnHold => "on_hold",
                SubscriptionStatus.Cancelled => "cancelled",
                SubscriptionStatus.Failed => "failed",
                SubscriptionStatus.Expired => "expired",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
