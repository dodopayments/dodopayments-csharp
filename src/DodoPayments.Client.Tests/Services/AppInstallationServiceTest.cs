using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class AppInstallationServiceTest : TestBase
{
    [Fact]
    public async Task RetrieveSettings_Works()
    {
        var response = await this.client.AppInstallation.RetrieveSettings(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
