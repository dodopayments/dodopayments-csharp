using System;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Tests.Models.LicenseKeyInstances;

public class LicenseKeyInstanceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyInstanceRetrieveParams { ID = "lki_EeWORStkMc7z0KycI31VS" };

        string expectedID = "lki_EeWORStkMc7z0KycI31VS";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseKeyInstanceRetrieveParams parameters = new() { ID = "lki_EeWORStkMc7z0KycI31VS" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/license_key_instances/lki_EeWORStkMc7z0KycI31VS"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseKeyInstanceRetrieveParams { ID = "lki_EeWORStkMc7z0KycI31VS" };

        LicenseKeyInstanceRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
