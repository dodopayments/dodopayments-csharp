using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.WebhookEvents;

/// <summary>
/// Event types for Dodo events
/// </summary>
[JsonConverter(typeof(WebhookEventTypeConverter))]
public enum WebhookEventType
{
    PaymentSucceeded,
    PaymentFailed,
    PaymentProcessing,
    PaymentCancelled,
    RefundSucceeded,
    RefundFailed,
    DisputeOpened,
    DisputeExpired,
    DisputeAccepted,
    DisputeCancelled,
    DisputeChallenged,
    DisputeWon,
    DisputeLost,
    SubscriptionActive,
    SubscriptionRenewed,
    SubscriptionOnHold,
    SubscriptionCancelled,
    SubscriptionFailed,
    SubscriptionExpired,
    SubscriptionPlanChanged,
    LicenseKeyCreated,
}

sealed class WebhookEventTypeConverter : JsonConverter<WebhookEventType>
{
    public override WebhookEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment.succeeded" => WebhookEventType.PaymentSucceeded,
            "payment.failed" => WebhookEventType.PaymentFailed,
            "payment.processing" => WebhookEventType.PaymentProcessing,
            "payment.cancelled" => WebhookEventType.PaymentCancelled,
            "refund.succeeded" => WebhookEventType.RefundSucceeded,
            "refund.failed" => WebhookEventType.RefundFailed,
            "dispute.opened" => WebhookEventType.DisputeOpened,
            "dispute.expired" => WebhookEventType.DisputeExpired,
            "dispute.accepted" => WebhookEventType.DisputeAccepted,
            "dispute.cancelled" => WebhookEventType.DisputeCancelled,
            "dispute.challenged" => WebhookEventType.DisputeChallenged,
            "dispute.won" => WebhookEventType.DisputeWon,
            "dispute.lost" => WebhookEventType.DisputeLost,
            "subscription.active" => WebhookEventType.SubscriptionActive,
            "subscription.renewed" => WebhookEventType.SubscriptionRenewed,
            "subscription.on_hold" => WebhookEventType.SubscriptionOnHold,
            "subscription.cancelled" => WebhookEventType.SubscriptionCancelled,
            "subscription.failed" => WebhookEventType.SubscriptionFailed,
            "subscription.expired" => WebhookEventType.SubscriptionExpired,
            "subscription.plan_changed" => WebhookEventType.SubscriptionPlanChanged,
            "license_key.created" => WebhookEventType.LicenseKeyCreated,
            _ => (WebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookEventType.PaymentSucceeded => "payment.succeeded",
                WebhookEventType.PaymentFailed => "payment.failed",
                WebhookEventType.PaymentProcessing => "payment.processing",
                WebhookEventType.PaymentCancelled => "payment.cancelled",
                WebhookEventType.RefundSucceeded => "refund.succeeded",
                WebhookEventType.RefundFailed => "refund.failed",
                WebhookEventType.DisputeOpened => "dispute.opened",
                WebhookEventType.DisputeExpired => "dispute.expired",
                WebhookEventType.DisputeAccepted => "dispute.accepted",
                WebhookEventType.DisputeCancelled => "dispute.cancelled",
                WebhookEventType.DisputeChallenged => "dispute.challenged",
                WebhookEventType.DisputeWon => "dispute.won",
                WebhookEventType.DisputeLost => "dispute.lost",
                WebhookEventType.SubscriptionActive => "subscription.active",
                WebhookEventType.SubscriptionRenewed => "subscription.renewed",
                WebhookEventType.SubscriptionOnHold => "subscription.on_hold",
                WebhookEventType.SubscriptionCancelled => "subscription.cancelled",
                WebhookEventType.SubscriptionFailed => "subscription.failed",
                WebhookEventType.SubscriptionExpired => "subscription.expired",
                WebhookEventType.SubscriptionPlanChanged => "subscription.plan_changed",
                WebhookEventType.LicenseKeyCreated => "license_key.created",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
