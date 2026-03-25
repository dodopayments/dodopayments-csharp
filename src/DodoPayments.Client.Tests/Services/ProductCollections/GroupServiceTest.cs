using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.ProductCollections;

public class GroupServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var group = await this.client.ProductCollections.Groups.Create(
            "id",
            new() { Products = [new() { ProductID = "product_id", Status = true }] },
            TestContext.Current.CancellationToken
        );
        group.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.ProductCollections.Groups.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.ProductCollections.Groups.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
