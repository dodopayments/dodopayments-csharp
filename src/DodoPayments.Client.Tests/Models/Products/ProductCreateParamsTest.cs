using System.Text.Json;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class DigitalProductDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalProductDelivery
        {
            ExternalURL = "external_url",
            Instructions = "instructions",
        };

        string expectedExternalURL = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalURL, model.ExternalURL);
        Assert.Equal(expectedInstructions, model.Instructions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalProductDelivery
        {
            ExternalURL = "external_url",
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DigitalProductDelivery>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalProductDelivery
        {
            ExternalURL = "external_url",
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DigitalProductDelivery>(json);
        Assert.NotNull(deserialized);

        string expectedExternalURL = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalURL, deserialized.ExternalURL);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalProductDelivery
        {
            ExternalURL = "external_url",
            Instructions = "instructions",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigitalProductDelivery { };

        Assert.Null(model.ExternalURL);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalProductDelivery { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DigitalProductDelivery { ExternalURL = null, Instructions = null };

        Assert.Null(model.ExternalURL);
        Assert.True(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigitalProductDelivery { ExternalURL = null, Instructions = null };

        model.Validate();
    }
}
