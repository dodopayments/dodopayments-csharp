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
using DisputeListParamsProperties = DodoPayments.Client.Models.Disputes.DisputeListParamsProperties;
using IntersectionMember1Properties = DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.SubscriptionProperties.IntersectionMember1Properties;
using ItemProperties = DodoPayments.Client.Models.Payouts.PayoutListPageResponseProperties.ItemProperties;
using LicenseKeyListParamsProperties = DodoPayments.Client.Models.LicenseKeys.LicenseKeyListParamsProperties;
using MeterAggregationProperties = DodoPayments.Client.Models.Meters.MeterAggregationProperties;
using MeterFilterConditionProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties;
using MeterFilterProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;
using RecurringPriceProperties = DodoPayments.Client.Models.Products.PriceProperties.RecurringPriceProperties;
using RefundListParamsProperties = DodoPayments.Client.Models.Refunds.RefundListParamsProperties;
using SubscriptionListParamsProperties = DodoPayments.Client.Models.Subscriptions.SubscriptionListParamsProperties;
using UsageBasedPriceProperties = DodoPayments.Client.Models.Products.PriceProperties.UsageBasedPriceProperties;

namespace DodoPayments.Client;

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
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, RecurringPriceProperties::Type>(),
            new ApiEnumConverter<string, UsageBasedPriceProperties::Type>(),
            new ApiEnumConverter<string, TaxCategory>(),
            new ApiEnumConverter<string, CountryCode>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, VerificationStatus>(),
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
