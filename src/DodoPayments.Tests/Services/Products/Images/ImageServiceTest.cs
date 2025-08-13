using System.Threading.Tasks;

namespace DodoPayments.Tests.Services.Products.Images;

public class ImageServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var image = await this.client.Products.Images.Update(new() { ID = "id" });
        image.Validate();
    }
}
