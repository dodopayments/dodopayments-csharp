using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Refunds;
using Disputes = DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Tests.Models.Payments;

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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
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
            RefundStatus = PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BillingAddress expectedBilling = new()
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
        CustomerLimitedDetails expectedCustomer = new()
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
        ApiEnum<string, PaymentProvider> expectedPaymentProvider = PaymentProvider.Stripe;
        List<RefundListItem> expectedRefunds =
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
        int expectedRetryAttempt = 0;
        int expectedSettlementAmount = 0;
        ApiEnum<string, Currency> expectedSettlementCurrency = Currency.Aed;
        int expectedTotalAmount = 0;
        string expectedCardHolderName = "card_holder_name";
        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardLastFour = "card_last_four";
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedCheckoutSessionID = "checkout_session_id";
        List<CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        string expectedDiscountID = "discount_id";
        List<DiscountDetail> expectedDiscounts =
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
        List<ProductCart> expectedProductCart = [new() { ProductID = "product_id", Quantity = 0 }];
        ApiEnum<string, PaymentRefundStatus> expectedRefundStatus = PaymentRefundStatus.Partial;
        int expectedSettlementTax = 0;
        ApiEnum<string, IntentStatus> expectedStatus = IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";
        int expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

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
        Assert.Equal(expectedPaymentProvider, model.PaymentProvider);
        Assert.Equal(expectedRefunds.Count, model.Refunds.Count);
        for (int i = 0; i < expectedRefunds.Count; i++)
        {
            Assert.Equal(expectedRefunds[i], model.Refunds[i]);
        }
        Assert.Equal(expectedRetryAttempt, model.RetryAttempt);
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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
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
            RefundStatus = PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = IntentStatus.Succeeded,
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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
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
            RefundStatus = PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = IntentStatus.Succeeded,
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

        BillingAddress expectedBilling = new()
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
        CustomerLimitedDetails expectedCustomer = new()
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
        ApiEnum<string, PaymentProvider> expectedPaymentProvider = PaymentProvider.Stripe;
        List<RefundListItem> expectedRefunds =
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
        int expectedRetryAttempt = 0;
        int expectedSettlementAmount = 0;
        ApiEnum<string, Currency> expectedSettlementCurrency = Currency.Aed;
        int expectedTotalAmount = 0;
        string expectedCardHolderName = "card_holder_name";
        ApiEnum<string, CountryCode> expectedCardIssuingCountry = CountryCode.Af;
        string expectedCardLastFour = "card_last_four";
        string expectedCardNetwork = "card_network";
        string expectedCardType = "card_type";
        string expectedCheckoutSessionID = "checkout_session_id";
        List<CustomFieldResponse> expectedCustomFieldResponses =
        [
            new() { Key = "key", Value = "value" },
        ];
        string expectedDiscountID = "discount_id";
        List<DiscountDetail> expectedDiscounts =
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
        List<ProductCart> expectedProductCart = [new() { ProductID = "product_id", Quantity = 0 }];
        ApiEnum<string, PaymentRefundStatus> expectedRefundStatus = PaymentRefundStatus.Partial;
        int expectedSettlementTax = 0;
        ApiEnum<string, IntentStatus> expectedStatus = IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";
        int expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

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
        Assert.Equal(expectedPaymentProvider, deserialized.PaymentProvider);
        Assert.Equal(expectedRefunds.Count, deserialized.Refunds.Count);
        for (int i = 0; i < expectedRefunds.Count; i++)
        {
            Assert.Equal(expectedRefunds[i], deserialized.Refunds[i]);
        }
        Assert.Equal(expectedRetryAttempt, deserialized.RetryAttempt);
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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
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
            RefundStatus = PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
        };

        Assert.Null(model.CardHolderName);
        Assert.False(model.RawData.ContainsKey("card_holder_name"));
        Assert.Null(model.CardIssuingCountry);
        Assert.False(model.RawData.ContainsKey("card_issuing_country"));
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
        Assert.Null(model.RefundStatus);
        Assert.False(model.RawData.ContainsKey("refund_status"));
        Assert.Null(model.SettlementTax);
        Assert.False(model.RawData.ContainsKey("settlement_tax"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,

            CardHolderName = null,
            CardIssuingCountry = null,
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
            RefundStatus = null,
            SettlementTax = null,
            Status = null,
            SubscriptionID = null,
            Tax = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CardHolderName);
        Assert.True(model.RawData.ContainsKey("card_holder_name"));
        Assert.Null(model.CardIssuingCountry);
        Assert.True(model.RawData.ContainsKey("card_issuing_country"));
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
        Assert.Null(model.RefundStatus);
        Assert.True(model.RawData.ContainsKey("refund_status"));
        Assert.Null(model.SettlementTax);
        Assert.True(model.RawData.ContainsKey("settlement_tax"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,

            CardHolderName = null,
            CardIssuingCountry = null,
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
            RefundStatus = null,
            SettlementTax = null,
            Status = null,
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
            PaymentProvider = PaymentProvider.Stripe,
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
            RetryAttempt = 0,
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
            RefundStatus = PaymentRefundStatus.Partial,
            SettlementTax = 0,
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Payment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentProviderTest : TestBase
{
    [Theory]
    [InlineData(PaymentProvider.Stripe)]
    [InlineData(PaymentProvider.Adyen)]
    [InlineData(PaymentProvider.Dodo)]
    public void Validation_Works(PaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentProvider.Stripe)]
    [InlineData(PaymentProvider.Adyen)]
    [InlineData(PaymentProvider.Dodo)]
    public void SerializationRoundtrip_Works(PaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProductCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCart { ProductID = "product_id", Quantity = 0 };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCart { ProductID = "product_id", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCart { ProductID = "product_id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCart>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProductID = "product_id";
        int expectedQuantity = 0;

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCart { ProductID = "product_id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCart { ProductID = "product_id", Quantity = 0 };

        ProductCart copied = new(model);

        Assert.Equal(model, copied);
    }
}
