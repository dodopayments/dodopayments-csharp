using System;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementRetrieveParams { ID = "ent_jt7jcvI79Xh8eehqgWdcm" };

        string expectedID = "ent_jt7jcvI79Xh8eehqgWdcm";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementRetrieveParams parameters = new() { ID = "ent_jt7jcvI79Xh8eehqgWdcm" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/entitlements/ent_jt7jcvI79Xh8eehqgWdcm"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementRetrieveParams { ID = "ent_jt7jcvI79Xh8eehqgWdcm" };

        EntitlementRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
