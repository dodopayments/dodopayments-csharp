using System;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceRetrieveParams
        {
            CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
        };

        string expectedCreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM";
        string expectedCustomerID = "cus_TV52uJWWXt2yIoBBxpjaa";

        Assert.Equal(expectedCreditEntitlementID, parameters.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        BalanceRetrieveParams parameters = new()
        {
            CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/credit-entitlements/cde_ztxm5XJsKxWucRWA3rjdM/balances/cus_TV52uJWWXt2yIoBBxpjaa"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BalanceRetrieveParams
        {
            CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
        };

        BalanceRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
