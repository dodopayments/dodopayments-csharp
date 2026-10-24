using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Services.Addons;

public class TranslationServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var translation = await this.client.Addons.Translations.Update(
            Locale.Ar,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        translation.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var translationsListResponse = await this.client.Addons.Translations.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        translationsListResponse.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Addons.Translations.Delete(
            Locale.Ar,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
