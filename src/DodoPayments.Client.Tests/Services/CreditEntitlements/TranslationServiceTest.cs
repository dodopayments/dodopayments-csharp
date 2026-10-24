using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Services.CreditEntitlements;

public class TranslationServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var creditEntitlementTranslation = await this.client.CreditEntitlements.Translations.Update(
            Locale.Ar,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        creditEntitlementTranslation.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var creditEntitlementTranslationsListResponse =
            await this.client.CreditEntitlements.Translations.List(
                "id",
                new(),
                TestContext.Current.CancellationToken
            );
        creditEntitlementTranslationsListResponse.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.CreditEntitlements.Translations.Delete(
            Locale.Ar,
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
