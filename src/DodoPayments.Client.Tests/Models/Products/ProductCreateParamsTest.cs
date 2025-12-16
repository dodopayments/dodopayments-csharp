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
}
