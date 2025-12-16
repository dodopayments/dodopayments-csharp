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
}
