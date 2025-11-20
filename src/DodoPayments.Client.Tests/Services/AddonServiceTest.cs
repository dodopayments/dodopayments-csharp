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
            }
        );
        addonResponse.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var addonResponse = await this.client.Addons.Retrieve("id");
        addonResponse.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var addonResponse = await this.client.Addons.Update("id");
        addonResponse.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Addons.List();
        page.Validate();
    }

    [Fact]
    public async Task UpdateImages_Works()
    {
        var response = await this.client.Addons.UpdateImages("id");
        response.Validate();
    }
}
