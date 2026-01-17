using System;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Tests.Models.Payouts;

public class PayoutListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PayoutListParams
        {
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageNumber = 0,
            PageSize = 0,
        };

        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PayoutListParams { };

        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PayoutListParams
        {
            // Null should be interpreted as omitted for these properties
            CreatedAtGte = null,
            CreatedAtLte = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        PayoutListParams parameters = new()
        {
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/payouts?created_at_gte=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at_lte=2019-12-27T18%3a11%3a19.117%2b00%3a00&page_number=0&page_size=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PayoutListParams
        {
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageNumber = 0,
            PageSize = 0,
        };

        PayoutListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
