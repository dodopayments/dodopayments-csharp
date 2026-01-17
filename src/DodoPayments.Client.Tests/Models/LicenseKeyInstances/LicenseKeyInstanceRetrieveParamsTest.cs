using System;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Tests.Models.LicenseKeyInstances;

public class LicenseKeyInstanceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyInstanceRetrieveParams { ID = "lki_123" };

        string expectedID = "lki_123";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseKeyInstanceRetrieveParams parameters = new() { ID = "lki_123" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/license_key_instances/lki_123"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseKeyInstanceRetrieveParams { ID = "lki_123" };

        LicenseKeyInstanceRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
