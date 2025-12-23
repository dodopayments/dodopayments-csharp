using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Products;

public class ShortLinkServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var shortLink = await this.client.Products.ShortLinks.Create(
            "id",
            new() { Slug = "slug" },
            TestContext.Current.CancellationToken
        );
        shortLink.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Products.ShortLinks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
