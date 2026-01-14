using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Tests.Models.Products.Images;

public class ImageUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageUpdateResponse
        {
            Url = "url",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedUrl = "url";
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedImageID, model.ImageID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageUpdateResponse
        {
            Url = "url",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageUpdateResponse
        {
            Url = "url",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "url";
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedImageID, deserialized.ImageID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageUpdateResponse
        {
            Url = "url",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageUpdateResponse { Url = "url" };

        Assert.Null(model.ImageID);
        Assert.False(model.RawData.ContainsKey("image_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageUpdateResponse { Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ImageUpdateResponse
        {
            Url = "url",

            ImageID = null,
        };

        Assert.Null(model.ImageID);
        Assert.True(model.RawData.ContainsKey("image_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageUpdateResponse
        {
            Url = "url",

            ImageID = null,
        };

        model.Validate();
    }
}
