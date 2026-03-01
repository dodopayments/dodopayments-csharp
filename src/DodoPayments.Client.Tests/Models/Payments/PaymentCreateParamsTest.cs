using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentCreateParams
        {
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            Customer = new AttachExistingCustomer("customer_id"),
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3ds = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentLink = true,
            PaymentMethodID = "payment_method_id",
            RedirectImmediately = true,
            ReturnUrl = "return_url",
            ShortLink = true,
            ShowSavedPaymentMethods = true,
            TaxID = "tax_id",
        };

        BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        CustomerRequest expectedCustomer = new AttachExistingCustomer("customer_id");
        List<ProductCart> expectedProductCart =
        [
            new()
            {
                ProductID = "product_id",
                Quantity = 0,
                Amount = 0,
            },
        ];
        List<ApiEnum<string, PaymentMethodTypes>> expectedAllowedPaymentMethodTypes =
        [
            PaymentMethodTypes.Ach,
        ];
        ApiEnum<string, Currency> expectedBillingCurrency = Currency.Aed;
        string expectedDiscountCode = "discount_code";
        bool expectedForce3ds = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedPaymentLink = true;
        string expectedPaymentMethodID = "payment_method_id";
        bool expectedRedirectImmediately = true;
        string expectedReturnUrl = "return_url";
        bool expectedShortLink = true;
        bool expectedShowSavedPaymentMethods = true;
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedBilling, parameters.Billing);
        Assert.Equal(expectedCustomer, parameters.Customer);
        Assert.Equal(expectedProductCart.Count, parameters.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], parameters.ProductCart[i]);
        }
        Assert.NotNull(parameters.AllowedPaymentMethodTypes);
        Assert.Equal(
            expectedAllowedPaymentMethodTypes.Count,
            parameters.AllowedPaymentMethodTypes.Count
        );
        for (int i = 0; i < expectedAllowedPaymentMethodTypes.Count; i++)
        {
            Assert.Equal(
                expectedAllowedPaymentMethodTypes[i],
                parameters.AllowedPaymentMethodTypes[i]
            );
        }
        Assert.Equal(expectedBillingCurrency, parameters.BillingCurrency);
        Assert.Equal(expectedDiscountCode, parameters.DiscountCode);
        Assert.Equal(expectedForce3ds, parameters.Force3ds);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentLink, parameters.PaymentLink);
        Assert.Equal(expectedPaymentMethodID, parameters.PaymentMethodID);
        Assert.Equal(expectedRedirectImmediately, parameters.RedirectImmediately);
        Assert.Equal(expectedReturnUrl, parameters.ReturnUrl);
        Assert.Equal(expectedShortLink, parameters.ShortLink);
        Assert.Equal(expectedShowSavedPaymentMethods, parameters.ShowSavedPaymentMethods);
        Assert.Equal(expectedTaxID, parameters.TaxID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PaymentCreateParams
        {
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            Customer = new AttachExistingCustomer("customer_id"),
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3ds = true,
            PaymentLink = true,
            PaymentMethodID = "payment_method_id",
            ReturnUrl = "return_url",
            ShortLink = true,
            TaxID = "tax_id",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RedirectImmediately);
        Assert.False(parameters.RawBodyData.ContainsKey("redirect_immediately"));
        Assert.Null(parameters.ShowSavedPaymentMethods);
        Assert.False(parameters.RawBodyData.ContainsKey("show_saved_payment_methods"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PaymentCreateParams
        {
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            Customer = new AttachExistingCustomer("customer_id"),
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3ds = true,
            PaymentLink = true,
            PaymentMethodID = "payment_method_id",
            ReturnUrl = "return_url",
            ShortLink = true,
            TaxID = "tax_id",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            RedirectImmediately = null,
            ShowSavedPaymentMethods = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RedirectImmediately);
        Assert.False(parameters.RawBodyData.ContainsKey("redirect_immediately"));
        Assert.Null(parameters.ShowSavedPaymentMethods);
        Assert.False(parameters.RawBodyData.ContainsKey("show_saved_payment_methods"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PaymentCreateParams
        {
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            Customer = new AttachExistingCustomer("customer_id"),
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RedirectImmediately = true,
            ShowSavedPaymentMethods = true,
        };

        Assert.Null(parameters.AllowedPaymentMethodTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(parameters.BillingCurrency);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_currency"));
        Assert.Null(parameters.DiscountCode);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.Force3ds);
        Assert.False(parameters.RawBodyData.ContainsKey("force_3ds"));
        Assert.Null(parameters.PaymentLink);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_link"));
        Assert.Null(parameters.PaymentMethodID);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_method_id"));
        Assert.Null(parameters.ReturnUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("return_url"));
        Assert.Null(parameters.ShortLink);
        Assert.False(parameters.RawBodyData.ContainsKey("short_link"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PaymentCreateParams
        {
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            Customer = new AttachExistingCustomer("customer_id"),
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RedirectImmediately = true,
            ShowSavedPaymentMethods = true,

            AllowedPaymentMethodTypes = null,
            BillingCurrency = null,
            DiscountCode = null,
            Force3ds = null,
            PaymentLink = null,
            PaymentMethodID = null,
            ReturnUrl = null,
            ShortLink = null,
            TaxID = null,
        };

        Assert.Null(parameters.AllowedPaymentMethodTypes);
        Assert.True(parameters.RawBodyData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(parameters.BillingCurrency);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_currency"));
        Assert.Null(parameters.DiscountCode);
        Assert.True(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.Force3ds);
        Assert.True(parameters.RawBodyData.ContainsKey("force_3ds"));
        Assert.Null(parameters.PaymentLink);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_link"));
        Assert.Null(parameters.PaymentMethodID);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_method_id"));
        Assert.Null(parameters.ReturnUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("return_url"));
        Assert.Null(parameters.ShortLink);
        Assert.True(parameters.RawBodyData.ContainsKey("short_link"));
        Assert.Null(parameters.TaxID);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PaymentCreateParams parameters = new()
        {
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            Customer = new AttachExistingCustomer("customer_id"),
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

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/payments"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentCreateParams
        {
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            Customer = new AttachExistingCustomer("customer_id"),
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3ds = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentLink = true,
            PaymentMethodID = "payment_method_id",
            RedirectImmediately = true,
            ReturnUrl = "return_url",
            ShortLink = true,
            ShowSavedPaymentMethods = true,
            TaxID = "tax_id",
        };

        PaymentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProductCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        int expectedAmount = 0;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedAmount, model.Amount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

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
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCart>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        int expectedAmount = 0;

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedAmount, deserialized.Amount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductCart { ProductID = "product_id", Quantity = 0 };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductCart { ProductID = "product_id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,

            Amount = null,
        };

        Assert.Null(model.Amount);
        Assert.True(model.RawData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,

            Amount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        ProductCart copied = new(model);

        Assert.Equal(model, copied);
    }
}
