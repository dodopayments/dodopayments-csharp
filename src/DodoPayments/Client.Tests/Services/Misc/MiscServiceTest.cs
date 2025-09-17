using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Misc;

public class MiscServiceTest : TestBase
{
    [Fact]
    public async Task ListSupportedCountries_Works()
    {
        var countryCodes = await this.client.Misc.ListSupportedCountries(new());
        foreach (var item in countryCodes)
        {
            item.Validate();
        }
    }
}
