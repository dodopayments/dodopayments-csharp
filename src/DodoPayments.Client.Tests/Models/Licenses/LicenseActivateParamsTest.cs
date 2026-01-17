using System;
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

    [Fact]
    public void Url_Works()
    {
        LicenseActivateParams parameters = new() { LicenseKey = "license_key", Name = "name" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/licenses/activate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseActivateParams { LicenseKey = "license_key", Name = "name" };

        LicenseActivateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
