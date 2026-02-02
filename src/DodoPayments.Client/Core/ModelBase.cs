using System.Text.Json;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Brands;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.WebhookEvents;
using LicenseKeys = DodoPayments.Client.Models.LicenseKeys;
using Meters = DodoPayments.Client.Models.Meters;
using Payouts = DodoPayments.Client.Models.Payouts;
using Refunds = DodoPayments.Client.Models.Refunds;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using Webhooks = DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, CheckoutSessionRequestCustomFieldFieldType>(),
            new ApiEnumConverter<string, CheckoutSessionRequestCustomizationTheme>(),
            new ApiEnumConverter<string, CheckoutSessionRequestCustomizationThemeConfigFontSize>(),
            new ApiEnumConverter<
                string,
                CheckoutSessionRequestCustomizationThemeConfigFontWeight
            >(),
            new ApiEnumConverter<string, Currency>(),
            new ApiEnumConverter<string, FieldType>(),
            new ApiEnumConverter<string, Theme>(),
            new ApiEnumConverter<string, FontSize>(),
            new ApiEnumConverter<string, FontWeight>(),
            new ApiEnumConverter<string, CheckoutSessionPreviewParamsCustomFieldFieldType>(),
            new ApiEnumConverter<string, CheckoutSessionPreviewParamsCustomizationTheme>(),
            new ApiEnumConverter<
                string,
                CheckoutSessionPreviewParamsCustomizationThemeConfigFontSize
            >(),
            new ApiEnumConverter<
                string,
                CheckoutSessionPreviewParamsCustomizationThemeConfigFontWeight
            >(),
            new ApiEnumConverter<string, IntentStatus>(),
            new ApiEnumConverter<string, PaymentMethodTypes>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionStatus>(),
            new ApiEnumConverter<string, Subscriptions::TimeInterval>(),
            new ApiEnumConverter<string, Subscriptions::LineItemSubscriptionType>(),
            new ApiEnumConverter<string, Subscriptions::AddonType>(),
            new ApiEnumConverter<string, Subscriptions::LineItemMeterType>(),
            new ApiEnumConverter<string, Subscriptions::Status>(),
            new ApiEnumConverter<string, Subscriptions::ProrationBillingMode>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewChangePlanParamsProrationBillingMode
            >(),
            new ApiEnumConverter<string, Subscriptions::Type>(),
            new ApiEnumConverter<string, Subscriptions::ExistingType>(),
            new ApiEnumConverter<string, LicenseKeys::LicenseKeyStatus>(),
            new ApiEnumConverter<string, LicenseKeys::Status>(),
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
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, STAINLESS_FIXME_Type>(),
            new ApiEnumConverter<string, Webhooks::Type>(),
            new ApiEnumConverter<string, Webhooks::DisputeCancelledWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeChallengedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeExpiredWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeLostWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeOpenedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeWonWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::LicenseKeyCreatedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::PaymentCancelledWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::PaymentFailedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::PaymentProcessingWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::PaymentSucceededWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::RefundFailedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::RefundSucceededWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::SubscriptionActiveWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::SubscriptionCancelledWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::SubscriptionExpiredWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::SubscriptionFailedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::SubscriptionOnHoldWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::SubscriptionPlanChangedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::SubscriptionRenewedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::SubscriptionUpdatedWebhookEventType>(),
            new ApiEnumConverter<string, WebhookEventType>(),
            new ApiEnumConverter<string, PayloadType>(),
            new ApiEnumConverter<string, SubscriptionIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, RefundIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, DisputeIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, LicenseKeyIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, Meters::Type>(),
            new ApiEnumConverter<string, Meters::Operator>(),
            new ApiEnumConverter<
                string,
                Meters::ClausesMeterFilterClausesMeterFilterConditionOperator
            >(),
            new ApiEnumConverter<
                string,
                Meters::ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator
            >(),
            new ApiEnumConverter<string, Meters::ClauseOperator>(),
            new ApiEnumConverter<string, Meters::Conjunction>(),
            new ApiEnumConverter<string, Meters::ClausesMeterFilterClausesMeterFilterConjunction>(),
            new ApiEnumConverter<string, Meters::ClausesMeterFilterConjunction>(),
            new ApiEnumConverter<string, Meters::MeterFilterConjunction>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
