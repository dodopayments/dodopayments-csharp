using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Brands.BrandProperties;
using DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionRequestProperties.CustomizationProperties;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries.CustomerWalletTransactionProperties;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries.LedgerEntryCreateParamsProperties;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties;
using DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Payments.PaymentListParamsProperties;
using DodoPayments.Client.Models.Products.PriceProperties.OneTimePriceProperties;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.Subscriptions;
using DodoPayments.Client.Models.Subscriptions.SubscriptionChangePlanParamsProperties;
using DodoPayments.Client.Models.WebhookEvents;
using DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.PaymentProperties.IntersectionMember1Properties;
using ClauseProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClauseProperties;
using CustomizationProperties = DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionCreateParamsProperties.CustomizationProperties;
using DisputeAcceptedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.DisputeAcceptedWebhookEventProperties;
using DisputeCancelledWebhookEventProperties = DodoPayments.Client.Models.Webhooks.DisputeCancelledWebhookEventProperties;
using DisputeChallengedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.DisputeChallengedWebhookEventProperties;
using DisputeExpiredWebhookEventProperties = DodoPayments.Client.Models.Webhooks.DisputeExpiredWebhookEventProperties;
using DisputeListParamsProperties = DodoPayments.Client.Models.Disputes.DisputeListParamsProperties;
using DisputeLostWebhookEventProperties = DodoPayments.Client.Models.Webhooks.DisputeLostWebhookEventProperties;
using DisputeOpenedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.DisputeOpenedWebhookEventProperties;
using DisputeWonWebhookEventProperties = DodoPayments.Client.Models.Webhooks.DisputeWonWebhookEventProperties;
using IntersectionMember1Properties = DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.SubscriptionProperties.IntersectionMember1Properties;
using ItemProperties = DodoPayments.Client.Models.Payouts.PayoutListPageResponseProperties.ItemProperties;
using LicenseKeyCreatedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.LicenseKeyCreatedWebhookEventProperties;
using LicenseKeyListParamsProperties = DodoPayments.Client.Models.LicenseKeys.LicenseKeyListParamsProperties;
using MeterAggregationProperties = DodoPayments.Client.Models.Meters.MeterAggregationProperties;
using MeterFilterConditionProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties;
using MeterFilterProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;
using PaymentCancelledWebhookEventProperties = DodoPayments.Client.Models.Webhooks.PaymentCancelledWebhookEventProperties;
using PaymentFailedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.PaymentFailedWebhookEventProperties;
using PaymentProcessingWebhookEventProperties = DodoPayments.Client.Models.Webhooks.PaymentProcessingWebhookEventProperties;
using PaymentSucceededWebhookEventProperties = DodoPayments.Client.Models.Webhooks.PaymentSucceededWebhookEventProperties;
using RecurringPriceProperties = DodoPayments.Client.Models.Products.PriceProperties.RecurringPriceProperties;
using RefundFailedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.RefundFailedWebhookEventProperties;
using RefundListParamsProperties = DodoPayments.Client.Models.Refunds.RefundListParamsProperties;
using RefundSucceededWebhookEventProperties = DodoPayments.Client.Models.Webhooks.RefundSucceededWebhookEventProperties;
using SubscriptionActiveWebhookEventProperties = DodoPayments.Client.Models.Webhooks.SubscriptionActiveWebhookEventProperties;
using SubscriptionCancelledWebhookEventProperties = DodoPayments.Client.Models.Webhooks.SubscriptionCancelledWebhookEventProperties;
using SubscriptionExpiredWebhookEventProperties = DodoPayments.Client.Models.Webhooks.SubscriptionExpiredWebhookEventProperties;
using SubscriptionFailedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.SubscriptionFailedWebhookEventProperties;
using SubscriptionListParamsProperties = DodoPayments.Client.Models.Subscriptions.SubscriptionListParamsProperties;
using SubscriptionOnHoldWebhookEventProperties = DodoPayments.Client.Models.Webhooks.SubscriptionOnHoldWebhookEventProperties;
using SubscriptionPlanChangedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.SubscriptionPlanChangedWebhookEventProperties;
using SubscriptionRenewedWebhookEventProperties = DodoPayments.Client.Models.Webhooks.SubscriptionRenewedWebhookEventProperties;
using UsageBasedPriceProperties = DodoPayments.Client.Models.Products.PriceProperties.UsageBasedPriceProperties;

