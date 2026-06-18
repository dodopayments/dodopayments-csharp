using System;
using DodoPayments.Client.Models.CreditEntitlements;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CreditEntitlementDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditEntitlementDeleteParams { ID = "cde_ztxm5XJsKxWucRWA3rjdM" };

        string expectedID = "cde_ztxm5XJsKxWucRWA3rjdM";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CreditEntitlementDeleteParams parameters = new() { ID = "cde_ztxm5XJsKxWucRWA3rjdM" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/credit-entitlements/cde_ztxm5XJsKxWucRWA3rjdM"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditEntitlementDeleteParams { ID = "cde_ztxm5XJsKxWucRWA3rjdM" };

        CreditEntitlementDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
