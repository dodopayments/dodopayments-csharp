using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.Subscriptions;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class UnsafeUnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void DisputeAcceptedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeAcceptedWebhookEvent()
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
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeAccepted,
        };
        value.Validate();
    }

    [Fact]
    public void DisputeCancelledValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeCancelledWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new DisputeChallengedWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new DisputeExpiredWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new DisputeLostWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new DisputeOpenedWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new DisputeWonWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new LicenseKeyCreatedWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new PaymentCancelledWebhookEvent()
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
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
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
        UnsafeUnwrapWebhookEvent value = new PaymentFailedWebhookEvent()
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
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
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
        UnsafeUnwrapWebhookEvent value = new PaymentProcessingWebhookEvent()
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
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
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
        UnsafeUnwrapWebhookEvent value = new PaymentSucceededWebhookEvent()
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
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
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
        UnsafeUnwrapWebhookEvent value = new RefundFailedWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new RefundSucceededWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new SubscriptionActiveWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new SubscriptionCancelledWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new SubscriptionExpiredWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new SubscriptionFailedWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new SubscriptionOnHoldWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new SubscriptionPlanChangedWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new SubscriptionRenewedWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new SubscriptionUpdatedWebhookEvent()
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
        UnsafeUnwrapWebhookEvent value = new DisputeAcceptedWebhookEvent()
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
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_DisputeAccepted,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeCancelledSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeCancelledWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeChallengedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeChallengedWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeExpiredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeExpiredWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeLostSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeLostWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeOpenedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeOpenedWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeWonSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeWonWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeyCreatedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new LicenseKeyCreatedWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentCancelledSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentCancelledWebhookEvent()
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
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentCancelled,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentFailedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentFailedWebhookEvent()
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
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentFailed,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentProcessingSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentProcessingWebhookEvent()
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
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentProcessing,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentSucceededSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentSucceededWebhookEvent()
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
                DiscountID = "discount_id",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            STAINLESS_FIXME_Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            STAINLESS_FIXME_Type = STAINLESS_FIXME_Type.STAINLESS_FIXME_PaymentSucceeded,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundFailedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new RefundFailedWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundSucceededSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new RefundSucceededWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionActiveSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionActiveWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionCancelledSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionCancelledWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionExpiredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionExpiredWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionFailedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionFailedWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionOnHoldSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionOnHoldWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionPlanChangedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionPlanChangedWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionRenewedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionRenewedWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionUpdatedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionUpdatedWebhookEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
