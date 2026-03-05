using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.CreditEntitlements.Balances;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.Subscriptions;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class UnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void CreditAddedValidationWorks()
    {
        UnwrapWebhookEvent value = new CreditAddedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = global::DodoPayments.Client.Models.Webhooks.Type.CreditAdded,
        };
        value.Validate();
    }

    [Fact]
    public void CreditBalanceLowValidationWorks()
    {
        UnwrapWebhookEvent value = new CreditBalanceLowWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditBalanceLowWebhookEventType.CreditBalanceLow,
        };
        value.Validate();
    }

    [Fact]
    public void CreditDeductedValidationWorks()
    {
        UnwrapWebhookEvent value = new CreditDeductedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditDeductedWebhookEventType.CreditDeducted,
        };
        value.Validate();
    }

    [Fact]
    public void CreditExpiredValidationWorks()
    {
        UnwrapWebhookEvent value = new CreditExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditExpiredWebhookEventType.CreditExpired,
        };
        value.Validate();
    }

    [Fact]
    public void CreditManualAdjustmentValidationWorks()
    {
        UnwrapWebhookEvent value = new CreditManualAdjustmentWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditManualAdjustmentWebhookEventType.CreditManualAdjustment,
        };
        value.Validate();
    }

    [Fact]
    public void CreditOverageChargedValidationWorks()
    {
        UnwrapWebhookEvent value = new CreditOverageChargedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditOverageChargedWebhookEventType.CreditOverageCharged,
        };
        value.Validate();
    }

    [Fact]
    public void CreditRolledOverValidationWorks()
    {
        UnwrapWebhookEvent value = new CreditRolledOverWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditRolledOverWebhookEventType.CreditRolledOver,
        };
        value.Validate();
    }

    [Fact]
    public void CreditRolloverForfeitedValidationWorks()
    {
        UnwrapWebhookEvent value = new CreditRolloverForfeitedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditRolloverForfeitedWebhookEventType.CreditRolloverForfeited,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeAcceptedValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeAcceptedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeAcceptedWebhookEventType.DisputeAccepted,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeCancelledValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeCancelledWebhookEventType.DisputeCancelled,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeChallengedValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeChallengedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeChallengedWebhookEventType.DisputeChallenged,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeExpiredValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeExpiredWebhookEventType.DisputeExpired,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeLostValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeLostWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeLostWebhookEventType.DisputeLost,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeOpenedValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeOpenedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeOpenedWebhookEventType.DisputeOpened,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeWonValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeWonWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeWonWebhookEventType.DisputeWon,
        };
        value.Validate();
    }

    [Fact]
    public void LicenseKeyCreatedValidationWorks()
    {
        UnwrapWebhookEvent value = new LicenseKeyCreatedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "lic_123",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                CustomerID = "cus_123",
                InstancesCount = 0,
                Key = "key",
                PaymentID = "payment_id",
                ProductID = "product_id",
                Status = LicenseKeyStatus.Active,
                ActivationsLimit = 5,
                ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
        };
        value.Validate();
    }

    [Fact]
    public void PaymentCancelledValidationWorks()
    {
        UnwrapWebhookEvent value = new PaymentCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentCancelledWebhookEventType.PaymentCancelled,
        };
        value.Validate();
    }

    [Fact]
    public void PaymentFailedValidationWorks()
    {
        UnwrapWebhookEvent value = new PaymentFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentFailedWebhookEventType.PaymentFailed,
        };
        value.Validate();
    }

    [Fact]
    public void PaymentProcessingValidationWorks()
    {
        UnwrapWebhookEvent value = new PaymentProcessingWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentProcessingWebhookEventType.PaymentProcessing,
        };
        value.Validate();
    }

    [Fact]
    public void PaymentSucceededValidationWorks()
    {
        UnwrapWebhookEvent value = new PaymentSucceededWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentSucceededWebhookEventType.PaymentSucceeded,
        };
        value.Validate();
    }

    [Fact]
    public void RefundFailedValidationWorks()
    {
        UnwrapWebhookEvent value = new RefundFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                IsPartial = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = RefundFailedWebhookEventType.RefundFailed,
        };
        value.Validate();
    }

    [Fact]
    public void RefundSucceededValidationWorks()
    {
        UnwrapWebhookEvent value = new RefundSucceededWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                IsPartial = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = RefundSucceededWebhookEventType.RefundSucceeded,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionActiveValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionActiveWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionActiveWebhookEventType.SubscriptionActive,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionCancelledValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionCancelledWebhookEventType.SubscriptionCancelled,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionExpiredValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionExpiredWebhookEventType.SubscriptionExpired,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionFailedValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionFailedWebhookEventType.SubscriptionFailed,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionOnHoldValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionOnHoldWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionOnHoldWebhookEventType.SubscriptionOnHold,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionPlanChangedValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionPlanChangedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionPlanChangedWebhookEventType.SubscriptionPlanChanged,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionRenewedValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionRenewedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionRenewedWebhookEventType.SubscriptionRenewed,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionUpdatedValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionUpdatedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionUpdatedWebhookEventType.SubscriptionUpdated,
        };
        value.Validate();
    }

    [Fact]
    public void CreditAddedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CreditAddedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = global::DodoPayments.Client.Models.Webhooks.Type.CreditAdded,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditBalanceLowSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CreditBalanceLowWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditBalanceLowWebhookEventType.CreditBalanceLow,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditDeductedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CreditDeductedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditDeductedWebhookEventType.CreditDeducted,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditExpiredSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CreditExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditExpiredWebhookEventType.CreditExpired,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditManualAdjustmentSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CreditManualAdjustmentWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditManualAdjustmentWebhookEventType.CreditManualAdjustment,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditOverageChargedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CreditOverageChargedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditOverageChargedWebhookEventType.CreditOverageCharged,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditRolledOverSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CreditRolledOverWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditRolledOverWebhookEventType.CreditRolledOver,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditRolloverForfeitedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new CreditRolloverForfeitedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = CreditRolloverForfeitedWebhookEventType.CreditRolloverForfeited,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeAcceptedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new DisputeAcceptedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeAcceptedWebhookEventType.DisputeAccepted,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeCancelledSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new DisputeCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeCancelledWebhookEventType.DisputeCancelled,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeChallengedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new DisputeChallengedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeChallengedWebhookEventType.DisputeChallenged,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeExpiredSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new DisputeExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeExpiredWebhookEventType.DisputeExpired,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeLostSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new DisputeLostWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeLostWebhookEventType.DisputeLost,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeOpenedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new DisputeOpenedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeOpenedWebhookEventType.DisputeOpened,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeWonSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new DisputeWonWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeWonWebhookEventType.DisputeWon,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeyCreatedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new LicenseKeyCreatedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "lic_123",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                CustomerID = "cus_123",
                InstancesCount = 0,
                Key = "key",
                PaymentID = "payment_id",
                ProductID = "product_id",
                Status = LicenseKeyStatus.Active,
                ActivationsLimit = 5,
                ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentCancelledSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new PaymentCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentCancelledWebhookEventType.PaymentCancelled,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentFailedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new PaymentFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentFailedWebhookEventType.PaymentFailed,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentProcessingSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new PaymentProcessingWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentProcessingWebhookEventType.PaymentProcessing,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentSucceededSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new PaymentSucceededWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentSucceededWebhookEventType.PaymentSucceeded,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundFailedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new RefundFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                IsPartial = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = RefundFailedWebhookEventType.RefundFailed,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundSucceededSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new RefundSucceededWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                IsPartial = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = RefundSucceededWebhookEventType.RefundSucceeded,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionActiveSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionActiveWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionActiveWebhookEventType.SubscriptionActive,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionCancelledSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionCancelledWebhookEventType.SubscriptionCancelled,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionExpiredSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionExpiredWebhookEventType.SubscriptionExpired,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionFailedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionFailedWebhookEventType.SubscriptionFailed,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionOnHoldSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionOnHoldWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionOnHoldWebhookEventType.SubscriptionOnHold,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionPlanChangedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionPlanChangedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionPlanChangedWebhookEventType.SubscriptionPlanChanged,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionRenewedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionRenewedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionRenewedWebhookEventType.SubscriptionRenewed,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionUpdatedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionUpdatedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = SubscriptionUpdatedWebhookEventType.SubscriptionUpdated,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
