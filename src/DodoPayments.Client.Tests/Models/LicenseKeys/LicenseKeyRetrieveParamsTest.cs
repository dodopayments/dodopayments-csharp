using System;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Tests.Models.LicenseKeys;

public class LicenseKeyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyRetrieveParams { ID = "lic_7namTC0VcgrnzrF3GTSwB" };

        string expectedID = "lic_7namTC0VcgrnzrF3GTSwB";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseKeyRetrieveParams parameters = new() { ID = "lic_7namTC0VcgrnzrF3GTSwB" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/license_keys/lic_7namTC0VcgrnzrF3GTSwB"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseKeyRetrieveParams { ID = "lic_7namTC0VcgrnzrF3GTSwB" };

        LicenseKeyRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
