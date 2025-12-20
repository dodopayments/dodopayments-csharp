using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Tests.Models.Licenses;

public class LicenseActivateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseActivateParams { LicenseKey = "license_key", Name = "name" };

        string expectedLicenseKey = "license_key";
        string expectedName = "name";

        Assert.Equal(expectedLicenseKey, parameters.LicenseKey);
        Assert.Equal(expectedName, parameters.Name);
    }
}
