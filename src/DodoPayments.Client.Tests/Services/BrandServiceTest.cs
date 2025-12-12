using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class BrandServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var brand = await this.client.Brands.Create(new(), TestContext.Current.CancellationToken);
        brand.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var brand = await this.client.Brands.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        brand.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var brand = await this.client.Brands.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        brand.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var brands = await this.client.Brands.List(new(), TestContext.Current.CancellationToken);
        brands.Validate();
    }

    [Fact]
    public async Task UpdateImages_Works()
    {
        var response = await this.client.Brands.UpdateImages(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
