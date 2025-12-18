using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.Subscriptions;
using Webhooks = DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class UnsafeUnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void DisputeAcceptedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeAcceptedWebhookEvent()
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
                    PayloadType = Webhooks::PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::Type.DisputeAccepted,
            }
        );
        value.Validate();
    }

    [Fact]
    public void DisputeCancelledValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeCancelledWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeCancelledWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeCancelledWebhookEventType.DisputeCancelled,
            }
        );
        value.Validate();
    }

    [Fact]
    public void DisputeChallengedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeChallengedWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeChallengedWebhookEventType.DisputeChallenged,
            }
        );
        value.Validate();
    }

    [Fact]
    public void DisputeExpiredValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeExpiredWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeExpiredWebhookEventType.DisputeExpired,
            }
        );
        value.Validate();
    }

    [Fact]
    public void DisputeLostValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeLostWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeLostWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeLostWebhookEventType.DisputeLost,
            }
        );
        value.Validate();
    }

    [Fact]
    public void DisputeOpenedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeOpenedWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeOpenedWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeOpenedWebhookEventType.DisputeOpened,
            }
        );
        value.Validate();
    }

    [Fact]
    public void DisputeWonValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeWonWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeWonWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeWonWebhookEventType.DisputeWon,
            }
        );
        value.Validate();
    }

    [Fact]
    public void LicenseKeyCreatedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::LicenseKeyCreatedWebhookEvent()
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
                    PayloadType =
                        Webhooks::LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
            }
        );
        value.Validate();
    }

    [Fact]
    public void PaymentCancelledValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::PaymentCancelledWebhookEvent()
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
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    CheckoutSessionID = "checkout_session_id",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType =
                        Webhooks::PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::PaymentCancelledWebhookEventType.PaymentCancelled,
            }
        );
        value.Validate();
    }

    [Fact]
    public void PaymentFailedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::PaymentFailedWebhookEvent()
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
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    CheckoutSessionID = "checkout_session_id",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType =
                        Webhooks::PaymentFailedWebhookEventDataIntersectionMember1PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::PaymentFailedWebhookEventType.PaymentFailed,
            }
        );
        value.Validate();
    }

    [Fact]
    public void PaymentProcessingValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::PaymentProcessingWebhookEvent()
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
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    CheckoutSessionID = "checkout_session_id",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType =
                        Webhooks::PaymentProcessingWebhookEventDataIntersectionMember1PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::PaymentProcessingWebhookEventType.PaymentProcessing,
            }
        );
        value.Validate();
    }

    [Fact]
    public void PaymentSucceededValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::PaymentSucceededWebhookEvent()
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
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    CheckoutSessionID = "checkout_session_id",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType =
                        Webhooks::PaymentSucceededWebhookEventDataIntersectionMember1PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::PaymentSucceededWebhookEventType.PaymentSucceeded,
            }
        );
        value.Validate();
    }

    [Fact]
    public void RefundFailedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::RefundFailedWebhookEvent()
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
                    PayloadType =
                        Webhooks::RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::RefundFailedWebhookEventType.RefundFailed,
            }
        );
        value.Validate();
    }

    [Fact]
    public void RefundSucceededValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::RefundSucceededWebhookEvent()
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
                    PayloadType =
                        Webhooks::RefundSucceededWebhookEventDataIntersectionMember1PayloadType.Refund,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::RefundSucceededWebhookEventType.RefundSucceeded,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SubscriptionActiveValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionActiveWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionActiveWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionActiveWebhookEventType.SubscriptionActive,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SubscriptionCancelledValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionCancelledWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionCancelledWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionCancelledWebhookEventType.SubscriptionCancelled,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SubscriptionExpiredValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionExpiredWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionExpiredWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionExpiredWebhookEventType.SubscriptionExpired,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SubscriptionFailedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionFailedWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionFailedWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionFailedWebhookEventType.SubscriptionFailed,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SubscriptionOnHoldValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionOnHoldWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionOnHoldWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionOnHoldWebhookEventType.SubscriptionOnHold,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SubscriptionPlanChangedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionPlanChangedWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionPlanChangedWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionPlanChangedWebhookEventType.SubscriptionPlanChanged,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SubscriptionRenewedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionRenewedWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionRenewedWebhookEventType.SubscriptionRenewed,
            }
        );
        value.Validate();
    }

    [Fact]
    public void SubscriptionUpdatedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionUpdatedWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionUpdatedWebhookEventType.SubscriptionUpdated,
            }
        );
        value.Validate();
    }

    [Fact]
    public void DisputeAcceptedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeAcceptedWebhookEvent()
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
                    PayloadType = Webhooks::PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::Type.DisputeAccepted,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeCancelledSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeCancelledWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeCancelledWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeCancelledWebhookEventType.DisputeCancelled,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeChallengedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeChallengedWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeChallengedWebhookEventType.DisputeChallenged,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeExpiredSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeExpiredWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeExpiredWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeExpiredWebhookEventType.DisputeExpired,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeLostSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeLostWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeLostWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeLostWebhookEventType.DisputeLost,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeOpenedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeOpenedWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeOpenedWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeOpenedWebhookEventType.DisputeOpened,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeWonSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::DisputeWonWebhookEvent()
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
                    PayloadType =
                        Webhooks::DisputeWonWebhookEventDataIntersectionMember1PayloadType.Dispute,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::DisputeWonWebhookEventType.DisputeWon,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeyCreatedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::LicenseKeyCreatedWebhookEvent()
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
                    PayloadType =
                        Webhooks::LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentCancelledSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::PaymentCancelledWebhookEvent()
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
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    CheckoutSessionID = "checkout_session_id",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType =
                        Webhooks::PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::PaymentCancelledWebhookEventType.PaymentCancelled,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentFailedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::PaymentFailedWebhookEvent()
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
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    CheckoutSessionID = "checkout_session_id",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType =
                        Webhooks::PaymentFailedWebhookEventDataIntersectionMember1PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::PaymentFailedWebhookEventType.PaymentFailed,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentProcessingSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::PaymentProcessingWebhookEvent()
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
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    CheckoutSessionID = "checkout_session_id",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType =
                        Webhooks::PaymentProcessingWebhookEventDataIntersectionMember1PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::PaymentProcessingWebhookEventType.PaymentProcessing,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentSucceededSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::PaymentSucceededWebhookEvent()
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
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    CheckoutSessionID = "checkout_session_id",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType =
                        Webhooks::PaymentSucceededWebhookEventDataIntersectionMember1PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::PaymentSucceededWebhookEventType.PaymentSucceeded,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundFailedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::RefundFailedWebhookEvent()
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
                    PayloadType =
                        Webhooks::RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::RefundFailedWebhookEventType.RefundFailed,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundSucceededSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::RefundSucceededWebhookEvent()
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
                    PayloadType =
                        Webhooks::RefundSucceededWebhookEventDataIntersectionMember1PayloadType.Refund,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::RefundSucceededWebhookEventType.RefundSucceeded,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionActiveSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionActiveWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionActiveWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionActiveWebhookEventType.SubscriptionActive,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionCancelledSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionCancelledWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionCancelledWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionCancelledWebhookEventType.SubscriptionCancelled,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionExpiredSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionExpiredWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionExpiredWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionExpiredWebhookEventType.SubscriptionExpired,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionFailedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionFailedWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionFailedWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionFailedWebhookEventType.SubscriptionFailed,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionOnHoldSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionOnHoldWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionOnHoldWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionOnHoldWebhookEventType.SubscriptionOnHold,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionPlanChangedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionPlanChangedWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionPlanChangedWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionPlanChangedWebhookEventType.SubscriptionPlanChanged,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionRenewedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionRenewedWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionRenewedWebhookEventType.SubscriptionRenewed,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionUpdatedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new(
            new Webhooks::SubscriptionUpdatedWebhookEvent()
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
                    PayloadType =
                        Webhooks::SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType.Subscription,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Webhooks::SubscriptionUpdatedWebhookEventType.SubscriptionUpdated,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(json);

        Assert.Equal(value, deserialized);
    }
}
