using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(UnsafeUnwrapWebhookEventConverter))]
public record class UnsafeUnwrapWebhookEvent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string BusinessID
    {
        get
        {
            return Match(
                disputeAccepted: (x) => x.BusinessID,
                disputeCancelled: (x) => x.BusinessID,
                disputeChallenged: (x) => x.BusinessID,
                disputeExpired: (x) => x.BusinessID,
                disputeLost: (x) => x.BusinessID,
                disputeOpened: (x) => x.BusinessID,
                disputeWon: (x) => x.BusinessID,
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
                subscriptionRenewed: (x) => x.BusinessID
            );
        }
    }

    public System::DateTimeOffset Timestamp
    {
        get
        {
            return Match(
                disputeAccepted: (x) => x.Timestamp,
                disputeCancelled: (x) => x.Timestamp,
                disputeChallenged: (x) => x.Timestamp,
                disputeExpired: (x) => x.Timestamp,
                disputeLost: (x) => x.Timestamp,
                disputeOpened: (x) => x.Timestamp,
                disputeWon: (x) => x.Timestamp,
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
                subscriptionRenewed: (x) => x.Timestamp
            );
        }
    }

    public UnsafeUnwrapWebhookEvent(DisputeAcceptedWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(DisputeCancelledWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(DisputeChallengedWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(DisputeExpiredWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(DisputeLostWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(DisputeOpenedWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(DisputeWonWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(LicenseKeyCreatedWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(PaymentCancelledWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(PaymentFailedWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(PaymentProcessingWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(PaymentSucceededWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(RefundFailedWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(RefundSucceededWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionActiveWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionCancelledWebhookEvent value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionExpiredWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionFailedWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionOnHoldWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(
        SubscriptionPlanChangedWebhookEvent value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionRenewedWebhookEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UnsafeUnwrapWebhookEvent(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDisputeAccepted([NotNullWhen(true)] out DisputeAcceptedWebhookEvent? value)
    {
        value = this.Value as DisputeAcceptedWebhookEvent;
        return value != null;
    }

    public bool TryPickDisputeCancelled([NotNullWhen(true)] out DisputeCancelledWebhookEvent? value)
    {
        value = this.Value as DisputeCancelledWebhookEvent;
        return value != null;
    }

    public bool TryPickDisputeChallenged(
        [NotNullWhen(true)] out DisputeChallengedWebhookEvent? value
    )
    {
        value = this.Value as DisputeChallengedWebhookEvent;
        return value != null;
    }

    public bool TryPickDisputeExpired([NotNullWhen(true)] out DisputeExpiredWebhookEvent? value)
    {
        value = this.Value as DisputeExpiredWebhookEvent;
        return value != null;
    }

    public bool TryPickDisputeLost([NotNullWhen(true)] out DisputeLostWebhookEvent? value)
    {
        value = this.Value as DisputeLostWebhookEvent;
        return value != null;
    }

    public bool TryPickDisputeOpened([NotNullWhen(true)] out DisputeOpenedWebhookEvent? value)
    {
        value = this.Value as DisputeOpenedWebhookEvent;
        return value != null;
    }

    public bool TryPickDisputeWon([NotNullWhen(true)] out DisputeWonWebhookEvent? value)
    {
        value = this.Value as DisputeWonWebhookEvent;
        return value != null;
    }

    public bool TryPickLicenseKeyCreated(
        [NotNullWhen(true)] out LicenseKeyCreatedWebhookEvent? value
    )
    {
        value = this.Value as LicenseKeyCreatedWebhookEvent;
        return value != null;
    }

    public bool TryPickPaymentCancelled([NotNullWhen(true)] out PaymentCancelledWebhookEvent? value)
    {
        value = this.Value as PaymentCancelledWebhookEvent;
        return value != null;
    }

    public bool TryPickPaymentFailed([NotNullWhen(true)] out PaymentFailedWebhookEvent? value)
    {
        value = this.Value as PaymentFailedWebhookEvent;
        return value != null;
    }

    public bool TryPickPaymentProcessing(
        [NotNullWhen(true)] out PaymentProcessingWebhookEvent? value
    )
    {
        value = this.Value as PaymentProcessingWebhookEvent;
        return value != null;
    }

    public bool TryPickPaymentSucceeded([NotNullWhen(true)] out PaymentSucceededWebhookEvent? value)
    {
        value = this.Value as PaymentSucceededWebhookEvent;
        return value != null;
    }

    public bool TryPickRefundFailed([NotNullWhen(true)] out RefundFailedWebhookEvent? value)
    {
        value = this.Value as RefundFailedWebhookEvent;
        return value != null;
    }

    public bool TryPickRefundSucceeded([NotNullWhen(true)] out RefundSucceededWebhookEvent? value)
    {
        value = this.Value as RefundSucceededWebhookEvent;
        return value != null;
    }

    public bool TryPickSubscriptionActive(
        [NotNullWhen(true)] out SubscriptionActiveWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionActiveWebhookEvent;
        return value != null;
    }

    public bool TryPickSubscriptionCancelled(
        [NotNullWhen(true)] out SubscriptionCancelledWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionCancelledWebhookEvent;
        return value != null;
    }

    public bool TryPickSubscriptionExpired(
        [NotNullWhen(true)] out SubscriptionExpiredWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionExpiredWebhookEvent;
        return value != null;
    }

    public bool TryPickSubscriptionFailed(
        [NotNullWhen(true)] out SubscriptionFailedWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionFailedWebhookEvent;
        return value != null;
    }

    public bool TryPickSubscriptionOnHold(
        [NotNullWhen(true)] out SubscriptionOnHoldWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionOnHoldWebhookEvent;
        return value != null;
    }

    public bool TryPickSubscriptionPlanChanged(
        [NotNullWhen(true)] out SubscriptionPlanChangedWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionPlanChangedWebhookEvent;
        return value != null;
    }

    public bool TryPickSubscriptionRenewed(
        [NotNullWhen(true)] out SubscriptionRenewedWebhookEvent? value
    )
    {
        value = this.Value as SubscriptionRenewedWebhookEvent;
        return value != null;
    }

    public void Switch(
        System::Action<DisputeAcceptedWebhookEvent> disputeAccepted,
        System::Action<DisputeCancelledWebhookEvent> disputeCancelled,
        System::Action<DisputeChallengedWebhookEvent> disputeChallenged,
        System::Action<DisputeExpiredWebhookEvent> disputeExpired,
        System::Action<DisputeLostWebhookEvent> disputeLost,
        System::Action<DisputeOpenedWebhookEvent> disputeOpened,
        System::Action<DisputeWonWebhookEvent> disputeWon,
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
        System::Action<SubscriptionRenewedWebhookEvent> subscriptionRenewed
    )
    {
        switch (this.Value)
        {
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
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of UnsafeUnwrapWebhookEvent"
                );
        }
    }

    public T Match<T>(
        System::Func<DisputeAcceptedWebhookEvent, T> disputeAccepted,
        System::Func<DisputeCancelledWebhookEvent, T> disputeCancelled,
        System::Func<DisputeChallengedWebhookEvent, T> disputeChallenged,
        System::Func<DisputeExpiredWebhookEvent, T> disputeExpired,
        System::Func<DisputeLostWebhookEvent, T> disputeLost,
        System::Func<DisputeOpenedWebhookEvent, T> disputeOpened,
        System::Func<DisputeWonWebhookEvent, T> disputeWon,
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
        System::Func<SubscriptionRenewedWebhookEvent, T> subscriptionRenewed
    )
    {
        return this.Value switch
        {
            DisputeAcceptedWebhookEvent value => disputeAccepted(value),
            DisputeCancelledWebhookEvent value => disputeCancelled(value),
            DisputeChallengedWebhookEvent value => disputeChallenged(value),
            DisputeExpiredWebhookEvent value => disputeExpired(value),
            DisputeLostWebhookEvent value => disputeLost(value),
            DisputeOpenedWebhookEvent value => disputeOpened(value),
            DisputeWonWebhookEvent value => disputeWon(value),
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
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            ),
        };
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            );
        }
    }

    public virtual bool Equals(UnsafeUnwrapWebhookEvent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeAcceptedWebhookEvent>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeLostWebhookEvent>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeOpenedWebhookEvent>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeWonWebhookEvent>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentFailedWebhookEvent>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RefundFailedWebhookEvent>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
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
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
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
