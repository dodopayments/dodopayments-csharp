using System.Threading.Tasks;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Services;

public class DiscountServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var discount = await this.client.Discounts.Create(
            new() { Amount = 0, Type = DiscountType.Percentage },
            TestContext.Current.CancellationToken
        );
        discount.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var discount = await this.client.Discounts.Retrieve(
            "discount_id",
            new(),
            TestContext.Current.CancellationToken
        );
        discount.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var discount = await this.client.Discounts.Update(
            "discount_id",
            new(),
            TestContext.Current.CancellationToken
        );
        discount.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Discounts.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Discounts.Delete(
            "discount_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task RetrieveByCode_Works()
    {
        var discount = await this.client.Discounts.RetrieveByCode(
            "code",
            new(),
            TestContext.Current.CancellationToken
        );
        discount.Validate();
    }
}
