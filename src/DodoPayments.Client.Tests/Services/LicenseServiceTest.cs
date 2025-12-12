using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class LicenseServiceTest : TestBase
{
    [Fact]
    public async Task Activate_Works()
    {
        var response = await this.client.Licenses.Activate(
            new() { LicenseKey = "license_key", Name = "name" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Deactivate_Works()
    {
        await this.client.Licenses.Deactivate(
            new() { LicenseKey = "license_key", LicenseKeyInstanceID = "license_key_instance_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Validate_Works()
    {
        var response = await this.client.Licenses.Validate(
            new() { LicenseKey = "2b1f8e2d-c41e-4e8f-b2d3-d9fd61c38f43" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
