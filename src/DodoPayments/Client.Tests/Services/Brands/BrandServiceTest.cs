using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Brands;

public class BrandServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var brand = await this.client.Brands.Create(new());
        brand.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var brand = await this.client.Brands.Retrieve(new() { ID = "id" });
        brand.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var brand = await this.client.Brands.Update(new() { ID = "id" });
        brand.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var brands = await this.client.Brands.List(new());
        brands.Validate();
    }

    [Fact]
    public async Task UpdateImages_Works()
    {
        var response = await this.client.Brands.UpdateImages(new() { ID = "id" });
        response.Validate();
    }
}
