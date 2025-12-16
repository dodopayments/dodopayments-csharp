using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductUpdateFilesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUpdateFilesResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            URL = "url",
        };

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedURL = "url";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedURL, model.URL);
    }
}
