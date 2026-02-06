using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionPreviewParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckoutSessionPreviewParams
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
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
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
            Customer = new AttachExistingCustomer("customer_id"),
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
                    FontPrimaryUrl = "font_primary_url",
                    FontSecondaryUrl = "font_secondary_url",
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

        List<ProductItemReq> expectedProductCart =
        [
            new()
            {
                ProductID = "product_id",
                Quantity = 0,
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Amount = 0,
            },
        ];
        List<ApiEnum<string, PaymentMethodTypes>> expectedAllowedPaymentMethodTypes =
        [
            PaymentMethodTypes.Ach,
        ];
        CheckoutSessionBillingAddress expectedBillingAddress = new()
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
        CustomerRequest expectedCustomer = new AttachExistingCustomer("customer_id");
        CheckoutSessionCustomization expectedCustomization = new()
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
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
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
        CheckoutSessionFlags expectedFeatureFlags = new()
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
        var parameters = new CheckoutSessionPreviewParams
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
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
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
            Customer = new AttachExistingCustomer("customer_id"),
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
        var parameters = new CheckoutSessionPreviewParams
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
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
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
            Customer = new AttachExistingCustomer("customer_id"),
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
        var parameters = new CheckoutSessionPreviewParams
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
                    FontPrimaryUrl = "font_primary_url",
                    FontSecondaryUrl = "font_secondary_url",
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
        var parameters = new CheckoutSessionPreviewParams
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
                    FontPrimaryUrl = "font_primary_url",
                    FontSecondaryUrl = "font_secondary_url",
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
        CheckoutSessionPreviewParams parameters = new()
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

        Assert.Equal(new Uri("https://live.dodopayments.com/checkouts/preview"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckoutSessionPreviewParams
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
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
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
            Customer = new AttachExistingCustomer("customer_id"),
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
                    FontPrimaryUrl = "font_primary_url",
                    FontSecondaryUrl = "font_secondary_url",
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

        CheckoutSessionPreviewParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
