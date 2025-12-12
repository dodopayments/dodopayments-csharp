using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class LicenseKeyServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var licenseKey = await this.client.LicenseKeys.Retrieve(
            "lic_123",
            new(),
            TestContext.Current.CancellationToken
        );
        licenseKey.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var licenseKey = await this.client.LicenseKeys.Update(
            "lic_123",
            new(),
            TestContext.Current.CancellationToken
        );
        licenseKey.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.LicenseKeys.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
