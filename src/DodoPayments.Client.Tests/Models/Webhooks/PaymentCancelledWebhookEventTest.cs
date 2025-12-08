using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.Webhooks;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class PaymentCancelledWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentCancelledWebhookEvent
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
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType =
                    PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentCancelledWebhookEventType.PaymentCancelled,
        };

        string expectedBusinessID = "business_id";
        PaymentCancelledWebhookEventData expectedData = new()
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
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PaymentCancelledWebhookEventType> expectedType =
            PaymentCancelledWebhookEventType.PaymentCancelled;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentCancelledWebhookEvent
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
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType =
                    PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentCancelledWebhookEventType.PaymentCancelled,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentCancelledWebhookEvent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentCancelledWebhookEvent
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
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType =
                    PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentCancelledWebhookEventType.PaymentCancelled,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentCancelledWebhookEvent>(json);
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        PaymentCancelledWebhookEventData expectedData = new()
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
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PaymentCancelledWebhookEventType> expectedType =
            PaymentCancelledWebhookEventType.PaymentCancelled;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentCancelledWebhookEvent
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
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                SettlementTax = 0,
                Status = Payments::IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType =
                    PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = PaymentCancelledWebhookEventType.PaymentCancelled,
        };

        model.Validate();
    }
}

public class PaymentCancelledWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentCancelledWebhookEventData
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
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
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
        List<Dispute> expectedDisputes =
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
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
        ];
        int expectedSettlementAmount = 0;
        ApiEnum<string, Currency> expectedSettlementCurrency = Currency.Aed;
        int expectedTotalAmount = 0;
        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardLastFour = "card_last_four";
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedCheckoutSessionID = "checkout_session_id";
        string expectedDiscountID = "discount_id";
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
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
        ApiEnum<
            string,
            PaymentCancelledWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment;

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
        Assert.Equal(expectedCardIssuingCountry, model.CardIssuingCountry);
        Assert.Equal(expectedCardLastFour, model.CardLastFour);
        Assert.Equal(expectedCardNetwork, model.CardNetwork);
        Assert.Equal(expectedCardType, model.CardType);
        Assert.Equal(expectedCheckoutSessionID, model.CheckoutSessionID);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedPaymentLink, model.PaymentLink);
        Assert.Equal(expectedPaymentMethod, model.PaymentMethod);
        Assert.Equal(expectedPaymentMethodType, model.PaymentMethodType);
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
        var model = new PaymentCancelledWebhookEventData
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
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentCancelledWebhookEventData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentCancelledWebhookEventData
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
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentCancelledWebhookEventData>(json);
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
        List<Dispute> expectedDisputes =
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
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
        ];
        int expectedSettlementAmount = 0;
        ApiEnum<string, Currency> expectedSettlementCurrency = Currency.Aed;
        int expectedTotalAmount = 0;
        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardLastFour = "card_last_four";
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedCheckoutSessionID = "checkout_session_id";
        string expectedDiscountID = "discount_id";
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
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
        ApiEnum<
            string,
            PaymentCancelledWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment;

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
        Assert.Equal(expectedCardIssuingCountry, deserialized.CardIssuingCountry);
        Assert.Equal(expectedCardLastFour, deserialized.CardLastFour);
        Assert.Equal(expectedCardNetwork, deserialized.CardNetwork);
        Assert.Equal(expectedCardType, deserialized.CardType);
        Assert.Equal(expectedCheckoutSessionID, deserialized.CheckoutSessionID);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedPaymentLink, deserialized.PaymentLink);
        Assert.Equal(expectedPaymentMethod, deserialized.PaymentMethod);
        Assert.Equal(expectedPaymentMethodType, deserialized.PaymentMethodType);
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
        var model = new PaymentCancelledWebhookEventData
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
            PaymentLink = "payment_link",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            SettlementTax = 0,
            Status = Payments::IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentCancelledWebhookEventData
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
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            CardType = "card_type",
            CheckoutSessionID = "checkout_session_id",
            DiscountID = "discount_id",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
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
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaymentCancelledWebhookEventData
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
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            CardType = "card_type",
            CheckoutSessionID = "checkout_session_id",
            DiscountID = "discount_id",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
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
        var model = new PaymentCancelledWebhookEventData
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
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            CardType = "card_type",
            CheckoutSessionID = "checkout_session_id",
            DiscountID = "discount_id",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
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
            Status = null,
            PayloadType = null,
        };

        Assert.Null(model.CardIssuingCountry);
        Assert.False(model.RawData.ContainsKey("card_issuing_country"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaymentCancelledWebhookEventData
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
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            CardType = "card_type",
            CheckoutSessionID = "checkout_session_id",
            DiscountID = "discount_id",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
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
            Status = null,
            PayloadType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentCancelledWebhookEventData
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
            Status = Payments::IntentStatus.Succeeded,
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        Assert.Null(model.CardLastFour);
        Assert.False(model.RawData.ContainsKey("card_last_four"));
        Assert.Null(model.CardNetwork);
        Assert.False(model.RawData.ContainsKey("card_network"));
        Assert.Null(model.CardType);
        Assert.False(model.RawData.ContainsKey("card_type"));
        Assert.Null(model.CheckoutSessionID);
        Assert.False(model.RawData.ContainsKey("checkout_session_id"));
        Assert.Null(model.DiscountID);
        Assert.False(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
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
        var model = new PaymentCancelledWebhookEventData
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
            Status = Payments::IntentStatus.Succeeded,
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PaymentCancelledWebhookEventData
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
            Status = Payments::IntentStatus.Succeeded,
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,

            CardLastFour = null,
            CardNetwork = null,
            CardType = null,
            CheckoutSessionID = null,
            DiscountID = null,
            ErrorCode = null,
            ErrorMessage = null,
            PaymentLink = null,
            PaymentMethod = null,
            PaymentMethodType = null,
            ProductCart = null,
            SettlementTax = null,
            SubscriptionID = null,
            Tax = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CardLastFour);
        Assert.True(model.RawData.ContainsKey("card_last_four"));
        Assert.Null(model.CardNetwork);
        Assert.True(model.RawData.ContainsKey("card_network"));
        Assert.Null(model.CardType);
        Assert.True(model.RawData.ContainsKey("card_type"));
        Assert.Null(model.CheckoutSessionID);
        Assert.True(model.RawData.ContainsKey("checkout_session_id"));
        Assert.Null(model.DiscountID);
        Assert.True(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.ErrorCode);
        Assert.True(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
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
        var model = new PaymentCancelledWebhookEventData
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
            Status = Payments::IntentStatus.Succeeded,
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,

            CardLastFour = null,
            CardNetwork = null,
            CardType = null,
            CheckoutSessionID = null,
            DiscountID = null,
            ErrorCode = null,
            ErrorMessage = null,
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

public class PaymentCancelledWebhookEventDataIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentCancelledWebhookEventDataIntersectionMember1
        {
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        ApiEnum<
            string,
            PaymentCancelledWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentCancelledWebhookEventDataIntersectionMember1
        {
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PaymentCancelledWebhookEventDataIntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentCancelledWebhookEventDataIntersectionMember1
        {
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<PaymentCancelledWebhookEventDataIntersectionMember1>(json);
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PaymentCancelledWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentCancelledWebhookEventDataIntersectionMember1
        {
            PayloadType = PaymentCancelledWebhookEventDataIntersectionMember1PayloadType.Payment,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentCancelledWebhookEventDataIntersectionMember1 { };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaymentCancelledWebhookEventDataIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PaymentCancelledWebhookEventDataIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaymentCancelledWebhookEventDataIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        model.Validate();
    }
}
