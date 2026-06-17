using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class LicenseKeyInstanceServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var licenseKeyInstance = await this.client.LicenseKeyInstances.Retrieve(
            "lki_EeWORStkMc7z0KycI31VS",
            new(),
            TestContext.Current.CancellationToken
        );
        licenseKeyInstance.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var licenseKeyInstance = await this.client.LicenseKeyInstances.Update(
            "lki_EeWORStkMc7z0KycI31VS",
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        licenseKeyInstance.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.LicenseKeyInstances.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
