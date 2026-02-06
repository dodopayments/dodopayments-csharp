using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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

        CheckoutSessionRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
