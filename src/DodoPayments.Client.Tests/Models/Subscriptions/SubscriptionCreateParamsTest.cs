using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionCreateParams
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
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3ds = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            OneTimeProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            PaymentLink = true,
            PaymentMethodID = "payment_method_id",
            RedirectImmediately = true,
            ReturnUrl = "return_url",
            ShortLink = true,
            ShowSavedPaymentMethods = true,
            TaxID = "tax_id",
            TrialPeriodDays = 0,
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
        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        List<ApiEnum<string, PaymentMethodTypes>> expectedAllowedPaymentMethodTypes =
        [
            PaymentMethodTypes.Ach,
        ];
        ApiEnum<string, Currency> expectedBillingCurrency = Currency.Aed;
        string expectedDiscountCode = "discount_code";
        bool expectedForce3ds = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        OnDemandSubscription expectedOnDemand = new()
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };
        List<OneTimeProductCartItem> expectedOneTimeProductCart =
        [
            new()
            {
                ProductID = "product_id",
                Quantity = 0,
                Amount = 0,
            },
        ];
        bool expectedPaymentLink = true;
        string expectedPaymentMethodID = "payment_method_id";
        bool expectedRedirectImmediately = true;
        string expectedReturnUrl = "return_url";
        bool expectedShortLink = true;
        bool expectedShowSavedPaymentMethods = true;
        string expectedTaxID = "tax_id";
        int expectedTrialPeriodDays = 0;

        Assert.Equal(expectedBilling, parameters.Billing);
        Assert.Equal(expectedCustomer, parameters.Customer);
        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.NotNull(parameters.Addons);
        Assert.Equal(expectedAddons.Count, parameters.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], parameters.Addons[i]);
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
        Assert.Equal(expectedOnDemand, parameters.OnDemand);
        Assert.NotNull(parameters.OneTimeProductCart);
        Assert.Equal(expectedOneTimeProductCart.Count, parameters.OneTimeProductCart.Count);
        for (int i = 0; i < expectedOneTimeProductCart.Count; i++)
        {
            Assert.Equal(expectedOneTimeProductCart[i], parameters.OneTimeProductCart[i]);
        }
        Assert.Equal(expectedPaymentLink, parameters.PaymentLink);
        Assert.Equal(expectedPaymentMethodID, parameters.PaymentMethodID);
        Assert.Equal(expectedRedirectImmediately, parameters.RedirectImmediately);
        Assert.Equal(expectedReturnUrl, parameters.ReturnUrl);
        Assert.Equal(expectedShortLink, parameters.ShortLink);
        Assert.Equal(expectedShowSavedPaymentMethods, parameters.ShowSavedPaymentMethods);
        Assert.Equal(expectedTaxID, parameters.TaxID);
        Assert.Equal(expectedTrialPeriodDays, parameters.TrialPeriodDays);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionCreateParams
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
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3ds = true,
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            OneTimeProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            PaymentLink = true,
            PaymentMethodID = "payment_method_id",
            ReturnUrl = "return_url",
            ShortLink = true,
            TaxID = "tax_id",
            TrialPeriodDays = 0,
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
        var parameters = new SubscriptionCreateParams
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
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3ds = true,
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            OneTimeProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            PaymentLink = true,
            PaymentMethodID = "payment_method_id",
            ReturnUrl = "return_url",
            ShortLink = true,
            TaxID = "tax_id",
            TrialPeriodDays = 0,

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
        var parameters = new SubscriptionCreateParams
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
            ProductID = "product_id",
            Quantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RedirectImmediately = true,
            ShowSavedPaymentMethods = true,
        };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.AllowedPaymentMethodTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(parameters.BillingCurrency);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_currency"));
        Assert.Null(parameters.DiscountCode);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.Force3ds);
        Assert.False(parameters.RawBodyData.ContainsKey("force_3ds"));
        Assert.Null(parameters.OnDemand);
        Assert.False(parameters.RawBodyData.ContainsKey("on_demand"));
        Assert.Null(parameters.OneTimeProductCart);
        Assert.False(parameters.RawBodyData.ContainsKey("one_time_product_cart"));
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
        Assert.Null(parameters.TrialPeriodDays);
        Assert.False(parameters.RawBodyData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionCreateParams
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
            ProductID = "product_id",
            Quantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RedirectImmediately = true,
            ShowSavedPaymentMethods = true,

            Addons = null,
            AllowedPaymentMethodTypes = null,
            BillingCurrency = null,
            DiscountCode = null,
            Force3ds = null,
            OnDemand = null,
            OneTimeProductCart = null,
            PaymentLink = null,
            PaymentMethodID = null,
            ReturnUrl = null,
            ShortLink = null,
            TaxID = null,
            TrialPeriodDays = null,
        };

        Assert.Null(parameters.Addons);
        Assert.True(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.AllowedPaymentMethodTypes);
        Assert.True(parameters.RawBodyData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(parameters.BillingCurrency);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_currency"));
        Assert.Null(parameters.DiscountCode);
        Assert.True(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.Force3ds);
        Assert.True(parameters.RawBodyData.ContainsKey("force_3ds"));
        Assert.Null(parameters.OnDemand);
        Assert.True(parameters.RawBodyData.ContainsKey("on_demand"));
        Assert.Null(parameters.OneTimeProductCart);
        Assert.True(parameters.RawBodyData.ContainsKey("one_time_product_cart"));
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
        Assert.Null(parameters.TrialPeriodDays);
        Assert.True(parameters.RawBodyData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionCreateParams parameters = new()
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
            ProductID = "product_id",
            Quantity = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/subscriptions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionCreateParams
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
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            BillingCurrency = Currency.Aed,
            DiscountCode = "discount_code",
            Force3ds = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            OneTimeProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Amount = 0,
                },
            ],
            PaymentLink = true,
            PaymentMethodID = "payment_method_id",
            RedirectImmediately = true,
            ReturnUrl = "return_url",
            ShortLink = true,
            ShowSavedPaymentMethods = true,
            TaxID = "tax_id",
            TrialPeriodDays = 0,
        };

        SubscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
