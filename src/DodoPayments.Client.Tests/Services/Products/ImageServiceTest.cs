using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Products;

public class ImageServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var image = await this.client.Products.Images.Update(
            "pdt_R8AWMPiV8RyJElcCKvAID",
            new(),
            TestContext.Current.CancellationToken
        );
        image.Validate();
    }
}
