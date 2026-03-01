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
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCreditEntitlementID, parameters.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        BalanceRetrieveParams parameters = new()
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/credit-entitlements/credit_entitlement_id/balances/customer_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BalanceRetrieveParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
        };

        BalanceRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
