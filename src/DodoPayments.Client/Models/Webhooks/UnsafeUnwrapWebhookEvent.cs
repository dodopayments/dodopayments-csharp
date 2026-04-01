using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(UnsafeUnwrapWebhookEventConverter))]
public record class UnsafeUnwrapWebhookEvent : ModelBase
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
                abandonedCheckoutRecovered: (x) => x.STAINLESS_FIXME_BusinessID,
                creditAdded: (x) => x.BusinessID,
                creditBalanceLow: (x) => x.BusinessID,
                creditDeducted: (x) => x.BusinessID,
                creditExpired: (x) => x.BusinessID,
                creditManualAdjustment: (x) => x.BusinessID,
                creditOverageCharged: (x) => x.BusinessID,
                creditRolledOver: (x) => x.BusinessID,
                creditRolloverForfeited: (x) => x.BusinessID,
                disputeAccepted: (x) => x.BusinessID,
                disputeCancelled: (x) => x.BusinessID,
                disputeChallenged: (x) => x.BusinessID,
                disputeExpired: (x) => x.BusinessID,
                disputeLost: (x) => x.BusinessID,
                disputeOpened: (x) => x.BusinessID,
                disputeWon: (x) => x.BusinessID,
                dunningRecovered: (x) => x.STAINLESS_FIXME_BusinessID,
                dunningStarted: (x) => x.STAINLESS_FIXME_BusinessID,
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
                abandonedCheckoutRecovered: (x) => x.STAINLESS_FIXME_Timestamp,
                creditAdded: (x) => x.Timestamp,
                creditBalanceLow: (x) => x.Timestamp,
                creditDeducted: (x) => x.Timestamp,
                creditExpired: (x) => x.Timestamp,
                creditManualAdjustment: (x) => x.Timestamp,
                creditOverageCharged: (x) => x.Timestamp,
                creditRolledOver: (x) => x.Timestamp,
                creditRolloverForfeited: (x) => x.Timestamp,
                disputeAccepted: (x) => x.Timestamp,
                disputeCancelled: (x) => x.Timestamp,
                disputeChallenged: (x) => x.Timestamp,
                disputeExpired: (x) => x.Timestamp,
                disputeLost: (x) => x.Timestamp,
                disputeOpened: (x) => x.Timestamp,
                disputeWon: (x) => x.Timestamp,
                dunningRecovered: (x) => x.STAINLESS_FIXME_Timestamp,
                dunningStarted: (x) => x.STAINLESS_FIXME_Timestamp,
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

    public UnsafeUnwrapWebhookEvent(
        AbandonedCheckoutDetectedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        AbandonedCheckoutRecoveredWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(CreditAddedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(CreditBalanceLowWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(CreditDeductedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(CreditExpiredWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        CreditManualAdjustmentWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        CreditOverageChargedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(CreditRolledOverWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        CreditRolloverForfeitedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(DisputeAcceptedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(DisputeCancelledWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        DisputeChallengedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(DisputeExpiredWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(DisputeLostWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(DisputeOpenedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(DisputeWonWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(DunningRecoveredWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(DunningStartedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        LicenseKeyCreatedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(PaymentCancelledWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(PaymentFailedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        PaymentProcessingWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(PaymentSucceededWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(RefundFailedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(RefundSucceededWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionActiveWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionCancelledWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionExpiredWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionFailedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionOnHoldWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionPlanChangedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionRenewedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionUpdatedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(JsonElement element)
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
                    "Data did not match any variant of UnsafeUnwrapWebhookEvent"
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
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            ),
        };
    }

    public static implicit operator UnsafeUnwrapWebhookEvent(
        AbandonedCheckoutDetectedWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        AbandonedCheckoutRecoveredWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(CreditAddedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(CreditBalanceLowWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(CreditDeductedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(CreditExpiredWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        CreditManualAdjustmentWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        CreditOverageChargedWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(CreditRolledOverWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        CreditRolloverForfeitedWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DisputeAcceptedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DisputeCancelledWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DisputeChallengedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DisputeExpiredWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DisputeLostWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DisputeOpenedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DisputeWonWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DunningRecoveredWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(DunningStartedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(LicenseKeyCreatedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(PaymentCancelledWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(PaymentFailedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(PaymentProcessingWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(PaymentSucceededWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(RefundFailedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(RefundSucceededWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        SubscriptionActiveWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        SubscriptionCancelledWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        SubscriptionExpiredWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        SubscriptionFailedWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        SubscriptionOnHoldWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        SubscriptionPlanChangedWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        SubscriptionRenewedWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        SubscriptionUpdatedWebhookEvent value
    ) => new(value);

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
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
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

    public virtual bool Equals(UnsafeUnwrapWebhookEvent? other) =>
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
            CreditRolledOverWebhookEvent _ => 8,
            CreditRolloverForfeitedWebhookEvent _ => 9,
            DisputeAcceptedWebhookEvent _ => 10,
            DisputeCancelledWebhookEvent _ => 11,
            DisputeChallengedWebhookEvent _ => 12,
            DisputeExpiredWebhookEvent _ => 13,
            DisputeLostWebhookEvent _ => 14,
            DisputeOpenedWebhookEvent _ => 15,
            DisputeWonWebhookEvent _ => 16,
            DunningRecoveredWebhookEvent _ => 17,
            DunningStartedWebhookEvent _ => 18,
            LicenseKeyCreatedWebhookEvent _ => 19,
            PaymentCancelledWebhookEvent _ => 20,
            PaymentFailedWebhookEvent _ => 21,
            PaymentProcessingWebhookEvent _ => 22,
            PaymentSucceededWebhookEvent _ => 23,
            RefundFailedWebhookEvent _ => 24,
            RefundSucceededWebhookEvent _ => 25,
            SubscriptionActiveWebhookEvent _ => 26,
            SubscriptionCancelledWebhookEvent _ => 27,
            SubscriptionExpiredWebhookEvent _ => 28,
            SubscriptionFailedWebhookEvent _ => 29,
            SubscriptionOnHoldWebhookEvent _ => 30,
            SubscriptionPlanChangedWebhookEvent _ => 31,
            SubscriptionRenewedWebhookEvent _ => 32,
            SubscriptionUpdatedWebhookEvent _ => 33,
            _ => -1,
        };
    }
}

sealed class UnsafeUnwrapWebhookEventConverter : JsonConverter<UnsafeUnwrapWebhookEvent>
{
    public override UnsafeUnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AbandonedCheckoutDetectedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AbandonedCheckoutRecoveredWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreditAddedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreditBalanceLowWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreditDeductedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreditExpiredWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreditManualAdjustmentWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreditOverageChargedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreditRolledOverWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreditRolloverForfeitedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeAcceptedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeCancelledWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeChallengedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeExpiredWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeLostWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeOpenedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeWonWebhookEvent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DunningRecoveredWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DunningStartedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentCancelledWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentFailedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentProcessingWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentSucceededWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RefundFailedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RefundSucceededWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionActiveWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionCancelledWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionExpiredWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionFailedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionOnHoldWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionPlanChangedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionRenewedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionUpdatedWebhookEvent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnsafeUnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
