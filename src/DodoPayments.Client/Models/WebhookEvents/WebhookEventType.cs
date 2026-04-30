using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

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
    SubscriptionUpdated,
    LicenseKeyCreated,
    PayoutNotInitiated,
    PayoutOnHold,
    PayoutInProgress,
    PayoutFailed,
    PayoutSuccess,
    CreditAdded,
    CreditDeducted,
    CreditExpired,
    CreditRolledOver,
    CreditRolloverForfeited,
    CreditOverageCharged,
    CreditOverageReset,
    CreditManualAdjustment,
    CreditBalanceLow,
    AbandonedCheckoutDetected,
    AbandonedCheckoutRecovered,
    DunningStarted,
    DunningRecovered,
    AcrEmail,
    DunningEmail,
    EntitlementGrantCreated,
    EntitlementGrantDelivered,
    EntitlementGrantFailed,
    EntitlementGrantRevoked,
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
            "subscription.updated" => WebhookEventType.SubscriptionUpdated,
            "license_key.created" => WebhookEventType.LicenseKeyCreated,
            "payout.not_initiated" => WebhookEventType.PayoutNotInitiated,
            "payout.on_hold" => WebhookEventType.PayoutOnHold,
            "payout.in_progress" => WebhookEventType.PayoutInProgress,
            "payout.failed" => WebhookEventType.PayoutFailed,
            "payout.success" => WebhookEventType.PayoutSuccess,
            "credit.added" => WebhookEventType.CreditAdded,
            "credit.deducted" => WebhookEventType.CreditDeducted,
            "credit.expired" => WebhookEventType.CreditExpired,
            "credit.rolled_over" => WebhookEventType.CreditRolledOver,
            "credit.rollover_forfeited" => WebhookEventType.CreditRolloverForfeited,
            "credit.overage_charged" => WebhookEventType.CreditOverageCharged,
            "credit.overage_reset" => WebhookEventType.CreditOverageReset,
            "credit.manual_adjustment" => WebhookEventType.CreditManualAdjustment,
            "credit.balance_low" => WebhookEventType.CreditBalanceLow,
            "abandoned_checkout.detected" => WebhookEventType.AbandonedCheckoutDetected,
            "abandoned_checkout.recovered" => WebhookEventType.AbandonedCheckoutRecovered,
            "dunning.started" => WebhookEventType.DunningStarted,
            "dunning.recovered" => WebhookEventType.DunningRecovered,
            "acr.email" => WebhookEventType.AcrEmail,
            "dunning.email" => WebhookEventType.DunningEmail,
            "entitlement_grant.created" => WebhookEventType.EntitlementGrantCreated,
            "entitlement_grant.delivered" => WebhookEventType.EntitlementGrantDelivered,
            "entitlement_grant.failed" => WebhookEventType.EntitlementGrantFailed,
            "entitlement_grant.revoked" => WebhookEventType.EntitlementGrantRevoked,
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
                WebhookEventType.SubscriptionUpdated => "subscription.updated",
                WebhookEventType.LicenseKeyCreated => "license_key.created",
                WebhookEventType.PayoutNotInitiated => "payout.not_initiated",
                WebhookEventType.PayoutOnHold => "payout.on_hold",
                WebhookEventType.PayoutInProgress => "payout.in_progress",
                WebhookEventType.PayoutFailed => "payout.failed",
                WebhookEventType.PayoutSuccess => "payout.success",
                WebhookEventType.CreditAdded => "credit.added",
                WebhookEventType.CreditDeducted => "credit.deducted",
                WebhookEventType.CreditExpired => "credit.expired",
                WebhookEventType.CreditRolledOver => "credit.rolled_over",
                WebhookEventType.CreditRolloverForfeited => "credit.rollover_forfeited",
                WebhookEventType.CreditOverageCharged => "credit.overage_charged",
                WebhookEventType.CreditOverageReset => "credit.overage_reset",
                WebhookEventType.CreditManualAdjustment => "credit.manual_adjustment",
                WebhookEventType.CreditBalanceLow => "credit.balance_low",
                WebhookEventType.AbandonedCheckoutDetected => "abandoned_checkout.detected",
                WebhookEventType.AbandonedCheckoutRecovered => "abandoned_checkout.recovered",
                WebhookEventType.DunningStarted => "dunning.started",
                WebhookEventType.DunningRecovered => "dunning.recovered",
                WebhookEventType.AcrEmail => "acr.email",
                WebhookEventType.DunningEmail => "dunning.email",
                WebhookEventType.EntitlementGrantCreated => "entitlement_grant.created",
                WebhookEventType.EntitlementGrantDelivered => "entitlement_grant.delivered",
                WebhookEventType.EntitlementGrantFailed => "entitlement_grant.failed",
                WebhookEventType.EntitlementGrantRevoked => "entitlement_grant.revoked",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
