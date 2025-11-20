using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class LicenseKeyInstanceServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var licenseKeyInstance = await this.client.LicenseKeyInstances.Retrieve("lki_123");
        licenseKeyInstance.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var licenseKeyInstance = await this.client.LicenseKeyInstances.Update(
            "lki_123",
            new() { Name = "name" }
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
