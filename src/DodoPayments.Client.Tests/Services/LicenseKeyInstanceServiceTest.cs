using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class LicenseKeyInstanceServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var licenseKeyInstance = await this.client.LicenseKeyInstances.Retrieve(
            new() { ID = "lki_123" }
        );
        licenseKeyInstance.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var licenseKeyInstance = await this.client.LicenseKeyInstances.Update(
            new() { ID = "lki_123", Name = "name" }
        );
        licenseKeyInstance.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.LicenseKeyInstances.List();
        page.Validate();
    }
}
