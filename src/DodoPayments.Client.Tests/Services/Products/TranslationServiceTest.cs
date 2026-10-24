using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Services.Products;

public class TranslationServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var translation = await this.client.Products.Translations.Update(
            Locale.Ar,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        translation.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var translationsListResponse = await this.client.Products.Translations.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        translationsListResponse.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Products.Translations.Delete(
            Locale.Ar,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
