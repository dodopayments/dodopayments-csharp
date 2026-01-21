using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.WebhookEvents;
using Disputes = DodoPayments.Client.Models.Disputes;
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
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType = PayloadType.Payment,
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
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PayloadType.Payment,
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
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType = PayloadType.Payment,
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
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType = PayloadType.Payment,
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
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PayloadType.Payment,
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
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType = PayloadType.Payment,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = WebhookEventType.PaymentSucceeded,
        };

        model.Validate();
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
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PayloadType.Payment,
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
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
            Reason = "reason",
            Remarks = "remarks",
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            SubscriptionID = "subscription_id",
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
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
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PayloadType.Payment,
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
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
            Reason = "reason",
            Remarks = "remarks",
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            SubscriptionID = "subscription_id",
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
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
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PayloadType.Payment,
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
                Remarks = "remarks",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        List<Payments::Refund> expectedRefunds =
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
        int expectedSettlementTax = 0;
        ApiEnum<string, Payments::IntentStatus> expectedStatus = Payments::IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";
        int expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PayloadType> expectedPayloadType = PayloadType.Payment;

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
        Assert.Equal(expectedSettlementTax, model.SettlementTax);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedPayloadType, model.PayloadType);
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
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PayloadType.Payment,
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
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PayloadType.Payment,
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
                Remarks = "remarks",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        List<Payments::Refund> expectedRefunds =
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
        int expectedSettlementTax = 0;
        ApiEnum<string, Payments::IntentStatus> expectedStatus = Payments::IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";
        int expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PayloadType> expectedPayloadType = PayloadType.Payment;

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
        Assert.Equal(expectedSettlementTax, deserialized.SettlementTax);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
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
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PayloadType.Payment,
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
            PayloadType = PayloadType.Payment,
        };

        Assert.Null(model.CardIssuingCountry);
        Assert.False(model.RawData.ContainsKey("card_issuing_country"));
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
            PayloadType = PayloadType.Payment,
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
            PayloadType = PayloadType.Payment,

            // Null should be interpreted as omitted for these properties
            CardIssuingCountry = null,
            Status = null,
        };

        Assert.Null(model.CardIssuingCountry);
        Assert.False(model.RawData.ContainsKey("card_issuing_country"));
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
            PayloadType = PayloadType.Payment,

            // Null should be interpreted as omitted for these properties
            CardIssuingCountry = null,
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
            Status = Payments::IntentStatus.Succeeded,
            PayloadType = PayloadType.Payment,
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
            Status = Payments::IntentStatus.Succeeded,
            PayloadType = PayloadType.Payment,
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
            Status = Payments::IntentStatus.Succeeded,
            PayloadType = PayloadType.Payment,

            CardHolderName = null,
            CardLastFour = null,
            CardNetwork = null,
            CardType = null,
            CheckoutSessionID = null,
            CustomFieldResponses = null,
            DiscountID = null,
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
            Status = Payments::IntentStatus.Succeeded,
            PayloadType = PayloadType.Payment,

            CardHolderName = null,
            CardLastFour = null,
            CardNetwork = null,
            CardType = null,
            CheckoutSessionID = null,
            CustomFieldResponses = null,
            DiscountID = null,
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
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1 { PayloadType = PayloadType.Payment };

        ApiEnum<string, PayloadType> expectedPayloadType = PayloadType.Payment;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1 { PayloadType = PayloadType.Payment };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1 { PayloadType = PayloadType.Payment };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PayloadType> expectedPayloadType = PayloadType.Payment;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1 { PayloadType = PayloadType.Payment };

        model.Validate();
    }
}

