using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products.PriceProperties;
using DodoPayments.Client.Models.Products.PriceProperties.OneTimePriceProperties;

namespace DodoPayments.Client.Tests.Services.Products;

public class ProductServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var product = await this.client.Products.Create(
            new()
            {
                Price = new(
                    new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        Price = 0,
                        PurchasingPowerParity = true,
                        Type = Type.OneTimePrice,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    }
                ),
                TaxCategory = TaxCategory.DigitalProducts,
            }
        );
        product.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var product = await this.client.Products.Retrieve(new() { ID = "id" });
        product.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Products.Update(new() { ID = "id" });
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Products.List();
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        await this.client.Products.Archive(new() { ID = "id" });
    }

    [Fact]
    public async Task Unarchive_Works()
    {
        await this.client.Products.Unarchive(new() { ID = "id" });
    }

    [Fact]
    public async Task UpdateFiles_Works()
    {
        var response = await this.client.Products.UpdateFiles(
            new() { ID = "id", FileName = "file_name" }
        );
        response.Validate();
    }
}
