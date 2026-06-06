using System.Text.Json;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Meters;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.ProductCollections;
using DodoPayments.Client.Models.Products;
using Balances = DodoPayments.Client.Models.Balances;
using CreditEntitlementsBalances = DodoPayments.Client.Models.CreditEntitlements.Balances;
using Grants = DodoPayments.Client.Models.Entitlements.Grants;
using LicenseKeys = DodoPayments.Client.Models.LicenseKeys;
using Refunds = DodoPayments.Client.Models.Refunds;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using WebhookEvents = DodoPayments.Client.Models.WebhookEvents;

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
            new ApiEnumConverter<string, Currency>(),
            new ApiEnumConverter<string, IntentStatus>(),
            new ApiEnumConverter<string, PaymentMethodTypes>(),
            new ApiEnumConverter<string, PaymentRefundStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Subscriptions::CancellationFeedback>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionStatus>(),
            new ApiEnumConverter<string, Subscriptions::TimeInterval>(),
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
            new ApiEnumConverter<string, LicenseKeys::LicenseKeyStatus>(),
            new ApiEnumConverter<string, LicenseKeys::Source>(),
            new ApiEnumConverter<string, LicenseKeys::Status>(),
            new ApiEnumConverter<string, EntryType>(),
            new ApiEnumConverter<string, Refunds::RefundStatus>(),
            new ApiEnumConverter<string, Refunds::Status>(),
            new ApiEnumConverter<string, DisputeDisputeStage>(),
            new ApiEnumConverter<string, DisputeDisputeStatus>(),
            new ApiEnumConverter<string, DisputeStage>(),
            new ApiEnumConverter<string, DisputeStatus>(),
            new ApiEnumConverter<string, CbbProrationBehavior>(),
            new ApiEnumConverter<string, TaxCategory>(),
            new ApiEnumConverter<string, CountryCode>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, WebhookEvents::WebhookEventType>(),
            new ApiEnumConverter<string, Conjunction>(),
            new ApiEnumConverter<string, FilterOperator>(),
            new ApiEnumConverter<string, Balances::Currency>(),
            new ApiEnumConverter<string, Balances::EventType>(),
            new ApiEnumConverter<string, CbbOverageBehavior>(),
            new ApiEnumConverter<string, CreditEntitlementsBalances::LedgerEntryType>(),
            new ApiEnumConverter<string, CreditEntitlementsBalances::Status>(),
            new ApiEnumConverter<string, EntitlementIntegrationType>(),
            new ApiEnumConverter<string, GitHubPermission>(),
            new ApiEnumConverter<string, IntegrationType>(),
            new ApiEnumConverter<string, Grants::IntegrationType>(),
            new ApiEnumConverter<string, Grants::Status>(),
            new ApiEnumConverter<string, EffectiveAtOnDowngrade>(),
            new ApiEnumConverter<string, EffectiveAtOnUpgrade>(),
            new ApiEnumConverter<string, OnPaymentFailure>(),
            new ApiEnumConverter<string, ProrationBillingModeOnDowngrade>(),
            new ApiEnumConverter<string, ProrationBillingModeOnUpgrade>(),
            new ApiEnumConverter<string, ProductCollectionUpdateParamsEffectiveAtOnDowngrade>(),
            new ApiEnumConverter<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade>(),
            new ApiEnumConverter<string, ProductCollectionUpdateParamsOnPaymentFailure>(),
            new ApiEnumConverter<
                string,
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade
            >(),
            new ApiEnumConverter<
                string,
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade
            >(),
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
