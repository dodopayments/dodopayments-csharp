using System;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Tests.Models.Entitlements.Grants;

public class GrantFulfillLicenseKeyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GrantFulfillLicenseKeyParams
        {
            GrantID = "entg_w0ZCJZgNXuNDdMVzvja6p",
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedGrantID = "entg_w0ZCJZgNXuNDdMVzvja6p";
        string expectedKey = "key";
        int expectedActivationsLimit = 0;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedGrantID, parameters.GrantID);
        Assert.Equal(expectedKey, parameters.Key);
        Assert.Equal(expectedActivationsLimit, parameters.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GrantFulfillLicenseKeyParams
        {
            GrantID = "entg_w0ZCJZgNXuNDdMVzvja6p",
            Key = "key",
        };

        Assert.Null(parameters.ActivationsLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("activations_limit"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GrantFulfillLicenseKeyParams
        {
            GrantID = "entg_w0ZCJZgNXuNDdMVzvja6p",
            Key = "key",

            ActivationsLimit = null,
            ExpiresAt = null,
        };

        Assert.Null(parameters.ActivationsLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("activations_limit"));
        Assert.Null(parameters.ExpiresAt);
        Assert.True(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void Url_Works()
    {
        GrantFulfillLicenseKeyParams parameters = new()
        {
            GrantID = "entg_w0ZCJZgNXuNDdMVzvja6p",
            Key = "key",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/grants/entg_w0ZCJZgNXuNDdMVzvja6p/license-key"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GrantFulfillLicenseKeyParams
        {
            GrantID = "entg_w0ZCJZgNXuNDdMVzvja6p",
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        GrantFulfillLicenseKeyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
