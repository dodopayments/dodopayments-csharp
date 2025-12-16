using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Webhooks;
using Refunds = DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class PaymentCancelledWebhookEventTest1 : TestBase
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
                    City = "city",
                    Country = CountryCode.Af,
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
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PayloadType = Data7IntersectionMember1PayloadType.Payment,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Type7.PaymentCancelled,
        };

        string expectedBusinessID = "business_id";
        Data7 expectedData = new()
        {
            Billing = new()
            {
                City = "city",
                Country = CountryCode.Af,
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
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = Data7IntersectionMember1PayloadType.Payment,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Type7> expectedType = Type7.PaymentCancelled;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }
}

public class Data7Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data7
        {
            Billing = new()
            {
                City = "city",
                Country = CountryCode.Af,
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
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
            Tax = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayloadType = Data7IntersectionMember1PayloadType.Payment,
        };

        BillingAddress expectedBilling = new()
        {
            City = "city",
            Country = CountryCode.Af,
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
        List<Refund> expectedRefunds =
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
        List<ProductCart> expectedProductCart = [new() { ProductID = "product_id", Quantity = 0 }];
        int expectedSettlementTax = 0;
        ApiEnum<string, IntentStatus> expectedStatus = IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";
        int expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Data7IntersectionMember1PayloadType> expectedPayloadType =
            Data7IntersectionMember1PayloadType.Payment;

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
}

public class Data7IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data7IntersectionMember1
        {
            PayloadType = Data7IntersectionMember1PayloadType.Payment,
        };

        ApiEnum<string, Data7IntersectionMember1PayloadType> expectedPayloadType =
            Data7IntersectionMember1PayloadType.Payment;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }
}
