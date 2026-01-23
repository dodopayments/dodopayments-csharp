using System.Text.Json;
using DodoPayments.Client.Core;
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachExistingCustomer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachExistingCustomer { CustomerID = "customer_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachExistingCustomer>(
            element,
            ModelBase.SerializerOptions
        );
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttachExistingCustomer { CustomerID = "customer_id" };

        AttachExistingCustomer copied = new(model);

        Assert.Equal(model, copied);
    }
}
