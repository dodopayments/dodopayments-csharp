using System.Text.Json;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Meters;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.Products.LocalizedPrices;
using DodoPayments.Client.Models.Subscriptions;
using Balances = DodoPayments.Client.Models.Balances;
using CreditEntitlementsBalances = DodoPayments.Client.Models.CreditEntitlements.Balances;
using Customers = DodoPayments.Client.Models.Customers;
using Grants = DodoPayments.Client.Models.Entitlements.Grants;
using LicenseKeys = DodoPayments.Client.Models.LicenseKeys;
using Payments = DodoPayments.Client.Models.Payments;
using ProductCollections = DodoPayments.Client.Models.ProductCollections;
using Refunds = DodoPayments.Client.Models.Refunds;
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
            new ApiEnumConverter<string, Payments::IntentStatus>(),
            new ApiEnumConverter<string, Payments::PaymentMethodTypes>(),
            new ApiEnumConverter<string, Payments::PaymentRefundStatus>(),
            new ApiEnumConverter<string, Payments::Currency>(),
            new ApiEnumConverter<string, Payments::Status>(),
            new ApiEnumConverter<string, CancellationFeedback>(),
            new ApiEnumConverter<string, SubscriptionStatus>(),
            new ApiEnumConverter<string, TimeInterval>(),
            new ApiEnumConverter<string, CancelReason>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, ProrationBillingMode>(),
            new ApiEnumConverter<string, EffectiveAt>(),
            new ApiEnumConverter<string, OnPaymentFailure>(),
            new ApiEnumConverter<string, SubscriptionPreviewChangePlanParamsProrationBillingMode>(),
            new ApiEnumConverter<string, SubscriptionPreviewChangePlanParamsEffectiveAt>(),
            new ApiEnumConverter<string, SubscriptionPreviewChangePlanParamsOnPaymentFailure>(),
            new ApiEnumConverter<string, LicenseKeys::LicenseKeyStatus>(),
            new ApiEnumConverter<string, LicenseKeys::Source>(),
            new ApiEnumConverter<string, LicenseKeys::Status>(),
            new ApiEnumConverter<string, Customers::IntegrationType>(),
            new ApiEnumConverter<string, Customers::Status>(),
            new ApiEnumConverter<string, EntryType>(),
            new ApiEnumConverter<string, Refunds::RefundStatus>(),
            new ApiEnumConverter<string, Refunds::Status>(),
            new ApiEnumConverter<string, DisputeDisputeStage>(),
            new ApiEnumConverter<string, DisputeDisputeStatus>(),
            new ApiEnumConverter<string, DisputeStage>(),
            new ApiEnumConverter<string, DisputeStatus>(),
            new ApiEnumConverter<string, CbbProrationBehavior>(),
            new ApiEnumConverter<string, TaxCategory>(),
            new ApiEnumConverter<string, PricingMode>(),
            new ApiEnumConverter<string, CountryCode>(),
            new ApiEnumConverter<string, DiscountType>(),
            new ApiEnumConverter<string, CustomerEligibility>(),
            new ApiEnumConverter<string, DiscountUpdateParamsCustomerEligibility>(),
            new ApiEnumConverter<string, WebhookEvents::WebhookEventType>(),
            new ApiEnumConverter<string, Conjunction>(),
            new ApiEnumConverter<string, FilterOperator>(),
            new ApiEnumConverter<string, Balances::Currency>(),
            new ApiEnumConverter<string, Balances::EventType>(),
            new ApiEnumConverter<string, CbbOverageBehavior>(),
            new ApiEnumConverter<string, CreditEntitlementsBalances::LedgerEntryType>(),
            new ApiEnumConverter<string, CreditEntitlementsBalances::Status>(),
            new ApiEnumConverter<string, EntitlementIntegrationType>(),
            new ApiEnumConverter<string, FeatureType>(),
            new ApiEnumConverter<string, GitHubPermission>(),
            new ApiEnumConverter<string, IntegrationType>(),
            new ApiEnumConverter<string, Grants::Status>(),
            new ApiEnumConverter<string, ProductCollections::EffectiveAtOnDowngrade>(),
            new ApiEnumConverter<string, ProductCollections::EffectiveAtOnUpgrade>(),
            new ApiEnumConverter<string, ProductCollections::OnPaymentFailure>(),
            new ApiEnumConverter<string, ProductCollections::ProrationBillingModeOnDowngrade>(),
            new ApiEnumConverter<string, ProductCollections::ProrationBillingModeOnUpgrade>(),
            new ApiEnumConverter<
                string,
                ProductCollections::ProductCollectionUpdateParamsEffectiveAtOnDowngrade
            >(),
            new ApiEnumConverter<
                string,
                ProductCollections::ProductCollectionUpdateParamsEffectiveAtOnUpgrade
            >(),
            new ApiEnumConverter<
                string,
                ProductCollections::ProductCollectionUpdateParamsOnPaymentFailure
            >(),
            new ApiEnumConverter<
                string,
                ProductCollections::ProductCollectionUpdateParamsProrationBillingModeOnDowngrade
            >(),
            new ApiEnumConverter<
                string,
                ProductCollections::ProductCollectionUpdateParamsProrationBillingModeOnUpgrade
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
