using System.Threading.Tasks;

namespace Dodopayments.Tests.Services.LicenseKeyInstances;

public class LicenseKeyInstanceServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var licenseKeyInstance = await this.client.LicenseKeyInstances.Retrieve(
            new() { ID = "id" }
        );
        licenseKeyInstance.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var licenseKeyInstance = await this.client.LicenseKeyInstances.Update(
            new() { ID = "id", Name = "name" }
        );
        licenseKeyInstance.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.LicenseKeyInstances.List(new());
        page.Validate();
    }
}
