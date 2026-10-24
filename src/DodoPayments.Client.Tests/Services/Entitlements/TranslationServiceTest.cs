using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Services.Entitlements;

public class TranslationServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var entitlementTranslation = await this.client.Entitlements.Translations.Update(
            Locale.Ar,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        entitlementTranslation.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var entitlementTranslationsListResponse = await this.client.Entitlements.Translations.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        entitlementTranslationsListResponse.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Entitlements.Translations.Delete(
            Locale.Ar,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
