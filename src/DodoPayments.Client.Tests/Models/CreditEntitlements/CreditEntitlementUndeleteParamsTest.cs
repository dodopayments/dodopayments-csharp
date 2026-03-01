using System;
using DodoPayments.Client.Models.CreditEntitlements;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CreditEntitlementUndeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditEntitlementUndeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CreditEntitlementUndeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/credit-entitlements/id/undelete"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditEntitlementUndeleteParams { ID = "id" };

        CreditEntitlementUndeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
