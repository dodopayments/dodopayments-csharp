using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class AttachProductEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachProductEntitlement { EntitlementID = "entitlement_id" };

        string expectedEntitlementID = "entitlement_id";

        Assert.Equal(expectedEntitlementID, model.EntitlementID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttachProductEntitlement { EntitlementID = "entitlement_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachProductEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachProductEntitlement { EntitlementID = "entitlement_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachProductEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEntitlementID = "entitlement_id";

        Assert.Equal(expectedEntitlementID, deserialized.EntitlementID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttachProductEntitlement { EntitlementID = "entitlement_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttachProductEntitlement { EntitlementID = "entitlement_id" };

        AttachProductEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}
