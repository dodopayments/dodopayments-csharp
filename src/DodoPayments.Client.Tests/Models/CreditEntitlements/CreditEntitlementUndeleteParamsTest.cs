using System;
using DodoPayments.Client.Models.CreditEntitlements;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CreditEntitlementUndeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditEntitlementUndeleteParams { ID = "cde_ztxm5XJsKxWucRWA3rjdM" };

        string expectedID = "cde_ztxm5XJsKxWucRWA3rjdM";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CreditEntitlementUndeleteParams parameters = new() { ID = "cde_ztxm5XJsKxWucRWA3rjdM" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/credit-entitlements/cde_ztxm5XJsKxWucRWA3rjdM/undelete"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditEntitlementUndeleteParams { ID = "cde_ztxm5XJsKxWucRWA3rjdM" };

        CreditEntitlementUndeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