public class PayloadTypeTest : TestBase
{
    [Theory]
    [InlineData(PayloadType.Payment)]
    public void Validation_Works(PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PayloadType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PayloadType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PayloadType.Payment)]
    public void SerializationRoundtrip_Works(PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PayloadType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PayloadType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PayloadType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PayloadType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
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
        List<Subscriptions::Meter> expectedMeters =
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
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Subscriptions::CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        int expectedDiscountCyclesRemaining = 0;
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentMethodID = "payment_method_id";
        string expectedTaxID = "tax_id";
        ApiEnum<string, SubscriptionIntersectionMember1PayloadType> expectedPayloadType =
            SubscriptionIntersectionMember1PayloadType.Subscription;

        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedBilling, model.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, model.CancelAtNextBillingDate);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
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
        Assert.Equal(expectedCancelledAt, model.CancelledAt);
        Assert.NotNull(model.CustomFieldResponses);
        Assert.Equal(expectedCustomFieldResponses.Count, model.CustomFieldResponses.Count);
        for (int i = 0; i < expectedCustomFieldResponses.Count; i++)
        {
            Assert.Equal(expectedCustomFieldResponses[i], model.CustomFieldResponses[i]);
        }
        Assert.Equal(expectedDiscountCyclesRemaining, model.DiscountCyclesRemaining);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedTaxID, model.TaxID);
        Assert.Equal(expectedPayloadType, model.PayloadType);
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
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
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
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
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
        List<Subscriptions::Meter> expectedMeters =
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
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Subscriptions::CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        int expectedDiscountCyclesRemaining = 0;
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentMethodID = "payment_method_id";
        string expectedTaxID = "tax_id";
        ApiEnum<string, SubscriptionIntersectionMember1PayloadType> expectedPayloadType =
            SubscriptionIntersectionMember1PayloadType.Subscription;

        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedBilling, deserialized.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, deserialized.CancelAtNextBillingDate);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
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
        Assert.Equal(expectedCancelledAt, deserialized.CancelledAt);
        Assert.NotNull(deserialized.CustomFieldResponses);
        Assert.Equal(expectedCustomFieldResponses.Count, deserialized.CustomFieldResponses.Count);
        for (int i = 0; i < expectedCustomFieldResponses.Count; i++)
        {
            Assert.Equal(expectedCustomFieldResponses[i], deserialized.CustomFieldResponses[i]);
        }
        Assert.Equal(expectedDiscountCyclesRemaining, deserialized.DiscountCyclesRemaining);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
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
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomFieldResponses = [new() { Key = "key", Value = "value" }],
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
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
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
        };

        Assert.Null(model.CancelledAt);
        Assert.False(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.CustomFieldResponses);
        Assert.False(model.RawData.ContainsKey("custom_field_responses"));
        Assert.Null(model.DiscountCyclesRemaining);
        Assert.False(model.RawData.ContainsKey("discount_cycles_remaining"));
        Assert.Null(model.DiscountID);
        Assert.False(model.RawData.ContainsKey("discount_id"));
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
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
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
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,

            CancelledAt = null,
            CustomFieldResponses = null,
            DiscountCyclesRemaining = null,
            DiscountID = null,
            ExpiresAt = null,
            PaymentMethodID = null,
            TaxID = null,
        };

        Assert.Null(model.CancelledAt);
        Assert.True(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.CustomFieldResponses);
        Assert.True(model.RawData.ContainsKey("custom_field_responses"));
        Assert.Null(model.DiscountCyclesRemaining);
        Assert.True(model.RawData.ContainsKey("discount_cycles_remaining"));
        Assert.Null(model.DiscountID);
        Assert.True(model.RawData.ContainsKey("discount_id"));
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
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,

            CancelledAt = null,
            CustomFieldResponses = null,
            DiscountCyclesRemaining = null,
            DiscountID = null,
            ExpiresAt = null,
            PaymentMethodID = null,
            TaxID = null,
        };

        model.Validate();
    }
}

public class SubscriptionIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionIntersectionMember1
        {
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
        };

        ApiEnum<string, SubscriptionIntersectionMember1PayloadType> expectedPayloadType =
            SubscriptionIntersectionMember1PayloadType.Subscription;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionIntersectionMember1
        {
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionIntersectionMember1
        {
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SubscriptionIntersectionMember1PayloadType> expectedPayloadType =
            SubscriptionIntersectionMember1PayloadType.Subscription;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionIntersectionMember1
        {
            PayloadType = SubscriptionIntersectionMember1PayloadType.Subscription,
        };

        model.Validate();
    }
}

public class SubscriptionIntersectionMember1PayloadTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionIntersectionMember1PayloadType.Subscription)]
    public void Validation_Works(SubscriptionIntersectionMember1PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionIntersectionMember1PayloadType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionIntersectionMember1PayloadType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionIntersectionMember1PayloadType.Subscription)]
    public void SerializationRoundtrip_Works(SubscriptionIntersectionMember1PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionIntersectionMember1PayloadType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionIntersectionMember1PayloadType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
        ApiEnum<string, RefundIntersectionMember1PayloadType> expectedPayloadType =
            RefundIntersectionMember1PayloadType.Refund;

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
        Assert.Equal(expectedPayloadType, model.PayloadType);
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
        ApiEnum<string, RefundIntersectionMember1PayloadType> expectedPayloadType =
            RefundIntersectionMember1PayloadType.Refund;

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
        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,

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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,

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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,

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
            PayloadType = RefundIntersectionMember1PayloadType.Refund,

            Amount = null,
            Reason = null,
        };

        model.Validate();
    }
}

public class RefundIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RefundIntersectionMember1
        {
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
        };

        ApiEnum<string, RefundIntersectionMember1PayloadType> expectedPayloadType =
            RefundIntersectionMember1PayloadType.Refund;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RefundIntersectionMember1
        {
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RefundIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RefundIntersectionMember1
        {
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RefundIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RefundIntersectionMember1PayloadType> expectedPayloadType =
            RefundIntersectionMember1PayloadType.Refund;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RefundIntersectionMember1
        {
            PayloadType = RefundIntersectionMember1PayloadType.Refund,
        };

        model.Validate();
    }
}

