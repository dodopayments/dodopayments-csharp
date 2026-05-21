using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class ProductCollectionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var productCollection = await this.client.ProductCollections.Create(
            new()
            {
                Groups =
                [
                    new()
                    {
                        Products = [new() { ProductID = "product_id", Status = true }],
                        GroupName = "group_name",
                        Status = true,
                    },
                ],
                Name = "name",
            },
            TestContext.Current.CancellationToken
        );
        productCollection.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var productCollection = await this.client.ProductCollections.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        productCollection.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.ProductCollections.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.ProductCollections.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.ProductCollections.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Unarchive_Works()
    {
        var response = await this.client.ProductCollections.Unarchive(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task UpdateImages_Works()
    {
        var response = await this.client.ProductCollections.UpdateImages(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
