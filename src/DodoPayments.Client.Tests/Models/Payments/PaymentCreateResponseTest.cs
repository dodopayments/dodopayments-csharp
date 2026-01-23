using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentLink = "payment_link",
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
        };

        string expectedClientSecret = "client_secret";
        CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        int expectedTotalAmount = 0;
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentLink = "payment_link";
        List<OneTimeProductCartItem> expectedProductCart =
        [
            new()
            {
                ProductID = "product_id",
                Quantity = 0,
                Amount = 0,
            },
        ];

        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedExpiresOn, model.ExpiresOn);
        Assert.Equal(expectedPaymentLink, model.PaymentLink);
        Assert.NotNull(model.ProductCart);
        Assert.Equal(expectedProductCart.Count, model.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], model.ProductCart[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentLink = "payment_link",
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentLink = "payment_link",
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientSecret = "client_secret";
        CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        int expectedTotalAmount = 0;
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentLink = "payment_link";
        List<OneTimeProductCartItem> expectedProductCart =
        [
            new()
            {
                ProductID = "product_id",
                Quantity = 0,
                Amount = 0,
            },
        ];

        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.Equal(expectedExpiresOn, deserialized.ExpiresOn);
        Assert.Equal(expectedPaymentLink, deserialized.PaymentLink);
        Assert.NotNull(deserialized.ProductCart);
        Assert.Equal(expectedProductCart.Count, deserialized.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], deserialized.ProductCart[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentLink = "payment_link",
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,
        };

        Assert.Null(model.DiscountID);
        Assert.False(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.ExpiresOn);
        Assert.False(model.RawData.ContainsKey("expires_on"));
        Assert.Null(model.PaymentLink);
        Assert.False(model.RawData.ContainsKey("payment_link"));
        Assert.Null(model.ProductCart);
        Assert.False(model.RawData.ContainsKey("product_cart"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,

            DiscountID = null,
            ExpiresOn = null,
            PaymentLink = null,
            ProductCart = null,
        };

        Assert.Null(model.DiscountID);
        Assert.True(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.ExpiresOn);
        Assert.True(model.RawData.ContainsKey("expires_on"));
        Assert.Null(model.PaymentLink);
        Assert.True(model.RawData.ContainsKey("payment_link"));
        Assert.Null(model.ProductCart);
        Assert.True(model.RawData.ContainsKey("product_cart"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,

            DiscountID = null,
            ExpiresOn = null,
            PaymentLink = null,
            ProductCart = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaymentCreateResponse
        {
            ClientSecret = "client_secret",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            TotalAmount = 0,
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentLink = "payment_link",
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
        };

        PaymentCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
