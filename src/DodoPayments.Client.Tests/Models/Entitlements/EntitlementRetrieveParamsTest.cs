using System;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/entitlements/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementRetrieveParams { ID = "id" };

        EntitlementRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
