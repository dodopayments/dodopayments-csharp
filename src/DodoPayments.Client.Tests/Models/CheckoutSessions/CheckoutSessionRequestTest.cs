using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        List<CheckoutSessionRequestProductCart> expectedProductCart =
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
        CheckoutSessionRequestBillingAddress expectedBillingAddress = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        ApiEnum<string, Currency> expectedBillingCurrency = Currency.Aed;
        bool expectedConfirm = true;
        List<CheckoutSessionRequestCustomField> expectedCustomFields =
        [
            new()
            {
                FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
                Key = "key",
                Label = "label",
                Options = ["string"],
                Placeholder = "placeholder",
                Required = true,
            },
        ];
        CustomerRequest expectedCustomer = new AttachExistingCustomer("customer_id");
        CheckoutSessionRequestCustomization expectedCustomization = new()
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        CheckoutSessionRequestFeatureFlags expectedFeatureFlags = new()
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
        CheckoutSessionRequestSubscriptionData expectedSubscriptionData = new()
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

        Assert.Equal(expectedProductCart.Count, model.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], model.ProductCart[i]);
        }
        Assert.NotNull(model.AllowedPaymentMethodTypes);
        Assert.Equal(
            expectedAllowedPaymentMethodTypes.Count,
            model.AllowedPaymentMethodTypes.Count
        );
        for (int i = 0; i < expectedAllowedPaymentMethodTypes.Count; i++)
        {
            Assert.Equal(expectedAllowedPaymentMethodTypes[i], model.AllowedPaymentMethodTypes[i]);
        }
        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedBillingCurrency, model.BillingCurrency);
        Assert.Equal(expectedConfirm, model.Confirm);
        Assert.NotNull(model.CustomFields);
        Assert.Equal(expectedCustomFields.Count, model.CustomFields.Count);
        for (int i = 0; i < expectedCustomFields.Count; i++)
        {
            Assert.Equal(expectedCustomFields[i], model.CustomFields[i]);
        }
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedCustomization, model.Customization);
        Assert.Equal(expectedDiscountCode, model.DiscountCode);
        Assert.Equal(expectedFeatureFlags, model.FeatureFlags);
        Assert.Equal(expectedForce3ds, model.Force3ds);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimalAddress, model.MinimalAddress);
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedProductCollectionID, model.ProductCollectionID);
        Assert.Equal(expectedReturnUrl, model.ReturnUrl);
        Assert.Equal(expectedShortLink, model.ShortLink);
        Assert.Equal(expectedShowSavedPaymentMethods, model.ShowSavedPaymentMethods);
        Assert.Equal(expectedSubscriptionData, model.SubscriptionData);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CheckoutSessionRequestProductCart> expectedProductCart =
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
        CheckoutSessionRequestBillingAddress expectedBillingAddress = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        ApiEnum<string, Currency> expectedBillingCurrency = Currency.Aed;
        bool expectedConfirm = true;
        List<CheckoutSessionRequestCustomField> expectedCustomFields =
        [
            new()
            {
                FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
                Key = "key",
                Label = "label",
                Options = ["string"],
                Placeholder = "placeholder",
                Required = true,
            },
        ];
        CustomerRequest expectedCustomer = new AttachExistingCustomer("customer_id");
        CheckoutSessionRequestCustomization expectedCustomization = new()
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        CheckoutSessionRequestFeatureFlags expectedFeatureFlags = new()
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
        CheckoutSessionRequestSubscriptionData expectedSubscriptionData = new()
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

        Assert.Equal(expectedProductCart.Count, deserialized.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], deserialized.ProductCart[i]);
        }
        Assert.NotNull(deserialized.AllowedPaymentMethodTypes);
        Assert.Equal(
            expectedAllowedPaymentMethodTypes.Count,
            deserialized.AllowedPaymentMethodTypes.Count
        );
        for (int i = 0; i < expectedAllowedPaymentMethodTypes.Count; i++)
        {
            Assert.Equal(
                expectedAllowedPaymentMethodTypes[i],
                deserialized.AllowedPaymentMethodTypes[i]
            );
        }
        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedBillingCurrency, deserialized.BillingCurrency);
        Assert.Equal(expectedConfirm, deserialized.Confirm);
        Assert.NotNull(deserialized.CustomFields);
        Assert.Equal(expectedCustomFields.Count, deserialized.CustomFields.Count);
        for (int i = 0; i < expectedCustomFields.Count; i++)
        {
            Assert.Equal(expectedCustomFields[i], deserialized.CustomFields[i]);
        }
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedCustomization, deserialized.Customization);
        Assert.Equal(expectedDiscountCode, deserialized.DiscountCode);
        Assert.Equal(expectedFeatureFlags, deserialized.FeatureFlags);
        Assert.Equal(expectedForce3ds, deserialized.Force3ds);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimalAddress, deserialized.MinimalAddress);
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedProductCollectionID, deserialized.ProductCollectionID);
        Assert.Equal(expectedReturnUrl, deserialized.ReturnUrl);
        Assert.Equal(expectedShortLink, deserialized.ShortLink);
        Assert.Equal(expectedShowSavedPaymentMethods, deserialized.ShowSavedPaymentMethods);
        Assert.Equal(expectedSubscriptionData, deserialized.SubscriptionData);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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

        Assert.Null(model.Confirm);
        Assert.False(model.RawData.ContainsKey("confirm"));
        Assert.Null(model.Customization);
        Assert.False(model.RawData.ContainsKey("customization"));
        Assert.Null(model.FeatureFlags);
        Assert.False(model.RawData.ContainsKey("feature_flags"));
        Assert.Null(model.MinimalAddress);
        Assert.False(model.RawData.ContainsKey("minimal_address"));
        Assert.Null(model.ShortLink);
        Assert.False(model.RawData.ContainsKey("short_link"));
        Assert.Null(model.ShowSavedPaymentMethods);
        Assert.False(model.RawData.ContainsKey("show_saved_payment_methods"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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

        Assert.Null(model.Confirm);
        Assert.False(model.RawData.ContainsKey("confirm"));
        Assert.Null(model.Customization);
        Assert.False(model.RawData.ContainsKey("customization"));
        Assert.Null(model.FeatureFlags);
        Assert.False(model.RawData.ContainsKey("feature_flags"));
        Assert.Null(model.MinimalAddress);
        Assert.False(model.RawData.ContainsKey("minimal_address"));
        Assert.Null(model.ShortLink);
        Assert.False(model.RawData.ContainsKey("short_link"));
        Assert.Null(model.ShowSavedPaymentMethods);
        Assert.False(model.RawData.ContainsKey("show_saved_payment_methods"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionRequest
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        Assert.Null(model.AllowedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billing_address"));
        Assert.Null(model.BillingCurrency);
        Assert.False(model.RawData.ContainsKey("billing_currency"));
        Assert.Null(model.CustomFields);
        Assert.False(model.RawData.ContainsKey("custom_fields"));
        Assert.Null(model.Customer);
        Assert.False(model.RawData.ContainsKey("customer"));
        Assert.Null(model.DiscountCode);
        Assert.False(model.RawData.ContainsKey("discount_code"));
        Assert.Null(model.Force3ds);
        Assert.False(model.RawData.ContainsKey("force_3ds"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("payment_method_id"));
        Assert.Null(model.ProductCollectionID);
        Assert.False(model.RawData.ContainsKey("product_collection_id"));
        Assert.Null(model.ReturnUrl);
        Assert.False(model.RawData.ContainsKey("return_url"));
        Assert.Null(model.SubscriptionData);
        Assert.False(model.RawData.ContainsKey("subscription_data"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionRequest
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequest
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        Assert.Null(model.AllowedPaymentMethodTypes);
        Assert.True(model.RawData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(model.BillingAddress);
        Assert.True(model.RawData.ContainsKey("billing_address"));
        Assert.Null(model.BillingCurrency);
        Assert.True(model.RawData.ContainsKey("billing_currency"));
        Assert.Null(model.CustomFields);
        Assert.True(model.RawData.ContainsKey("custom_fields"));
        Assert.Null(model.Customer);
        Assert.True(model.RawData.ContainsKey("customer"));
        Assert.Null(model.DiscountCode);
        Assert.True(model.RawData.ContainsKey("discount_code"));
        Assert.Null(model.Force3ds);
        Assert.True(model.RawData.ContainsKey("force_3ds"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentMethodID);
        Assert.True(model.RawData.ContainsKey("payment_method_id"));
        Assert.Null(model.ProductCollectionID);
        Assert.True(model.RawData.ContainsKey("product_collection_id"));
        Assert.Null(model.ReturnUrl);
        Assert.True(model.RawData.ContainsKey("return_url"));
        Assert.Null(model.SubscriptionData);
        Assert.True(model.RawData.ContainsKey("subscription_data"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionRequest
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckoutSessionRequest
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
                    FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                    FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                    FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        CheckoutSessionRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestProductCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestProductCart
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
        var model = new CheckoutSessionRequestProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestProductCart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestProductCart>(
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
        var model = new CheckoutSessionRequestProductCart
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
        var model = new CheckoutSessionRequestProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionRequestProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequestProductCart
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
        var model = new CheckoutSessionRequestProductCart
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
        var model = new CheckoutSessionRequestProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        CheckoutSessionRequestProductCart copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestBillingAddress
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
        var model = new CheckoutSessionRequestBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestBillingAddress>(
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
        var model = new CheckoutSessionRequestBillingAddress
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
        var model = new CheckoutSessionRequestBillingAddress { Country = CountryCode.Af };

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
        var model = new CheckoutSessionRequestBillingAddress { Country = CountryCode.Af };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequestBillingAddress
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
        var model = new CheckoutSessionRequestBillingAddress
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
        var model = new CheckoutSessionRequestBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        CheckoutSessionRequestBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestCustomFieldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType> expectedFieldType =
            CheckoutSessionRequestCustomFieldFieldType.Text;
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestCustomField>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestCustomField>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType> expectedFieldType =
            CheckoutSessionRequestCustomFieldFieldType.Text;
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionRequestCustomField
        {
            FieldType = CheckoutSessionRequestCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        CheckoutSessionRequestCustomField copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestCustomFieldFieldTypeTest : TestBase
{
    [Theory]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Text)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Number)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Email)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Url)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Date)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Dropdown)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Boolean)]
    public void Validation_Works(CheckoutSessionRequestCustomFieldFieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Text)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Number)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Email)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Url)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Date)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Dropdown)]
    [InlineData(CheckoutSessionRequestCustomFieldFieldType.Boolean)]
    public void SerializationRoundtrip_Works(CheckoutSessionRequestCustomFieldFieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomFieldFieldType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutSessionRequestCustomizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        ApiEnum<string, CheckoutSessionRequestCustomizationTheme> expectedTheme =
            CheckoutSessionRequestCustomizationTheme.Dark;
        CheckoutSessionRequestCustomizationThemeConfig expectedThemeConfig = new()
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
            FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
            FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var model = new CheckoutSessionRequestCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestCustomization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestCustomization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, CheckoutSessionRequestCustomizationTheme> expectedTheme =
            CheckoutSessionRequestCustomizationTheme.Dark;
        CheckoutSessionRequestCustomizationThemeConfig expectedThemeConfig = new()
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
            FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
            FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var model = new CheckoutSessionRequestCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var model = new CheckoutSessionRequestCustomization
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var model = new CheckoutSessionRequestCustomization
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var model = new CheckoutSessionRequestCustomization
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var model = new CheckoutSessionRequestCustomization
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var model = new CheckoutSessionRequestCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
        };

        Assert.Null(model.ForceLanguage);
        Assert.False(model.RawData.ContainsKey("force_language"));
        Assert.Null(model.ThemeConfig);
        Assert.False(model.RawData.ContainsKey("theme_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionRequestCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequestCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,

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
        var model = new CheckoutSessionRequestCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,

            ForceLanguage = null,
            ThemeConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckoutSessionRequestCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
                FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
                FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        CheckoutSessionRequestCustomization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestCustomizationThemeTest : TestBase
{
    [Theory]
    [InlineData(CheckoutSessionRequestCustomizationTheme.Dark)]
    [InlineData(CheckoutSessionRequestCustomizationTheme.Light)]
    [InlineData(CheckoutSessionRequestCustomizationTheme.System)]
    public void Validation_Works(CheckoutSessionRequestCustomizationTheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionRequestCustomizationTheme> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationTheme>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckoutSessionRequestCustomizationTheme.Dark)]
    [InlineData(CheckoutSessionRequestCustomizationTheme.Light)]
    [InlineData(CheckoutSessionRequestCustomizationTheme.System)]
    public void SerializationRoundtrip_Works(CheckoutSessionRequestCustomizationTheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionRequestCustomizationTheme> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationTheme>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationTheme>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationTheme>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutSessionRequestCustomizationThemeConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfig
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
            FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
            FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        CheckoutSessionRequestCustomizationThemeConfigDark expectedDark = new()
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
        ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize> expectedFontSize =
            CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs;
        ApiEnum<
            string,
            CheckoutSessionRequestCustomizationThemeConfigFontWeight
        > expectedFontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal;
        CheckoutSessionRequestCustomizationThemeConfigLight expectedLight = new()
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
        var model = new CheckoutSessionRequestCustomizationThemeConfig
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
            FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
            FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var deserialized =
            JsonSerializer.Deserialize<CheckoutSessionRequestCustomizationThemeConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfig
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
            FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
            FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var deserialized =
            JsonSerializer.Deserialize<CheckoutSessionRequestCustomizationThemeConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        CheckoutSessionRequestCustomizationThemeConfigDark expectedDark = new()
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
        ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize> expectedFontSize =
            CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs;
        ApiEnum<
            string,
            CheckoutSessionRequestCustomizationThemeConfigFontWeight
        > expectedFontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal;
        CheckoutSessionRequestCustomizationThemeConfigLight expectedLight = new()
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
        var model = new CheckoutSessionRequestCustomizationThemeConfig
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
            FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
            FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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
        var model = new CheckoutSessionRequestCustomizationThemeConfig { };

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
        var model = new CheckoutSessionRequestCustomizationThemeConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfig
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
        var model = new CheckoutSessionRequestCustomizationThemeConfig
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
        var model = new CheckoutSessionRequestCustomizationThemeConfig
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
            FontSize = CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs,
            FontWeight = CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal,
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

        CheckoutSessionRequestCustomizationThemeConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestCustomizationThemeConfigDarkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark
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
        var deserialized =
            JsonSerializer.Deserialize<CheckoutSessionRequestCustomizationThemeConfigDark>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark
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
        var deserialized =
            JsonSerializer.Deserialize<CheckoutSessionRequestCustomizationThemeConfigDark>(
                element,
                ModelBase.SerializerOptions
            );
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark { };

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
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigDark
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

        CheckoutSessionRequestCustomizationThemeConfigDark copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestCustomizationThemeConfigFontSizeTest : TestBase
{
    [Theory]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Sm)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Md)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Lg)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Xl)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.V2xl)]
    public void Validation_Works(CheckoutSessionRequestCustomizationThemeConfigFontSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Xs)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Sm)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Md)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Lg)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.Xl)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontSize.V2xl)]
    public void SerializationRoundtrip_Works(
        CheckoutSessionRequestCustomizationThemeConfigFontSize rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontSize>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutSessionRequestCustomizationThemeConfigFontWeightTest : TestBase
{
    [Theory]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontWeight.Medium)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontWeight.Bold)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontWeight.ExtraBold)]
    public void Validation_Works(CheckoutSessionRequestCustomizationThemeConfigFontWeight rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontWeight> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontWeight>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontWeight.Normal)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontWeight.Medium)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontWeight.Bold)]
    [InlineData(CheckoutSessionRequestCustomizationThemeConfigFontWeight.ExtraBold)]
    public void SerializationRoundtrip_Works(
        CheckoutSessionRequestCustomizationThemeConfigFontWeight rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontWeight> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontWeight>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontWeight>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionRequestCustomizationThemeConfigFontWeight>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutSessionRequestCustomizationThemeConfigLightTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight
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
        var deserialized =
            JsonSerializer.Deserialize<CheckoutSessionRequestCustomizationThemeConfigLight>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight
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
        var deserialized =
            JsonSerializer.Deserialize<CheckoutSessionRequestCustomizationThemeConfigLight>(
                element,
                ModelBase.SerializerOptions
            );
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight { };

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
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight
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
        var model = new CheckoutSessionRequestCustomizationThemeConfigLight
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

        CheckoutSessionRequestCustomizationThemeConfigLight copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestFeatureFlagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestFeatureFlags
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
        var model = new CheckoutSessionRequestFeatureFlags
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestFeatureFlags>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestFeatureFlags
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestFeatureFlags>(
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
        var model = new CheckoutSessionRequestFeatureFlags
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
        var model = new CheckoutSessionRequestFeatureFlags { };

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
        var model = new CheckoutSessionRequestFeatureFlags { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CheckoutSessionRequestFeatureFlags
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
        var model = new CheckoutSessionRequestFeatureFlags
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
        var model = new CheckoutSessionRequestFeatureFlags
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

        CheckoutSessionRequestFeatureFlags copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionRequestSubscriptionDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionRequestSubscriptionData
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
        var model = new CheckoutSessionRequestSubscriptionData
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestSubscriptionData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionRequestSubscriptionData
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequestSubscriptionData>(
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
        var model = new CheckoutSessionRequestSubscriptionData
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
        var model = new CheckoutSessionRequestSubscriptionData { };

        Assert.Null(model.OnDemand);
        Assert.False(model.RawData.ContainsKey("on_demand"));
        Assert.Null(model.TrialPeriodDays);
        Assert.False(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionRequestSubscriptionData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionRequestSubscriptionData
        {
            OnDemand = null,
            TrialPeriodDays = null,
        };

        Assert.Null(model.OnDemand);
        Assert.True(model.RawData.ContainsKey("on_demand"));
        Assert.Null(model.TrialPeriodDays);
        Assert.True(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionRequestSubscriptionData
        {
            OnDemand = null,
            TrialPeriodDays = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckoutSessionRequestSubscriptionData
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

        CheckoutSessionRequestSubscriptionData copied = new(model);

        Assert.Equal(model, copied);
    }
}
