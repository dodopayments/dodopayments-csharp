using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Tests.Models.Addons;

public class AddonUpdateImagesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedUrl = "url";

        Assert.Equal(expectedImageID, model.ImageID);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonUpdateImagesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonUpdateImagesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedUrl = "url";

        Assert.Equal(expectedImageID, deserialized.ImageID);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        AddonUpdateImagesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
