using System.Text.Json;
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
        };

        string expectedEmail = "email";
        string expectedName = "name";
        bool expectedCreateNewCustomerValue = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCreateNewCustomerValue, model.CreateNewCustomerValue);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreateNewCustomer>(json);

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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreateNewCustomer>(element);
        Assert.NotNull(deserialized);

        string expectedEmail = "email";
        string expectedName = "name";
        bool expectedCreateNewCustomerValue = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedCreateNewCustomerValue, deserialized.CreateNewCustomerValue);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
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
        };

        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
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
        };

        model.Validate();
    }
}
