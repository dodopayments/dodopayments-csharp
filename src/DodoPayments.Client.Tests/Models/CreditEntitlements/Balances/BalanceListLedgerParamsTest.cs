using System;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceListLedgerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceListLedgerParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageNumber = 0,
            PageSize = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionType = "transaction_type",
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionType = "transaction_type";

        Assert.Equal(expectedCreditEntitlementID, parameters.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedTransactionType, parameters.TransactionType);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceListLedgerParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
        };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
        Assert.Null(parameters.TransactionType);
        Assert.False(parameters.RawQueryData.ContainsKey("transaction_type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BalanceListLedgerParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",

            // Null should be interpreted as omitted for these properties
            EndDate = null,
            PageNumber = null,
            PageSize = null,
            StartDate = null,
            TransactionType = null,
        };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
        Assert.Null(parameters.TransactionType);
        Assert.False(parameters.RawQueryData.ContainsKey("transaction_type"));
    }

    [Fact]
    public void Url_Works()
    {
        BalanceListLedgerParams parameters = new()
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageNumber = 0,
            PageSize = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionType = "transaction_type",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/credit-entitlements/credit_entitlement_id/balances/customer_id/ledger?end_date=2019-12-27T18%3a11%3a19.117%2b00%3a00&page_number=0&page_size=0&start_date=2019-12-27T18%3a11%3a19.117%2b00%3a00&transaction_type=transaction_type"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BalanceListLedgerParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageNumber = 0,
            PageSize = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionType = "transaction_type",
        };

        BalanceListLedgerParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
