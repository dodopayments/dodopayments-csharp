using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.WebhookEvents;
using Balances = DodoPayments.Client.Models.CreditEntitlements.Balances;
using Disputes = DodoPayments.Client.Models.Disputes;
using Grants = DodoPayments.Client.Models.Entitlements.Grants;
using LicenseKeys = DodoPayments.Client.Models.LicenseKeys;
using Payments = DodoPayments.Client.Models.Payments;
using Refunds = DodoPayments.Client.Models.Refunds;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.WebhookEvents;

public class WebhookPayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookPayload
        {
            BusinessID = "business_id",
            Data = new Payment()
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
                        DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                        DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
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
                        Status = Refunds::RefundStatus.Succeeded,
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
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = Payments::PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = WebhookEventType.PaymentSucceeded,
        };

        string expectedBusinessID = "business_id";
        Data expectedData = new Payment()
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, WebhookEventType> expectedType = WebhookEventType.PaymentSucceeded;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookPayload
        {
            BusinessID = "business_id",
            Data = new Payment()
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
                        DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                        DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
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
                        Status = Refunds::RefundStatus.Succeeded,
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
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = Payments::PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = WebhookEventType.PaymentSucceeded,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookPayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookPayload
        {
            BusinessID = "business_id",
            Data = new Payment()
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
                        DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                        DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
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
                        Status = Refunds::RefundStatus.Succeeded,
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
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = Payments::PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = WebhookEventType.PaymentSucceeded,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookPayload>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        Data expectedData = new Payment()
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, WebhookEventType> expectedType = WebhookEventType.PaymentSucceeded;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookPayload
        {
            BusinessID = "business_id",
            Data = new Payment()
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
                        DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                        DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
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
                        Status = Refunds::RefundStatus.Succeeded,
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
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = Payments::PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = WebhookEventType.PaymentSucceeded,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookPayload
        {
            BusinessID = "business_id",
            Data = new Payment()
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
                        DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                        DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
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
                        Status = Refunds::RefundStatus.Succeeded,
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
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = Payments::PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = WebhookEventType.PaymentSucceeded,
        };

        WebhookPayload copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void PaymentValidationWorks()
    {
        Data value = new Payment()
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionValidationWorks()
    {
        Data value = new Subscription()
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };
        value.Validate();
    }

    [Fact]
    public void RefundValidationWorks()
    {
        Data value = new Refund()
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
        };
        value.Validate();
    }

    [Fact]
    public void DisputeValidationWorks()
    {
        Data value = new Dispute()
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            IsResolvedByRdr = true,
            Reason = "reason",
            Remarks = "remarks",
        };
        value.Validate();
    }

    [Fact]
    public void LicenseKeyValidationWorks()
    {
        Data value = new LicenseKey()
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };
        value.Validate();
    }

    [Fact]
    public void CreditLedgerEntryValidationWorks()
    {
        Data value = new CreditLedgerEntry()
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
            TransactionType = Balances::TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };
        value.Validate();
    }

    [Fact]
    public void CreditBalanceLowValidationWorks()
    {
        Data value = new CreditBalanceLow()
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };
        value.Validate();
    }

    [Fact]
    public void AbandonedCheckoutValidationWorks()
    {
        Data value = new AbandonedCheckout()
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };
        value.Validate();
    }

    [Fact]
    public void DunningAttemptValidationWorks()
    {
        Data value = new DunningAttempt()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };
        value.Validate();
    }

    [Fact]
    public void EntitlementGrantValidationWorks()
    {
        Data value = new EntitlementGrant()
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };
        value.Validate();
    }

    [Fact]
    public void PaymentSerializationRoundtripWorks()
    {
        Data value = new Payment()
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionSerializationRoundtripWorks()
    {
        Data value = new Subscription()
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundSerializationRoundtripWorks()
    {
        Data value = new Refund()
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeSerializationRoundtripWorks()
    {
        Data value = new Dispute()
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            IsResolvedByRdr = true,
            Reason = "reason",
            Remarks = "remarks",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeySerializationRoundtripWorks()
    {
        Data value = new LicenseKey()
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditLedgerEntrySerializationRoundtripWorks()
    {
        Data value = new CreditLedgerEntry()
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
            TransactionType = Balances::TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditBalanceLowSerializationRoundtripWorks()
    {
        Data value = new CreditBalanceLow()
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AbandonedCheckoutSerializationRoundtripWorks()
    {
        Data value = new AbandonedCheckout()
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DunningAttemptSerializationRoundtripWorks()
    {
        Data value = new DunningAttempt()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EntitlementGrantSerializationRoundtripWorks()
    {
        Data value = new EntitlementGrant()
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PaymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Payments::BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        bool expectedDigitalProductsDelivered = true;
        List<Disputes::Dispute> expectedDisputes =
        [
            new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        List<Payments::RefundListItem> expectedRefunds =
        [
            new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPartial = true,
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = Refunds::RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
        ];
        int expectedSettlementAmount = 0;
        ApiEnum<string, Currency> expectedSettlementCurrency = Currency.Aed;
        int expectedTotalAmount = 0;
        string expectedCardHolderName = "card_holder_name";
        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardLastFour = "card_last_four";
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedCheckoutSessionID = "checkout_session_id";
        List<Payments::CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        string expectedDiscountID = "discount_id";
        List<Payments::Discount> expectedDiscounts =
        [
            new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Code = "code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountID = "discount_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Position = 0,
                PreserveOnPlanChange = true,
                RestrictedTo = ["string"],
                TimesUsed = 0,
                Type = DiscountType.Percentage,
                CyclesRemaining = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                SubscriptionCycles = 0,
                UsageLimit = 0,
            },
        ];
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        string expectedInvoiceID = "invoice_id";
        string expectedInvoiceUrl = "invoice_url";
        string expectedPaymentLink = "payment_link";
        string expectedPaymentMethod = "payment_method";
        string expectedPaymentMethodType = "payment_method_type";
        List<Payments::ProductCart> expectedProductCart =
        [
            new() { ProductID = "product_id", Quantity = 0 },
        ];
        ApiEnum<string, Payments::PaymentRefundStatus> expectedRefundStatus =
            Payments::PaymentRefundStatus.Partial;
        int expectedSettlementTax = 0;
        ApiEnum<string, Payments::IntentStatus> expectedStatus = Payments::IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";
        int expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("Payment");

        Assert.Equal(expectedBilling, model.Billing);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDigitalProductsDelivered, model.DigitalProductsDelivered);
        Assert.Equal(expectedDisputes.Count, model.Disputes.Count);
        for (int i = 0; i < expectedDisputes.Count; i++)
        {
            Assert.Equal(expectedDisputes[i], model.Disputes[i]);
        }
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRefunds.Count, model.Refunds.Count);
        for (int i = 0; i < expectedRefunds.Count; i++)
        {
            Assert.Equal(expectedRefunds[i], model.Refunds[i]);
        }
        Assert.Equal(expectedSettlementAmount, model.SettlementAmount);
        Assert.Equal(expectedSettlementCurrency, model.SettlementCurrency);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedCardHolderName, model.CardHolderName);
        Assert.Equal(expectedCardIssuingCountry, model.CardIssuingCountry);
        Assert.Equal(expectedCardLastFour, model.CardLastFour);
        Assert.Equal(expectedCardNetwork, model.CardNetwork);
        Assert.Equal(expectedCardType, model.CardType);
        Assert.Equal(expectedCheckoutSessionID, model.CheckoutSessionID);
        Assert.NotNull(model.CustomFieldResponses);
        Assert.Equal(expectedCustomFieldResponses.Count, model.CustomFieldResponses.Count);
        for (int i = 0; i < expectedCustomFieldResponses.Count; i++)
        {
            Assert.Equal(expectedCustomFieldResponses[i], model.CustomFieldResponses[i]);
        }
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.NotNull(model.Discounts);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedInvoiceUrl, model.InvoiceUrl);
        Assert.Equal(expectedPaymentLink, model.PaymentLink);
        Assert.Equal(expectedPaymentMethod, model.PaymentMethod);
        Assert.Equal(expectedPaymentMethodType, model.PaymentMethodType);
        Assert.NotNull(model.ProductCart);
        Assert.Equal(expectedProductCart.Count, model.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], model.ProductCart[i]);
        }
        Assert.Equal(expectedRefundStatus, model.RefundStatus);
        Assert.Equal(expectedSettlementTax, model.SettlementTax);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payment>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Payments::BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        bool expectedDigitalProductsDelivered = true;
        List<Disputes::Dispute> expectedDisputes =
        [
            new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        List<Payments::RefundListItem> expectedRefunds =
        [
            new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPartial = true,
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = Refunds::RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
        ];
        int expectedSettlementAmount = 0;
        ApiEnum<string, Currency> expectedSettlementCurrency = Currency.Aed;
        int expectedTotalAmount = 0;
        string expectedCardHolderName = "card_holder_name";
        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardLastFour = "card_last_four";
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedCheckoutSessionID = "checkout_session_id";
        List<Payments::CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        string expectedDiscountID = "discount_id";
        List<Payments::Discount> expectedDiscounts =
        [
            new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Code = "code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountID = "discount_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Position = 0,
                PreserveOnPlanChange = true,
                RestrictedTo = ["string"],
                TimesUsed = 0,
                Type = DiscountType.Percentage,
                CyclesRemaining = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                SubscriptionCycles = 0,
                UsageLimit = 0,
            },
        ];
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        string expectedInvoiceID = "invoice_id";
        string expectedInvoiceUrl = "invoice_url";
        string expectedPaymentLink = "payment_link";
        string expectedPaymentMethod = "payment_method";
        string expectedPaymentMethodType = "payment_method_type";
        List<Payments::ProductCart> expectedProductCart =
        [
            new() { ProductID = "product_id", Quantity = 0 },
        ];
        ApiEnum<string, Payments::PaymentRefundStatus> expectedRefundStatus =
            Payments::PaymentRefundStatus.Partial;
        int expectedSettlementTax = 0;
        ApiEnum<string, Payments::IntentStatus> expectedStatus = Payments::IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";
        int expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("Payment");

        Assert.Equal(expectedBilling, deserialized.Billing);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedDigitalProductsDelivered, deserialized.DigitalProductsDelivered);
        Assert.Equal(expectedDisputes.Count, deserialized.Disputes.Count);
        for (int i = 0; i < expectedDisputes.Count; i++)
        {
            Assert.Equal(expectedDisputes[i], deserialized.Disputes[i]);
        }
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRefunds.Count, deserialized.Refunds.Count);
        for (int i = 0; i < expectedRefunds.Count; i++)
        {
            Assert.Equal(expectedRefunds[i], deserialized.Refunds[i]);
        }
        Assert.Equal(expectedSettlementAmount, deserialized.SettlementAmount);
        Assert.Equal(expectedSettlementCurrency, deserialized.SettlementCurrency);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedCardHolderName, deserialized.CardHolderName);
        Assert.Equal(expectedCardIssuingCountry, deserialized.CardIssuingCountry);
        Assert.Equal(expectedCardLastFour, deserialized.CardLastFour);
        Assert.Equal(expectedCardNetwork, deserialized.CardNetwork);
        Assert.Equal(expectedCardType, deserialized.CardType);
        Assert.Equal(expectedCheckoutSessionID, deserialized.CheckoutSessionID);
        Assert.NotNull(deserialized.CustomFieldResponses);
        Assert.Equal(expectedCustomFieldResponses.Count, deserialized.CustomFieldResponses.Count);
        for (int i = 0; i < expectedCustomFieldResponses.Count; i++)
        {
            Assert.Equal(expectedCustomFieldResponses[i], deserialized.CustomFieldResponses[i]);
        }
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.NotNull(deserialized.Discounts);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedInvoiceUrl, deserialized.InvoiceUrl);
        Assert.Equal(expectedPaymentLink, deserialized.PaymentLink);
        Assert.Equal(expectedPaymentMethod, deserialized.PaymentMethod);
        Assert.Equal(expectedPaymentMethodType, deserialized.PaymentMethodType);
        Assert.NotNull(deserialized.ProductCart);
        Assert.Equal(expectedProductCart.Count, deserialized.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], deserialized.ProductCart[i]);
        }
        Assert.Equal(expectedRefundStatus, deserialized.RefundStatus);
        Assert.Equal(expectedSettlementTax, deserialized.SettlementTax);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            CardHolderName = "card_holder_name",
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            CardType = "card_type",
            CheckoutSessionID = "checkout_session_id",
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.CardIssuingCountry);
        Assert.False(model.RawData.ContainsKey("card_issuing_country"));
        Assert.Null(model.RefundStatus);
        Assert.False(model.RawData.ContainsKey("refund_status"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            CardHolderName = "card_holder_name",
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            CardType = "card_type",
            CheckoutSessionID = "checkout_session_id",
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            CardHolderName = "card_holder_name",
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            CardType = "card_type",
            CheckoutSessionID = "checkout_session_id",
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            CardIssuingCountry = null,
            RefundStatus = null,
            Status = null,
        };

        Assert.Null(model.CardIssuingCountry);
        Assert.False(model.RawData.ContainsKey("card_issuing_country"));
        Assert.Null(model.RefundStatus);
        Assert.False(model.RawData.ContainsKey("refund_status"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            CardHolderName = "card_holder_name",
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            CardType = "card_type",
            CheckoutSessionID = "checkout_session_id",
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            CardIssuingCountry = null,
            RefundStatus = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            CardIssuingCountry = CountryCode.Af,
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            Status = Payments::IntentStatus.Succeeded,
        };

        Assert.Null(model.CardHolderName);
        Assert.False(model.RawData.ContainsKey("card_holder_name"));
        Assert.Null(model.CardLastFour);
        Assert.False(model.RawData.ContainsKey("card_last_four"));
        Assert.Null(model.CardNetwork);
        Assert.False(model.RawData.ContainsKey("card_network"));
        Assert.Null(model.CardType);
        Assert.False(model.RawData.ContainsKey("card_type"));
        Assert.Null(model.CheckoutSessionID);
        Assert.False(model.RawData.ContainsKey("checkout_session_id"));
        Assert.Null(model.CustomFieldResponses);
        Assert.False(model.RawData.ContainsKey("custom_field_responses"));
        Assert.Null(model.DiscountID);
        Assert.False(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.InvoiceID);
        Assert.False(model.RawData.ContainsKey("invoice_id"));
        Assert.Null(model.InvoiceUrl);
        Assert.False(model.RawData.ContainsKey("invoice_url"));
        Assert.Null(model.PaymentLink);
        Assert.False(model.RawData.ContainsKey("payment_link"));
        Assert.Null(model.PaymentMethod);
        Assert.False(model.RawData.ContainsKey("payment_method"));
        Assert.Null(model.PaymentMethodType);
        Assert.False(model.RawData.ContainsKey("payment_method_type"));
        Assert.Null(model.ProductCart);
        Assert.False(model.RawData.ContainsKey("product_cart"));
        Assert.Null(model.SettlementTax);
        Assert.False(model.RawData.ContainsKey("settlement_tax"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            CardIssuingCountry = CountryCode.Af,
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            Status = Payments::IntentStatus.Succeeded,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            CardIssuingCountry = CountryCode.Af,
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            Status = Payments::IntentStatus.Succeeded,

            CardHolderName = null,
            CardLastFour = null,
            CardNetwork = null,
            CardType = null,
            CheckoutSessionID = null,
            CustomFieldResponses = null,
            DiscountID = null,
            Discounts = null,
            ErrorCode = null,
            ErrorMessage = null,
            InvoiceID = null,
            InvoiceUrl = null,
            PaymentLink = null,
            PaymentMethod = null,
            PaymentMethodType = null,
            ProductCart = null,
            SettlementTax = null,
            SubscriptionID = null,
            Tax = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CardHolderName);
        Assert.True(model.RawData.ContainsKey("card_holder_name"));
        Assert.Null(model.CardLastFour);
        Assert.True(model.RawData.ContainsKey("card_last_four"));
        Assert.Null(model.CardNetwork);
        Assert.True(model.RawData.ContainsKey("card_network"));
        Assert.Null(model.CardType);
        Assert.True(model.RawData.ContainsKey("card_type"));
        Assert.Null(model.CheckoutSessionID);
        Assert.True(model.RawData.ContainsKey("checkout_session_id"));
        Assert.Null(model.CustomFieldResponses);
        Assert.True(model.RawData.ContainsKey("custom_field_responses"));
        Assert.Null(model.DiscountID);
        Assert.True(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.Discounts);
        Assert.True(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.ErrorCode);
        Assert.True(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.InvoiceID);
        Assert.True(model.RawData.ContainsKey("invoice_id"));
        Assert.Null(model.InvoiceUrl);
        Assert.True(model.RawData.ContainsKey("invoice_url"));
        Assert.Null(model.PaymentLink);
        Assert.True(model.RawData.ContainsKey("payment_link"));
        Assert.Null(model.PaymentMethod);
        Assert.True(model.RawData.ContainsKey("payment_method"));
        Assert.Null(model.PaymentMethodType);
        Assert.True(model.RawData.ContainsKey("payment_method_type"));
        Assert.Null(model.ProductCart);
        Assert.True(model.RawData.ContainsKey("product_cart"));
        Assert.Null(model.SettlementTax);
        Assert.True(model.RawData.ContainsKey("settlement_tax"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            CardIssuingCountry = CountryCode.Af,
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            Status = Payments::IntentStatus.Succeeded,

            CardHolderName = null,
            CardLastFour = null,
            CardNetwork = null,
            CardType = null,
            CheckoutSessionID = null,
            CustomFieldResponses = null,
            DiscountID = null,
            Discounts = null,
            ErrorCode = null,
            ErrorMessage = null,
            InvoiceID = null,
            InvoiceUrl = null,
            PaymentLink = null,
            PaymentMethod = null,
            PaymentMethodType = null,
            ProductCart = null,
            SettlementTax = null,
            SubscriptionID = null,
            Tax = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Payment
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
                    DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
                    DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
                    PaymentID = "payment_id",
                    IsResolvedByRdr = true,
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
                    Status = Refunds::RefundStatus.Succeeded,
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
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            RefundStatus = Payments::PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Payment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };

        List<Subscriptions::AddonCartResponseItem> expectedAddons =
        [
            new() { AddonID = "addon_id", Quantity = 0 },
        ];
        Payments::BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Subscriptions::CreditEntitlementCartResponse> expectedCreditEntitlementCart =
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
                RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
            },
        ];
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<Subscriptions::MeterCreditEntitlementCartResponse> expectedMeterCreditEntitlementCart =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                MeterID = "meter_id",
                MeterName = "meter_name",
                MeterUnitsPerCredit = "meter_units_per_credit",
                ProductID = "product_id",
            },
        ];
        List<Subscriptions::MeterCartResponseItem> expectedMeters =
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
        ];
        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedOnDemand = true;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedPaymentFrequencyInterval =
            Subscriptions::TimeInterval.Day;
        DateTimeOffset expectedPreviousBillingDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        int expectedRecurringPreTaxAmount = 0;
        ApiEnum<string, Subscriptions::SubscriptionStatus> expectedStatus =
            Subscriptions::SubscriptionStatus.Pending;
        string expectedSubscriptionID = "subscription_id";
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedSubscriptionPeriodInterval =
            Subscriptions::TimeInterval.Day;
        bool expectedTaxInclusive = true;
        int expectedTrialPeriodDays = 0;
        string expectedCancellationComment = "cancellation_comment";
        ApiEnum<string, Subscriptions::CancellationFeedback> expectedCancellationFeedback =
            Subscriptions::CancellationFeedback.TooExpensive;
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Payments::CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        int expectedDiscountCyclesRemaining = 0;
        string expectedDiscountID = "discount_id";
        List<Subscriptions::Discount> expectedDiscounts =
        [
            new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Code = "code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountID = "discount_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Position = 0,
                PreserveOnPlanChange = true,
                RestrictedTo = ["string"],
                TimesUsed = 0,
                Type = DiscountType.Percentage,
                CyclesRemaining = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                SubscriptionCycles = 0,
                UsageLimit = 0,
            },
        ];
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentMethodID = "payment_method_id";
        Subscriptions::ScheduledPlanChange expectedScheduledChange = new()
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            ProductDescription = "product_description",
            ProductName = "product_name",
        };
        string expectedTaxID = "tax_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("Subscription");

        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedBilling, model.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, model.CancelAtNextBillingDate);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditEntitlementCart.Count, model.CreditEntitlementCart.Count);
        for (int i = 0; i < expectedCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlementCart[i], model.CreditEntitlementCart[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(
            expectedMeterCreditEntitlementCart.Count,
            model.MeterCreditEntitlementCart.Count
        );
        for (int i = 0; i < expectedMeterCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(
                expectedMeterCreditEntitlementCart[i],
                model.MeterCreditEntitlementCart[i]
            );
        }
        Assert.Equal(expectedMeters.Count, model.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], model.Meters[i]);
        }
        Assert.Equal(expectedNextBillingDate, model.NextBillingDate);
        Assert.Equal(expectedOnDemand, model.OnDemand);
        Assert.Equal(expectedPaymentFrequencyCount, model.PaymentFrequencyCount);
        Assert.Equal(expectedPaymentFrequencyInterval, model.PaymentFrequencyInterval);
        Assert.Equal(expectedPreviousBillingDate, model.PreviousBillingDate);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedRecurringPreTaxAmount, model.RecurringPreTaxAmount);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedSubscriptionPeriodCount, model.SubscriptionPeriodCount);
        Assert.Equal(expectedSubscriptionPeriodInterval, model.SubscriptionPeriodInterval);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedTrialPeriodDays, model.TrialPeriodDays);
        Assert.Equal(expectedCancellationComment, model.CancellationComment);
        Assert.Equal(expectedCancellationFeedback, model.CancellationFeedback);
        Assert.Equal(expectedCancelledAt, model.CancelledAt);
        Assert.NotNull(model.CustomFieldResponses);
        Assert.Equal(expectedCustomFieldResponses.Count, model.CustomFieldResponses.Count);
        for (int i = 0; i < expectedCustomFieldResponses.Count; i++)
        {
            Assert.Equal(expectedCustomFieldResponses[i], model.CustomFieldResponses[i]);
        }
        Assert.Equal(expectedDiscountCyclesRemaining, model.DiscountCyclesRemaining);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.NotNull(model.Discounts);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedScheduledChange, model.ScheduledChange);
        Assert.Equal(expectedTaxID, model.TaxID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Subscriptions::AddonCartResponseItem> expectedAddons =
        [
            new() { AddonID = "addon_id", Quantity = 0 },
        ];
        Payments::BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Subscriptions::CreditEntitlementCartResponse> expectedCreditEntitlementCart =
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
                RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
            },
        ];
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<Subscriptions::MeterCreditEntitlementCartResponse> expectedMeterCreditEntitlementCart =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                MeterID = "meter_id",
                MeterName = "meter_name",
                MeterUnitsPerCredit = "meter_units_per_credit",
                ProductID = "product_id",
            },
        ];
        List<Subscriptions::MeterCartResponseItem> expectedMeters =
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
        ];
        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedOnDemand = true;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedPaymentFrequencyInterval =
            Subscriptions::TimeInterval.Day;
        DateTimeOffset expectedPreviousBillingDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        int expectedRecurringPreTaxAmount = 0;
        ApiEnum<string, Subscriptions::SubscriptionStatus> expectedStatus =
            Subscriptions::SubscriptionStatus.Pending;
        string expectedSubscriptionID = "subscription_id";
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedSubscriptionPeriodInterval =
            Subscriptions::TimeInterval.Day;
        bool expectedTaxInclusive = true;
        int expectedTrialPeriodDays = 0;
        string expectedCancellationComment = "cancellation_comment";
        ApiEnum<string, Subscriptions::CancellationFeedback> expectedCancellationFeedback =
            Subscriptions::CancellationFeedback.TooExpensive;
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Payments::CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        int expectedDiscountCyclesRemaining = 0;
        string expectedDiscountID = "discount_id";
        List<Subscriptions::Discount> expectedDiscounts =
        [
            new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Code = "code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountID = "discount_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Position = 0,
                PreserveOnPlanChange = true,
                RestrictedTo = ["string"],
                TimesUsed = 0,
                Type = DiscountType.Percentage,
                CyclesRemaining = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                SubscriptionCycles = 0,
                UsageLimit = 0,
            },
        ];
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentMethodID = "payment_method_id";
        Subscriptions::ScheduledPlanChange expectedScheduledChange = new()
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            ProductDescription = "product_description",
            ProductName = "product_name",
        };
        string expectedTaxID = "tax_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("Subscription");

        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedBilling, deserialized.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, deserialized.CancelAtNextBillingDate);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditEntitlementCart.Count, deserialized.CreditEntitlementCart.Count);
        for (int i = 0; i < expectedCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlementCart[i], deserialized.CreditEntitlementCart[i]);
        }
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(
            expectedMeterCreditEntitlementCart.Count,
            deserialized.MeterCreditEntitlementCart.Count
        );
        for (int i = 0; i < expectedMeterCreditEntitlementCart.Count; i++)
        {
            Assert.Equal(
                expectedMeterCreditEntitlementCart[i],
                deserialized.MeterCreditEntitlementCart[i]
            );
        }
        Assert.Equal(expectedMeters.Count, deserialized.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], deserialized.Meters[i]);
        }
        Assert.Equal(expectedNextBillingDate, deserialized.NextBillingDate);
        Assert.Equal(expectedOnDemand, deserialized.OnDemand);
        Assert.Equal(expectedPaymentFrequencyCount, deserialized.PaymentFrequencyCount);
        Assert.Equal(expectedPaymentFrequencyInterval, deserialized.PaymentFrequencyInterval);
        Assert.Equal(expectedPreviousBillingDate, deserialized.PreviousBillingDate);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedRecurringPreTaxAmount, deserialized.RecurringPreTaxAmount);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedSubscriptionPeriodCount, deserialized.SubscriptionPeriodCount);
        Assert.Equal(expectedSubscriptionPeriodInterval, deserialized.SubscriptionPeriodInterval);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedTrialPeriodDays, deserialized.TrialPeriodDays);
        Assert.Equal(expectedCancellationComment, deserialized.CancellationComment);
        Assert.Equal(expectedCancellationFeedback, deserialized.CancellationFeedback);
        Assert.Equal(expectedCancelledAt, deserialized.CancelledAt);
        Assert.NotNull(deserialized.CustomFieldResponses);
        Assert.Equal(expectedCustomFieldResponses.Count, deserialized.CustomFieldResponses.Count);
        for (int i = 0; i < expectedCustomFieldResponses.Count; i++)
        {
            Assert.Equal(expectedCustomFieldResponses[i], deserialized.CustomFieldResponses[i]);
        }
        Assert.Equal(expectedDiscountCyclesRemaining, deserialized.DiscountCyclesRemaining);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.NotNull(deserialized.Discounts);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedScheduledChange, deserialized.ScheduledChange);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        Assert.Null(model.CancellationFeedback);
        Assert.False(model.RawData.ContainsKey("cancellation_feedback"));
        Assert.Null(model.ScheduledChange);
        Assert.False(model.RawData.ContainsKey("scheduled_change"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",

            // Null should be interpreted as omitted for these properties
            CancellationFeedback = null,
            ScheduledChange = null,
        };

        Assert.Null(model.CancellationFeedback);
        Assert.False(model.RawData.ContainsKey("cancellation_feedback"));
        Assert.Null(model.ScheduledChange);
        Assert.False(model.RawData.ContainsKey("scheduled_change"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",

            // Null should be interpreted as omitted for these properties
            CancellationFeedback = null,
            ScheduledChange = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
        };

        Assert.Null(model.CancellationComment);
        Assert.False(model.RawData.ContainsKey("cancellation_comment"));
        Assert.Null(model.CancelledAt);
        Assert.False(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.CustomFieldResponses);
        Assert.False(model.RawData.ContainsKey("custom_field_responses"));
        Assert.Null(model.DiscountCyclesRemaining);
        Assert.False(model.RawData.ContainsKey("discount_cycles_remaining"));
        Assert.Null(model.DiscountID);
        Assert.False(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("payment_method_id"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },

            CancellationComment = null,
            CancelledAt = null,
            CustomFieldResponses = null,
            DiscountCyclesRemaining = null,
            DiscountID = null,
            Discounts = null,
            ExpiresAt = null,
            PaymentMethodID = null,
            TaxID = null,
        };

        Assert.Null(model.CancellationComment);
        Assert.True(model.RawData.ContainsKey("cancellation_comment"));
        Assert.Null(model.CancelledAt);
        Assert.True(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.CustomFieldResponses);
        Assert.True(model.RawData.ContainsKey("custom_field_responses"));
        Assert.Null(model.DiscountCyclesRemaining);
        Assert.True(model.RawData.ContainsKey("discount_cycles_remaining"));
        Assert.Null(model.DiscountID);
        Assert.True(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.Discounts);
        Assert.True(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.PaymentMethodID);
        Assert.True(model.RawData.ContainsKey("payment_method_id"));
        Assert.Null(model.TaxID);
        Assert.True(model.RawData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },

            CancellationComment = null,
            CancelledAt = null,
            CustomFieldResponses = null,
            DiscountCyclesRemaining = null,
            DiscountID = null,
            Discounts = null,
            ExpiresAt = null,
            PaymentMethodID = null,
            TaxID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscription
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
                    RolloverTimeframeInterval = Subscriptions::TimeInterval.Day,
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
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = Subscriptions::SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancellationComment = "cancellation_comment",
            CancellationFeedback = Subscriptions::CancellationFeedback.TooExpensive,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Code = "code",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Position = 0,
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Percentage,
                    CyclesRemaining = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            ScheduledChange = new()
            {
                ID = "id",
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Name = "name",
                        Quantity = 0,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                ProductDescription = "product_description",
                ProductName = "product_name",
            },
            TaxID = "tax_id",
        };

        Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RefundTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
        };

        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        bool expectedIsPartial = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        string expectedRefundID = "refund_id";
        ApiEnum<string, Refunds::RefundStatus> expectedStatus = Refunds::RefundStatus.Succeeded;
        int expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedReason = "reason";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("Refund");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedIsPartial, model.IsPartial);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRefundID, model.RefundID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedReason, model.Reason);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Refund>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Refund>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        bool expectedIsPartial = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        string expectedRefundID = "refund_id";
        ApiEnum<string, Refunds::RefundStatus> expectedStatus = Refunds::RefundStatus.Succeeded;
        int expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedReason = "reason";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("Refund");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedIsPartial, deserialized.IsPartial);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRefundID, deserialized.RefundID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Reason = "reason",
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Currency = null,
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Currency = Currency.Aed,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Currency = Currency.Aed,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Currency = Currency.Aed,

            Amount = null,
            Reason = null,
        };

        Assert.Null(model.Amount);
        Assert.True(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Currency = Currency.Aed,

            Amount = null,
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Refund
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
            Status = Refunds::RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
        };

        Refund copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DisputeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            IsResolvedByRdr = true,
            Reason = "reason",
            Remarks = "remarks",
        };

        string expectedAmount = "amount";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        string expectedDisputeID = "dispute_id";
        ApiEnum<string, Disputes::DisputeDisputeStage> expectedDisputeStage =
            Disputes::DisputeDisputeStage.PreDispute;
        ApiEnum<string, Disputes::DisputeDisputeStatus> expectedDisputeStatus =
            Disputes::DisputeDisputeStatus.DisputeOpened;
        string expectedPaymentID = "payment_id";
        bool expectedIsResolvedByRdr = true;
        string expectedReason = "reason";
        string expectedRemarks = "remarks";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("Dispute");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDisputeID, model.DisputeID);
        Assert.Equal(expectedDisputeStage, model.DisputeStage);
        Assert.Equal(expectedDisputeStatus, model.DisputeStatus);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedIsResolvedByRdr, model.IsResolvedByRdr);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRemarks, model.Remarks);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            IsResolvedByRdr = true,
            Reason = "reason",
            Remarks = "remarks",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dispute>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            IsResolvedByRdr = true,
            Reason = "reason",
            Remarks = "remarks",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dispute>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "amount";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        Payments::CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        string expectedDisputeID = "dispute_id";
        ApiEnum<string, Disputes::DisputeDisputeStage> expectedDisputeStage =
            Disputes::DisputeDisputeStage.PreDispute;
        ApiEnum<string, Disputes::DisputeDisputeStatus> expectedDisputeStatus =
            Disputes::DisputeDisputeStatus.DisputeOpened;
        string expectedPaymentID = "payment_id";
        bool expectedIsResolvedByRdr = true;
        string expectedReason = "reason";
        string expectedRemarks = "remarks";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("Dispute");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedDisputeID, deserialized.DisputeID);
        Assert.Equal(expectedDisputeStage, deserialized.DisputeStage);
        Assert.Equal(expectedDisputeStatus, deserialized.DisputeStatus);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedIsResolvedByRdr, deserialized.IsResolvedByRdr);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRemarks, deserialized.Remarks);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            IsResolvedByRdr = true,
            Reason = "reason",
            Remarks = "remarks",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
        };

        Assert.Null(model.IsResolvedByRdr);
        Assert.False(model.RawData.ContainsKey("is_resolved_by_rdr"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Remarks);
        Assert.False(model.RawData.ContainsKey("remarks"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",

            IsResolvedByRdr = null,
            Reason = null,
            Remarks = null,
        };

        Assert.Null(model.IsResolvedByRdr);
        Assert.True(model.RawData.ContainsKey("is_resolved_by_rdr"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Remarks);
        Assert.True(model.RawData.ContainsKey("remarks"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",

            IsResolvedByRdr = null,
            Reason = null,
            Remarks = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Dispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = Disputes::DisputeDisputeStage.PreDispute,
            DisputeStatus = Disputes::DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            IsResolvedByRdr = true,
            Reason = "reason",
            Remarks = "remarks",
        };

        Dispute copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LicenseKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        string expectedID = "lic_123";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedCustomerID = "cus_123";
        int expectedInstancesCount = 0;
        string expectedKey = "key";
        string expectedProductID = "product_id";
        ApiEnum<string, LicenseKeys::LicenseKeySource> expectedSource =
            LicenseKeys::LicenseKeySource.Auto;
        ApiEnum<string, LicenseKeys::LicenseKeyStatus> expectedStatus =
            LicenseKeys::LicenseKeyStatus.Active;
        int expectedActivationsLimit = 5;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z");
        string expectedPaymentID = "payment_id";
        string expectedSubscriptionID = "subscription_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("LicenseKey");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedInstancesCount, model.InstancesCount);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedActivationsLimit, model.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "lic_123";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedCustomerID = "cus_123";
        int expectedInstancesCount = 0;
        string expectedKey = "key";
        string expectedProductID = "product_id";
        ApiEnum<string, LicenseKeys::LicenseKeySource> expectedSource =
            LicenseKeys::LicenseKeySource.Auto;
        ApiEnum<string, LicenseKeys::LicenseKeyStatus> expectedStatus =
            LicenseKeys::LicenseKeyStatus.Active;
        int expectedActivationsLimit = 5;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z");
        string expectedPaymentID = "payment_id";
        string expectedSubscriptionID = "subscription_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("LicenseKey");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedInstancesCount, deserialized.InstancesCount);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedActivationsLimit, deserialized.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.False(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,

            ActivationsLimit = null,
            ExpiresAt = null,
            PaymentID = null,
            SubscriptionID = null,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.True(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,

            ActivationsLimit = null,
            ExpiresAt = null,
            PaymentID = null,
            SubscriptionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LicenseKey
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            ProductID = "product_id",
            Source = LicenseKeys::LicenseKeySource.Auto,
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            PaymentID = "payment_id",
            SubscriptionID = "subscription_id",
        };

        LicenseKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditLedgerEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        string expectedBalanceBefore = "balance_before";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        bool expectedIsCredit = true;
        string expectedOverageAfter = "overage_after";
        string expectedOverageBefore = "overage_before";
        ApiEnum<string, Balances::TransactionType> expectedTransactionType =
            Balances::TransactionType.CreditAdded;
        string expectedDescription = "description";
        string expectedGrantID = "grant_id";
        string expectedReferenceID = "reference_id";
        string expectedReferenceType = "reference_type";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("CreditLedgerEntry");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBalanceAfter, model.BalanceAfter);
        Assert.Equal(expectedBalanceBefore, model.BalanceBefore);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedIsCredit, model.IsCredit);
        Assert.Equal(expectedOverageAfter, model.OverageAfter);
        Assert.Equal(expectedOverageBefore, model.OverageBefore);
        Assert.Equal(expectedTransactionType, model.TransactionType);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedGrantID, model.GrantID);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedReferenceType, model.ReferenceType);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditLedgerEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditLedgerEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        string expectedBalanceBefore = "balance_before";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        bool expectedIsCredit = true;
        string expectedOverageAfter = "overage_after";
        string expectedOverageBefore = "overage_before";
        ApiEnum<string, Balances::TransactionType> expectedTransactionType =
            Balances::TransactionType.CreditAdded;
        string expectedDescription = "description";
        string expectedGrantID = "grant_id";
        string expectedReferenceID = "reference_id";
        string expectedReferenceType = "reference_type";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("CreditLedgerEntry");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBalanceAfter, deserialized.BalanceAfter);
        Assert.Equal(expectedBalanceBefore, deserialized.BalanceBefore);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedIsCredit, deserialized.IsCredit);
        Assert.Equal(expectedOverageAfter, deserialized.OverageAfter);
        Assert.Equal(expectedOverageBefore, deserialized.OverageBefore);
        Assert.Equal(expectedTransactionType, deserialized.TransactionType);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedGrantID, deserialized.GrantID);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedReferenceType, deserialized.ReferenceType);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.GrantID);
        Assert.False(model.RawData.ContainsKey("grant_id"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
        Assert.Null(model.ReferenceType);
        Assert.False(model.RawData.ContainsKey("reference_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,

            Description = null,
            GrantID = null,
            ReferenceID = null,
            ReferenceType = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.GrantID);
        Assert.True(model.RawData.ContainsKey("grant_id"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
        Assert.Null(model.ReferenceType);
        Assert.True(model.RawData.ContainsKey("reference_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,

            Description = null,
            GrantID = null,
            ReferenceID = null,
            ReferenceType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditLedgerEntry
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
            TransactionType = Balances::TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };

        CreditLedgerEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditBalanceLowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditBalanceLow
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string expectedAvailableBalance = "available_balance";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCustomerID = "customer_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("CreditBalanceLow");
        string expectedSubscriptionCreditsAmount = "subscription_credits_amount";
        string expectedSubscriptionID = "subscription_id";
        string expectedThresholdAmount = "threshold_amount";
        int expectedThresholdPercent = 0;

        Assert.Equal(expectedAvailableBalance, model.AvailableBalance);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, model.CreditEntitlementName);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
        Assert.Equal(expectedSubscriptionCreditsAmount, model.SubscriptionCreditsAmount);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedThresholdAmount, model.ThresholdAmount);
        Assert.Equal(expectedThresholdPercent, model.ThresholdPercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditBalanceLow
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBalanceLow>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditBalanceLow
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBalanceLow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAvailableBalance = "available_balance";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        string expectedCustomerID = "customer_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("CreditBalanceLow");
        string expectedSubscriptionCreditsAmount = "subscription_credits_amount";
        string expectedSubscriptionID = "subscription_id";
        string expectedThresholdAmount = "threshold_amount";
        int expectedThresholdPercent = 0;

        Assert.Equal(expectedAvailableBalance, deserialized.AvailableBalance);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, deserialized.CreditEntitlementName);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
        Assert.Equal(expectedSubscriptionCreditsAmount, deserialized.SubscriptionCreditsAmount);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedThresholdAmount, deserialized.ThresholdAmount);
        Assert.Equal(expectedThresholdPercent, deserialized.ThresholdPercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditBalanceLow
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditBalanceLow
        {
            AvailableBalance = "available_balance",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            CustomerID = "customer_id",
            SubscriptionCreditsAmount = "subscription_credits_amount",
            SubscriptionID = "subscription_id",
            ThresholdAmount = "threshold_amount",
            ThresholdPercent = 0,
        };

        CreditBalanceLow copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AbandonedCheckoutTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        DateTimeOffset expectedAbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AbandonmentReason> expectedAbandonmentReason =
            AbandonmentReason.PaymentFailed;
        string expectedCustomerID = "customer_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("AbandonedCheckout");
        string expectedPaymentID = "payment_id";
        ApiEnum<string, Status> expectedStatus = Status.Abandoned;
        string expectedRecoveredPaymentID = "recovered_payment_id";

        Assert.Equal(expectedAbandonedAt, model.AbandonedAt);
        Assert.Equal(expectedAbandonmentReason, model.AbandonmentReason);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedRecoveredPaymentID, model.RecoveredPaymentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AbandonedCheckout>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AbandonedCheckout>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AbandonmentReason> expectedAbandonmentReason =
            AbandonmentReason.PaymentFailed;
        string expectedCustomerID = "customer_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("AbandonedCheckout");
        string expectedPaymentID = "payment_id";
        ApiEnum<string, Status> expectedStatus = Status.Abandoned;
        string expectedRecoveredPaymentID = "recovered_payment_id";

        Assert.Equal(expectedAbandonedAt, deserialized.AbandonedAt);
        Assert.Equal(expectedAbandonmentReason, deserialized.AbandonmentReason);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedRecoveredPaymentID, deserialized.RecoveredPaymentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
        };

        Assert.Null(model.RecoveredPaymentID);
        Assert.False(model.RawData.ContainsKey("recovered_payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,

            RecoveredPaymentID = null,
        };

        Assert.Null(model.RecoveredPaymentID);
        Assert.True(model.RawData.ContainsKey("recovered_payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,

            RecoveredPaymentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AbandonedCheckout
        {
            AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AbandonmentReason = AbandonmentReason.PaymentFailed,
            CustomerID = "customer_id",
            PaymentID = "payment_id",
            Status = Status.Abandoned,
            RecoveredPaymentID = "recovered_payment_id",
        };

        AbandonedCheckout copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AbandonmentReasonTest : TestBase
{
    [Theory]
    [InlineData(AbandonmentReason.PaymentFailed)]
    [InlineData(AbandonmentReason.CheckoutIncomplete)]
    public void Validation_Works(AbandonmentReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonmentReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AbandonmentReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AbandonmentReason.PaymentFailed)]
    [InlineData(AbandonmentReason.CheckoutIncomplete)]
    public void SerializationRoundtrip_Works(AbandonmentReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AbandonmentReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AbandonmentReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AbandonmentReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AbandonmentReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Abandoned)]
    [InlineData(Status.Recovering)]
    [InlineData(Status.Recovered)]
    [InlineData(Status.Exhausted)]
    [InlineData(Status.OptedOut)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Abandoned)]
    [InlineData(Status.Recovering)]
    [InlineData(Status.Recovered)]
    [InlineData(Status.Exhausted)]
    [InlineData(Status.OptedOut)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DunningAttemptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("DunningAttempt");
        ApiEnum<string, DunningAttemptStatus> expectedStatus = DunningAttemptStatus.Recovering;
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, TriggerState> expectedTriggerState = TriggerState.OnHold;
        string expectedPaymentID = "payment_id";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedTriggerState, model.TriggerState);
        Assert.Equal(expectedPaymentID, model.PaymentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningAttempt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DunningAttempt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("DunningAttempt");
        ApiEnum<string, DunningAttemptStatus> expectedStatus = DunningAttemptStatus.Recovering;
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, TriggerState> expectedTriggerState = TriggerState.OnHold;
        string expectedPaymentID = "payment_id";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedTriggerState, deserialized.TriggerState);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
        };

        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,

            PaymentID = null,
        };

        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,

            PaymentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DunningAttempt
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            Status = DunningAttemptStatus.Recovering,
            SubscriptionID = "subscription_id",
            TriggerState = TriggerState.OnHold,
            PaymentID = "payment_id",
        };

        DunningAttempt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DunningAttemptStatusTest : TestBase
{
    [Theory]
    [InlineData(DunningAttemptStatus.Recovering)]
    [InlineData(DunningAttemptStatus.Recovered)]
    [InlineData(DunningAttemptStatus.Exhausted)]
    public void Validation_Works(DunningAttemptStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningAttemptStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DunningAttemptStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DunningAttemptStatus.Recovering)]
    [InlineData(DunningAttemptStatus.Recovered)]
    [InlineData(DunningAttemptStatus.Exhausted)]
    public void SerializationRoundtrip_Works(DunningAttemptStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DunningAttemptStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DunningAttemptStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DunningAttemptStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DunningAttemptStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TriggerStateTest : TestBase
{
    [Theory]
    [InlineData(TriggerState.OnHold)]
    [InlineData(TriggerState.Cancelled)]
    public void Validation_Works(TriggerState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TriggerState.OnHold)]
    [InlineData(TriggerState.Cancelled)]
    public void SerializationRoundtrip_Works(TriggerState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementGrantTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        string expectedEntitlementID = "entitlement_id";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Grants::EntitlementGrantStatus> expectedStatus =
            Grants::EntitlementGrantStatus.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductDigitalProductDelivery expectedDigitalProductDelivery = new()
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        Grants::LicenseKeyGrant expectedLicenseKey = new()
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        DateTimeOffset expectedOAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedOAuthUrl = "oauth_url";
        string expectedPaymentID = "payment_id";
        string expectedRevocationReason = "revocation_reason";
        DateTimeOffset expectedRevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSubscriptionID = "subscription_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("EntitlementGrant");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEntitlementID, model.EntitlementID);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDeliveredAt, model.DeliveredAt);
        Assert.Equal(expectedDigitalProductDelivery, model.DigitalProductDelivery);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedLicenseKey, model.LicenseKey);
        Assert.Equal(expectedOAuthExpiresAt, model.OAuthExpiresAt);
        Assert.Equal(expectedOAuthUrl, model.OAuthUrl);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRevocationReason, model.RevocationReason);
        Assert.Equal(expectedRevokedAt, model.RevokedAt);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, model.PayloadType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementGrant>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementGrant>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        string expectedEntitlementID = "entitlement_id";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Grants::EntitlementGrantStatus> expectedStatus =
            Grants::EntitlementGrantStatus.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductDigitalProductDelivery expectedDigitalProductDelivery = new()
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        Grants::LicenseKeyGrant expectedLicenseKey = new()
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        DateTimeOffset expectedOAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedOAuthUrl = "oauth_url";
        string expectedPaymentID = "payment_id";
        string expectedRevocationReason = "revocation_reason";
        DateTimeOffset expectedRevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSubscriptionID = "subscription_id";
        JsonElement expectedPayloadType = JsonSerializer.SerializeToElement("EntitlementGrant");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEntitlementID, deserialized.EntitlementID);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDeliveredAt, deserialized.DeliveredAt);
        Assert.Equal(expectedDigitalProductDelivery, deserialized.DigitalProductDelivery);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedLicenseKey, deserialized.LicenseKey);
        Assert.Equal(expectedOAuthExpiresAt, deserialized.OAuthExpiresAt);
        Assert.Equal(expectedOAuthUrl, deserialized.OAuthUrl);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRevocationReason, deserialized.RevocationReason);
        Assert.Equal(expectedRevokedAt, deserialized.RevokedAt);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.True(JsonElement.DeepEquals(expectedPayloadType, deserialized.PayloadType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        Assert.Null(model.DigitalProductDelivery);
        Assert.False(model.RawData.ContainsKey("digital_product_delivery"));
        Assert.Null(model.LicenseKey);
        Assert.False(model.RawData.ContainsKey("license_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",

            // Null should be interpreted as omitted for these properties
            DigitalProductDelivery = null,
            LicenseKey = null,
        };

        Assert.Null(model.DigitalProductDelivery);
        Assert.False(model.RawData.ContainsKey("digital_product_delivery"));
        Assert.Null(model.LicenseKey);
        Assert.False(model.RawData.ContainsKey("license_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",

            // Null should be interpreted as omitted for these properties
            DigitalProductDelivery = null,
            LicenseKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Null(model.DeliveredAt);
        Assert.False(model.RawData.ContainsKey("delivered_at"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.OAuthExpiresAt);
        Assert.False(model.RawData.ContainsKey("oauth_expires_at"));
        Assert.Null(model.OAuthUrl);
        Assert.False(model.RawData.ContainsKey("oauth_url"));
        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.RevocationReason);
        Assert.False(model.RawData.ContainsKey("revocation_reason"));
        Assert.Null(model.RevokedAt);
        Assert.False(model.RawData.ContainsKey("revoked_at"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            DeliveredAt = null,
            ErrorCode = null,
            ErrorMessage = null,
            OAuthExpiresAt = null,
            OAuthUrl = null,
            PaymentID = null,
            RevocationReason = null,
            RevokedAt = null,
            SubscriptionID = null,
        };

        Assert.Null(model.DeliveredAt);
        Assert.True(model.RawData.ContainsKey("delivered_at"));
        Assert.Null(model.ErrorCode);
        Assert.True(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.OAuthExpiresAt);
        Assert.True(model.RawData.ContainsKey("oauth_expires_at"));
        Assert.Null(model.OAuthUrl);
        Assert.True(model.RawData.ContainsKey("oauth_url"));
        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.RevocationReason);
        Assert.True(model.RawData.ContainsKey("revocation_reason"));
        Assert.Null(model.RevokedAt);
        Assert.True(model.RawData.ContainsKey("revoked_at"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            DeliveredAt = null,
            ErrorCode = null,
            ErrorMessage = null,
            OAuthExpiresAt = null,
            OAuthUrl = null,
            PaymentID = null,
            RevocationReason = null,
            RevokedAt = null,
            SubscriptionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementGrant
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Grants::EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        EntitlementGrant copied = new(model);

        Assert.Equal(model, copied);
    }
}
