using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductUpdateParamsDigitalProductDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUpdateParamsDigitalProductDelivery
        {
            ExternalURL = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        string expectedExternalURL = "external_url";
        List<string> expectedFiles = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalURL, model.ExternalURL);
        Assert.NotNull(model.Files);
        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedInstructions, model.Instructions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductUpdateParamsDigitalProductDelivery
        {
            ExternalURL = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProductUpdateParamsDigitalProductDelivery>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductUpdateParamsDigitalProductDelivery
        {
            ExternalURL = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProductUpdateParamsDigitalProductDelivery>(
            element
        );
        Assert.NotNull(deserialized);

        string expectedExternalURL = "external_url";
        List<string> expectedFiles = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalURL, deserialized.ExternalURL);
        Assert.NotNull(deserialized.Files);
        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
        Assert.Equal(expectedInstructions, deserialized.Instructions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductUpdateParamsDigitalProductDelivery
        {
            ExternalURL = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductUpdateParamsDigitalProductDelivery { };

        Assert.Null(model.ExternalURL);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Files);
        Assert.False(model.RawData.ContainsKey("files"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductUpdateParamsDigitalProductDelivery { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductUpdateParamsDigitalProductDelivery
        {
            ExternalURL = null,
            Files = null,
            Instructions = null,
        };

        Assert.Null(model.ExternalURL);
        Assert.True(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Files);
        Assert.True(model.RawData.ContainsKey("files"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductUpdateParamsDigitalProductDelivery
        {
            ExternalURL = null,
            Files = null,
            Instructions = null,
        };

        model.Validate();
    }
}
