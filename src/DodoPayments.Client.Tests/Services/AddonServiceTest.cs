using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Services;

public class AddonServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var addonResponse = await this.client.Addons.Create(
            new()
            {
                Currency = Currency.Aed,
                Name = "name",
                Price = 0,
                TaxCategory = TaxCategory.DigitalProducts,
            },
            TestContext.Current.CancellationToken
        );
        addonResponse.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var addonResponse = await this.client.Addons.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        addonResponse.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var addonResponse = await this.client.Addons.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        addonResponse.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Addons.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task UpdateImages_Works()
    {
        var response = await this.client.Addons.UpdateImages(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
