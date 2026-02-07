using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.Subscriptions;
using DodoPayments.Client.Models.Webhooks;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class UnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void DisputeAcceptedValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeAcceptedWebhookEvent()
        {
            BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeAccepted,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeCancelledValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeCancelledWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeCancelled,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeChallengedValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeChallengedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeChallenged,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeExpiredValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeExpiredWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeExpired,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeLostValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeLostWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeLost,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeOpenedValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeOpenedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeOpened,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeWonValidationWorks()
    {
        UnwrapWebhookEvent value = new DisputeWonWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeWon,
        };
        value.Validate();
    }

    [Fact]
    public void LicenseKeyCreatedValidationWorks()
    {
        UnwrapWebhookEvent value = new LicenseKeyCreatedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_LicenseKeyCreated,
        };
        value.Validate();
    }

    [Fact]
    public void PaymentCancelledValidationWorks()
    {
        UnwrapWebhookEvent value = new PaymentCancelledWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                RefundStatus = Payments::RefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentCancelled,
        };
        value.Validate();
    }

    [Fact]
    public void PaymentFailedValidationWorks()
    {
        UnwrapWebhookEvent value = new PaymentFailedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                RefundStatus = Payments::RefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentFailed,
        };
        value.Validate();
    }

    [Fact]
    public void PaymentProcessingValidationWorks()
    {
        UnwrapWebhookEvent value = new PaymentProcessingWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                RefundStatus = Payments::RefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentProcessing,
        };
        value.Validate();
    }

    [Fact]
    public void PaymentSucceededValidationWorks()
    {
        UnwrapWebhookEvent value = new PaymentSucceededWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                RefundStatus = Payments::RefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentSucceeded,
        };
        value.Validate();
    }

    [Fact]
    public void RefundFailedValidationWorks()
    {
        UnwrapWebhookEvent value = new RefundFailedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_RefundFailed,
        };
        value.Validate();
    }

    [Fact]
    public void RefundSucceededValidationWorks()
    {
        UnwrapWebhookEvent value = new RefundSucceededWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_RefundSucceeded,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionActiveValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionActiveWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionActive,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionCancelledValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionCancelledWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionCancelled,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionExpiredValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionExpiredWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionExpired,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionFailedValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionFailedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionFailed,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionOnHoldValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionOnHoldWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionOnHold,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionPlanChangedValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionPlanChangedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionPlanChanged,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionRenewedValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionRenewedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionRenewed,
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionUpdatedValidationWorks()
    {
        UnwrapWebhookEvent value = new SubscriptionUpdatedWebhookEvent()
        {
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionUpdated,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeAcceptedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new DisputeAcceptedWebhookEvent()
        {
            BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeAccepted,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeCancelled,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeChallenged,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeExpired,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeLost,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeOpened,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeWon,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_LicenseKeyCreated,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                RefundStatus = Payments::RefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentCancelled,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                RefundStatus = Payments::RefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentFailed,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                RefundStatus = Payments::RefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentProcessing,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                RefundStatus = Payments::RefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentSucceeded,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_RefundFailed,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_RefundSucceeded,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionActive,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionCancelled,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionExpired,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionFailed,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionOnHold,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionPlanChanged,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionRenewed,
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
            STAINLESS_FIXME_BusinessID = "business_id",
            STAINLESS_FIXME_Data = new()
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
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
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
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_SubscriptionUpdated,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
