using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class MiscServiceTest : TestBase
{
    [Fact]
    public async Task ListLocales_Works()
    {
        var localeInfos = await this.client.Misc.ListLocales(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in localeInfos)
        {
            item.Validate();
        }
    }

    [Fact]
    public async Task ListSupportedCountries_Works()
    {
        var countryCodes = await this.client.Misc.ListSupportedCountries(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in countryCodes)
        {
            item.Validate();
        }
    }
}
