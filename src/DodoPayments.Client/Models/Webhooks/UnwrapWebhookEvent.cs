using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(UnwrapWebhookEventConverter))]
public record class UnwrapWebhookEvent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string BusinessID
    {
        get
        {
            return Match(
                abandonedCheckoutDetected: (x) => x.BusinessID,
                abandonedCheckoutRecovered: (x) => x.BusinessID,
                creditAdded: (x) => x.BusinessID,
                creditBalanceLow: (x) => x.BusinessID,
                creditDeducted: (x) => x.BusinessID,
                creditExpired: (x) => x.BusinessID,
                creditManualAdjustment: (x) => x.BusinessID,
                creditOverageCharged: (x) => x.BusinessID,
                creditOverageReset: (x) => x.BusinessID,
                creditRolledOver: (x) => x.BusinessID,
                creditRolloverForfeited: (x) => x.BusinessID,
                disputeAccepted: (x) => x.BusinessID,
                disputeCancelled: (x) => x.BusinessID,
                disputeChallenged: (x) => x.BusinessID,
                disputeExpired: (x) => x.BusinessID,
                disputeLost: (x) => x.BusinessID,
                disputeOpened: (x) => x.BusinessID,
                disputeWon: (x) => x.BusinessID,
                dunningRecovered: (x) => x.BusinessID,
                dunningStarted: (x) => x.BusinessID,
                entitlementGrantCreated: (x) => x.BusinessID,
                entitlementGrantDelivered: (x) => x.BusinessID,
                entitlementGrantFailed: (x) => x.BusinessID,
                entitlementGrantRevoked: (x) => x.BusinessID,
                licenseKeyCreated: (x) => x.BusinessID,
                paymentCancelled: (x) => x.BusinessID,
                paymentFailed: (x) => x.BusinessID,
                paymentProcessing: (x) => x.BusinessID,
                paymentSucceeded: (x) => x.BusinessID,
                refundFailed: (x) => x.BusinessID,
                refundSucceeded: (x) => x.BusinessID,
                subscriptionActive: (x) => x.BusinessID,
                subscriptionCancelled: (x) => x.BusinessID,
                subscriptionExpired: (x) => x.BusinessID,
                subscriptionFailed: (x) => x.BusinessID,
                subscriptionOnHold: (x) => x.BusinessID,
                subscriptionPlanChanged: (x) => x.BusinessID,
                subscriptionRenewed: (x) => x.BusinessID,
                subscriptionUpdated: (x) => x.BusinessID
            );
        }
    }

    public System::DateTimeOffset Timestamp
    {
        get
        {
            return Match(
                abandonedCheckoutDetected: (x) => x.Timestamp,
                abandonedCheckoutRecovered: (x) => x.Timestamp,
                creditAdded: (x) => x.Timestamp,
                creditBalanceLow: (x) => x.Timestamp,
                creditDeducted: (x) => x.Timestamp,
                creditExpired: (x) => x.Timestamp,
                creditManualAdjustment: (x) => x.Timestamp,
                creditOverageCharged: (x) => x.Timestamp,
                creditOverageReset: (x) => x.Timestamp,
                creditRolledOver: (x) => x.Timestamp,
                creditRolloverForfeited: (x) => x.Timestamp,
                disputeAccepted: (x) => x.Timestamp,
                disputeCancelled: (x) => x.Timestamp,
                disputeChallenged: (x) => x.Timestamp,
                disputeExpired: (x) => x.Timestamp,
                disputeLost: (x) => x.Timestamp,
                disputeOpened: (x) => x.Timestamp,
                disputeWon: (x) => x.Timestamp,
                dunningRecovered: (x) => x.Timestamp,
                dunningStarted: (x) => x.Timestamp,
                entitlementGrantCreated: (x) => x.Timestamp,
                entitlementGrantDelivered: (x) => x.Timestamp,
                entitlementGrantFailed: (x) => x.Timestamp,
                entitlementGrantRevoked: (x) => x.Timestamp,
                licenseKeyCreated: (x) => x.Timestamp,
                paymentCancelled: (x) => x.Timestamp,
                paymentFailed: (x) => x.Timestamp,
                paymentProcessing: (x) => x.Timestamp,
                paymentSucceeded: (x) => x.Timestamp,
                refundFailed: (x) => x.Timestamp,
                refundSucceeded: (x) => x.Timestamp,
                subscriptionActive: (x) => x.Timestamp,
                subscriptionCancelled: (x) => x.Timestamp,
                subscriptionExpired: (x) => x.Timestamp,
                subscriptionFailed: (x) => x.Timestamp,
                subscriptionOnHold: (x) => x.Timestamp,
                subscriptionPlanChanged: (x) => x.Timestamp,
                subscriptionRenewed: (x) => x.Timestamp,
                subscriptionUpdated: (x) => x.Timestamp
            );
        }
    }

    public UnwrapWebhookEvent(
        AbandonedCheckoutDetectedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        AbandonedCheckoutRecoveredWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CreditAddedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CreditBalanceLowWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CreditDeductedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CreditExpiredWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CreditManualAdjustmentWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CreditOverageChargedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CreditOverageResetWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(CreditRolledOverWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        CreditRolloverForfeitedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DisputeAcceptedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DisputeCancelledWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DisputeChallengedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DisputeExpiredWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DisputeLostWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DisputeOpenedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DisputeWonWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DunningRecoveredWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(DunningStartedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        EntitlementGrantCreatedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        EntitlementGrantDeliveredWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(EntitlementGrantFailedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        EntitlementGrantRevokedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(LicenseKeyCreatedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PaymentCancelledWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PaymentFailedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PaymentProcessingWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(PaymentSucceededWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(RefundFailedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(RefundSucceededWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SubscriptionActiveWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SubscriptionCancelledWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SubscriptionExpiredWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SubscriptionFailedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SubscriptionOnHoldWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(
        SubscriptionPlanChangedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SubscriptionRenewedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(SubscriptionUpdatedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AbandonedCheckoutDetectedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAbandonedCheckoutDetected(out var value)) {
    ///     // `value` is of type `AbandonedCheckoutDetectedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAbandonedCheckoutDetected(
        [NotNullWhen(true)] out AbandonedCheckoutDetectedWebhookEvent? value
    )
    {
        value = this.Value as AbandonedCheckoutDetectedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AbandonedCheckoutRecoveredWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAbandonedCheckoutRecovered(out var value)) {
    ///     // `value` is of type `AbandonedCheckoutRecoveredWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAbandonedCheckoutRecovered(
        [NotNullWhen(true)] out AbandonedCheckoutRecoveredWebhookEvent? value
    )
    {
        value = this.Value as AbandonedCheckoutRecoveredWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditAddedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditAdded(out var value)) {
    ///     // `value` is of type `CreditAddedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditAdded([NotNullWhen(true)] out CreditAddedWebhookEvent? value)
    {
        value = this.Value as CreditAddedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditBalanceLowWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditBalanceLow(out var value)) {
    ///     // `value` is of type `CreditBalanceLowWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditBalanceLow([NotNullWhen(true)] out CreditBalanceLowWebhookEvent? value)
    {
        value = this.Value as CreditBalanceLowWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditDeductedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditDeducted(out var value)) {
    ///     // `value` is of type `CreditDeductedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditDeducted([NotNullWhen(true)] out CreditDeductedWebhookEvent? value)
    {
        value = this.Value as CreditDeductedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditExpiredWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditExpired(out var value)) {
    ///     // `value` is of type `CreditExpiredWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditExpired([NotNullWhen(true)] out CreditExpiredWebhookEvent? value)
    {
        value = this.Value as CreditExpiredWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditManualAdjustmentWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditManualAdjustment(out var value)) {
    ///     // `value` is of type `CreditManualAdjustmentWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditManualAdjustment(
        [NotNullWhen(true)] out CreditManualAdjustmentWebhookEvent? value
    )
    {
        value = this.Value as CreditManualAdjustmentWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditOverageChargedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditOverageCharged(out var value)) {
    ///     // `value` is of type `CreditOverageChargedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditOverageCharged(
        [NotNullWhen(true)] out CreditOverageChargedWebhookEvent? value
    )
    {
        value = this.Value as CreditOverageChargedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditOverageResetWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditOverageReset(out var value)) {
    ///     // `value` is of type `CreditOverageResetWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditOverageReset(
        [NotNullWhen(true)] out CreditOverageResetWebhookEvent? value
    )
    {
        value = this.Value as CreditOverageResetWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditRolledOverWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditRolledOver(out var value)) {
    ///     // `value` is of type `CreditRolledOverWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditRolledOver([NotNullWhen(true)] out CreditRolledOverWebhookEvent? value)
    {
        value = this.Value as CreditRolledOverWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditRolloverForfeitedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditRolloverForfeited(out var value)) {
    ///     // `value` is of type `CreditRolloverForfeitedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditRolloverForfeited(
        [NotNullWhen(true)] out CreditRolloverForfeitedWebhookEvent? value
    )
    {
        value = this.Value as CreditRolloverForfeitedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DisputeAcceptedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisputeAccepted(out var value)) {
    ///     // `value` is of type `DisputeAcceptedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisputeAccepted([NotNullWhen(true)] out DisputeAcceptedWebhookEvent? value)
    {
        value = this.Value as DisputeAcceptedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DisputeCancelledWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisputeCancelled(out var value)) {
    ///     // `value` is of type `DisputeCancelledWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisputeCancelled([NotNullWhen(true)] out DisputeCancelledWebhookEvent? value)
    {
        value = this.Value as DisputeCancelledWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DisputeChallengedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisputeChallenged(out var value)) {
    ///     // `value` is of type `DisputeChallengedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisputeChallenged(
        [NotNullWhen(true)] out DisputeChallengedWebhookEvent? value
    )
    {
        value = this.Value as DisputeChallengedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DisputeExpiredWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisputeExpired(out var value)) {
    ///     // `value` is of type `DisputeExpiredWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisputeExpired([NotNullWhen(true)] out DisputeExpiredWebhookEvent? value)
    {
        value = this.Value as DisputeExpiredWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DisputeLostWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisputeLost(out var value)) {
    ///     // `value` is of type `DisputeLostWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisputeLost([NotNullWhen(true)] out DisputeLostWebhookEvent? value)
    {
        value = this.Value as DisputeLostWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DisputeOpenedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisputeOpened(out var value)) {
    ///     // `value` is of type `DisputeOpenedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisputeOpened([NotNullWhen(true)] out DisputeOpenedWebhookEvent? value)
    {
        value = this.Value as DisputeOpenedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DisputeWonWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisputeWon(out var value)) {
    ///     // `value` is of type `DisputeWonWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisputeWon([NotNullWhen(true)] out DisputeWonWebhookEvent? value)
    {
        value = this.Value as DisputeWonWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DunningRecoveredWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDunningRecovered(out var value)) {
    ///     // `value` is of type `DunningRecoveredWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDunningRecovered([NotNullWhen(true)] out DunningRecoveredWebhookEvent? value)
    {
        value = this.Value as DunningRecoveredWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DunningStartedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDunningStarted(out var value)) {
    ///     // `value` is of type `DunningStartedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDunningStarted([NotNullWhen(true)] out DunningStartedWebhookEvent? value)
    {
        value = this.Value as DunningStartedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementGrantCreatedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEntitlementGrantCreated(out var value)) {
    ///     // `value` is of type `EntitlementGrantCreatedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEntitlementGrantCreated(
        [NotNullWhen(true)] out EntitlementGrantCreatedWebhookEvent? value
    )
    {
        value = this.Value as EntitlementGrantCreatedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementGrantDeliveredWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEntitlementGrantDelivered(out var value)) {
    ///     // `value` is of type `EntitlementGrantDeliveredWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEntitlementGrantDelivered(
        [NotNullWhen(true)] out EntitlementGrantDeliveredWebhookEvent? value
    )
    {
        value = this.Value as EntitlementGrantDeliveredWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementGrantFailedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEntitlementGrantFailed(out var value)) {
    ///     // `value` is of type `EntitlementGrantFailedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEntitlementGrantFailed(
        [NotNullWhen(true)] out EntitlementGrantFailedWebhookEvent? value
    )
    {
        value = this.Value as EntitlementGrantFailedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementGrantRevokedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEntitlementGrantRevoked(out var value)) {
    ///     // `value` is of type `EntitlementGrantRevokedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEntitlementGrantRevoked(
        [NotNullWhen(true)] out EntitlementGrantRevokedWebhookEvent? value
    )
    {
        value = this.Value as EntitlementGrantRevokedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LicenseKeyCreatedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKeyCreated(out var value)) {
    ///     // `value` is of type `LicenseKeyCreatedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKeyCreated(
        [NotNullWhen(true)] out LicenseKeyCreatedWebhookEvent? value
    )
    {
        value = this.Value as LicenseKeyCreatedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PaymentCancelledWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPaymentCancelled(out var value)) {
    ///     // `value` is of type `PaymentCancelledWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPaymentCancelled([NotNullWhen(true)] out PaymentCancelledWebhookEvent? value)
    {
        value = this.Value as PaymentCancelledWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PaymentFailedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPaymentFailed(out var value)) {
    ///     // `value` is of type `PaymentFailedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPaymentFailed([NotNullWhen(true)] out PaymentFailedWebhookEvent? value)
    {
        value = this.Value as PaymentFailedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PaymentProcessingWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPaymentProcessing(out var value)) {
    ///     // `value` is of type `PaymentProcessingWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPaymentProcessing(
        [NotNullWhen(true)] out PaymentProcessingWebhookEvent? value
    )
    {
        value = this.Value as PaymentProcessingWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PaymentSucceededWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPaymentSucceeded(out var value)) {
    ///     // `value` is of type `PaymentSucceededWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPaymentSucceeded([NotNullWhen(true)] out PaymentSucceededWebhookEvent? value)
    {
        value = this.Value as PaymentSucceededWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RefundFailedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRefundFailed(out var value)) {
    ///     // `value` is of type `RefundFailedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRefundFailed([NotNullWhen(true)] out RefundFailedWebhookEvent? value)
    {
        value = this.Value as RefundFailedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RefundSucceededWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRefundSucceeded(out var value)) {
    ///     // `value` is of type `RefundSucceededWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRefundSucceeded([NotNullWhen(true)] out RefundSucceededWebhookEvent? value)
    {
        value = this.Value as RefundSucceededWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionActiveWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscriptionActive(out var value)) {
    ///     // `value` is of type `SubscriptionActiveWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscriptionActive(
        [NotNullWhen(true)] out SubscriptionActiveWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionActiveWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionCancelledWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscriptionCancelled(out var value)) {
    ///     // `value` is of type `SubscriptionCancelledWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscriptionCancelled(
        [NotNullWhen(true)] out SubscriptionCancelledWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionCancelledWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionExpiredWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscriptionExpired(out var value)) {
    ///     // `value` is of type `SubscriptionExpiredWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscriptionExpired(
        [NotNullWhen(true)] out SubscriptionExpiredWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionExpiredWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionFailedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscriptionFailed(out var value)) {
    ///     // `value` is of type `SubscriptionFailedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscriptionFailed(
        [NotNullWhen(true)] out SubscriptionFailedWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionFailedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionOnHoldWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscriptionOnHold(out var value)) {
    ///     // `value` is of type `SubscriptionOnHoldWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscriptionOnHold(
        [NotNullWhen(true)] out SubscriptionOnHoldWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionOnHoldWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionPlanChangedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscriptionPlanChanged(out var value)) {
    ///     // `value` is of type `SubscriptionPlanChangedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscriptionPlanChanged(
        [NotNullWhen(true)] out SubscriptionPlanChangedWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionPlanChangedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionRenewedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscriptionRenewed(out var value)) {
    ///     // `value` is of type `SubscriptionRenewedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscriptionRenewed(
        [NotNullWhen(true)] out SubscriptionRenewedWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionRenewedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionUpdatedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscriptionUpdated(out var value)) {
    ///     // `value` is of type `SubscriptionUpdatedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscriptionUpdated(
        [NotNullWhen(true)] out SubscriptionUpdatedWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionUpdatedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (AbandonedCheckoutDetectedWebhookEvent value) =&gt; {...},
    ///     (AbandonedCheckoutRecoveredWebhookEvent value) =&gt; {...},
    ///     (CreditAddedWebhookEvent value) =&gt; {...},
    ///     (CreditBalanceLowWebhookEvent value) =&gt; {...},
    ///     (CreditDeductedWebhookEvent value) =&gt; {...},
    ///     (CreditExpiredWebhookEvent value) =&gt; {...},
    ///     (CreditManualAdjustmentWebhookEvent value) =&gt; {...},
    ///     (CreditOverageChargedWebhookEvent value) =&gt; {...},
    ///     (CreditOverageResetWebhookEvent value) =&gt; {...},
    ///     (CreditRolledOverWebhookEvent value) =&gt; {...},
    ///     (CreditRolloverForfeitedWebhookEvent value) =&gt; {...},
    ///     (DisputeAcceptedWebhookEvent value) =&gt; {...},
    ///     (DisputeCancelledWebhookEvent value) =&gt; {...},
    ///     (DisputeChallengedWebhookEvent value) =&gt; {...},
    ///     (DisputeExpiredWebhookEvent value) =&gt; {...},
    ///     (DisputeLostWebhookEvent value) =&gt; {...},
    ///     (DisputeOpenedWebhookEvent value) =&gt; {...},
    ///     (DisputeWonWebhookEvent value) =&gt; {...},
    ///     (DunningRecoveredWebhookEvent value) =&gt; {...},
    ///     (DunningStartedWebhookEvent value) =&gt; {...},
    ///     (EntitlementGrantCreatedWebhookEvent value) =&gt; {...},
    ///     (EntitlementGrantDeliveredWebhookEvent value) =&gt; {...},
    ///     (EntitlementGrantFailedWebhookEvent value) =&gt; {...},
    ///     (EntitlementGrantRevokedWebhookEvent value) =&gt; {...},
    ///     (LicenseKeyCreatedWebhookEvent value) =&gt; {...},
    ///     (PaymentCancelledWebhookEvent value) =&gt; {...},
    ///     (PaymentFailedWebhookEvent value) =&gt; {...},
    ///     (PaymentProcessingWebhookEvent value) =&gt; {...},
    ///     (PaymentSucceededWebhookEvent value) =&gt; {...},
    ///     (RefundFailedWebhookEvent value) =&gt; {...},
    ///     (RefundSucceededWebhookEvent value) =&gt; {...},
    ///     (SubscriptionActiveWebhookEvent value) =&gt; {...},
    ///     (SubscriptionCancelledWebhookEvent value) =&gt; {...},
    ///     (SubscriptionExpiredWebhookEvent value) =&gt; {...},
    ///     (SubscriptionFailedWebhookEvent value) =&gt; {...},
    ///     (SubscriptionOnHoldWebhookEvent value) =&gt; {...},
    ///     (SubscriptionPlanChangedWebhookEvent value) =&gt; {...},
    ///     (SubscriptionRenewedWebhookEvent value) =&gt; {...},
    ///     (SubscriptionUpdatedWebhookEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<AbandonedCheckoutDetectedWebhookEvent> abandonedCheckoutDetected,
        System::Action<AbandonedCheckoutRecoveredWebhookEvent> abandonedCheckoutRecovered,
        System::Action<CreditAddedWebhookEvent> creditAdded,
        System::Action<CreditBalanceLowWebhookEvent> creditBalanceLow,
        System::Action<CreditDeductedWebhookEvent> creditDeducted,
        System::Action<CreditExpiredWebhookEvent> creditExpired,
        System::Action<CreditManualAdjustmentWebhookEvent> creditManualAdjustment,
        System::Action<CreditOverageChargedWebhookEvent> creditOverageCharged,
        System::Action<CreditOverageResetWebhookEvent> creditOverageReset,
        System::Action<CreditRolledOverWebhookEvent> creditRolledOver,
        System::Action<CreditRolloverForfeitedWebhookEvent> creditRolloverForfeited,
        System::Action<DisputeAcceptedWebhookEvent> disputeAccepted,
        System::Action<DisputeCancelledWebhookEvent> disputeCancelled,
        System::Action<DisputeChallengedWebhookEvent> disputeChallenged,
        System::Action<DisputeExpiredWebhookEvent> disputeExpired,
        System::Action<DisputeLostWebhookEvent> disputeLost,
        System::Action<DisputeOpenedWebhookEvent> disputeOpened,
        System::Action<DisputeWonWebhookEvent> disputeWon,
        System::Action<DunningRecoveredWebhookEvent> dunningRecovered,
        System::Action<DunningStartedWebhookEvent> dunningStarted,
        System::Action<EntitlementGrantCreatedWebhookEvent> entitlementGrantCreated,
        System::Action<EntitlementGrantDeliveredWebhookEvent> entitlementGrantDelivered,
        System::Action<EntitlementGrantFailedWebhookEvent> entitlementGrantFailed,
        System::Action<EntitlementGrantRevokedWebhookEvent> entitlementGrantRevoked,
        System::Action<LicenseKeyCreatedWebhookEvent> licenseKeyCreated,
        System::Action<PaymentCancelledWebhookEvent> paymentCancelled,
        System::Action<PaymentFailedWebhookEvent> paymentFailed,
        System::Action<PaymentProcessingWebhookEvent> paymentProcessing,
        System::Action<PaymentSucceededWebhookEvent> paymentSucceeded,
        System::Action<RefundFailedWebhookEvent> refundFailed,
        System::Action<RefundSucceededWebhookEvent> refundSucceeded,
        System::Action<SubscriptionActiveWebhookEvent> subscriptionActive,
        System::Action<SubscriptionCancelledWebhookEvent> subscriptionCancelled,
        System::Action<SubscriptionExpiredWebhookEvent> subscriptionExpired,
        System::Action<SubscriptionFailedWebhookEvent> subscriptionFailed,
        System::Action<SubscriptionOnHoldWebhookEvent> subscriptionOnHold,
        System::Action<SubscriptionPlanChangedWebhookEvent> subscriptionPlanChanged,
        System::Action<SubscriptionRenewedWebhookEvent> subscriptionRenewed,
        System::Action<SubscriptionUpdatedWebhookEvent> subscriptionUpdated
    )
    {
        switch (this.Value)
        {
            case AbandonedCheckoutDetectedWebhookEvent value:
                abandonedCheckoutDetected(value);
                break;
            case AbandonedCheckoutRecoveredWebhookEvent value:
                abandonedCheckoutRecovered(value);
                break;
            case CreditAddedWebhookEvent value:
                creditAdded(value);
                break;
            case CreditBalanceLowWebhookEvent value:
                creditBalanceLow(value);
                break;
            case CreditDeductedWebhookEvent value:
                creditDeducted(value);
                break;
            case CreditExpiredWebhookEvent value:
                creditExpired(value);
                break;
            case CreditManualAdjustmentWebhookEvent value:
                creditManualAdjustment(value);
                break;
            case CreditOverageChargedWebhookEvent value:
                creditOverageCharged(value);
                break;
            case CreditOverageResetWebhookEvent value:
                creditOverageReset(value);
                break;
            case CreditRolledOverWebhookEvent value:
                creditRolledOver(value);
                break;
            case CreditRolloverForfeitedWebhookEvent value:
                creditRolloverForfeited(value);
                break;
            case DisputeAcceptedWebhookEvent value:
                disputeAccepted(value);
                break;
            case DisputeCancelledWebhookEvent value:
                disputeCancelled(value);
                break;
            case DisputeChallengedWebhookEvent value:
                disputeChallenged(value);
                break;
            case DisputeExpiredWebhookEvent value:
                disputeExpired(value);
                break;
            case DisputeLostWebhookEvent value:
                disputeLost(value);
                break;
            case DisputeOpenedWebhookEvent value:
                disputeOpened(value);
                break;
            case DisputeWonWebhookEvent value:
                disputeWon(value);
                break;
            case DunningRecoveredWebhookEvent value:
                dunningRecovered(value);
                break;
            case DunningStartedWebhookEvent value:
                dunningStarted(value);
                break;
            case EntitlementGrantCreatedWebhookEvent value:
                entitlementGrantCreated(value);
                break;
            case EntitlementGrantDeliveredWebhookEvent value:
                entitlementGrantDelivered(value);
                break;
            case EntitlementGrantFailedWebhookEvent value:
                entitlementGrantFailed(value);
                break;
            case EntitlementGrantRevokedWebhookEvent value:
                entitlementGrantRevoked(value);
                break;
            case LicenseKeyCreatedWebhookEvent value:
                licenseKeyCreated(value);
                break;
            case PaymentCancelledWebhookEvent value:
                paymentCancelled(value);
                break;
            case PaymentFailedWebhookEvent value:
                paymentFailed(value);
                break;
            case PaymentProcessingWebhookEvent value:
                paymentProcessing(value);
                break;
            case PaymentSucceededWebhookEvent value:
                paymentSucceeded(value);
                break;
            case RefundFailedWebhookEvent value:
                refundFailed(value);
                break;
            case RefundSucceededWebhookEvent value:
                refundSucceeded(value);
                break;
            case SubscriptionActiveWebhookEvent value:
                subscriptionActive(value);
                break;
            case SubscriptionCancelledWebhookEvent value:
                subscriptionCancelled(value);
                break;
            case SubscriptionExpiredWebhookEvent value:
                subscriptionExpired(value);
                break;
            case SubscriptionFailedWebhookEvent value:
                subscriptionFailed(value);
                break;
            case SubscriptionOnHoldWebhookEvent value:
                subscriptionOnHold(value);
                break;
            case SubscriptionPlanChangedWebhookEvent value:
                subscriptionPlanChanged(value);
                break;
            case SubscriptionRenewedWebhookEvent value:
                subscriptionRenewed(value);
                break;
            case SubscriptionUpdatedWebhookEvent value:
                subscriptionUpdated(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of UnwrapWebhookEvent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (AbandonedCheckoutDetectedWebhookEvent value) =&gt; {...},
    ///     (AbandonedCheckoutRecoveredWebhookEvent value) =&gt; {...},
    ///     (CreditAddedWebhookEvent value) =&gt; {...},
    ///     (CreditBalanceLowWebhookEvent value) =&gt; {...},
    ///     (CreditDeductedWebhookEvent value) =&gt; {...},
    ///     (CreditExpiredWebhookEvent value) =&gt; {...},
    ///     (CreditManualAdjustmentWebhookEvent value) =&gt; {...},
    ///     (CreditOverageChargedWebhookEvent value) =&gt; {...},
    ///     (CreditOverageResetWebhookEvent value) =&gt; {...},
    ///     (CreditRolledOverWebhookEvent value) =&gt; {...},
    ///     (CreditRolloverForfeitedWebhookEvent value) =&gt; {...},
    ///     (DisputeAcceptedWebhookEvent value) =&gt; {...},
    ///     (DisputeCancelledWebhookEvent value) =&gt; {...},
    ///     (DisputeChallengedWebhookEvent value) =&gt; {...},
    ///     (DisputeExpiredWebhookEvent value) =&gt; {...},
    ///     (DisputeLostWebhookEvent value) =&gt; {...},
    ///     (DisputeOpenedWebhookEvent value) =&gt; {...},
    ///     (DisputeWonWebhookEvent value) =&gt; {...},
    ///     (DunningRecoveredWebhookEvent value) =&gt; {...},
    ///     (DunningStartedWebhookEvent value) =&gt; {...},
    ///     (EntitlementGrantCreatedWebhookEvent value) =&gt; {...},
    ///     (EntitlementGrantDeliveredWebhookEvent value) =&gt; {...},
    ///     (EntitlementGrantFailedWebhookEvent value) =&gt; {...},
    ///     (EntitlementGrantRevokedWebhookEvent value) =&gt; {...},
    ///     (LicenseKeyCreatedWebhookEvent value) =&gt; {...},
    ///     (PaymentCancelledWebhookEvent value) =&gt; {...},
    ///     (PaymentFailedWebhookEvent value) =&gt; {...},
    ///     (PaymentProcessingWebhookEvent value) =&gt; {...},
    ///     (PaymentSucceededWebhookEvent value) =&gt; {...},
    ///     (RefundFailedWebhookEvent value) =&gt; {...},
    ///     (RefundSucceededWebhookEvent value) =&gt; {...},
    ///     (SubscriptionActiveWebhookEvent value) =&gt; {...},
    ///     (SubscriptionCancelledWebhookEvent value) =&gt; {...},
    ///     (SubscriptionExpiredWebhookEvent value) =&gt; {...},
    ///     (SubscriptionFailedWebhookEvent value) =&gt; {...},
    ///     (SubscriptionOnHoldWebhookEvent value) =&gt; {...},
    ///     (SubscriptionPlanChangedWebhookEvent value) =&gt; {...},
    ///     (SubscriptionRenewedWebhookEvent value) =&gt; {...},
    ///     (SubscriptionUpdatedWebhookEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<AbandonedCheckoutDetectedWebhookEvent, T> abandonedCheckoutDetected,
        System::Func<AbandonedCheckoutRecoveredWebhookEvent, T> abandonedCheckoutRecovered,
        System::Func<CreditAddedWebhookEvent, T> creditAdded,
        System::Func<CreditBalanceLowWebhookEvent, T> creditBalanceLow,
        System::Func<CreditDeductedWebhookEvent, T> creditDeducted,
        System::Func<CreditExpiredWebhookEvent, T> creditExpired,
        System::Func<CreditManualAdjustmentWebhookEvent, T> creditManualAdjustment,
        System::Func<CreditOverageChargedWebhookEvent, T> creditOverageCharged,
        System::Func<CreditOverageResetWebhookEvent, T> creditOverageReset,
        System::Func<CreditRolledOverWebhookEvent, T> creditRolledOver,
        System::Func<CreditRolloverForfeitedWebhookEvent, T> creditRolloverForfeited,
        System::Func<DisputeAcceptedWebhookEvent, T> disputeAccepted,
        System::Func<DisputeCancelledWebhookEvent, T> disputeCancelled,
        System::Func<DisputeChallengedWebhookEvent, T> disputeChallenged,
        System::Func<DisputeExpiredWebhookEvent, T> disputeExpired,
        System::Func<DisputeLostWebhookEvent, T> disputeLost,
        System::Func<DisputeOpenedWebhookEvent, T> disputeOpened,
        System::Func<DisputeWonWebhookEvent, T> disputeWon,
        System::Func<DunningRecoveredWebhookEvent, T> dunningRecovered,
        System::Func<DunningStartedWebhookEvent, T> dunningStarted,
        System::Func<EntitlementGrantCreatedWebhookEvent, T> entitlementGrantCreated,
        System::Func<EntitlementGrantDeliveredWebhookEvent, T> entitlementGrantDelivered,
        System::Func<EntitlementGrantFailedWebhookEvent, T> entitlementGrantFailed,
        System::Func<EntitlementGrantRevokedWebhookEvent, T> entitlementGrantRevoked,
        System::Func<LicenseKeyCreatedWebhookEvent, T> licenseKeyCreated,
        System::Func<PaymentCancelledWebhookEvent, T> paymentCancelled,
        System::Func<PaymentFailedWebhookEvent, T> paymentFailed,
        System::Func<PaymentProcessingWebhookEvent, T> paymentProcessing,
        System::Func<PaymentSucceededWebhookEvent, T> paymentSucceeded,
        System::Func<RefundFailedWebhookEvent, T> refundFailed,
        System::Func<RefundSucceededWebhookEvent, T> refundSucceeded,
        System::Func<SubscriptionActiveWebhookEvent, T> subscriptionActive,
        System::Func<SubscriptionCancelledWebhookEvent, T> subscriptionCancelled,
        System::Func<SubscriptionExpiredWebhookEvent, T> subscriptionExpired,
        System::Func<SubscriptionFailedWebhookEvent, T> subscriptionFailed,
        System::Func<SubscriptionOnHoldWebhookEvent, T> subscriptionOnHold,
        System::Func<SubscriptionPlanChangedWebhookEvent, T> subscriptionPlanChanged,
        System::Func<SubscriptionRenewedWebhookEvent, T> subscriptionRenewed,
        System::Func<SubscriptionUpdatedWebhookEvent, T> subscriptionUpdated
    )
    {
        return this.Value switch
        {
            AbandonedCheckoutDetectedWebhookEvent value => abandonedCheckoutDetected(value),
            AbandonedCheckoutRecoveredWebhookEvent value => abandonedCheckoutRecovered(value),
            CreditAddedWebhookEvent value => creditAdded(value),
            CreditBalanceLowWebhookEvent value => creditBalanceLow(value),
            CreditDeductedWebhookEvent value => creditDeducted(value),
            CreditExpiredWebhookEvent value => creditExpired(value),
            CreditManualAdjustmentWebhookEvent value => creditManualAdjustment(value),
            CreditOverageChargedWebhookEvent value => creditOverageCharged(value),
            CreditOverageResetWebhookEvent value => creditOverageReset(value),
            CreditRolledOverWebhookEvent value => creditRolledOver(value),
            CreditRolloverForfeitedWebhookEvent value => creditRolloverForfeited(value),
            DisputeAcceptedWebhookEvent value => disputeAccepted(value),
            DisputeCancelledWebhookEvent value => disputeCancelled(value),
            DisputeChallengedWebhookEvent value => disputeChallenged(value),
            DisputeExpiredWebhookEvent value => disputeExpired(value),
            DisputeLostWebhookEvent value => disputeLost(value),
            DisputeOpenedWebhookEvent value => disputeOpened(value),
            DisputeWonWebhookEvent value => disputeWon(value),
            DunningRecoveredWebhookEvent value => dunningRecovered(value),
            DunningStartedWebhookEvent value => dunningStarted(value),
            EntitlementGrantCreatedWebhookEvent value => entitlementGrantCreated(value),
            EntitlementGrantDeliveredWebhookEvent value => entitlementGrantDelivered(value),
            EntitlementGrantFailedWebhookEvent value => entitlementGrantFailed(value),
            EntitlementGrantRevokedWebhookEvent value => entitlementGrantRevoked(value),
            LicenseKeyCreatedWebhookEvent value => licenseKeyCreated(value),
            PaymentCancelledWebhookEvent value => paymentCancelled(value),
            PaymentFailedWebhookEvent value => paymentFailed(value),
            PaymentProcessingWebhookEvent value => paymentProcessing(value),
            PaymentSucceededWebhookEvent value => paymentSucceeded(value),
            RefundFailedWebhookEvent value => refundFailed(value),
            RefundSucceededWebhookEvent value => refundSucceeded(value),
            SubscriptionActiveWebhookEvent value => subscriptionActive(value),
            SubscriptionCancelledWebhookEvent value => subscriptionCancelled(value),
            SubscriptionExpiredWebhookEvent value => subscriptionExpired(value),
            SubscriptionFailedWebhookEvent value => subscriptionFailed(value),
            SubscriptionOnHoldWebhookEvent value => subscriptionOnHold(value),
            SubscriptionPlanChangedWebhookEvent value => subscriptionPlanChanged(value),
            SubscriptionRenewedWebhookEvent value => subscriptionRenewed(value),
            SubscriptionUpdatedWebhookEvent value => subscriptionUpdated(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of UnwrapWebhookEvent"
            ),
        };
    }

    public static implicit operator UnwrapWebhookEvent(
        AbandonedCheckoutDetectedWebhookEvent value
    ) => new(value);

    public static implicit operator UnwrapWebhookEvent(
        AbandonedCheckoutRecoveredWebhookEvent value
    ) => new(value);

    public static implicit operator UnwrapWebhookEvent(CreditAddedWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(CreditBalanceLowWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(CreditDeductedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(CreditExpiredWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(CreditManualAdjustmentWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(CreditOverageChargedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(CreditOverageResetWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(CreditRolledOverWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(CreditRolloverForfeitedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(DisputeAcceptedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(DisputeCancelledWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(DisputeChallengedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(DisputeExpiredWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(DisputeLostWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(DisputeOpenedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(DisputeWonWebhookEvent value) => new(value);

    public static implicit operator UnwrapWebhookEvent(DunningRecoveredWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(DunningStartedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(EntitlementGrantCreatedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(
        EntitlementGrantDeliveredWebhookEvent value
    ) => new(value);

    public static implicit operator UnwrapWebhookEvent(EntitlementGrantFailedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(EntitlementGrantRevokedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(LicenseKeyCreatedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PaymentCancelledWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PaymentFailedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PaymentProcessingWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(PaymentSucceededWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(RefundFailedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(RefundSucceededWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SubscriptionActiveWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SubscriptionCancelledWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SubscriptionExpiredWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SubscriptionFailedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SubscriptionOnHoldWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SubscriptionPlanChangedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SubscriptionRenewedWebhookEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(SubscriptionUpdatedWebhookEvent value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of UnwrapWebhookEvent"
            );
        }
        this.Switch(
            (abandonedCheckoutDetected) => abandonedCheckoutDetected.Validate(),
            (abandonedCheckoutRecovered) => abandonedCheckoutRecovered.Validate(),
            (creditAdded) => creditAdded.Validate(),
            (creditBalanceLow) => creditBalanceLow.Validate(),
            (creditDeducted) => creditDeducted.Validate(),
            (creditExpired) => creditExpired.Validate(),
            (creditManualAdjustment) => creditManualAdjustment.Validate(),
            (creditOverageCharged) => creditOverageCharged.Validate(),
            (creditOverageReset) => creditOverageReset.Validate(),
            (creditRolledOver) => creditRolledOver.Validate(),
            (creditRolloverForfeited) => creditRolloverForfeited.Validate(),
            (disputeAccepted) => disputeAccepted.Validate(),
            (disputeCancelled) => disputeCancelled.Validate(),
            (disputeChallenged) => disputeChallenged.Validate(),
            (disputeExpired) => disputeExpired.Validate(),
            (disputeLost) => disputeLost.Validate(),
            (disputeOpened) => disputeOpened.Validate(),
            (disputeWon) => disputeWon.Validate(),
            (dunningRecovered) => dunningRecovered.Validate(),
            (dunningStarted) => dunningStarted.Validate(),
            (entitlementGrantCreated) => entitlementGrantCreated.Validate(),
            (entitlementGrantDelivered) => entitlementGrantDelivered.Validate(),
            (entitlementGrantFailed) => entitlementGrantFailed.Validate(),
            (entitlementGrantRevoked) => entitlementGrantRevoked.Validate(),
            (licenseKeyCreated) => licenseKeyCreated.Validate(),
            (paymentCancelled) => paymentCancelled.Validate(),
            (paymentFailed) => paymentFailed.Validate(),
            (paymentProcessing) => paymentProcessing.Validate(),
            (paymentSucceeded) => paymentSucceeded.Validate(),
            (refundFailed) => refundFailed.Validate(),
            (refundSucceeded) => refundSucceeded.Validate(),
            (subscriptionActive) => subscriptionActive.Validate(),
            (subscriptionCancelled) => subscriptionCancelled.Validate(),
            (subscriptionExpired) => subscriptionExpired.Validate(),
            (subscriptionFailed) => subscriptionFailed.Validate(),
            (subscriptionOnHold) => subscriptionOnHold.Validate(),
            (subscriptionPlanChanged) => subscriptionPlanChanged.Validate(),
            (subscriptionRenewed) => subscriptionRenewed.Validate(),
            (subscriptionUpdated) => subscriptionUpdated.Validate()
        );
    }

    public virtual bool Equals(UnwrapWebhookEvent? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            AbandonedCheckoutDetectedWebhookEvent _ => 0,
            AbandonedCheckoutRecoveredWebhookEvent _ => 1,
            CreditAddedWebhookEvent _ => 2,
            CreditBalanceLowWebhookEvent _ => 3,
            CreditDeductedWebhookEvent _ => 4,
            CreditExpiredWebhookEvent _ => 5,
            CreditManualAdjustmentWebhookEvent _ => 6,
            CreditOverageChargedWebhookEvent _ => 7,
            CreditOverageResetWebhookEvent _ => 8,
            CreditRolledOverWebhookEvent _ => 9,
            CreditRolloverForfeitedWebhookEvent _ => 10,
            DisputeAcceptedWebhookEvent _ => 11,
            DisputeCancelledWebhookEvent _ => 12,
            DisputeChallengedWebhookEvent _ => 13,
            DisputeExpiredWebhookEvent _ => 14,
            DisputeLostWebhookEvent _ => 15,
            DisputeOpenedWebhookEvent _ => 16,
            DisputeWonWebhookEvent _ => 17,
            DunningRecoveredWebhookEvent _ => 18,
            DunningStartedWebhookEvent _ => 19,
            EntitlementGrantCreatedWebhookEvent _ => 20,
            EntitlementGrantDeliveredWebhookEvent _ => 21,
            EntitlementGrantFailedWebhookEvent _ => 22,
            EntitlementGrantRevokedWebhookEvent _ => 23,
            LicenseKeyCreatedWebhookEvent _ => 24,
            PaymentCancelledWebhookEvent _ => 25,
            PaymentFailedWebhookEvent _ => 26,
            PaymentProcessingWebhookEvent _ => 27,
            PaymentSucceededWebhookEvent _ => 28,
            RefundFailedWebhookEvent _ => 29,
            RefundSucceededWebhookEvent _ => 30,
            SubscriptionActiveWebhookEvent _ => 31,
            SubscriptionCancelledWebhookEvent _ => 32,
            SubscriptionExpiredWebhookEvent _ => 33,
            SubscriptionFailedWebhookEvent _ => 34,
            SubscriptionOnHoldWebhookEvent _ => 35,
            SubscriptionPlanChangedWebhookEvent _ => 36,
            SubscriptionRenewedWebhookEvent _ => 37,
            SubscriptionUpdatedWebhookEvent _ => 38,
            _ => -1,
        };
    }
}

sealed class UnwrapWebhookEventConverter : JsonConverter<UnwrapWebhookEvent>
{
    public override UnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "abandoned_checkout.detected":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<AbandonedCheckoutDetectedWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "abandoned_checkout.recovered":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<AbandonedCheckoutRecoveredWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.added":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditAddedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.balance_low":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditBalanceLowWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.deducted":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditDeductedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.expired":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditExpiredWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.manual_adjustment":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CreditManualAdjustmentWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.overage_charged":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditOverageChargedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.overage_reset":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditOverageResetWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.rolled_over":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditRolledOverWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit.rollover_forfeited":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CreditRolloverForfeitedWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dispute.accepted":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DisputeAcceptedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dispute.cancelled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DisputeCancelledWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dispute.challenged":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DisputeChallengedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dispute.expired":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DisputeExpiredWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dispute.lost":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DisputeLostWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dispute.opened":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DisputeOpenedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dispute.won":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DisputeWonWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dunning.recovered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DunningRecoveredWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "dunning.started":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DunningStartedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "entitlement_grant.created":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<EntitlementGrantCreatedWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "entitlement_grant.delivered":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<EntitlementGrantDeliveredWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "entitlement_grant.failed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<EntitlementGrantFailedWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "entitlement_grant.revoked":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<EntitlementGrantRevokedWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "license_key.created":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "payment.cancelled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PaymentCancelledWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "payment.failed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PaymentFailedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "payment.processing":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PaymentProcessingWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "payment.succeeded":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PaymentSucceededWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "refund.failed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RefundFailedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "refund.succeeded":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RefundSucceededWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "subscription.active":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SubscriptionActiveWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "subscription.cancelled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionCancelledWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "subscription.expired":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SubscriptionExpiredWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "subscription.failed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SubscriptionFailedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "subscription.on_hold":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SubscriptionOnHoldWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "subscription.plan_changed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionPlanChangedWebhookEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "subscription.renewed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SubscriptionRenewedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "subscription.updated":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SubscriptionUpdatedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new UnwrapWebhookEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
