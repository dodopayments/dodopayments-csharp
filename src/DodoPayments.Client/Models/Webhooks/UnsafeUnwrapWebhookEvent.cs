using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(UnsafeUnwrapWebhookEventConverter))]
public record class UnsafeUnwrapWebhookEvent
{
    public object Value { get; private init; }

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

    public UnsafeUnwrapWebhookEvent(DisputeAcceptedWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(DisputeCancelledWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(DisputeChallengedWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(DisputeExpiredWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(DisputeLostWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(DisputeOpenedWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(DisputeWonWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(LicenseKeyCreatedWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(PaymentCancelledWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(PaymentFailedWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(PaymentProcessingWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(PaymentSucceededWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(RefundFailedWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(RefundSucceededWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionActiveWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionCancelledWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionExpiredWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionFailedWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionOnHoldWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionPlanChangedWebhookEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(SubscriptionRenewedWebhookEvent value)
    {
        Value = value;
    }

    UnsafeUnwrapWebhookEvent(UnknownVariant value)
    {
        Value = value;
    }

    public static UnsafeUnwrapWebhookEvent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class UnsafeUnwrapWebhookEventConverter : JsonConverter<UnsafeUnwrapWebhookEvent>
{
    public override UnsafeUnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeAcceptedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DisputeAcceptedWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeCancelledWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DisputeCancelledWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeChallengedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DisputeChallengedWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeExpiredWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DisputeExpiredWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeLostWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DisputeLostWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeOpenedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DisputeOpenedWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DisputeWonWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DisputeWonWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'LicenseKeyCreatedWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentCancelledWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'PaymentCancelledWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentFailedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'PaymentFailedWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentProcessingWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'PaymentProcessingWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PaymentSucceededWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'PaymentSucceededWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RefundFailedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'RefundFailedWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RefundSucceededWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'RefundSucceededWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionActiveWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'SubscriptionActiveWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionCancelledWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'SubscriptionCancelledWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionExpiredWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'SubscriptionExpiredWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionFailedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'SubscriptionFailedWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionOnHoldWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'SubscriptionOnHoldWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionPlanChangedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'SubscriptionPlanChangedWebhookEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SubscriptionRenewedWebhookEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'SubscriptionRenewedWebhookEvent'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnsafeUnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
