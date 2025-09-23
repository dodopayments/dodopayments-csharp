using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.LicenseKeys;

public class LicenseKeyServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var licenseKey = await this.client.LicenseKeys.Retrieve(new() { ID = "lic_123" });
        licenseKey.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var licenseKey = await this.client.LicenseKeys.Update(new() { ID = "lic_123" });
        licenseKey.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.LicenseKeys.List();
        page.Validate();
    }
}
