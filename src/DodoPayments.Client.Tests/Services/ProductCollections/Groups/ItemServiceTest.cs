using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.ProductCollections.Groups;

public class ItemServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var productCollectionProducts = await this.client.ProductCollections.Groups.Items.Create(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { ID = "id", Products = [new() { ProductID = "product_id", Status = true }] },
            TestContext.Current.CancellationToken
        );
        foreach (var item in productCollectionProducts)
        {
            item.Validate();
        }
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.ProductCollections.Groups.Items.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new()
            {
                ID = "id",
                GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Status = true,
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.ProductCollections.Groups.Items.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { ID = "id", GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
    }
}
