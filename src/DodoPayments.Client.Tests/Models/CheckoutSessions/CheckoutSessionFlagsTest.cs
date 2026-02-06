using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionFlagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionFlags
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
        var model = new CheckoutSessionFlags
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionFlags>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionFlags
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
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionFlags>(
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
        var model = new CheckoutSessionFlags
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
        var model = new CheckoutSessionFlags { };

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
        var model = new CheckoutSessionFlags { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CheckoutSessionFlags
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
        var model = new CheckoutSessionFlags
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
        var model = new CheckoutSessionFlags
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

        CheckoutSessionFlags copied = new(model);

        Assert.Equal(model, copied);
    }
}
