using System.Text.Json;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Brands;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Products;
using Balances = DodoPayments.Client.Models.Balances;
using CreditEntitlementsBalances = DodoPayments.Client.Models.CreditEntitlements.Balances;
using Customers = DodoPayments.Client.Models.Customers;
using Grants = DodoPayments.Client.Models.Entitlements.Grants;
using LicenseKeys = DodoPayments.Client.Models.LicenseKeys;
using Meters = DodoPayments.Client.Models.Meters;
using Payouts = DodoPayments.Client.Models.Payouts;
using Refunds = DodoPayments.Client.Models.Refunds;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using WebhookEvents = DodoPayments.Client.Models.WebhookEvents;
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
            new ApiEnumConverter<string, Theme>(),
            new ApiEnumConverter<string, FieldType>(),
            new ApiEnumConverter<string, FontSize>(),
            new ApiEnumConverter<string, FontWeight>(),
            new ApiEnumConverter<string, Currency>(),
            new ApiEnumConverter<string, IntentStatus>(),
            new ApiEnumConverter<string, PaymentMethodTypes>(),
            new ApiEnumConverter<string, PaymentRefundStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Subscriptions::CancellationFeedback>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionStatus>(),
            new ApiEnumConverter<string, Subscriptions::TimeInterval>(),
            new ApiEnumConverter<
                string,
                Subscriptions::UpdateSubscriptionPlanReqProrationBillingMode
            >(),
            new ApiEnumConverter<string, Subscriptions::UpdateSubscriptionPlanReqEffectiveAt>(),
            new ApiEnumConverter<
                string,
                Subscriptions::UpdateSubscriptionPlanReqOnPaymentFailure
            >(),
            new ApiEnumConverter<string, Subscriptions::LineItemSubscriptionType>(),
            new ApiEnumConverter<string, Subscriptions::LineItemAddonType>(),
            new ApiEnumConverter<string, Subscriptions::MeterType>(),
            new ApiEnumConverter<string, Subscriptions::CancelReason>(),
            new ApiEnumConverter<string, Subscriptions::Status>(),
            new ApiEnumConverter<string, Subscriptions::ProrationBillingMode>(),
            new ApiEnumConverter<string, Subscriptions::EffectiveAt>(),
            new ApiEnumConverter<string, Subscriptions::OnPaymentFailure>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewChangePlanParamsProrationBillingMode
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewChangePlanParamsEffectiveAt
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewChangePlanParamsOnPaymentFailure
            >(),
            new ApiEnumConverter<string, Subscriptions::Type>(),
            new ApiEnumConverter<string, Subscriptions::ExistingType>(),
            new ApiEnumConverter<string, LicenseKeys::LicenseKeySource>(),
            new ApiEnumConverter<string, LicenseKeys::LicenseKeyStatus>(),
            new ApiEnumConverter<string, LicenseKeys::Source>(),
            new ApiEnumConverter<string, LicenseKeys::Status>(),
            new ApiEnumConverter<string, Customers::Status>(),
            new ApiEnumConverter<string, Customers::PaymentMethod>(),
            new ApiEnumConverter<string, EventType>(),
            new ApiEnumConverter<string, EntryType>(),
            new ApiEnumConverter<string, Refunds::RefundStatus>(),
            new ApiEnumConverter<string, Refunds::Status>(),
            new ApiEnumConverter<string, DisputeDisputeStage>(),
            new ApiEnumConverter<string, DisputeDisputeStatus>(),
            new ApiEnumConverter<string, DisputeStage>(),
            new ApiEnumConverter<string, DisputeStatus>(),
            new ApiEnumConverter<string, Payouts::Status>(),
            new ApiEnumConverter<string, CbbProrationBehavior>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, RecurringPriceType>(),
            new ApiEnumConverter<string, UsageBasedPriceType>(),
            new ApiEnumConverter<string, TaxCategory>(),
            new ApiEnumConverter<string, CountryCode>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, VerificationStatus>(),
            new ApiEnumConverter<string, Webhooks::AbandonmentReason>(),
            new ApiEnumConverter<string, Webhooks::Status>(),
            new ApiEnumConverter<string, Webhooks::Type>(),
            new ApiEnumConverter<
                string,
                Webhooks::AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::AbandonedCheckoutRecoveredWebhookEventDataStatus
            >(),
            new ApiEnumConverter<string, Webhooks::AbandonedCheckoutRecoveredWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditAddedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditBalanceLowWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditDeductedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditExpiredWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditManualAdjustmentWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditOverageChargedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditOverageResetWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditRolledOverWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::CreditRolloverForfeitedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeAcceptedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeCancelledWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeChallengedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeExpiredWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeLostWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeOpenedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DisputeWonWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DunningRecoveredWebhookEventDataStatus>(),
            new ApiEnumConverter<string, Webhooks::TriggerState>(),
            new ApiEnumConverter<string, Webhooks::DunningRecoveredWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::DunningStartedWebhookEventDataStatus>(),
            new ApiEnumConverter<string, Webhooks::DunningStartedWebhookEventDataTriggerState>(),
            new ApiEnumConverter<string, Webhooks::DunningStartedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::EntitlementGrantCreatedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::EntitlementGrantDeliveredWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::EntitlementGrantFailedWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::EntitlementGrantRevokedWebhookEventType>(),
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
            new ApiEnumConverter<string, WebhookEvents::WebhookEventType>(),
            new ApiEnumConverter<string, WebhookEvents::PayloadType>(),
            new ApiEnumConverter<
                string,
                WebhookEvents::SubscriptionIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, WebhookEvents::RefundIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, WebhookEvents::DisputeIntersectionMember1PayloadType>(),
            new ApiEnumConverter<string, WebhookEvents::LicenseKeyIntersectionMember1PayloadType>(),
            new ApiEnumConverter<
                string,
                WebhookEvents::CreditLedgerEntryIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, WebhookEvents::CreditBalanceLowPayloadType>(),
            new ApiEnumConverter<string, WebhookEvents::AbandonmentReason>(),
            new ApiEnumConverter<string, WebhookEvents::AbandonedCheckoutPayloadType>(),
            new ApiEnumConverter<string, WebhookEvents::Status>(),
            new ApiEnumConverter<string, WebhookEvents::DunningAttemptPayloadType>(),
            new ApiEnumConverter<string, WebhookEvents::DunningAttemptStatus>(),
            new ApiEnumConverter<string, WebhookEvents::TriggerState>(),
            new ApiEnumConverter<
                string,
                WebhookEvents::EntitlementGrantIntersectionMember1PayloadType
            >(),
            new ApiEnumConverter<string, Meters::Conjunction>(),
            new ApiEnumConverter<string, Meters::FilterOperator>(),
            new ApiEnumConverter<string, Meters::Type>(),
            new ApiEnumConverter<string, Balances::BalanceLedgerEntryEventType>(),
            new ApiEnumConverter<string, Balances::Currency>(),
            new ApiEnumConverter<string, Balances::EventType>(),
            new ApiEnumConverter<string, CbbOverageBehavior>(),
            new ApiEnumConverter<string, CreditEntitlementsBalances::TransactionType>(),
            new ApiEnumConverter<string, CreditEntitlementsBalances::LedgerEntryType>(),
            new ApiEnumConverter<string, CreditEntitlementsBalances::SourceType>(),
            new ApiEnumConverter<string, CreditEntitlementsBalances::Status>(),
            new ApiEnumConverter<string, EntitlementIntegrationType>(),
            new ApiEnumConverter<string, IntegrationType>(),
            new ApiEnumConverter<string, Grants::EntitlementGrantStatus>(),
            new ApiEnumConverter<string, Grants::Status>(),
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
