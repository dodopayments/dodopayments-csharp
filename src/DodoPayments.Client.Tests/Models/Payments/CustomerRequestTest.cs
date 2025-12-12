using System.Text.Json;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class CustomerRequestTest : TestBase
{
    [Fact]
    public void attach_existing_customerValidation_Works()
    {
        CustomerRequest value = new(new AttachExistingCustomer("customer_id"));
        value.Validate();
    }

    [Fact]
    public void new_customerValidation_Works()
    {
        CustomerRequest value = new(
            new NewCustomer()
            {
                Email = "email",
                Name = "name",
                PhoneNumber = "phone_number",
            }
        );
        value.Validate();
    }

    [Fact]
    public void attach_existing_customerSerializationRoundtrip_Works()
    {
        CustomerRequest value = new(new AttachExistingCustomer("customer_id"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerRequest>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void new_customerSerializationRoundtrip_Works()
    {
        CustomerRequest value = new(
            new NewCustomer()
            {
                Email = "email",
                Name = "name",
                PhoneNumber = "phone_number",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CustomerRequest>(json);

        Assert.Equal(value, deserialized);
    }
}
