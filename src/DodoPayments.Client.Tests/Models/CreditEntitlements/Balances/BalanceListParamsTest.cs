using System;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceListParams
        {
            CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",
            CustomerID = "customer_id",
            PageNumber = 0,
            PageSize = 0,
        };

        string expectedCreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM";
        string expectedCustomerID = "customer_id";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedCreditEntitlementID, parameters.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceListParams
        {
            CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BalanceListParams
        {
            CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",

            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        BalanceListParams parameters = new()
        {
            CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",
            CustomerID = "customer_id",
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/credit-entitlements/cde_ztxm5XJsKxWucRWA3rjdM/balances?customer_id=customer_id&page_number=0&page_size=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BalanceListParams
        {
            CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",
            CustomerID = "customer_id",
            PageNumber = 0,
            PageSize = 0,
        };

        BalanceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
