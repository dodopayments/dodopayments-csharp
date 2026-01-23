using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerPortalSessionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerPortalSession { Link = "link" };

        string expectedLink = "link";

        Assert.Equal(expectedLink, model.Link);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerPortalSession { Link = "link" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerPortalSession>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerPortalSession { Link = "link" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerPortalSession>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLink = "link";

        Assert.Equal(expectedLink, deserialized.Link);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerPortalSession { Link = "link" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerPortalSession { Link = "link" };

        CustomerPortalSession copied = new(model);

        Assert.Equal(model, copied);
    }
}
