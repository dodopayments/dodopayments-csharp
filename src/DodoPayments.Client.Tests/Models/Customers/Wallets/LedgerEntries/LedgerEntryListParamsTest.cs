using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Customers.Wallets.LedgerEntries;

public class LedgerEntryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LedgerEntryListParams
        {
            CustomerID = "customer_id",
            Currency = Currency.Aed,
            PageNumber = 0,
            PageSize = 0,
        };

        string expectedCustomerID = "customer_id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LedgerEntryListParams { CustomerID = "customer_id" };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LedgerEntryListParams
        {
            CustomerID = "customer_id",

            // Null should be interpreted as omitted for these properties
            Currency = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        LedgerEntryListParams parameters = new()
        {
            CustomerID = "customer_id",
            Currency = Currency.Aed,
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/customers/customer_id/wallets/ledger-entries?currency=AED&page_number=0&page_size=0"
            ),
            url
        );
    }
}
