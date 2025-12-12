using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Services;

public class ProductServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var product = await this.client.Products.Create(
            new()
            {
                Name = "name",
                Price = new OneTimePrice()
                {
                    Currency = Currency.Aed,
                    Discount = 0,
                    Price = 0,
                    PurchasingPowerParity = true,
                    Type = Type.OneTimePrice,
                    PayWhatYouWant = true,
                    SuggestedPrice = 0,
                    TaxInclusive = true,
                },
                TaxCategory = TaxCategory.DigitalProducts,
            },
            TestContext.Current.CancellationToken
        );
        product.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var product = await this.client.Products.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        product.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Products.Update("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Products.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        await this.client.Products.Archive("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Unarchive_Works()
    {
        await this.client.Products.Unarchive("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task UpdateFiles_Works()
    {
        var response = await this.client.Products.UpdateFiles(
            "id",
            new() { FileName = "file_name" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
