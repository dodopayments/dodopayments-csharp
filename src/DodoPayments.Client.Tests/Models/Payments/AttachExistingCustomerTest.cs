using System.Text.Json;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class AttachExistingCustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachExistingCustomer { CustomerID = "customer_id" };

        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCustomerID, model.CustomerID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttachExistingCustomer { CustomerID = "customer_id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AttachExistingCustomer>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachExistingCustomer { CustomerID = "customer_id" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AttachExistingCustomer>(element);
        Assert.NotNull(deserialized);

        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttachExistingCustomer { CustomerID = "customer_id" };

        model.Validate();
    }
}
