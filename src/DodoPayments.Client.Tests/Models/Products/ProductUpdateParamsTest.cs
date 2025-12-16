using System.Collections.Generic;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class DigitalProductDeliveryModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalProductDeliveryModel
        {
            ExternalURL = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        string expectedExternalURL = "external_url";
        List<string> expectedFiles = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalURL, model.ExternalURL);
        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedInstructions, model.Instructions);
    }
}
