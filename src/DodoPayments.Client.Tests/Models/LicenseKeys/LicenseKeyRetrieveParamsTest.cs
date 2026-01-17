using System;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Tests.Models.LicenseKeys;

public class LicenseKeyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyRetrieveParams { ID = "lic_123" };

        string expectedID = "lic_123";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseKeyRetrieveParams parameters = new() { ID = "lic_123" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/license_keys/lic_123"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseKeyRetrieveParams { ID = "lic_123" };

        LicenseKeyRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