public class RefundIntersectionMember1PayloadTypeTest : TestBase
{
    [Theory]
    [InlineData(RefundIntersectionMember1PayloadType.Refund)]
    public void Validation_Works(RefundIntersectionMember1PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundIntersectionMember1PayloadType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RefundIntersectionMember1PayloadType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RefundIntersectionMember1PayloadType.Refund)]
    public void SerializationRoundtrip_Works(RefundIntersectionMember1PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundIntersectionMember1PayloadType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RefundIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RefundIntersectionMember1PayloadType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RefundIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
            Reason = "reason",
            Remarks = "remarks",
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
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
        string expectedReason = "reason";
        string expectedRemarks = "remarks";
        ApiEnum<string, DisputeIntersectionMember1PayloadType> expectedPayloadType =
            DisputeIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDisputeID, model.DisputeID);
        Assert.Equal(expectedDisputeStage, model.DisputeStage);
        Assert.Equal(expectedDisputeStatus, model.DisputeStatus);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRemarks, model.Remarks);
        Assert.Equal(expectedPayloadType, model.PayloadType);
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
            Reason = "reason",
            Remarks = "remarks",
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
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
            Reason = "reason",
            Remarks = "remarks",
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
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
        string expectedReason = "reason";
        string expectedRemarks = "remarks";
        ApiEnum<string, DisputeIntersectionMember1PayloadType> expectedPayloadType =
            DisputeIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedDisputeID, deserialized.DisputeID);
        Assert.Equal(expectedDisputeStage, deserialized.DisputeStage);
        Assert.Equal(expectedDisputeStatus, deserialized.DisputeStatus);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRemarks, deserialized.Remarks);
        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
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
            Reason = "reason",
            Remarks = "remarks",
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
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
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
        };

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
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
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
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,

            Reason = null,
            Remarks = null,
        };

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
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,

            Reason = null,
            Remarks = null,
        };

        model.Validate();
    }
}

public class DisputeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeIntersectionMember1
        {
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
        };

        ApiEnum<string, DisputeIntersectionMember1PayloadType> expectedPayloadType =
            DisputeIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DisputeIntersectionMember1
        {
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DisputeIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DisputeIntersectionMember1
        {
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DisputeIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DisputeIntersectionMember1PayloadType> expectedPayloadType =
            DisputeIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DisputeIntersectionMember1
        {
            PayloadType = DisputeIntersectionMember1PayloadType.Dispute,
        };

        model.Validate();
    }
}

public class DisputeIntersectionMember1PayloadTypeTest : TestBase
{
    [Theory]
    [InlineData(DisputeIntersectionMember1PayloadType.Dispute)]
    public void Validation_Works(DisputeIntersectionMember1PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeIntersectionMember1PayloadType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeIntersectionMember1PayloadType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeIntersectionMember1PayloadType.Dispute)]
    public void SerializationRoundtrip_Works(DisputeIntersectionMember1PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeIntersectionMember1PayloadType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeIntersectionMember1PayloadType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            SubscriptionID = "subscription_id",
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
        };

        string expectedID = "lic_123";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedCustomerID = "cus_123";
        int expectedInstancesCount = 0;
        string expectedKey = "key";
        string expectedPaymentID = "payment_id";
        string expectedProductID = "product_id";
        ApiEnum<string, LicenseKeys::LicenseKeyStatus> expectedStatus =
            LicenseKeys::LicenseKeyStatus.Active;
        int expectedActivationsLimit = 5;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z");
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> expectedPayloadType =
            LicenseKeyIntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedInstancesCount, model.InstancesCount);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedActivationsLimit, model.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedPayloadType, model.PayloadType);
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            SubscriptionID = "subscription_id",
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            SubscriptionID = "subscription_id",
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
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
        string expectedPaymentID = "payment_id";
        string expectedProductID = "product_id";
        ApiEnum<string, LicenseKeys::LicenseKeyStatus> expectedStatus =
            LicenseKeys::LicenseKeyStatus.Active;
        int expectedActivationsLimit = 5;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z");
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> expectedPayloadType =
            LicenseKeyIntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedInstancesCount, deserialized.InstancesCount);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedActivationsLimit, deserialized.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            SubscriptionID = "subscription_id",
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.False(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,

            ActivationsLimit = null,
            ExpiresAt = null,
            SubscriptionID = null,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.True(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
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
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeys::LicenseKeyStatus.Active,
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,

            ActivationsLimit = null,
            ExpiresAt = null,
            SubscriptionID = null,
        };

        model.Validate();
    }
}

public class LicenseKeyIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyIntersectionMember1
        {
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
        };

        ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> expectedPayloadType =
            LicenseKeyIntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKeyIntersectionMember1
        {
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyIntersectionMember1
        {
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> expectedPayloadType =
            LicenseKeyIntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKeyIntersectionMember1
        {
            PayloadType = LicenseKeyIntersectionMember1PayloadType.LicenseKey,
        };

        model.Validate();
    }
}

public class LicenseKeyIntersectionMember1PayloadTypeTest : TestBase
{
    [Theory]
    [InlineData(LicenseKeyIntersectionMember1PayloadType.LicenseKey)]
    public void Validation_Works(LicenseKeyIntersectionMember1PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LicenseKeyIntersectionMember1PayloadType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LicenseKeyIntersectionMember1PayloadType.LicenseKey)]
    public void SerializationRoundtrip_Works(LicenseKeyIntersectionMember1PayloadType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LicenseKeyIntersectionMember1PayloadType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LicenseKeyIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LicenseKeyIntersectionMember1PayloadType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LicenseKeyIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