namespace DodoPayments.Client.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Theme>(),
            new ApiEnumConverter<string, Currency>(),
            new ApiEnumConverter<string, CustomizationProperties::Theme>(),
            new ApiEnumConverter<string, IntentStatus>(),
            new ApiEnumConverter<string, PaymentMethodTypes>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, SubscriptionStatus>(),
            new ApiEnumConverter<string, TimeInterval>(),
            new ApiEnumConverter<string, SubscriptionListParamsProperties::Status>(),
            new ApiEnumConverter<string, ProrationBillingMode>(),
            new ApiEnumConverter<string, LicenseKeyStatus>(),
            new ApiEnumConverter<string, LicenseKeyListParamsProperties::Status>(),
            new ApiEnumConverter<string, EventType>(),
            new ApiEnumConverter<string, EntryType>(),
            new ApiEnumConverter<string, RefundStatus>(),
            new ApiEnumConverter<string, RefundListParamsProperties::Status>(),
            new ApiEnumConverter<string, DisputeStage>(),
            new ApiEnumConverter<string, DisputeStatus>(),
            new ApiEnumConverter<string, DisputeListParamsProperties::DisputeStage>(),
            new ApiEnumConverter<string, DisputeListParamsProperties::DisputeStatus>(),
            new ApiEnumConverter<string, ItemProperties::Status>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, RecurringPriceProperties::Type>(),
            new ApiEnumConverter<string, UsageBasedPriceProperties::Type>(),
            new ApiEnumConverter<string, TaxCategory>(),
            new ApiEnumConverter<string, CountryCode>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, VerificationStatus>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeAcceptedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, DisputeAcceptedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeCancelledWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, DisputeCancelledWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeChallengedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, DisputeChallengedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeExpiredWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, DisputeExpiredWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeLostWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, DisputeLostWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeOpenedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, DisputeOpenedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeWonWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, DisputeWonWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.LicenseKeyCreatedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, LicenseKeyCreatedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.PaymentCancelledWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, PaymentCancelledWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.PaymentFailedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, PaymentFailedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.PaymentProcessingWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, PaymentProcessingWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.PaymentSucceededWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, PaymentSucceededWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.RefundFailedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, RefundFailedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.RefundSucceededWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, RefundSucceededWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionActiveWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, SubscriptionActiveWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionCancelledWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, SubscriptionCancelledWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionExpiredWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, SubscriptionExpiredWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionFailedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, SubscriptionFailedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionOnHoldWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, SubscriptionOnHoldWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionPlanChangedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, SubscriptionPlanChangedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionRenewedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, SubscriptionRenewedWebhookEventProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeAcceptedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, DisputeAcceptedWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeCancelledWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, DisputeCancelledWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeChallengedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, DisputeChallengedWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeExpiredWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, DisputeExpiredWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeLostWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, DisputeLostWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeOpenedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, DisputeOpenedWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.DisputeWonWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, DisputeWonWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.LicenseKeyCreatedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, LicenseKeyCreatedWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.PaymentCancelledWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, PaymentCancelledWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.PaymentFailedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, PaymentFailedWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.PaymentProcessingWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, PaymentProcessingWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.PaymentSucceededWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, PaymentSucceededWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.RefundFailedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, RefundFailedWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.RefundSucceededWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, RefundSucceededWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionActiveWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, SubscriptionActiveWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionCancelledWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, SubscriptionCancelledWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionExpiredWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, SubscriptionExpiredWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionFailedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, SubscriptionFailedWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionOnHoldWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, SubscriptionOnHoldWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionPlanChangedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<
                string,
                SubscriptionPlanChangedWebhookEventProperties::TypeModel
            >(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Webhooks.SubscriptionRenewedWebhookEventProperties.DataProperties.IntersectionMember1Properties.PayloadTypeModel
            >(),
            new ApiEnumConverter<string, SubscriptionRenewedWebhookEventProperties::TypeModel>(),
            new ApiEnumConverter<string, WebhookEventType>(),
            new ApiEnumConverter<string, PayloadType>(),
            new ApiEnumConverter<string, IntersectionMember1Properties::PayloadType>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.RefundProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.DisputeProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.LicenseKeyProperties.IntersectionMember1Properties.PayloadType
            >(),
            new ApiEnumConverter<string, MeterAggregationProperties::Type>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, MeterFilterConditionProperties::Operator>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties.Operator
            >(),
            new ApiEnumConverter<string, ClauseProperties::Operator>(),
            new ApiEnumConverter<string, Conjunction>(),
            new ApiEnumConverter<string, MeterFilterProperties::Conjunction>(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.Conjunction
            >(),
            new ApiEnumConverter<
                string,
                global::DodoPayments.Client.Models.Meters.MeterFilterProperties.Conjunction
            >(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
