using System.Text.Json;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandUpdateImagesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            URL = "url",
        };

        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedURL = "url";

        Assert.Equal(expectedImageID, model.ImageID);
        Assert.Equal(expectedURL, model.URL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandUpdateImagesResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            URL = "url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandUpdateImagesResponse>(element);
        Assert.NotNull(deserialized);

        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedURL = "url";

        Assert.Equal(expectedImageID, deserialized.ImageID);
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            URL = "url",
        };

        model.Validate();
    }
}
