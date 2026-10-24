using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class CreateNewCustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,
        };

        string expectedEmail = "email";
        string expectedName = "name";
        bool expectedCreateNewCustomerValue = true;
        string expectedPhoneNumber = "phone_number";
        ApiEnum<string, Locale> expectedPreferredLocale = Locale.Ar;

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCreateNewCustomerValue, model.CreateNewCustomerValue);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPreferredLocale, model.PreferredLocale);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateNewCustomer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateNewCustomer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "email";
        string expectedName = "name";
        bool expectedCreateNewCustomerValue = true;
        string expectedPhoneNumber = "phone_number";
        ApiEnum<string, Locale> expectedPreferredLocale = Locale.Ar;

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedCreateNewCustomerValue, deserialized.CreateNewCustomerValue);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPreferredLocale, deserialized.PreferredLocale);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,
        };

        Assert.Null(model.CreateNewCustomerValue);
        Assert.False(model.RawData.ContainsKey("create_new_customer"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,

            // Null should be interpreted as omitted for these properties
            CreateNewCustomerValue = null,
        };

        Assert.Null(model.CreateNewCustomerValue);
        Assert.False(model.RawData.ContainsKey("create_new_customer"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,

            // Null should be interpreted as omitted for these properties
            CreateNewCustomerValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,
        };

        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PreferredLocale);
        Assert.False(model.RawData.ContainsKey("preferred_locale"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,

            PhoneNumber = null,
            PreferredLocale = null,
        };

        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PreferredLocale);
        Assert.True(model.RawData.ContainsKey("preferred_locale"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,

            PhoneNumber = null,
            PreferredLocale = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomerValue = true,
            PhoneNumber = "phone_number",
            PreferredLocale = Locale.Ar,
        };

        CreateNewCustomer copied = new(model);

        Assert.Equal(model, copied);
    }
}
