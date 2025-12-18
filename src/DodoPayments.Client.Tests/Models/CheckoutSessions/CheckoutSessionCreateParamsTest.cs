using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProductCart>(json);

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProductCart>(element);
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(json);

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(element);
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
        };

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, Theme> expectedTheme = Theme.Dark;

        Assert.Equal(expectedForceLanguage, model.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, model.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, model.ShowOrderDetails);
        Assert.Equal(expectedTheme, model.Theme);
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Customization>(json);

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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Customization>(element);
        Assert.NotNull(deserialized);

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, Theme> expectedTheme = Theme.Dark;

        Assert.Equal(expectedForceLanguage, deserialized.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, deserialized.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, deserialized.ShowOrderDetails);
        Assert.Equal(expectedTheme, deserialized.Theme);
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Customization { ForceLanguage = "force_language" };

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
        var model = new Customization { ForceLanguage = "force_language" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customization
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
        var model = new Customization
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
        var model = new Customization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
        };

        Assert.Null(model.ForceLanguage);
        Assert.False(model.RawData.ContainsKey("force_language"));
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
        };

        Assert.Null(model.ForceLanguage);
        Assert.True(model.RawData.ContainsKey("force_language"));
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
        };

        model.Validate();
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FeatureFlags>(json);

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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FeatureFlags>(element);
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
        };

        model.Validate();
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionData>(json);

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionData>(element);
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
}
