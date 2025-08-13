using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.WebhookEvents;

/// <summary>
/// Event types for Dodo events
/// </summary>
[JsonConverter(typeof(DodoPayments::EnumConverter<WebhookEventType, string>))]
public sealed record class WebhookEventType(string value)
    : DodoPayments::IEnum<WebhookEventType, string>
{
    public static readonly WebhookEventType PaymentSucceeded = new("payment.succeeded");

    public static readonly WebhookEventType PaymentFailed = new("payment.failed");

    public static readonly WebhookEventType PaymentProcessing = new("payment.processing");

    public static readonly WebhookEventType PaymentCancelled = new("payment.cancelled");

    public static readonly WebhookEventType RefundSucceeded = new("refund.succeeded");

    public static readonly WebhookEventType RefundFailed = new("refund.failed");

    public static readonly WebhookEventType DisputeOpened = new("dispute.opened");

    public static readonly WebhookEventType DisputeExpired = new("dispute.expired");

    public static readonly WebhookEventType DisputeAccepted = new("dispute.accepted");

    public static readonly WebhookEventType DisputeCancelled = new("dispute.cancelled");

    public static readonly WebhookEventType DisputeChallenged = new("dispute.challenged");

    public static readonly WebhookEventType DisputeWon = new("dispute.won");

    public static readonly WebhookEventType DisputeLost = new("dispute.lost");

    public static readonly WebhookEventType SubscriptionActive = new("subscription.active");

    public static readonly WebhookEventType SubscriptionRenewed = new("subscription.renewed");

    public static readonly WebhookEventType SubscriptionOnHold = new("subscription.on_hold");

    public static readonly WebhookEventType SubscriptionCancelled = new("subscription.cancelled");

    public static readonly WebhookEventType SubscriptionFailed = new("subscription.failed");

    public static readonly WebhookEventType SubscriptionExpired = new("subscription.expired");

    public static readonly WebhookEventType SubscriptionPlanChanged = new(
        "subscription.plan_changed"
    );

    public static readonly WebhookEventType LicenseKeyCreated = new("license_key.created");

    readonly string _value = value;

    public enum Value
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

    public Value Known() =>
        _value switch
        {
            "payment.succeeded" => Value.PaymentSucceeded,
            "payment.failed" => Value.PaymentFailed,
            "payment.processing" => Value.PaymentProcessing,
            "payment.cancelled" => Value.PaymentCancelled,
            "refund.succeeded" => Value.RefundSucceeded,
            "refund.failed" => Value.RefundFailed,
            "dispute.opened" => Value.DisputeOpened,
            "dispute.expired" => Value.DisputeExpired,
            "dispute.accepted" => Value.DisputeAccepted,
            "dispute.cancelled" => Value.DisputeCancelled,
            "dispute.challenged" => Value.DisputeChallenged,
            "dispute.won" => Value.DisputeWon,
            "dispute.lost" => Value.DisputeLost,
            "subscription.active" => Value.SubscriptionActive,
            "subscription.renewed" => Value.SubscriptionRenewed,
            "subscription.on_hold" => Value.SubscriptionOnHold,
            "subscription.cancelled" => Value.SubscriptionCancelled,
            "subscription.failed" => Value.SubscriptionFailed,
            "subscription.expired" => Value.SubscriptionExpired,
            "subscription.plan_changed" => Value.SubscriptionPlanChanged,
            "license_key.created" => Value.LicenseKeyCreated,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static WebhookEventType FromRaw(string value)
    {
        return new(value);
    }
}
