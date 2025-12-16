using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Tests.Models.Products.Images;

public class ImageUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageUpdateResponse
        {
            URL = "url",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedURL = "url";
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedImageID, model.ImageID);
    }
}
