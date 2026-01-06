using System;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Tests.Models.Licenses;

public class LicenseDeactivateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseDeactivateParams
        {
            LicenseKey = "license_key",
            LicenseKeyInstanceID = "license_key_instance_id",
        };

        string expectedLicenseKey = "license_key";
        string expectedLicenseKeyInstanceID = "license_key_instance_id";

        Assert.Equal(expectedLicenseKey, parameters.LicenseKey);
        Assert.Equal(expectedLicenseKeyInstanceID, parameters.LicenseKeyInstanceID);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseDeactivateParams parameters = new()
        {
            LicenseKey = "license_key",
            LicenseKeyInstanceID = "license_key_instance_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/licenses/deactivate"), url);
    }
}
