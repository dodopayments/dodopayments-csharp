using System.Threading.Tasks;

namespace Dodopayments.Tests.Services.Misc;

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
