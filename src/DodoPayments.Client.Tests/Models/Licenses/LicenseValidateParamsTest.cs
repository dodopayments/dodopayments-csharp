using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Tests.Models.Licenses;

public class LicenseValidateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseValidateParams
        {
            LicenseKey = "2b1f8e2d-c41e-4e8f-b2d3-d9fd61c38f43",
            LicenseKeyInstanceID = "lki_123",
        };

        string expectedLicenseKey = "2b1f8e2d-c41e-4e8f-b2d3-d9fd61c38f43";
        string expectedLicenseKeyInstanceID = "lki_123";

        Assert.Equal(expectedLicenseKey, parameters.LicenseKey);
        Assert.Equal(expectedLicenseKeyInstanceID, parameters.LicenseKeyInstanceID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseValidateParams
        {
            LicenseKey = "2b1f8e2d-c41e-4e8f-b2d3-d9fd61c38f43",
        };

        Assert.Null(parameters.LicenseKeyInstanceID);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_instance_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LicenseValidateParams
        {
            LicenseKey = "2b1f8e2d-c41e-4e8f-b2d3-d9fd61c38f43",

            LicenseKeyInstanceID = null,
        };

        Assert.Null(parameters.LicenseKeyInstanceID);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_instance_id"));
    }
}
