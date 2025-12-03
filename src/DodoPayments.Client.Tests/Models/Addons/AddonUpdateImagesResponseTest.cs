using System.Text.Json;
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
        var model = new AddonUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AddonUpdateImagesResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AddonUpdateImagesResponse>(json);
        Assert.NotNull(deserialized);

        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedURL = "url";

        Assert.Equal(expectedImageID, deserialized.ImageID);
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonUpdateImagesResponse
        {
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            URL = "url",
        };

        model.Validate();
    }
}
