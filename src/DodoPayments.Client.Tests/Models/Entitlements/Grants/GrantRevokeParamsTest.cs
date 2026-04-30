using System;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Tests.Models.Entitlements.Grants;

public class GrantRevokeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GrantRevokeParams { ID = "id", GrantID = "grant_id" };

        string expectedID = "id";
        string expectedGrantID = "grant_id";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedGrantID, parameters.GrantID);
    }

    [Fact]
    public void Url_Works()
    {
        GrantRevokeParams parameters = new() { ID = "id", GrantID = "grant_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/entitlements/id/grants/grant_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GrantRevokeParams { ID = "id", GrantID = "grant_id" };

        GrantRevokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
