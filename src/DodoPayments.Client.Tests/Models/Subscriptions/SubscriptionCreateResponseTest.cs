using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",
            ClientSecret = "client_secret",
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OneTimeProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            PaymentLink = "payment_link",
        };

        List<AddonCartResponseItem> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
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
        int expectedRecurringPreTaxAmount = 0;
        string expectedSubscriptionID = "subscription_id";
        string expectedClientSecret = "client_secret";
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<OneTimeProductCart> expectedOneTimeProductCart =
        [
            new() { ProductID = "product_id", Quantity = 0 },
        ];
        string expectedPaymentLink = "payment_link";

        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRecurringPreTaxAmount, model.RecurringPreTaxAmount);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedExpiresOn, model.ExpiresOn);
        Assert.NotNull(model.OneTimeProductCart);
        Assert.Equal(expectedOneTimeProductCart.Count, model.OneTimeProductCart.Count);
        for (int i = 0; i < expectedOneTimeProductCart.Count; i++)
        {
            Assert.Equal(expectedOneTimeProductCart[i], model.OneTimeProductCart[i]);
        }
        Assert.Equal(expectedPaymentLink, model.PaymentLink);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",
            ClientSecret = "client_secret",
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OneTimeProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            PaymentLink = "payment_link",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",
            ClientSecret = "client_secret",
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OneTimeProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            PaymentLink = "payment_link",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AddonCartResponseItem> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
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
        int expectedRecurringPreTaxAmount = 0;
        string expectedSubscriptionID = "subscription_id";
        string expectedClientSecret = "client_secret";
        string expectedDiscountID = "discount_id";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<OneTimeProductCart> expectedOneTimeProductCart =
        [
            new() { ProductID = "product_id", Quantity = 0 },
        ];
        string expectedPaymentLink = "payment_link";

        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRecurringPreTaxAmount, deserialized.RecurringPreTaxAmount);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.Equal(expectedExpiresOn, deserialized.ExpiresOn);
        Assert.NotNull(deserialized.OneTimeProductCart);
        Assert.Equal(expectedOneTimeProductCart.Count, deserialized.OneTimeProductCart.Count);
        for (int i = 0; i < expectedOneTimeProductCart.Count; i++)
        {
            Assert.Equal(expectedOneTimeProductCart[i], deserialized.OneTimeProductCart[i]);
        }
        Assert.Equal(expectedPaymentLink, deserialized.PaymentLink);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",
            ClientSecret = "client_secret",
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OneTimeProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            PaymentLink = "payment_link",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",
        };

        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.DiscountID);
        Assert.False(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.ExpiresOn);
        Assert.False(model.RawData.ContainsKey("expires_on"));
        Assert.Null(model.OneTimeProductCart);
        Assert.False(model.RawData.ContainsKey("one_time_product_cart"));
        Assert.Null(model.PaymentLink);
        Assert.False(model.RawData.ContainsKey("payment_link"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",

            ClientSecret = null,
            DiscountID = null,
            ExpiresOn = null,
            OneTimeProductCart = null,
            PaymentLink = null,
        };

        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.DiscountID);
        Assert.True(model.RawData.ContainsKey("discount_id"));
        Assert.Null(model.ExpiresOn);
        Assert.True(model.RawData.ContainsKey("expires_on"));
        Assert.Null(model.OneTimeProductCart);
        Assert.True(model.RawData.ContainsKey("one_time_product_cart"));
        Assert.Null(model.PaymentLink);
        Assert.True(model.RawData.ContainsKey("payment_link"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",

            ClientSecret = null,
            DiscountID = null,
            ExpiresOn = null,
            OneTimeProductCart = null,
            PaymentLink = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            RecurringPreTaxAmount = 0,
            SubscriptionID = "subscription_id",
            ClientSecret = "client_secret",
            DiscountID = "discount_id",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OneTimeProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
            PaymentLink = "payment_link",
        };

        SubscriptionCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OneTimeProductCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OneTimeProductCart { ProductID = "product_id", Quantity = 0 };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OneTimeProductCart { ProductID = "product_id", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OneTimeProductCart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OneTimeProductCart { ProductID = "product_id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OneTimeProductCart>(
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
        var model = new OneTimeProductCart { ProductID = "product_id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OneTimeProductCart { ProductID = "product_id", Quantity = 0 };

        OneTimeProductCart copied = new(model);

        Assert.Equal(model, copied);
    }
}
