using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentListPageResponse
        {
            Items =
            [
                new()
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
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentID = "payment_id",
                    TotalAmount = 0,
                    InvoiceID = "invoice_id",
                    InvoiceUrl = "invoice_url",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                },
            ],
        };

        List<PaymentListResponse> expectedItems =
        [
            new()
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
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                TotalAmount = 0,
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentListPageResponse
        {
            Items =
            [
                new()
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
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentID = "payment_id",
                    TotalAmount = 0,
                    InvoiceID = "invoice_id",
                    InvoiceUrl = "invoice_url",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentListPageResponse
        {
            Items =
            [
                new()
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
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentID = "payment_id",
                    TotalAmount = 0,
                    InvoiceID = "invoice_id",
                    InvoiceUrl = "invoice_url",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PaymentListResponse> expectedItems =
        [
            new()
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
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                TotalAmount = 0,
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentListPageResponse
        {
            Items =
            [
                new()
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
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentID = "payment_id",
                    TotalAmount = 0,
                    InvoiceID = "invoice_id",
                    InvoiceUrl = "invoice_url",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    Status = IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                },
            ],
        };

        model.Validate();
    }
}
