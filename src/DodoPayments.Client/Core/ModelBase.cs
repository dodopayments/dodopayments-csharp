using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Brands;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.WebhookEvents;
using Meters = DodoPayments.Client.Models.Meters;
using Payments = DodoPayments.Client.Models.Payments;
using Payouts = DodoPayments.Client.Models.Payouts;
using Refunds = DodoPayments.Client.Models.Refunds;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using Webhooks = DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, CheckoutSessionRequestCustomizationTheme>(),
            new ApiEnumConverter<string, Currency>(),
            new ApiEnumConverter<string, Theme>(),
            new ApiEnumConverter<string, Payments::IntentStatus>(),
            new ApiEnumConverter<string, Payments::PaymentMethodTypes>(),
            new ApiEnumConverter<string, Payments::Status>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionStatus>(),
            new ApiEnumConverter<string, Subscriptions::TimeInterval>(),
            new ApiEnumConverter<string, Subscriptions::Status>(),
            new ApiEnumConverter<string, Subscriptions::ProrationBillingMode>(),
            new ApiEnumConverter<string, Subscriptions::Type>(),
            new ApiEnumConverter<string, Subscriptions::ExistingType>(),
            new ApiEnumConverter<string, LicenseKeyStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, PaymentMethod>(),
            new ApiEnumConverter<string, EventType>(),
            new ApiEnumConverter<string, EntryType>(),
            new ApiEnumConverter<string, Refunds::RefundStatus>(),
            new ApiEnumConverter<string, Refunds::Status>(),
            new ApiEnumConverter<string, DisputeDisputeStage>(),
            new ApiEnumConverter<string, DisputeDisputeStatus>(),
            new ApiEnumConverter<string, DisputeStage>(),
            new ApiEnumConverter<string, DisputeStatus>(),
            new ApiEnumConverter<string, Payouts::Status>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, RecurringPriceType>(),
            new ApiEnumConverter<string, UsageBasedPriceType>(),
            new ApiEnumConverter<string, TaxCategory>(),
            new ApiEnumConverter<string, CountryCode>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, VerificationStatus>(),
            new ApiEnumConverter<string, Webhooks::PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type>(),
            new ApiEnumConverter<
                string,
                Webhooks::DisputeCancelledWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::DisputeCancelledWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::DisputeChallengedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::DisputeChallengedWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::DisputeExpiredWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::DisputeExpiredWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::DisputeLostWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::DisputeLostWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::DisputeOpenedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::DisputeOpenedWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::DisputeWonWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::DisputeWonWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::LicenseKeyCreatedWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::PaymentCancelledWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::PaymentCancelledWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::PaymentFailedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::PaymentFailedWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::PaymentProcessingWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::PaymentProcessingWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::PaymentSucceededWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::PaymentSucceededWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::RefundFailedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::RefundFailedWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::RefundSucceededWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::RefundSucceededWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::SubscriptionActiveWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::SubscriptionActiveWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::SubscriptionCancelledWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::SubscriptionCancelledWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::SubscriptionExpiredWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::SubscriptionExpiredWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::SubscriptionFailedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::SubscriptionFailedWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::SubscriptionOnHoldWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::SubscriptionOnHoldWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::SubscriptionPlanChangedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::SubscriptionPlanChangedWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::SubscriptionRenewedWebhookEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Webhooks::DisputeAcceptedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DataModelIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::TypeModel>(),
            new ApiEnumConverter<string, Webhooks::Data1IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type1>(),
            new ApiEnumConverter<string, Webhooks::Data2IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type2>(),
            new ApiEnumConverter<string, Webhooks::Data3IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type3>(),
            new ApiEnumConverter<string, Webhooks::Data4IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type4>(),
            new ApiEnumConverter<string, Webhooks::Data5IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type5>(),
            new ApiEnumConverter<string, Webhooks::Data6IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type6>(),
            new ApiEnumConverter<string, Webhooks::Data7IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type7>(),
            new ApiEnumConverter<string, Webhooks::Data8IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type8>(),
            new ApiEnumConverter<string, Webhooks::Data9IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type9>(),
            new ApiEnumConverter<string, Webhooks::Data10IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type10>(),
            new ApiEnumConverter<string, Webhooks::Data11IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type11>(),
            new ApiEnumConverter<string, Webhooks::Data12IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type12>(),
            new ApiEnumConverter<string, Webhooks::Data13IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type13>(),
            new ApiEnumConverter<string, Webhooks::Data14IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type14>(),
            new ApiEnumConverter<string, Webhooks::Data15IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type15>(),
            new ApiEnumConverter<string, Webhooks::Data16IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type16>(),
            new ApiEnumConverter<string, Webhooks::Data17IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type17>(),
            new ApiEnumConverter<string, Webhooks::Data18IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type18>(),
            new ApiEnumConverter<string, Webhooks::Data19IntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Webhooks::Type19>(),
            new ApiEnumConverter<string, WebhookEventType>(),
            new ApiEnumConverter<string, PayloadType>(),
            new ApiEnumConverter<string, SubscriptionIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, RefundIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, DisputeIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, LicenseKeyIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Meters::Type>(),
            new ApiEnumConverter<string, Meters::Operator>(),
            new ApiEnumConverter<string, Meters::MeterFilterConditionModelOperator>(),
            new ApiEnumConverter<string, Meters::MeterFilterCondition1Operator>(),
            new ApiEnumConverter<string, Meters::ClauseOperator>(),
            new ApiEnumConverter<string, Meters::Conjunction>(),
            new ApiEnumConverter<string, Meters::MeterFilterModelConjunction>(),
            new ApiEnumConverter<string, Meters::MeterFilterConjunction>(),
            new ApiEnumConverter<string, Meters::MeterMeterFilterConjunction>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
