using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckoutSessionCreateParams
        {
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                    Amount = 0,
                },
            ],
            AllowedPaymentMethodTypes = [Payments::PaymentMethodTypes.Ach],
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            BillingCurrency = Currency.Aed,
            Confirm = true,
            CustomFields =
            [
                new()
                {
                    FieldType = FieldType.Text,
                    Key = "key",
                    Label = "label",
                    Options = ["string"],
                    Placeholder = "placeholder",
                    Required = true,
                },
            ],
            Customer = new Payments::AttachExistingCustomer("customer_id"),
            Customization = new()
            {
                ForceLanguage = "force_language",
                ShowOnDemandTag = true,
                ShowOrderDetails = true,
                Theme = Theme.Dark,
                ThemeConfig = new()
                {
                    Dark = new()
                    {
                        BgPrimary = "bg_primary",
                        BgSecondary = "bg_secondary",
                        BorderPrimary = "border_primary",
                        BorderSecondary = "border_secondary",
                        ButtonPrimary = "button_primary",
                        ButtonPrimaryHover = "button_primary_hover",
                        ButtonSecondary = "button_secondary",
                        ButtonSecondaryHover = "button_secondary_hover",
                        ButtonTextPrimary = "button_text_primary",
                        ButtonTextSecondary = "button_text_secondary",
                        InputFocusBorder = "input_focus_border",
                        TextError = "text_error",
                        TextPlaceholder = "text_placeholder",
                        TextPrimary = "text_primary",
                        TextSecondary = "text_secondary",
                        TextSuccess = "text_success",
                    },
                    FontSize = FontSize.Xs,
                    FontWeight = FontWeight.Normal,
                    Light = new()
                    {
                        BgPrimary = "bg_primary",
                        BgSecondary = "bg_secondary",
                        BorderPrimary = "border_primary",
                        BorderSecondary = "border_secondary",
                        ButtonPrimary = "button_primary",
                        ButtonPrimaryHover = "button_primary_hover",
                        ButtonSecondary = "button_secondary",
                        ButtonSecondaryHover = "button_secondary_hover",
                        ButtonTextPrimary = "button_text_primary",
                        ButtonTextSecondary = "button_text_secondary",
                        InputFocusBorder = "input_focus_border",
                        TextError = "text_error",
                        TextPlaceholder = "text_placeholder",
                        TextPrimary = "text_primary",
                        TextSecondary = "text_secondary",
                        TextSuccess = "text_success",
                    },
                    PayButtonText = "pay_button_text",
                    Radius = "radius",
                },
            },
            DiscountCode = "discount_code",
            FeatureFlags = new()
            {
                AllowCurrencySelection = true,
                AllowCustomerEditingCity = true,
                AllowCustomerEditingCountry = true,
                AllowCustomerEditingEmail = true,
                AllowCustomerEditingName = true,
                AllowCustomerEditingState = true,
                AllowCustomerEditingStreet = true,
                AllowCustomerEditingZipcode = true,
                AllowDiscountCode = true,
                AllowPhoneNumberCollection = true,
                AllowTaxID = true,
                AlwaysCreateNewCustomer = true,
                RedirectImmediately = true,
            },
            Force3ds = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimalAddress = true,
            PaymentMethodID = "payment_method_id",
            ProductCollectionID = "product_collection_id",
            ReturnUrl = "return_url",
            ShortLink = true,
            ShowSavedPaymentMethods = true,
            SubscriptionData = new()
            {
                OnDemand = new()
                {
                    MandateOnly = true,
                    AdaptiveCurrencyFeesInclusive = true,
                    ProductCurrency = Currency.Aed,
                    ProductDescription = "product_description",
                    ProductPrice = 0,
                },
                TrialPeriodDays = 0,
            },
        };

        List<ProductCart> expectedProductCart =
        [
            new()
            {
                ProductID = "product_id",
                Quantity = 0,
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Amount = 0,
            },
        ];
        List<ApiEnum<string, Payments::PaymentMethodTypes>> expectedAllowedPaymentMethodTypes =
        [
            Payments::PaymentMethodTypes.Ach,
        ];
        BillingAddress expectedBillingAddress = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        ApiEnum<string, Currency> expectedBillingCurrency = Currency.Aed;
        bool expectedConfirm = true;
        List<CustomField> expectedCustomFields =
        [
            new()
            {
                FieldType = FieldType.Text,
                Key = "key",
                Label = "label",
                Options = ["string"],
                Placeholder = "placeholder",
                Required = true,
            },
        ];
        Payments::CustomerRequest expectedCustomer = new Payments::AttachExistingCustomer(
            "customer_id"
        );
        Customization expectedCustomization = new()
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };
        string expectedDiscountCode = "discount_code";
        FeatureFlags expectedFeatureFlags = new()
        {
            AllowCurrencySelection = true,
            AllowCustomerEditingCity = true,
            AllowCustomerEditingCountry = true,
            AllowCustomerEditingEmail = true,
            AllowCustomerEditingName = true,
            AllowCustomerEditingState = true,
            AllowCustomerEditingStreet = true,
            AllowCustomerEditingZipcode = true,
            AllowDiscountCode = true,
            AllowPhoneNumberCollection = true,
            AllowTaxID = true,
            AlwaysCreateNewCustomer = true,
            RedirectImmediately = true,
        };
        bool expectedForce3ds = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedMinimalAddress = true;
        string expectedPaymentMethodID = "payment_method_id";
        string expectedProductCollectionID = "product_collection_id";
        string expectedReturnUrl = "return_url";
        bool expectedShortLink = true;
        bool expectedShowSavedPaymentMethods = true;
        SubscriptionData expectedSubscriptionData = new()
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

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
        Assert.Equal(expectedBillingAddress, parameters.BillingAddress);
        Assert.Equal(expectedBillingCurrency, parameters.BillingCurrency);
        Assert.Equal(expectedConfirm, parameters.Confirm);
        Assert.NotNull(parameters.CustomFields);
        Assert.Equal(expectedCustomFields.Count, parameters.CustomFields.Count);
        for (int i = 0; i < expectedCustomFields.Count; i++)
        {
            Assert.Equal(expectedCustomFields[i], parameters.CustomFields[i]);
        }
        Assert.Equal(expectedCustomer, parameters.Customer);
        Assert.Equal(expectedCustomization, parameters.Customization);
        Assert.Equal(expectedDiscountCode, parameters.DiscountCode);
        Assert.Equal(expectedFeatureFlags, parameters.FeatureFlags);
        Assert.Equal(expectedForce3ds, parameters.Force3ds);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimalAddress, parameters.MinimalAddress);
        Assert.Equal(expectedPaymentMethodID, parameters.PaymentMethodID);
        Assert.Equal(expectedProductCollectionID, parameters.ProductCollectionID);
        Assert.Equal(expectedReturnUrl, parameters.ReturnUrl);
        Assert.Equal(expectedShortLink, parameters.ShortLink);
        Assert.Equal(expectedShowSavedPaymentMethods, parameters.ShowSavedPaymentMethods);
        Assert.Equal(expectedSubscriptionData, parameters.SubscriptionData);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CheckoutSessionCreateParams
        {
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                    Amount = 0,
                },
            ],
            AllowedPaymentMethodTypes = [Payments::PaymentMethodTypes.Ach],
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            BillingCurrency = Currency.Aed,
            CustomFields =
            [
                new()
                {
                    FieldType = FieldType.Text,
                    Key = "key",
                    Label = "label",
                    Options = ["string"],
                    Placeholder = "placeholder",
                    Required = true,
                },
            ],
            Customer = new Payments::AttachExistingCustomer("customer_id"),
            DiscountCode = "discount_code",
            Force3ds = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "payment_method_id",
            ProductCollectionID = "product_collection_id",
            ReturnUrl = "return_url",
            SubscriptionData = new()
            {
                OnDemand = new()
                {
                    MandateOnly = true,
                    AdaptiveCurrencyFeesInclusive = true,
                    ProductCurrency = Currency.Aed,
                    ProductDescription = "product_description",
                    ProductPrice = 0,
                },
                TrialPeriodDays = 0,
            },
        };

        Assert.Null(parameters.Confirm);
        Assert.False(parameters.RawBodyData.ContainsKey("confirm"));
        Assert.Null(parameters.Customization);
        Assert.False(parameters.RawBodyData.ContainsKey("customization"));
        Assert.Null(parameters.FeatureFlags);
        Assert.False(parameters.RawBodyData.ContainsKey("feature_flags"));
        Assert.Null(parameters.MinimalAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("minimal_address"));
        Assert.Null(parameters.ShortLink);
        Assert.False(parameters.RawBodyData.ContainsKey("short_link"));
        Assert.Null(parameters.ShowSavedPaymentMethods);
        Assert.False(parameters.RawBodyData.ContainsKey("show_saved_payment_methods"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CheckoutSessionCreateParams
        {
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                    Amount = 0,
                },
            ],
            AllowedPaymentMethodTypes = [Payments::PaymentMethodTypes.Ach],
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            BillingCurrency = Currency.Aed,
            CustomFields =
            [
                new()
                {
                    FieldType = FieldType.Text,
                    Key = "key",
                    Label = "label",
                    Options = ["string"],
                    Placeholder = "placeholder",
                    Required = true,
                },
            ],
            Customer = new Payments::AttachExistingCustomer("customer_id"),
            DiscountCode = "discount_code",
            Force3ds = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "payment_method_id",
            ProductCollectionID = "product_collection_id",
            ReturnUrl = "return_url",
            SubscriptionData = new()
            {
                OnDemand = new()
                {
                    MandateOnly = true,
                    AdaptiveCurrencyFeesInclusive = true,
                    ProductCurrency = Currency.Aed,
                    ProductDescription = "product_description",
                    ProductPrice = 0,
                },
                TrialPeriodDays = 0,
            },

            // Null should be interpreted as omitted for these properties
            Confirm = null,
            Customization = null,
            FeatureFlags = null,
            MinimalAddress = null,
            ShortLink = null,
            ShowSavedPaymentMethods = null,
        };

        Assert.Null(parameters.Confirm);
        Assert.False(parameters.RawBodyData.ContainsKey("confirm"));
        Assert.Null(parameters.Customization);
        Assert.False(parameters.RawBodyData.ContainsKey("customization"));
        Assert.Null(parameters.FeatureFlags);
        Assert.False(parameters.RawBodyData.ContainsKey("feature_flags"));
        Assert.Null(parameters.MinimalAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("minimal_address"));
        Assert.Null(parameters.ShortLink);
        Assert.False(parameters.RawBodyData.ContainsKey("short_link"));
        Assert.Null(parameters.ShowSavedPaymentMethods);
        Assert.False(parameters.RawBodyData.ContainsKey("show_saved_payment_methods"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CheckoutSessionCreateParams
        {
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                    Amount = 0,
                },
            ],
            Confirm = true,
            Customization = new()
            {
                ForceLanguage = "force_language",
                ShowOnDemandTag = true,
                ShowOrderDetails = true,
                Theme = Theme.Dark,
                ThemeConfig = new()
                {
                    Dark = new()
                    {
                        BgPrimary = "bg_primary",
                        BgSecondary = "bg_secondary",
                        BorderPrimary = "border_primary",
                        BorderSecondary = "border_secondary",
                        ButtonPrimary = "button_primary",
                        ButtonPrimaryHover = "button_primary_hover",
                        ButtonSecondary = "button_secondary",
                        ButtonSecondaryHover = "button_secondary_hover",
                        ButtonTextPrimary = "button_text_primary",
                        ButtonTextSecondary = "button_text_secondary",
                        InputFocusBorder = "input_focus_border",
                        TextError = "text_error",
                        TextPlaceholder = "text_placeholder",
                        TextPrimary = "text_primary",
                        TextSecondary = "text_secondary",
                        TextSuccess = "text_success",
                    },
                    FontSize = FontSize.Xs,
                    FontWeight = FontWeight.Normal,
                    Light = new()
                    {
                        BgPrimary = "bg_primary",
                        BgSecondary = "bg_secondary",
                        BorderPrimary = "border_primary",
                        BorderSecondary = "border_secondary",
                        ButtonPrimary = "button_primary",
                        ButtonPrimaryHover = "button_primary_hover",
                        ButtonSecondary = "button_secondary",
                        ButtonSecondaryHover = "button_secondary_hover",
                        ButtonTextPrimary = "button_text_primary",
                        ButtonTextSecondary = "button_text_secondary",
                        InputFocusBorder = "input_focus_border",
                        TextError = "text_error",
                        TextPlaceholder = "text_placeholder",
                        TextPrimary = "text_primary",
                        TextSecondary = "text_secondary",
                        TextSuccess = "text_success",
                    },
                    PayButtonText = "pay_button_text",
                    Radius = "radius",
                },
            },
            FeatureFlags = new()
            {
                AllowCurrencySelection = true,
                AllowCustomerEditingCity = true,
                AllowCustomerEditingCountry = true,
                AllowCustomerEditingEmail = true,
                AllowCustomerEditingName = true,
                AllowCustomerEditingState = true,
                AllowCustomerEditingStreet = true,
                AllowCustomerEditingZipcode = true,
                AllowDiscountCode = true,
                AllowPhoneNumberCollection = true,
                AllowTaxID = true,
                AlwaysCreateNewCustomer = true,
                RedirectImmediately = true,
            },
            MinimalAddress = true,
            ShortLink = true,
            ShowSavedPaymentMethods = true,
        };

        Assert.Null(parameters.AllowedPaymentMethodTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(parameters.BillingAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.BillingCurrency);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_currency"));
        Assert.Null(parameters.CustomFields);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_fields"));
        Assert.Null(parameters.Customer);
        Assert.False(parameters.RawBodyData.ContainsKey("customer"));
        Assert.Null(parameters.DiscountCode);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.Force3ds);
        Assert.False(parameters.RawBodyData.ContainsKey("force_3ds"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentMethodID);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_method_id"));
        Assert.Null(parameters.ProductCollectionID);
        Assert.False(parameters.RawBodyData.ContainsKey("product_collection_id"));
        Assert.Null(parameters.ReturnUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("return_url"));
        Assert.Null(parameters.SubscriptionData);
        Assert.False(parameters.RawBodyData.ContainsKey("subscription_data"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CheckoutSessionCreateParams
        {
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                    Amount = 0,
                },
            ],
            Confirm = true,
            Customization = new()
            {
                ForceLanguage = "force_language",
                ShowOnDemandTag = true,
                ShowOrderDetails = true,
                Theme = Theme.Dark,
                ThemeConfig = new()
                {
                    Dark = new()
                    {
                        BgPrimary = "bg_primary",
                        BgSecondary = "bg_secondary",
                        BorderPrimary = "border_primary",
                        BorderSecondary = "border_secondary",
                        ButtonPrimary = "button_primary",
                        ButtonPrimaryHover = "button_primary_hover",
                        ButtonSecondary = "button_secondary",
                        ButtonSecondaryHover = "button_secondary_hover",
                        ButtonTextPrimary = "button_text_primary",
                        ButtonTextSecondary = "button_text_secondary",
                        InputFocusBorder = "input_focus_border",
                        TextError = "text_error",
                        TextPlaceholder = "text_placeholder",
                        TextPrimary = "text_primary",
                        TextSecondary = "text_secondary",
                        TextSuccess = "text_success",
                    },
                    FontSize = FontSize.Xs,
                    FontWeight = FontWeight.Normal,
                    Light = new()
                    {
                        BgPrimary = "bg_primary",
                        BgSecondary = "bg_secondary",
                        BorderPrimary = "border_primary",
                        BorderSecondary = "border_secondary",
                        ButtonPrimary = "button_primary",
                        ButtonPrimaryHover = "button_primary_hover",
                        ButtonSecondary = "button_secondary",
                        ButtonSecondaryHover = "button_secondary_hover",
                        ButtonTextPrimary = "button_text_primary",
                        ButtonTextSecondary = "button_text_secondary",
                        InputFocusBorder = "input_focus_border",
                        TextError = "text_error",
                        TextPlaceholder = "text_placeholder",
                        TextPrimary = "text_primary",
                        TextSecondary = "text_secondary",
                        TextSuccess = "text_success",
                    },
                    PayButtonText = "pay_button_text",
                    Radius = "radius",
                },
            },
            FeatureFlags = new()
            {
                AllowCurrencySelection = true,
                AllowCustomerEditingCity = true,
                AllowCustomerEditingCountry = true,
                AllowCustomerEditingEmail = true,
                AllowCustomerEditingName = true,
                AllowCustomerEditingState = true,
                AllowCustomerEditingStreet = true,
                AllowCustomerEditingZipcode = true,
                AllowDiscountCode = true,
                AllowPhoneNumberCollection = true,
                AllowTaxID = true,
                AlwaysCreateNewCustomer = true,
                RedirectImmediately = true,
            },
            MinimalAddress = true,
            ShortLink = true,
            ShowSavedPaymentMethods = true,

            AllowedPaymentMethodTypes = null,
            BillingAddress = null,
            BillingCurrency = null,
            CustomFields = null,
            Customer = null,
            DiscountCode = null,
            Force3ds = null,
            Metadata = null,
            PaymentMethodID = null,
            ProductCollectionID = null,
            ReturnUrl = null,
            SubscriptionData = null,
        };

        Assert.Null(parameters.AllowedPaymentMethodTypes);
        Assert.True(parameters.RawBodyData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(parameters.BillingAddress);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.BillingCurrency);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_currency"));
        Assert.Null(parameters.CustomFields);
        Assert.True(parameters.RawBodyData.ContainsKey("custom_fields"));
        Assert.Null(parameters.Customer);
        Assert.True(parameters.RawBodyData.ContainsKey("customer"));
        Assert.Null(parameters.DiscountCode);
        Assert.True(parameters.RawBodyData.ContainsKey("discount_code"));
        Assert.Null(parameters.Force3ds);
        Assert.True(parameters.RawBodyData.ContainsKey("force_3ds"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentMethodID);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_method_id"));
        Assert.Null(parameters.ProductCollectionID);
        Assert.True(parameters.RawBodyData.ContainsKey("product_collection_id"));
        Assert.Null(parameters.ReturnUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("return_url"));
        Assert.Null(parameters.SubscriptionData);
        Assert.True(parameters.RawBodyData.ContainsKey("subscription_data"));
    }

    [Fact]
    public void Url_Works()
    {
        CheckoutSessionCreateParams parameters = new()
        {
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                    Amount = 0,
                },
            ],
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/checkouts"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckoutSessionCreateParams
        {
            ProductCart =
            [
                new()
                {
                    ProductID = "product_id",
                    Quantity = 0,
                    Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                    Amount = 0,
                },
            ],
            AllowedPaymentMethodTypes = [Payments::PaymentMethodTypes.Ach],
            BillingAddress = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            BillingCurrency = Currency.Aed,
            Confirm = true,
            CustomFields =
            [
                new()
                {
                    FieldType = FieldType.Text,
                    Key = "key",
                    Label = "label",
                    Options = ["string"],
                    Placeholder = "placeholder",
                    Required = true,
                },
            ],
            Customer = new Payments::AttachExistingCustomer("customer_id"),
            Customization = new()
            {
                ForceLanguage = "force_language",
                ShowOnDemandTag = true,
                ShowOrderDetails = true,
                Theme = Theme.Dark,
                ThemeConfig = new()
                {
                    Dark = new()
                    {
                        BgPrimary = "bg_primary",
                        BgSecondary = "bg_secondary",
                        BorderPrimary = "border_primary",
                        BorderSecondary = "border_secondary",
                        ButtonPrimary = "button_primary",
                        ButtonPrimaryHover = "button_primary_hover",
                        ButtonSecondary = "button_secondary",
                        ButtonSecondaryHover = "button_secondary_hover",
                        ButtonTextPrimary = "button_text_primary",
                        ButtonTextSecondary = "button_text_secondary",
                        InputFocusBorder = "input_focus_border",
                        TextError = "text_error",
                        TextPlaceholder = "text_placeholder",
                        TextPrimary = "text_primary",
                        TextSecondary = "text_secondary",
                        TextSuccess = "text_success",
                    },
                    FontSize = FontSize.Xs,
                    FontWeight = FontWeight.Normal,
                    Light = new()
                    {
                        BgPrimary = "bg_primary",
                        BgSecondary = "bg_secondary",
                        BorderPrimary = "border_primary",
                        BorderSecondary = "border_secondary",
                        ButtonPrimary = "button_primary",
                        ButtonPrimaryHover = "button_primary_hover",
                        ButtonSecondary = "button_secondary",
                        ButtonSecondaryHover = "button_secondary_hover",
                        ButtonTextPrimary = "button_text_primary",
                        ButtonTextSecondary = "button_text_secondary",
                        InputFocusBorder = "input_focus_border",
                        TextError = "text_error",
                        TextPlaceholder = "text_placeholder",
                        TextPrimary = "text_primary",
                        TextSecondary = "text_secondary",
                        TextSuccess = "text_success",
                    },
                    PayButtonText = "pay_button_text",
                    Radius = "radius",
                },
            },
            DiscountCode = "discount_code",
            FeatureFlags = new()
            {
                AllowCurrencySelection = true,
                AllowCustomerEditingCity = true,
                AllowCustomerEditingCountry = true,
                AllowCustomerEditingEmail = true,
                AllowCustomerEditingName = true,
                AllowCustomerEditingState = true,
                AllowCustomerEditingStreet = true,
                AllowCustomerEditingZipcode = true,
                AllowDiscountCode = true,
                AllowPhoneNumberCollection = true,
                AllowTaxID = true,
                AlwaysCreateNewCustomer = true,
                RedirectImmediately = true,
            },
            Force3ds = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimalAddress = true,
            PaymentMethodID = "payment_method_id",
            ProductCollectionID = "product_collection_id",
            ReturnUrl = "return_url",
            ShortLink = true,
            ShowSavedPaymentMethods = true,
            SubscriptionData = new()
            {
                OnDemand = new()
                {
                    MandateOnly = true,
                    AdaptiveCurrencyFeesInclusive = true,
                    ProductCurrency = Currency.Aed,
                    ProductDescription = "product_description",
                    ProductPrice = 0,
                },
                TrialPeriodDays = 0,
            },
        };

        CheckoutSessionCreateParams copied = new(parameters);

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
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        int expectedAmount = 0;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedAmount, model.Amount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
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
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        int expectedAmount = 0;

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedAmount, deserialized.Amount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductCart { ProductID = "product_id", Quantity = 0 };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
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

            Addons = null,
            Amount = null,
        };

        Assert.Null(model.Addons);
        Assert.True(model.RawData.ContainsKey("addons"));
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

            Addons = null,
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
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        ProductCart copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        ApiEnum<string, CountryCode> expectedCountry = CountryCode.Af;
        string expectedCity = "city";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedZipcode = "zipcode";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedZipcode, model.Zipcode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CountryCode> expectedCountry = CountryCode.Af;
        string expectedCity = "city";
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedZipcode = "zipcode";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedZipcode, deserialized.Zipcode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingAddress { Country = CountryCode.Af };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.Zipcode);
        Assert.False(model.RawData.ContainsKey("zipcode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingAddress { Country = CountryCode.Af };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,

            City = null,
            State = null,
            Street = null,
            Zipcode = null,
        };

        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
        Assert.Null(model.Zipcode);
        Assert.True(model.RawData.ContainsKey("zipcode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,

            City = null,
            State = null,
            Street = null,
            Zipcode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        BillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomFieldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        ApiEnum<string, FieldType> expectedFieldType = FieldType.Text;
        string expectedKey = "key";
        string expectedLabel = "label";
        List<string> expectedOptions = ["string"];
        string expectedPlaceholder = "placeholder";
        bool expectedRequired = true;

        Assert.Equal(expectedFieldType, model.FieldType);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedLabel, model.Label);
        Assert.NotNull(model.Options);
        Assert.Equal(expectedOptions.Count, model.Options.Count);
        for (int i = 0; i < expectedOptions.Count; i++)
        {
            Assert.Equal(expectedOptions[i], model.Options[i]);
        }
        Assert.Equal(expectedPlaceholder, model.Placeholder);
        Assert.Equal(expectedRequired, model.Required);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomField>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomField>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FieldType> expectedFieldType = FieldType.Text;
        string expectedKey = "key";
        string expectedLabel = "label";
        List<string> expectedOptions = ["string"];
        string expectedPlaceholder = "placeholder";
        bool expectedRequired = true;

        Assert.Equal(expectedFieldType, deserialized.FieldType);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.NotNull(deserialized.Options);
        Assert.Equal(expectedOptions.Count, deserialized.Options.Count);
        for (int i = 0; i < expectedOptions.Count; i++)
        {
            Assert.Equal(expectedOptions[i], deserialized.Options[i]);
        }
        Assert.Equal(expectedPlaceholder, deserialized.Placeholder);
        Assert.Equal(expectedRequired, deserialized.Required);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
        };

        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",

            // Null should be interpreted as omitted for these properties
            Required = null,
        };

        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",

            // Null should be interpreted as omitted for these properties
            Required = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
        Assert.Null(model.Placeholder);
        Assert.False(model.RawData.ContainsKey("placeholder"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,

            Options = null,
            Placeholder = null,
        };

        Assert.Null(model.Options);
        Assert.True(model.RawData.ContainsKey("options"));
        Assert.Null(model.Placeholder);
        Assert.True(model.RawData.ContainsKey("placeholder"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,

            Options = null,
            Placeholder = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        CustomField copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldTypeTest : TestBase
{
    [Theory]
    [InlineData(FieldType.Text)]
    [InlineData(FieldType.Number)]
    [InlineData(FieldType.Email)]
    [InlineData(FieldType.Url)]
    [InlineData(FieldType.Date)]
    [InlineData(FieldType.Dropdown)]
    [InlineData(FieldType.Boolean)]
    public void Validation_Works(FieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FieldType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FieldType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FieldType.Text)]
    [InlineData(FieldType.Number)]
    [InlineData(FieldType.Email)]
    [InlineData(FieldType.Url)]
    [InlineData(FieldType.Date)]
    [InlineData(FieldType.Dropdown)]
    [InlineData(FieldType.Boolean)]
    public void SerializationRoundtrip_Works(FieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FieldType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FieldType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FieldType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FieldType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, Theme> expectedTheme = Theme.Dark;
        ThemeConfig expectedThemeConfig = new()
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        Assert.Equal(expectedForceLanguage, model.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, model.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, model.ShowOrderDetails);
        Assert.Equal(expectedTheme, model.Theme);
        Assert.Equal(expectedThemeConfig, model.ThemeConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Customization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Customization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, Theme> expectedTheme = Theme.Dark;
        ThemeConfig expectedThemeConfig = new()
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        Assert.Equal(expectedForceLanguage, deserialized.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, deserialized.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, deserialized.ShowOrderDetails);
        Assert.Equal(expectedTheme, deserialized.Theme);
        Assert.Equal(expectedThemeConfig, deserialized.ThemeConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        Assert.Null(model.ShowOnDemandTag);
        Assert.False(model.RawData.ContainsKey("show_on_demand_tag"));
        Assert.Null(model.ShowOrderDetails);
        Assert.False(model.RawData.ContainsKey("show_order_details"));
        Assert.Null(model.Theme);
        Assert.False(model.RawData.ContainsKey("theme"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },

            // Null should be interpreted as omitted for these properties
            ShowOnDemandTag = null,
            ShowOrderDetails = null,
            Theme = null,
        };

        Assert.Null(model.ShowOnDemandTag);
        Assert.False(model.RawData.ContainsKey("show_on_demand_tag"));
        Assert.Null(model.ShowOrderDetails);
        Assert.False(model.RawData.ContainsKey("show_order_details"));
        Assert.Null(model.Theme);
        Assert.False(model.RawData.ContainsKey("theme"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },

            // Null should be interpreted as omitted for these properties
            ShowOnDemandTag = null,
            ShowOrderDetails = null,
            Theme = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Customization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
        };

        Assert.Null(model.ForceLanguage);
        Assert.False(model.RawData.ContainsKey("force_language"));
        Assert.Null(model.ThemeConfig);
        Assert.False(model.RawData.ContainsKey("theme_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Customization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Customization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,

            ForceLanguage = null,
            ThemeConfig = null,
        };

        Assert.Null(model.ForceLanguage);
        Assert.True(model.RawData.ContainsKey("force_language"));
        Assert.Null(model.ThemeConfig);
        Assert.True(model.RawData.ContainsKey("theme_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Customization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,

            ForceLanguage = null,
            ThemeConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Customization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        Customization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThemeTest : TestBase
{
    [Theory]
    [InlineData(Theme.Dark)]
    [InlineData(Theme.Light)]
    [InlineData(Theme.System)]
    public void Validation_Works(Theme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Theme> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Theme.Dark)]
    [InlineData(Theme.Light)]
    [InlineData(Theme.System)]
    public void SerializationRoundtrip_Works(Theme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Theme> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThemeConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThemeConfig
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        Dark expectedDark = new()
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };
        ApiEnum<string, FontSize> expectedFontSize = FontSize.Xs;
        ApiEnum<string, FontWeight> expectedFontWeight = FontWeight.Normal;
        Light expectedLight = new()
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };
        string expectedPayButtonText = "pay_button_text";
        string expectedRadius = "radius";

        Assert.Equal(expectedDark, model.Dark);
        Assert.Equal(expectedFontSize, model.FontSize);
        Assert.Equal(expectedFontWeight, model.FontWeight);
        Assert.Equal(expectedLight, model.Light);
        Assert.Equal(expectedPayButtonText, model.PayButtonText);
        Assert.Equal(expectedRadius, model.Radius);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThemeConfig
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThemeConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThemeConfig
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThemeConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dark expectedDark = new()
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };
        ApiEnum<string, FontSize> expectedFontSize = FontSize.Xs;
        ApiEnum<string, FontWeight> expectedFontWeight = FontWeight.Normal;
        Light expectedLight = new()
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };
        string expectedPayButtonText = "pay_button_text";
        string expectedRadius = "radius";

        Assert.Equal(expectedDark, deserialized.Dark);
        Assert.Equal(expectedFontSize, deserialized.FontSize);
        Assert.Equal(expectedFontWeight, deserialized.FontWeight);
        Assert.Equal(expectedLight, deserialized.Light);
        Assert.Equal(expectedPayButtonText, deserialized.PayButtonText);
        Assert.Equal(expectedRadius, deserialized.Radius);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThemeConfig
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThemeConfig { };

        Assert.Null(model.Dark);
        Assert.False(model.RawData.ContainsKey("dark"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.FontWeight);
        Assert.False(model.RawData.ContainsKey("font_weight"));
        Assert.Null(model.Light);
        Assert.False(model.RawData.ContainsKey("light"));
        Assert.Null(model.PayButtonText);
        Assert.False(model.RawData.ContainsKey("pay_button_text"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThemeConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ThemeConfig
        {
            Dark = null,
            FontSize = null,
            FontWeight = null,
            Light = null,
            PayButtonText = null,
            Radius = null,
        };

        Assert.Null(model.Dark);
        Assert.True(model.RawData.ContainsKey("dark"));
        Assert.Null(model.FontSize);
        Assert.True(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.FontWeight);
        Assert.True(model.RawData.ContainsKey("font_weight"));
        Assert.Null(model.Light);
        Assert.True(model.RawData.ContainsKey("light"));
        Assert.Null(model.PayButtonText);
        Assert.True(model.RawData.ContainsKey("pay_button_text"));
        Assert.Null(model.Radius);
        Assert.True(model.RawData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThemeConfig
        {
            Dark = null,
            FontSize = null,
            FontWeight = null,
            Light = null,
            PayButtonText = null,
            Radius = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThemeConfig
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        ThemeConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DarkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dark
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        string expectedBgPrimary = "bg_primary";
        string expectedBgSecondary = "bg_secondary";
        string expectedBorderPrimary = "border_primary";
        string expectedBorderSecondary = "border_secondary";
        string expectedButtonPrimary = "button_primary";
        string expectedButtonPrimaryHover = "button_primary_hover";
        string expectedButtonSecondary = "button_secondary";
        string expectedButtonSecondaryHover = "button_secondary_hover";
        string expectedButtonTextPrimary = "button_text_primary";
        string expectedButtonTextSecondary = "button_text_secondary";
        string expectedInputFocusBorder = "input_focus_border";
        string expectedTextError = "text_error";
        string expectedTextPlaceholder = "text_placeholder";
        string expectedTextPrimary = "text_primary";
        string expectedTextSecondary = "text_secondary";
        string expectedTextSuccess = "text_success";

        Assert.Equal(expectedBgPrimary, model.BgPrimary);
        Assert.Equal(expectedBgSecondary, model.BgSecondary);
        Assert.Equal(expectedBorderPrimary, model.BorderPrimary);
        Assert.Equal(expectedBorderSecondary, model.BorderSecondary);
        Assert.Equal(expectedButtonPrimary, model.ButtonPrimary);
        Assert.Equal(expectedButtonPrimaryHover, model.ButtonPrimaryHover);
        Assert.Equal(expectedButtonSecondary, model.ButtonSecondary);
        Assert.Equal(expectedButtonSecondaryHover, model.ButtonSecondaryHover);
        Assert.Equal(expectedButtonTextPrimary, model.ButtonTextPrimary);
        Assert.Equal(expectedButtonTextSecondary, model.ButtonTextSecondary);
        Assert.Equal(expectedInputFocusBorder, model.InputFocusBorder);
        Assert.Equal(expectedTextError, model.TextError);
        Assert.Equal(expectedTextPlaceholder, model.TextPlaceholder);
        Assert.Equal(expectedTextPrimary, model.TextPrimary);
        Assert.Equal(expectedTextSecondary, model.TextSecondary);
        Assert.Equal(expectedTextSuccess, model.TextSuccess);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Dark
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dark>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dark
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dark>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBgPrimary = "bg_primary";
        string expectedBgSecondary = "bg_secondary";
        string expectedBorderPrimary = "border_primary";
        string expectedBorderSecondary = "border_secondary";
        string expectedButtonPrimary = "button_primary";
        string expectedButtonPrimaryHover = "button_primary_hover";
        string expectedButtonSecondary = "button_secondary";
        string expectedButtonSecondaryHover = "button_secondary_hover";
        string expectedButtonTextPrimary = "button_text_primary";
        string expectedButtonTextSecondary = "button_text_secondary";
        string expectedInputFocusBorder = "input_focus_border";
        string expectedTextError = "text_error";
        string expectedTextPlaceholder = "text_placeholder";
        string expectedTextPrimary = "text_primary";
        string expectedTextSecondary = "text_secondary";
        string expectedTextSuccess = "text_success";

        Assert.Equal(expectedBgPrimary, deserialized.BgPrimary);
        Assert.Equal(expectedBgSecondary, deserialized.BgSecondary);
        Assert.Equal(expectedBorderPrimary, deserialized.BorderPrimary);
        Assert.Equal(expectedBorderSecondary, deserialized.BorderSecondary);
        Assert.Equal(expectedButtonPrimary, deserialized.ButtonPrimary);
        Assert.Equal(expectedButtonPrimaryHover, deserialized.ButtonPrimaryHover);
        Assert.Equal(expectedButtonSecondary, deserialized.ButtonSecondary);
        Assert.Equal(expectedButtonSecondaryHover, deserialized.ButtonSecondaryHover);
        Assert.Equal(expectedButtonTextPrimary, deserialized.ButtonTextPrimary);
        Assert.Equal(expectedButtonTextSecondary, deserialized.ButtonTextSecondary);
        Assert.Equal(expectedInputFocusBorder, deserialized.InputFocusBorder);
        Assert.Equal(expectedTextError, deserialized.TextError);
        Assert.Equal(expectedTextPlaceholder, deserialized.TextPlaceholder);
        Assert.Equal(expectedTextPrimary, deserialized.TextPrimary);
        Assert.Equal(expectedTextSecondary, deserialized.TextSecondary);
        Assert.Equal(expectedTextSuccess, deserialized.TextSuccess);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Dark
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Dark { };

        Assert.Null(model.BgPrimary);
        Assert.False(model.RawData.ContainsKey("bg_primary"));
        Assert.Null(model.BgSecondary);
        Assert.False(model.RawData.ContainsKey("bg_secondary"));
        Assert.Null(model.BorderPrimary);
        Assert.False(model.RawData.ContainsKey("border_primary"));
        Assert.Null(model.BorderSecondary);
        Assert.False(model.RawData.ContainsKey("border_secondary"));
        Assert.Null(model.ButtonPrimary);
        Assert.False(model.RawData.ContainsKey("button_primary"));
        Assert.Null(model.ButtonPrimaryHover);
        Assert.False(model.RawData.ContainsKey("button_primary_hover"));
        Assert.Null(model.ButtonSecondary);
        Assert.False(model.RawData.ContainsKey("button_secondary"));
        Assert.Null(model.ButtonSecondaryHover);
        Assert.False(model.RawData.ContainsKey("button_secondary_hover"));
        Assert.Null(model.ButtonTextPrimary);
        Assert.False(model.RawData.ContainsKey("button_text_primary"));
        Assert.Null(model.ButtonTextSecondary);
        Assert.False(model.RawData.ContainsKey("button_text_secondary"));
        Assert.Null(model.InputFocusBorder);
        Assert.False(model.RawData.ContainsKey("input_focus_border"));
        Assert.Null(model.TextError);
        Assert.False(model.RawData.ContainsKey("text_error"));
        Assert.Null(model.TextPlaceholder);
        Assert.False(model.RawData.ContainsKey("text_placeholder"));
        Assert.Null(model.TextPrimary);
        Assert.False(model.RawData.ContainsKey("text_primary"));
        Assert.Null(model.TextSecondary);
        Assert.False(model.RawData.ContainsKey("text_secondary"));
        Assert.Null(model.TextSuccess);
        Assert.False(model.RawData.ContainsKey("text_success"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Dark { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Dark
        {
            BgPrimary = null,
            BgSecondary = null,
            BorderPrimary = null,
            BorderSecondary = null,
            ButtonPrimary = null,
            ButtonPrimaryHover = null,
            ButtonSecondary = null,
            ButtonSecondaryHover = null,
            ButtonTextPrimary = null,
            ButtonTextSecondary = null,
            InputFocusBorder = null,
            TextError = null,
            TextPlaceholder = null,
            TextPrimary = null,
            TextSecondary = null,
            TextSuccess = null,
        };

        Assert.Null(model.BgPrimary);
        Assert.True(model.RawData.ContainsKey("bg_primary"));
        Assert.Null(model.BgSecondary);
        Assert.True(model.RawData.ContainsKey("bg_secondary"));
        Assert.Null(model.BorderPrimary);
        Assert.True(model.RawData.ContainsKey("border_primary"));
        Assert.Null(model.BorderSecondary);
        Assert.True(model.RawData.ContainsKey("border_secondary"));
        Assert.Null(model.ButtonPrimary);
        Assert.True(model.RawData.ContainsKey("button_primary"));
        Assert.Null(model.ButtonPrimaryHover);
        Assert.True(model.RawData.ContainsKey("button_primary_hover"));
        Assert.Null(model.ButtonSecondary);
        Assert.True(model.RawData.ContainsKey("button_secondary"));
        Assert.Null(model.ButtonSecondaryHover);
        Assert.True(model.RawData.ContainsKey("button_secondary_hover"));
        Assert.Null(model.ButtonTextPrimary);
        Assert.True(model.RawData.ContainsKey("button_text_primary"));
        Assert.Null(model.ButtonTextSecondary);
        Assert.True(model.RawData.ContainsKey("button_text_secondary"));
        Assert.Null(model.InputFocusBorder);
        Assert.True(model.RawData.ContainsKey("input_focus_border"));
        Assert.Null(model.TextError);
        Assert.True(model.RawData.ContainsKey("text_error"));
        Assert.Null(model.TextPlaceholder);
        Assert.True(model.RawData.ContainsKey("text_placeholder"));
        Assert.Null(model.TextPrimary);
        Assert.True(model.RawData.ContainsKey("text_primary"));
        Assert.Null(model.TextSecondary);
        Assert.True(model.RawData.ContainsKey("text_secondary"));
        Assert.Null(model.TextSuccess);
        Assert.True(model.RawData.ContainsKey("text_success"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Dark
        {
            BgPrimary = null,
            BgSecondary = null,
            BorderPrimary = null,
            BorderSecondary = null,
            ButtonPrimary = null,
            ButtonPrimaryHover = null,
            ButtonSecondary = null,
            ButtonSecondaryHover = null,
            ButtonTextPrimary = null,
            ButtonTextSecondary = null,
            InputFocusBorder = null,
            TextError = null,
            TextPlaceholder = null,
            TextPrimary = null,
            TextSecondary = null,
            TextSuccess = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Dark
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        Dark copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FontSizeTest : TestBase
{
    [Theory]
    [InlineData(FontSize.Xs)]
    [InlineData(FontSize.Sm)]
    [InlineData(FontSize.Md)]
    [InlineData(FontSize.Lg)]
    [InlineData(FontSize.Xl)]
    [InlineData(FontSize.V2xl)]
    public void Validation_Works(FontSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FontSize> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FontSize>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FontSize.Xs)]
    [InlineData(FontSize.Sm)]
    [InlineData(FontSize.Md)]
    [InlineData(FontSize.Lg)]
    [InlineData(FontSize.Xl)]
    [InlineData(FontSize.V2xl)]
    public void SerializationRoundtrip_Works(FontSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FontSize> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FontSize>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FontSize>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FontSize>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FontWeightTest : TestBase
{
    [Theory]
    [InlineData(FontWeight.Normal)]
    [InlineData(FontWeight.Medium)]
    [InlineData(FontWeight.Bold)]
    [InlineData(FontWeight.ExtraBold)]
    public void Validation_Works(FontWeight rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FontWeight> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FontWeight>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FontWeight.Normal)]
    [InlineData(FontWeight.Medium)]
    [InlineData(FontWeight.Bold)]
    [InlineData(FontWeight.ExtraBold)]
    public void SerializationRoundtrip_Works(FontWeight rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FontWeight> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FontWeight>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FontWeight>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FontWeight>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LightTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Light
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        string expectedBgPrimary = "bg_primary";
        string expectedBgSecondary = "bg_secondary";
        string expectedBorderPrimary = "border_primary";
        string expectedBorderSecondary = "border_secondary";
        string expectedButtonPrimary = "button_primary";
        string expectedButtonPrimaryHover = "button_primary_hover";
        string expectedButtonSecondary = "button_secondary";
        string expectedButtonSecondaryHover = "button_secondary_hover";
        string expectedButtonTextPrimary = "button_text_primary";
        string expectedButtonTextSecondary = "button_text_secondary";
        string expectedInputFocusBorder = "input_focus_border";
        string expectedTextError = "text_error";
        string expectedTextPlaceholder = "text_placeholder";
        string expectedTextPrimary = "text_primary";
        string expectedTextSecondary = "text_secondary";
        string expectedTextSuccess = "text_success";

        Assert.Equal(expectedBgPrimary, model.BgPrimary);
        Assert.Equal(expectedBgSecondary, model.BgSecondary);
        Assert.Equal(expectedBorderPrimary, model.BorderPrimary);
        Assert.Equal(expectedBorderSecondary, model.BorderSecondary);
        Assert.Equal(expectedButtonPrimary, model.ButtonPrimary);
        Assert.Equal(expectedButtonPrimaryHover, model.ButtonPrimaryHover);
        Assert.Equal(expectedButtonSecondary, model.ButtonSecondary);
        Assert.Equal(expectedButtonSecondaryHover, model.ButtonSecondaryHover);
        Assert.Equal(expectedButtonTextPrimary, model.ButtonTextPrimary);
        Assert.Equal(expectedButtonTextSecondary, model.ButtonTextSecondary);
        Assert.Equal(expectedInputFocusBorder, model.InputFocusBorder);
        Assert.Equal(expectedTextError, model.TextError);
        Assert.Equal(expectedTextPlaceholder, model.TextPlaceholder);
        Assert.Equal(expectedTextPrimary, model.TextPrimary);
        Assert.Equal(expectedTextSecondary, model.TextSecondary);
        Assert.Equal(expectedTextSuccess, model.TextSuccess);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Light
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Light>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Light
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Light>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBgPrimary = "bg_primary";
        string expectedBgSecondary = "bg_secondary";
        string expectedBorderPrimary = "border_primary";
        string expectedBorderSecondary = "border_secondary";
        string expectedButtonPrimary = "button_primary";
        string expectedButtonPrimaryHover = "button_primary_hover";
        string expectedButtonSecondary = "button_secondary";
        string expectedButtonSecondaryHover = "button_secondary_hover";
        string expectedButtonTextPrimary = "button_text_primary";
        string expectedButtonTextSecondary = "button_text_secondary";
        string expectedInputFocusBorder = "input_focus_border";
        string expectedTextError = "text_error";
        string expectedTextPlaceholder = "text_placeholder";
        string expectedTextPrimary = "text_primary";
        string expectedTextSecondary = "text_secondary";
        string expectedTextSuccess = "text_success";

        Assert.Equal(expectedBgPrimary, deserialized.BgPrimary);
        Assert.Equal(expectedBgSecondary, deserialized.BgSecondary);
        Assert.Equal(expectedBorderPrimary, deserialized.BorderPrimary);
        Assert.Equal(expectedBorderSecondary, deserialized.BorderSecondary);
        Assert.Equal(expectedButtonPrimary, deserialized.ButtonPrimary);
        Assert.Equal(expectedButtonPrimaryHover, deserialized.ButtonPrimaryHover);
        Assert.Equal(expectedButtonSecondary, deserialized.ButtonSecondary);
        Assert.Equal(expectedButtonSecondaryHover, deserialized.ButtonSecondaryHover);
        Assert.Equal(expectedButtonTextPrimary, deserialized.ButtonTextPrimary);
        Assert.Equal(expectedButtonTextSecondary, deserialized.ButtonTextSecondary);
        Assert.Equal(expectedInputFocusBorder, deserialized.InputFocusBorder);
        Assert.Equal(expectedTextError, deserialized.TextError);
        Assert.Equal(expectedTextPlaceholder, deserialized.TextPlaceholder);
        Assert.Equal(expectedTextPrimary, deserialized.TextPrimary);
        Assert.Equal(expectedTextSecondary, deserialized.TextSecondary);
        Assert.Equal(expectedTextSuccess, deserialized.TextSuccess);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Light
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Light { };

        Assert.Null(model.BgPrimary);
        Assert.False(model.RawData.ContainsKey("bg_primary"));
        Assert.Null(model.BgSecondary);
        Assert.False(model.RawData.ContainsKey("bg_secondary"));
        Assert.Null(model.BorderPrimary);
        Assert.False(model.RawData.ContainsKey("border_primary"));
        Assert.Null(model.BorderSecondary);
        Assert.False(model.RawData.ContainsKey("border_secondary"));
        Assert.Null(model.ButtonPrimary);
        Assert.False(model.RawData.ContainsKey("button_primary"));
        Assert.Null(model.ButtonPrimaryHover);
        Assert.False(model.RawData.ContainsKey("button_primary_hover"));
        Assert.Null(model.ButtonSecondary);
        Assert.False(model.RawData.ContainsKey("button_secondary"));
        Assert.Null(model.ButtonSecondaryHover);
        Assert.False(model.RawData.ContainsKey("button_secondary_hover"));
        Assert.Null(model.ButtonTextPrimary);
        Assert.False(model.RawData.ContainsKey("button_text_primary"));
        Assert.Null(model.ButtonTextSecondary);
        Assert.False(model.RawData.ContainsKey("button_text_secondary"));
        Assert.Null(model.InputFocusBorder);
        Assert.False(model.RawData.ContainsKey("input_focus_border"));
        Assert.Null(model.TextError);
        Assert.False(model.RawData.ContainsKey("text_error"));
        Assert.Null(model.TextPlaceholder);
        Assert.False(model.RawData.ContainsKey("text_placeholder"));
        Assert.Null(model.TextPrimary);
        Assert.False(model.RawData.ContainsKey("text_primary"));
        Assert.Null(model.TextSecondary);
        Assert.False(model.RawData.ContainsKey("text_secondary"));
        Assert.Null(model.TextSuccess);
        Assert.False(model.RawData.ContainsKey("text_success"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Light { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Light
        {
            BgPrimary = null,
            BgSecondary = null,
            BorderPrimary = null,
            BorderSecondary = null,
            ButtonPrimary = null,
            ButtonPrimaryHover = null,
            ButtonSecondary = null,
            ButtonSecondaryHover = null,
            ButtonTextPrimary = null,
            ButtonTextSecondary = null,
            InputFocusBorder = null,
            TextError = null,
            TextPlaceholder = null,
            TextPrimary = null,
            TextSecondary = null,
            TextSuccess = null,
        };

        Assert.Null(model.BgPrimary);
        Assert.True(model.RawData.ContainsKey("bg_primary"));
        Assert.Null(model.BgSecondary);
        Assert.True(model.RawData.ContainsKey("bg_secondary"));
        Assert.Null(model.BorderPrimary);
        Assert.True(model.RawData.ContainsKey("border_primary"));
        Assert.Null(model.BorderSecondary);
        Assert.True(model.RawData.ContainsKey("border_secondary"));
        Assert.Null(model.ButtonPrimary);
        Assert.True(model.RawData.ContainsKey("button_primary"));
        Assert.Null(model.ButtonPrimaryHover);
        Assert.True(model.RawData.ContainsKey("button_primary_hover"));
        Assert.Null(model.ButtonSecondary);
        Assert.True(model.RawData.ContainsKey("button_secondary"));
        Assert.Null(model.ButtonSecondaryHover);
        Assert.True(model.RawData.ContainsKey("button_secondary_hover"));
        Assert.Null(model.ButtonTextPrimary);
        Assert.True(model.RawData.ContainsKey("button_text_primary"));
        Assert.Null(model.ButtonTextSecondary);
        Assert.True(model.RawData.ContainsKey("button_text_secondary"));
        Assert.Null(model.InputFocusBorder);
        Assert.True(model.RawData.ContainsKey("input_focus_border"));
        Assert.Null(model.TextError);
        Assert.True(model.RawData.ContainsKey("text_error"));
        Assert.Null(model.TextPlaceholder);
        Assert.True(model.RawData.ContainsKey("text_placeholder"));
        Assert.Null(model.TextPrimary);
        Assert.True(model.RawData.ContainsKey("text_primary"));
        Assert.Null(model.TextSecondary);
        Assert.True(model.RawData.ContainsKey("text_secondary"));
        Assert.Null(model.TextSuccess);
        Assert.True(model.RawData.ContainsKey("text_success"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Light
        {
            BgPrimary = null,
            BgSecondary = null,
            BorderPrimary = null,
            BorderSecondary = null,
            ButtonPrimary = null,
            ButtonPrimaryHover = null,
            ButtonSecondary = null,
            ButtonSecondaryHover = null,
            ButtonTextPrimary = null,
            ButtonTextSecondary = null,
            InputFocusBorder = null,
            TextError = null,
            TextPlaceholder = null,
            TextPrimary = null,
            TextSecondary = null,
            TextSuccess = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Light
        {
            BgPrimary = "bg_primary",
            BgSecondary = "bg_secondary",
            BorderPrimary = "border_primary",
            BorderSecondary = "border_secondary",
            ButtonPrimary = "button_primary",
            ButtonPrimaryHover = "button_primary_hover",
            ButtonSecondary = "button_secondary",
            ButtonSecondaryHover = "button_secondary_hover",
            ButtonTextPrimary = "button_text_primary",
            ButtonTextSecondary = "button_text_secondary",
            InputFocusBorder = "input_focus_border",
            TextError = "text_error",
            TextPlaceholder = "text_placeholder",
            TextPrimary = "text_primary",
            TextSecondary = "text_secondary",
            TextSuccess = "text_success",
        };

        Light copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureFlagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureFlags
        {
            AllowCurrencySelection = true,
            AllowCustomerEditingCity = true,
            AllowCustomerEditingCountry = true,
            AllowCustomerEditingEmail = true,
            AllowCustomerEditingName = true,
            AllowCustomerEditingState = true,
            AllowCustomerEditingStreet = true,
            AllowCustomerEditingZipcode = true,
            AllowDiscountCode = true,
            AllowPhoneNumberCollection = true,
            AllowTaxID = true,
            AlwaysCreateNewCustomer = true,
            RedirectImmediately = true,
        };

        bool expectedAllowCurrencySelection = true;
        bool expectedAllowCustomerEditingCity = true;
        bool expectedAllowCustomerEditingCountry = true;
        bool expectedAllowCustomerEditingEmail = true;
        bool expectedAllowCustomerEditingName = true;
        bool expectedAllowCustomerEditingState = true;
        bool expectedAllowCustomerEditingStreet = true;
        bool expectedAllowCustomerEditingZipcode = true;
        bool expectedAllowDiscountCode = true;
        bool expectedAllowPhoneNumberCollection = true;
        bool expectedAllowTaxID = true;
        bool expectedAlwaysCreateNewCustomer = true;
        bool expectedRedirectImmediately = true;

        Assert.Equal(expectedAllowCurrencySelection, model.AllowCurrencySelection);
        Assert.Equal(expectedAllowCustomerEditingCity, model.AllowCustomerEditingCity);
        Assert.Equal(expectedAllowCustomerEditingCountry, model.AllowCustomerEditingCountry);
        Assert.Equal(expectedAllowCustomerEditingEmail, model.AllowCustomerEditingEmail);
        Assert.Equal(expectedAllowCustomerEditingName, model.AllowCustomerEditingName);
        Assert.Equal(expectedAllowCustomerEditingState, model.AllowCustomerEditingState);
        Assert.Equal(expectedAllowCustomerEditingStreet, model.AllowCustomerEditingStreet);
        Assert.Equal(expectedAllowCustomerEditingZipcode, model.AllowCustomerEditingZipcode);
        Assert.Equal(expectedAllowDiscountCode, model.AllowDiscountCode);
        Assert.Equal(expectedAllowPhoneNumberCollection, model.AllowPhoneNumberCollection);
        Assert.Equal(expectedAllowTaxID, model.AllowTaxID);
        Assert.Equal(expectedAlwaysCreateNewCustomer, model.AlwaysCreateNewCustomer);
        Assert.Equal(expectedRedirectImmediately, model.RedirectImmediately);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureFlags
        {
            AllowCurrencySelection = true,
            AllowCustomerEditingCity = true,
            AllowCustomerEditingCountry = true,
            AllowCustomerEditingEmail = true,
            AllowCustomerEditingName = true,
            AllowCustomerEditingState = true,
            AllowCustomerEditingStreet = true,
            AllowCustomerEditingZipcode = true,
            AllowDiscountCode = true,
            AllowPhoneNumberCollection = true,
            AllowTaxID = true,
            AlwaysCreateNewCustomer = true,
            RedirectImmediately = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureFlags>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureFlags
        {
            AllowCurrencySelection = true,
            AllowCustomerEditingCity = true,
            AllowCustomerEditingCountry = true,
            AllowCustomerEditingEmail = true,
            AllowCustomerEditingName = true,
            AllowCustomerEditingState = true,
            AllowCustomerEditingStreet = true,
            AllowCustomerEditingZipcode = true,
            AllowDiscountCode = true,
            AllowPhoneNumberCollection = true,
            AllowTaxID = true,
            AlwaysCreateNewCustomer = true,
            RedirectImmediately = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureFlags>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAllowCurrencySelection = true;
        bool expectedAllowCustomerEditingCity = true;
        bool expectedAllowCustomerEditingCountry = true;
        bool expectedAllowCustomerEditingEmail = true;
        bool expectedAllowCustomerEditingName = true;
        bool expectedAllowCustomerEditingState = true;
        bool expectedAllowCustomerEditingStreet = true;
        bool expectedAllowCustomerEditingZipcode = true;
        bool expectedAllowDiscountCode = true;
        bool expectedAllowPhoneNumberCollection = true;
        bool expectedAllowTaxID = true;
        bool expectedAlwaysCreateNewCustomer = true;
        bool expectedRedirectImmediately = true;

        Assert.Equal(expectedAllowCurrencySelection, deserialized.AllowCurrencySelection);
        Assert.Equal(expectedAllowCustomerEditingCity, deserialized.AllowCustomerEditingCity);
        Assert.Equal(expectedAllowCustomerEditingCountry, deserialized.AllowCustomerEditingCountry);
        Assert.Equal(expectedAllowCustomerEditingEmail, deserialized.AllowCustomerEditingEmail);
        Assert.Equal(expectedAllowCustomerEditingName, deserialized.AllowCustomerEditingName);
        Assert.Equal(expectedAllowCustomerEditingState, deserialized.AllowCustomerEditingState);
        Assert.Equal(expectedAllowCustomerEditingStreet, deserialized.AllowCustomerEditingStreet);
        Assert.Equal(expectedAllowCustomerEditingZipcode, deserialized.AllowCustomerEditingZipcode);
        Assert.Equal(expectedAllowDiscountCode, deserialized.AllowDiscountCode);
        Assert.Equal(expectedAllowPhoneNumberCollection, deserialized.AllowPhoneNumberCollection);
        Assert.Equal(expectedAllowTaxID, deserialized.AllowTaxID);
        Assert.Equal(expectedAlwaysCreateNewCustomer, deserialized.AlwaysCreateNewCustomer);
        Assert.Equal(expectedRedirectImmediately, deserialized.RedirectImmediately);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureFlags
        {
            AllowCurrencySelection = true,
            AllowCustomerEditingCity = true,
            AllowCustomerEditingCountry = true,
            AllowCustomerEditingEmail = true,
            AllowCustomerEditingName = true,
            AllowCustomerEditingState = true,
            AllowCustomerEditingStreet = true,
            AllowCustomerEditingZipcode = true,
            AllowDiscountCode = true,
            AllowPhoneNumberCollection = true,
            AllowTaxID = true,
            AlwaysCreateNewCustomer = true,
            RedirectImmediately = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FeatureFlags { };

        Assert.Null(model.AllowCurrencySelection);
        Assert.False(model.RawData.ContainsKey("allow_currency_selection"));
        Assert.Null(model.AllowCustomerEditingCity);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_city"));
        Assert.Null(model.AllowCustomerEditingCountry);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_country"));
        Assert.Null(model.AllowCustomerEditingEmail);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_email"));
        Assert.Null(model.AllowCustomerEditingName);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_name"));
        Assert.Null(model.AllowCustomerEditingState);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_state"));
        Assert.Null(model.AllowCustomerEditingStreet);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_street"));
        Assert.Null(model.AllowCustomerEditingZipcode);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_zipcode"));
        Assert.Null(model.AllowDiscountCode);
        Assert.False(model.RawData.ContainsKey("allow_discount_code"));
        Assert.Null(model.AllowPhoneNumberCollection);
        Assert.False(model.RawData.ContainsKey("allow_phone_number_collection"));
        Assert.Null(model.AllowTaxID);
        Assert.False(model.RawData.ContainsKey("allow_tax_id"));
        Assert.Null(model.AlwaysCreateNewCustomer);
        Assert.False(model.RawData.ContainsKey("always_create_new_customer"));
        Assert.Null(model.RedirectImmediately);
        Assert.False(model.RawData.ContainsKey("redirect_immediately"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FeatureFlags { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FeatureFlags
        {
            // Null should be interpreted as omitted for these properties
            AllowCurrencySelection = null,
            AllowCustomerEditingCity = null,
            AllowCustomerEditingCountry = null,
            AllowCustomerEditingEmail = null,
            AllowCustomerEditingName = null,
            AllowCustomerEditingState = null,
            AllowCustomerEditingStreet = null,
            AllowCustomerEditingZipcode = null,
            AllowDiscountCode = null,
            AllowPhoneNumberCollection = null,
            AllowTaxID = null,
            AlwaysCreateNewCustomer = null,
            RedirectImmediately = null,
        };

        Assert.Null(model.AllowCurrencySelection);
        Assert.False(model.RawData.ContainsKey("allow_currency_selection"));
        Assert.Null(model.AllowCustomerEditingCity);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_city"));
        Assert.Null(model.AllowCustomerEditingCountry);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_country"));
        Assert.Null(model.AllowCustomerEditingEmail);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_email"));
        Assert.Null(model.AllowCustomerEditingName);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_name"));
        Assert.Null(model.AllowCustomerEditingState);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_state"));
        Assert.Null(model.AllowCustomerEditingStreet);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_street"));
        Assert.Null(model.AllowCustomerEditingZipcode);
        Assert.False(model.RawData.ContainsKey("allow_customer_editing_zipcode"));
        Assert.Null(model.AllowDiscountCode);
        Assert.False(model.RawData.ContainsKey("allow_discount_code"));
        Assert.Null(model.AllowPhoneNumberCollection);
        Assert.False(model.RawData.ContainsKey("allow_phone_number_collection"));
        Assert.Null(model.AllowTaxID);
        Assert.False(model.RawData.ContainsKey("allow_tax_id"));
        Assert.Null(model.AlwaysCreateNewCustomer);
        Assert.False(model.RawData.ContainsKey("always_create_new_customer"));
        Assert.Null(model.RedirectImmediately);
        Assert.False(model.RawData.ContainsKey("redirect_immediately"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FeatureFlags
        {
            // Null should be interpreted as omitted for these properties
            AllowCurrencySelection = null,
            AllowCustomerEditingCity = null,
            AllowCustomerEditingCountry = null,
            AllowCustomerEditingEmail = null,
            AllowCustomerEditingName = null,
            AllowCustomerEditingState = null,
            AllowCustomerEditingStreet = null,
            AllowCustomerEditingZipcode = null,
            AllowDiscountCode = null,
            AllowPhoneNumberCollection = null,
            AllowTaxID = null,
            AlwaysCreateNewCustomer = null,
            RedirectImmediately = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureFlags
        {
            AllowCurrencySelection = true,
            AllowCustomerEditingCity = true,
            AllowCustomerEditingCountry = true,
            AllowCustomerEditingEmail = true,
            AllowCustomerEditingName = true,
            AllowCustomerEditingState = true,
            AllowCustomerEditingStreet = true,
            AllowCustomerEditingZipcode = true,
            AllowDiscountCode = true,
            AllowPhoneNumberCollection = true,
            AllowTaxID = true,
            AlwaysCreateNewCustomer = true,
            RedirectImmediately = true,
        };

        FeatureFlags copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        OnDemandSubscription expectedOnDemand = new()
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };
        int expectedTrialPeriodDays = 0;

        Assert.Equal(expectedOnDemand, model.OnDemand);
        Assert.Equal(expectedTrialPeriodDays, model.TrialPeriodDays);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        OnDemandSubscription expectedOnDemand = new()
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };
        int expectedTrialPeriodDays = 0;

        Assert.Equal(expectedOnDemand, deserialized.OnDemand);
        Assert.Equal(expectedTrialPeriodDays, deserialized.TrialPeriodDays);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionData { };

        Assert.Null(model.OnDemand);
        Assert.False(model.RawData.ContainsKey("on_demand"));
        Assert.Null(model.TrialPeriodDays);
        Assert.False(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionData { OnDemand = null, TrialPeriodDays = null };

        Assert.Null(model.OnDemand);
        Assert.True(model.RawData.ContainsKey("on_demand"));
        Assert.Null(model.TrialPeriodDays);
        Assert.True(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionData { OnDemand = null, TrialPeriodDays = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionData
        {
            OnDemand = new()
            {
                MandateOnly = true,
                AdaptiveCurrencyFeesInclusive = true,
                ProductCurrency = Currency.Aed,
                ProductDescription = "product_description",
                ProductPrice = 0,
            },
            TrialPeriodDays = 0,
        };

        SubscriptionData copied = new(model);

        Assert.Equal(model, copied);
    }
}
