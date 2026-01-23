using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class AddonCartResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonCartResponseItem { AddonID = "addon_id", Quantity = 0 };

        string expectedAddonID = "addon_id";
        int expectedQuantity = 0;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonCartResponseItem { AddonID = "addon_id", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonCartResponseItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonCartResponseItem { AddonID = "addon_id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonCartResponseItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addon_id";
        int expectedQuantity = 0;

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonCartResponseItem { AddonID = "addon_id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonCartResponseItem { AddonID = "addon_id", Quantity = 0 };

        AddonCartResponseItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
