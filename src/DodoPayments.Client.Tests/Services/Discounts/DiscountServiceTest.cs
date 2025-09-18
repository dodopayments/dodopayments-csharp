using System.Threading.Tasks;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Services.Discounts;

public class DiscountServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var discount = await this.client.Discounts.Create(
            new() { Amount = 0, Type = DiscountType.Percentage }
        );
        discount.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var discount = await this.client.Discounts.Retrieve(new() { DiscountID = "discount_id" });
        discount.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var discount = await this.client.Discounts.Update(new() { DiscountID = "discount_id" });
        discount.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Discounts.List();
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Discounts.Delete(new() { DiscountID = "discount_id" });
    }
}
