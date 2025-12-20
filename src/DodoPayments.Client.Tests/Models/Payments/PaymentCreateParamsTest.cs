using System.Collections.Generic;
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
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Credit],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3DS = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentLink = true,
            RedirectImmediately = true,
            ReturnURL = "return_url",
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
        List<OneTimeProductCartItem> expectedProductCart =
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
            PaymentMethodTypes.Credit,
        ];
        ApiEnum<string, Currency> expectedBillingCurrency = Currency.Aed;
        string expectedDiscountCode = "discount_code";
        bool expectedForce3DS = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedPaymentLink = true;
        bool expectedRedirectImmediately = true;
        string expectedReturnURL = "return_url";
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
        Assert.Equal(expectedForce3DS, parameters.Force3DS);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentLink, parameters.PaymentLink);
        Assert.Equal(expectedRedirectImmediately, parameters.RedirectImmediately);
        Assert.Equal(expectedReturnURL, parameters.ReturnURL);
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
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Credit],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3DS = true,
            PaymentLink = true,
            ReturnURL = "return_url",
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
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Credit],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3DS = true,
            PaymentLink = true,
            ReturnURL = "return_url",
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
        Assert.Null(parameters.Force3DS);
        Assert.False(parameters.RawBodyData.ContainsKey("force_3ds"));
        Assert.Null(parameters.PaymentLink);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_link"));
        Assert.Null(parameters.ReturnURL);
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
            Force3DS = null,
            PaymentLink = null,
            ReturnURL = null,
            ShortLink = null,
            TaxID = null,
        };

        Assert.Null(parameters.AllowedPaymentMethodTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(parameters.BillingCurrency);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_currency"));
        Assert.Null(parameters.DiscountCode);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.Force3DS);
        Assert.False(parameters.RawBodyData.ContainsKey("force_3ds"));
        Assert.Null(parameters.PaymentLink);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_link"));
        Assert.Null(parameters.ReturnURL);
        Assert.False(parameters.RawBodyData.ContainsKey("return_url"));
        Assert.Null(parameters.ShortLink);
        Assert.False(parameters.RawBodyData.ContainsKey("short_link"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
    }
}
