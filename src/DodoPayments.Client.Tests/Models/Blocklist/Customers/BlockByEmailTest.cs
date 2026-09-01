using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class BlockByEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BlockByEmail { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BlockByEmail { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockByEmail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BlockByEmail { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockByEmail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BlockByEmail { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BlockByEmail { Email = "email" };

        BlockByEmail copied = new(model);

        Assert.Equal(model, copied);
    }
}
