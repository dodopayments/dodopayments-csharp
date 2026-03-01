using System;
using DodoPayments.Client.Models.CreditEntitlements;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CreditEntitlementListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditEntitlementListParams
        {
            Deleted = true,
            PageNumber = 0,
            PageSize = 0,
        };

        bool expectedDeleted = true;
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedDeleted, parameters.Deleted);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditEntitlementListParams { };

        Assert.Null(parameters.Deleted);
        Assert.False(parameters.RawQueryData.ContainsKey("deleted"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CreditEntitlementListParams
        {
            // Null should be interpreted as omitted for these properties
            Deleted = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.Deleted);
        Assert.False(parameters.RawQueryData.ContainsKey("deleted"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        CreditEntitlementListParams parameters = new()
        {
            Deleted = true,
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/credit-entitlements?deleted=true&page_number=0&page_size=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditEntitlementListParams
        {
            Deleted = true,
            PageNumber = 0,
            PageSize = 0,
        };

        CreditEntitlementListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
