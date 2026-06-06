using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            RefundStatus = PaymentRefundStatus.Partial,
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
        };

        string expectedBrandID = "brand_id";
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
        bool expectedHasLicenseKey = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        ApiEnum<string, PaymentListResponsePaymentProvider> expectedPaymentProvider =
            PaymentListResponsePaymentProvider.Stripe;
        int expectedTotalAmount = 0;
        string expectedCardLastFour = "card_last_four";
        string expectedCardNetwork = "card_network";
        ApiEnum<string, DisputeDisputeStatus> expectedDisputeStatus =
            DisputeDisputeStatus.DisputeOpened;
        string expectedInvoiceID = "invoice_id";
        string expectedInvoiceUrl = "invoice_url";
        string expectedPaymentMethod = "payment_method";
        string expectedPaymentMethodType = "payment_method_type";
        ApiEnum<string, PaymentRefundStatus> expectedRefundStatus = PaymentRefundStatus.Partial;
        ApiEnum<string, IntentStatus> expectedStatus = IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDigitalProductsDelivered, model.DigitalProductsDelivered);
        Assert.Equal(expectedHasLicenseKey, model.HasLicenseKey);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedPaymentProvider, model.PaymentProvider);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedCardLastFour, model.CardLastFour);
        Assert.Equal(expectedCardNetwork, model.CardNetwork);
        Assert.Equal(expectedDisputeStatus, model.DisputeStatus);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedInvoiceUrl, model.InvoiceUrl);
        Assert.Equal(expectedPaymentMethod, model.PaymentMethod);
        Assert.Equal(expectedPaymentMethodType, model.PaymentMethodType);
        Assert.Equal(expectedRefundStatus, model.RefundStatus);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            RefundStatus = PaymentRefundStatus.Partial,
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            RefundStatus = PaymentRefundStatus.Partial,
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBrandID = "brand_id";
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
        bool expectedHasLicenseKey = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        ApiEnum<string, PaymentListResponsePaymentProvider> expectedPaymentProvider =
            PaymentListResponsePaymentProvider.Stripe;
        int expectedTotalAmount = 0;
        string expectedCardLastFour = "card_last_four";
        string expectedCardNetwork = "card_network";
        ApiEnum<string, DisputeDisputeStatus> expectedDisputeStatus =
            DisputeDisputeStatus.DisputeOpened;
        string expectedInvoiceID = "invoice_id";
        string expectedInvoiceUrl = "invoice_url";
        string expectedPaymentMethod = "payment_method";
        string expectedPaymentMethodType = "payment_method_type";
        ApiEnum<string, PaymentRefundStatus> expectedRefundStatus = PaymentRefundStatus.Partial;
        ApiEnum<string, IntentStatus> expectedStatus = IntentStatus.Succeeded;
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedDigitalProductsDelivered, deserialized.DigitalProductsDelivered);
        Assert.Equal(expectedHasLicenseKey, deserialized.HasLicenseKey);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedPaymentProvider, deserialized.PaymentProvider);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedCardLastFour, deserialized.CardLastFour);
        Assert.Equal(expectedCardNetwork, deserialized.CardNetwork);
        Assert.Equal(expectedDisputeStatus, deserialized.DisputeStatus);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedInvoiceUrl, deserialized.InvoiceUrl);
        Assert.Equal(expectedPaymentMethod, deserialized.PaymentMethod);
        Assert.Equal(expectedPaymentMethodType, deserialized.PaymentMethodType);
        Assert.Equal(expectedRefundStatus, deserialized.RefundStatus);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            RefundStatus = PaymentRefundStatus.Partial,
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,
        };

        Assert.Null(model.CardLastFour);
        Assert.False(model.RawData.ContainsKey("card_last_four"));
        Assert.Null(model.CardNetwork);
        Assert.False(model.RawData.ContainsKey("card_network"));
        Assert.Null(model.DisputeStatus);
        Assert.False(model.RawData.ContainsKey("dispute_status"));
        Assert.Null(model.InvoiceID);
        Assert.False(model.RawData.ContainsKey("invoice_id"));
        Assert.Null(model.InvoiceUrl);
        Assert.False(model.RawData.ContainsKey("invoice_url"));
        Assert.Null(model.PaymentMethod);
        Assert.False(model.RawData.ContainsKey("payment_method"));
        Assert.Null(model.PaymentMethodType);
        Assert.False(model.RawData.ContainsKey("payment_method_type"));
        Assert.Null(model.RefundStatus);
        Assert.False(model.RawData.ContainsKey("refund_status"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,

            CardLastFour = null,
            CardNetwork = null,
            DisputeStatus = null,
            InvoiceID = null,
            InvoiceUrl = null,
            PaymentMethod = null,
            PaymentMethodType = null,
            RefundStatus = null,
            Status = null,
            SubscriptionID = null,
        };

        Assert.Null(model.CardLastFour);
        Assert.True(model.RawData.ContainsKey("card_last_four"));
        Assert.Null(model.CardNetwork);
        Assert.True(model.RawData.ContainsKey("card_network"));
        Assert.Null(model.DisputeStatus);
        Assert.True(model.RawData.ContainsKey("dispute_status"));
        Assert.Null(model.InvoiceID);
        Assert.True(model.RawData.ContainsKey("invoice_id"));
        Assert.Null(model.InvoiceUrl);
        Assert.True(model.RawData.ContainsKey("invoice_url"));
        Assert.Null(model.PaymentMethod);
        Assert.True(model.RawData.ContainsKey("payment_method"));
        Assert.Null(model.PaymentMethodType);
        Assert.True(model.RawData.ContainsKey("payment_method_type"));
        Assert.Null(model.RefundStatus);
        Assert.True(model.RawData.ContainsKey("refund_status"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,

            CardLastFour = null,
            CardNetwork = null,
            DisputeStatus = null,
            InvoiceID = null,
            InvoiceUrl = null,
            PaymentMethod = null,
            PaymentMethodType = null,
            RefundStatus = null,
            Status = null,
            SubscriptionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaymentListResponse
        {
            BrandID = "brand_id",
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
            HasLicenseKey = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            PaymentProvider = PaymentListResponsePaymentProvider.Stripe,
            TotalAmount = 0,
            CardLastFour = "card_last_four",
            CardNetwork = "card_network",
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            InvoiceID = "invoice_id",
            InvoiceUrl = "invoice_url",
            PaymentMethod = "payment_method",
            PaymentMethodType = "payment_method_type",
            RefundStatus = PaymentRefundStatus.Partial,
            Status = IntentStatus.Succeeded,
            SubscriptionID = "subscription_id",
        };

        PaymentListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentListResponsePaymentProviderTest : TestBase
{
    [Theory]
    [InlineData(PaymentListResponsePaymentProvider.Stripe)]
    [InlineData(PaymentListResponsePaymentProvider.Adyen)]
    [InlineData(PaymentListResponsePaymentProvider.Dodo)]
    public void Validation_Works(PaymentListResponsePaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentListResponsePaymentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentListResponsePaymentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentListResponsePaymentProvider.Stripe)]
    [InlineData(PaymentListResponsePaymentProvider.Adyen)]
    [InlineData(PaymentListResponsePaymentProvider.Dodo)]
    public void SerializationRoundtrip_Works(PaymentListResponsePaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentListResponsePaymentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PaymentListResponsePaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentListResponsePaymentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PaymentListResponsePaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
