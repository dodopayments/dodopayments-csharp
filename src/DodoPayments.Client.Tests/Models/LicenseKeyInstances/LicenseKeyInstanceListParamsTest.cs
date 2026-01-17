using System;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Tests.Models.LicenseKeyInstances;

public class LicenseKeyInstanceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyInstanceListParams
        {
            LicenseKeyID = "license_key_id",
            PageNumber = 0,
            PageSize = 0,
        };

        string expectedLicenseKeyID = "license_key_id";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedLicenseKeyID, parameters.LicenseKeyID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseKeyInstanceListParams { };

        Assert.Null(parameters.LicenseKeyID);
        Assert.False(parameters.RawQueryData.ContainsKey("license_key_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LicenseKeyInstanceListParams
        {
            LicenseKeyID = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.LicenseKeyID);
        Assert.True(parameters.RawQueryData.ContainsKey("license_key_id"));
        Assert.Null(parameters.PageNumber);
        Assert.True(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        LicenseKeyInstanceListParams parameters = new()
        {
            LicenseKeyID = "license_key_id",
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/license_key_instances?license_key_id=license_key_id&page_number=0&page_size=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseKeyInstanceListParams
        {
            LicenseKeyID = "license_key_id",
            PageNumber = 0,
            PageSize = 0,
        };

        LicenseKeyInstanceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
