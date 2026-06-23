using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Services.Products;

public class LocalizedPriceServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var localizedPrice = await this.client.Products.LocalizedPrices.Create(
            "pdt_R8AWMPiV8RyJElcCKvAID",
            new() { Amount = 0, Currency = Currency.Aed },
            TestContext.Current.CancellationToken
        );
        localizedPrice.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var localizedPrice = await this.client.Products.LocalizedPrices.Retrieve(
            "lcp_3aOOT7ebrzBOV41yL2V6s",
            new() { ProductID = "pdt_R8AWMPiV8RyJElcCKvAID" },
            TestContext.Current.CancellationToken
        );
        localizedPrice.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var localizedPrice = await this.client.Products.LocalizedPrices.Update(
            "lcp_3aOOT7ebrzBOV41yL2V6s",
            new() { ProductID = "pdt_R8AWMPiV8RyJElcCKvAID" },
            TestContext.Current.CancellationToken
        );
        localizedPrice.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var listLocalizedPricesResponse = await this.client.Products.LocalizedPrices.List(
            "pdt_R8AWMPiV8RyJElcCKvAID",
            new(),
            TestContext.Current.CancellationToken
        );
        listLocalizedPricesResponse.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        await this.client.Products.LocalizedPrices.Archive(
            "lcp_3aOOT7ebrzBOV41yL2V6s",
            new() { ProductID = "pdt_R8AWMPiV8RyJElcCKvAID" },
            TestContext.Current.CancellationToken
        );
    }
}
