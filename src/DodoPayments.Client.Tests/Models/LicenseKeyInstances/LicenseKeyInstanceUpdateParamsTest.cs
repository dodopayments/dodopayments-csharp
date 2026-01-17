using System;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Tests.Models.LicenseKeyInstances;

public class LicenseKeyInstanceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyInstanceUpdateParams { ID = "lki_123", Name = "name" };

        string expectedID = "lki_123";
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseKeyInstanceUpdateParams parameters = new() { ID = "lki_123", Name = "name" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/license_key_instances/lki_123"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseKeyInstanceUpdateParams { ID = "lki_123", Name = "name" };

        LicenseKeyInstanceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
