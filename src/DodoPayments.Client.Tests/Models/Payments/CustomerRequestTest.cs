using System.Text.Json;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class CustomerRequestTest : TestBase
{
    [Fact]
    public void AttachExistingCustomerValidationWorks()
    {
        CustomerRequest value = new AttachExistingCustomer("customer_id");
        value.Validate();
    }

    [Fact]
    public void NewCustomerValidationWorks()
    {
        CustomerRequest value = new NewCustomer()
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",
        };
        value.Validate();
    }

    [Fact]
    public void AttachExistingCustomerSerializationRoundtripWorks()
    {
        CustomerRequest value = new AttachExistingCustomer("customer_id");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerRequest>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewCustomerSerializationRoundtripWorks()
    {
        CustomerRequest value = new NewCustomer()
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerRequest>(element);

        Assert.Equal(value, deserialized);
    }
}
