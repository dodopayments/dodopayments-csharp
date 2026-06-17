using System;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Tests.Models.Entitlements.Grants;

public class GrantRevokeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GrantRevokeParams
        {
            ID = "ent_jt7jcvI79Xh8eehqgWdcm",
            GrantID = "entg_w0ZCJZgNXuNDdMVzvja6p",
        };

        string expectedID = "ent_jt7jcvI79Xh8eehqgWdcm";
        string expectedGrantID = "entg_w0ZCJZgNXuNDdMVzvja6p";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedGrantID, parameters.GrantID);
    }

    [Fact]
    public void Url_Works()
    {
        GrantRevokeParams parameters = new()
        {
            ID = "ent_jt7jcvI79Xh8eehqgWdcm",
            GrantID = "entg_w0ZCJZgNXuNDdMVzvja6p",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/entitlements/ent_jt7jcvI79Xh8eehqgWdcm/grants/entg_w0ZCJZgNXuNDdMVzvja6p"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GrantRevokeParams
        {
            ID = "ent_jt7jcvI79Xh8eehqgWdcm",
            GrantID = "entg_w0ZCJZgNXuNDdMVzvja6p",
        };

        GrantRevokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
