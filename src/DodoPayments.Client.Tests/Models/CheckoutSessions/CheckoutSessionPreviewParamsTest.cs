using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

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
                    FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
                Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
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

        List<CheckoutSessionPreviewParamsProductCart> expectedProductCart =
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
        CheckoutSessionPreviewParamsBillingAddress expectedBillingAddress = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        ApiEnum<string, Currency> expectedBillingCurrency = Currency.Aed;
        bool expectedConfirm = true;
        List<CheckoutSessionPreviewParamsCustomField> expectedCustomFields =
        [
            new()
            {
                FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
                Key = "key",
                Label = "label",
                Options = ["string"],
                Placeholder = "placeholder",
                Required = true,
            },
        ];
        CustomerRequest expectedCustomer = new AttachExistingCustomer("customer_id");
        CheckoutSessionPreviewParamsCustomization expectedCustomization = new()
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
        };
        string expectedDiscountCode = "discount_code";
        CheckoutSessionPreviewParamsFeatureFlags expectedFeatureFlags = new()
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
        CheckoutSessionPreviewParamsSubscriptionData expectedSubscriptionData = new()
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
                    FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
                    FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
                Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
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
                Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
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
                    FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
                Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
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

public class CheckoutSessionPreviewParamsProductCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewParamsProductCart
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
        var model = new CheckoutSessionPreviewParamsProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsProductCart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionPreviewParamsProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsProductCart>(
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
        var model = new CheckoutSessionPreviewParamsProductCart
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
        var model = new CheckoutSessionPreviewParamsProductCart
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
        var model = new CheckoutSessionPreviewParamsProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionPreviewParamsProductCart
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
        var model = new CheckoutSessionPreviewParamsProductCart
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
        var model = new CheckoutSessionPreviewParamsProductCart
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
        };

        CheckoutSessionPreviewParamsProductCart copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionPreviewParamsBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewParamsBillingAddress
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
        var model = new CheckoutSessionPreviewParamsBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionPreviewParamsBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsBillingAddress>(
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
        var model = new CheckoutSessionPreviewParamsBillingAddress
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
        var model = new CheckoutSessionPreviewParamsBillingAddress { Country = CountryCode.Af };

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
        var model = new CheckoutSessionPreviewParamsBillingAddress { Country = CountryCode.Af };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionPreviewParamsBillingAddress
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
        var model = new CheckoutSessionPreviewParamsBillingAddress
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
        var model = new CheckoutSessionPreviewParamsBillingAddress
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        CheckoutSessionPreviewParamsBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionPreviewParamsCustomFieldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        ApiEnum<string, CheckoutSessionPreviewParamsCustomFieldFieldType> expectedFieldType =
            CheckoutSessionPreviewParamsCustomFieldFieldType.Text;
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsCustomField>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsCustomField>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CheckoutSessionPreviewParamsCustomFieldFieldType> expectedFieldType =
            CheckoutSessionPreviewParamsCustomFieldFieldType.Text;
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
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
        var model = new CheckoutSessionPreviewParamsCustomField
        {
            FieldType = CheckoutSessionPreviewParamsCustomFieldFieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        CheckoutSessionPreviewParamsCustomField copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionPreviewParamsCustomFieldFieldTypeTest : TestBase
{
    [Theory]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Text)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Number)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Email)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Url)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Phone)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Date)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Datetime)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Dropdown)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Boolean)]
    public void Validation_Works(CheckoutSessionPreviewParamsCustomFieldFieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionPreviewParamsCustomFieldFieldType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionPreviewParamsCustomFieldFieldType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Text)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Number)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Email)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Url)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Phone)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Date)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Datetime)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Dropdown)]
    [InlineData(CheckoutSessionPreviewParamsCustomFieldFieldType.Boolean)]
    public void SerializationRoundtrip_Works(
        CheckoutSessionPreviewParamsCustomFieldFieldType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionPreviewParamsCustomFieldFieldType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionPreviewParamsCustomFieldFieldType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionPreviewParamsCustomFieldFieldType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionPreviewParamsCustomFieldFieldType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutSessionPreviewParamsCustomizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
        };

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, CheckoutSessionPreviewParamsCustomizationTheme> expectedTheme =
            CheckoutSessionPreviewParamsCustomizationTheme.Dark;

        Assert.Equal(expectedForceLanguage, model.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, model.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, model.ShowOrderDetails);
        Assert.Equal(expectedTheme, model.Theme);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsCustomization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsCustomization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, CheckoutSessionPreviewParamsCustomizationTheme> expectedTheme =
            CheckoutSessionPreviewParamsCustomizationTheme.Dark;

        Assert.Equal(expectedForceLanguage, deserialized.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, deserialized.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, deserialized.ShowOrderDetails);
        Assert.Equal(expectedTheme, deserialized.Theme);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",
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
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",

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
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",

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
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
        };

        Assert.Null(model.ForceLanguage);
        Assert.False(model.RawData.ContainsKey("force_language"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,

            ForceLanguage = null,
        };

        Assert.Null(model.ForceLanguage);
        Assert.True(model.RawData.ContainsKey("force_language"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,

            ForceLanguage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckoutSessionPreviewParamsCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionPreviewParamsCustomizationTheme.Dark,
        };

        CheckoutSessionPreviewParamsCustomization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionPreviewParamsCustomizationThemeTest : TestBase
{
    [Theory]
    [InlineData(CheckoutSessionPreviewParamsCustomizationTheme.Dark)]
    [InlineData(CheckoutSessionPreviewParamsCustomizationTheme.Light)]
    [InlineData(CheckoutSessionPreviewParamsCustomizationTheme.System)]
    public void Validation_Works(CheckoutSessionPreviewParamsCustomizationTheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionPreviewParamsCustomizationTheme> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionPreviewParamsCustomizationTheme>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckoutSessionPreviewParamsCustomizationTheme.Dark)]
    [InlineData(CheckoutSessionPreviewParamsCustomizationTheme.Light)]
    [InlineData(CheckoutSessionPreviewParamsCustomizationTheme.System)]
    public void SerializationRoundtrip_Works(
        CheckoutSessionPreviewParamsCustomizationTheme rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutSessionPreviewParamsCustomizationTheme> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionPreviewParamsCustomizationTheme>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionPreviewParamsCustomizationTheme>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckoutSessionPreviewParamsCustomizationTheme>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutSessionPreviewParamsFeatureFlagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewParamsFeatureFlags
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
        var model = new CheckoutSessionPreviewParamsFeatureFlags
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsFeatureFlags>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionPreviewParamsFeatureFlags
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsFeatureFlags>(
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
        var model = new CheckoutSessionPreviewParamsFeatureFlags
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
        var model = new CheckoutSessionPreviewParamsFeatureFlags { };

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
        var model = new CheckoutSessionPreviewParamsFeatureFlags { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CheckoutSessionPreviewParamsFeatureFlags
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
        var model = new CheckoutSessionPreviewParamsFeatureFlags
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
        var model = new CheckoutSessionPreviewParamsFeatureFlags
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

        CheckoutSessionPreviewParamsFeatureFlags copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutSessionPreviewParamsSubscriptionDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewParamsSubscriptionData
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
        var model = new CheckoutSessionPreviewParamsSubscriptionData
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsSubscriptionData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionPreviewParamsSubscriptionData
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewParamsSubscriptionData>(
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
        var model = new CheckoutSessionPreviewParamsSubscriptionData
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
        var model = new CheckoutSessionPreviewParamsSubscriptionData { };

        Assert.Null(model.OnDemand);
        Assert.False(model.RawData.ContainsKey("on_demand"));
        Assert.Null(model.TrialPeriodDays);
        Assert.False(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionPreviewParamsSubscriptionData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionPreviewParamsSubscriptionData
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
        var model = new CheckoutSessionPreviewParamsSubscriptionData
        {
            OnDemand = null,
            TrialPeriodDays = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckoutSessionPreviewParamsSubscriptionData
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

        CheckoutSessionPreviewParamsSubscriptionData copied = new(model);

        Assert.Equal(model, copied);
    }
}
