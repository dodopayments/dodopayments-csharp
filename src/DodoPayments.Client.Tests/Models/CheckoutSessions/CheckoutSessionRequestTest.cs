using System.Collections.Generic;
using DodoPayments.Client.Core;
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
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Credit],
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
            Customer = new AttachExistingCustomer("customer_id"),
            Customization = new()
            {
                ForceLanguage = "force_language",
                ShowOnDemandTag = true,
                ShowOrderDetails = true,
                Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
            },
            Force3DS = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ReturnURL = "return_url",
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

        List<ProductCartModel> expectedProductCart =
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
            PaymentMethodTypes.Credit,
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
        CustomerRequest expectedCustomer = new AttachExistingCustomer("customer_id");
        CheckoutSessionRequestCustomization expectedCustomization = new()
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = CheckoutSessionRequestCustomizationTheme.Dark,
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
        };
        bool expectedForce3DS = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedReturnURL = "return_url";
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
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedCustomization, model.Customization);
        Assert.Equal(expectedDiscountCode, model.DiscountCode);
        Assert.Equal(expectedFeatureFlags, model.FeatureFlags);
        Assert.Equal(expectedForce3DS, model.Force3DS);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReturnURL, model.ReturnURL);
        Assert.Equal(expectedShowSavedPaymentMethods, model.ShowSavedPaymentMethods);
        Assert.Equal(expectedSubscriptionData, model.SubscriptionData);
    }
}

public class ProductCartModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCartModel
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
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedAmount, model.Amount);
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
        };

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, CheckoutSessionRequestCustomizationTheme> expectedTheme =
            CheckoutSessionRequestCustomizationTheme.Dark;

        Assert.Equal(expectedForceLanguage, model.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, model.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, model.ShowOrderDetails);
        Assert.Equal(expectedTheme, model.Theme);
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
}
