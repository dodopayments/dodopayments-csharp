using System;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class CustomerListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerListParams
        {
            BlockedByEmail = "blocked_by_email",
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identifier = "identifier",
            PageNumber = 0,
            PageSize = 0,
        };

        string expectedBlockedByEmail = "blocked_by_email";
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIdentifier = "identifier";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedBlockedByEmail, parameters.BlockedByEmail);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedIdentifier, parameters.Identifier);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerListParams { };

        Assert.Null(parameters.BlockedByEmail);
        Assert.False(parameters.RawQueryData.ContainsKey("blocked_by_email"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.Identifier);
        Assert.False(parameters.RawQueryData.ContainsKey("identifier"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CustomerListParams
        {
            BlockedByEmail = null,
            CreatedAtGte = null,
            CreatedAtLte = null,
            Identifier = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.BlockedByEmail);
        Assert.True(parameters.RawQueryData.ContainsKey("blocked_by_email"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.Identifier);
        Assert.True(parameters.RawQueryData.ContainsKey("identifier"));
        Assert.Null(parameters.PageNumber);
        Assert.True(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerListParams parameters = new()
        {
            BlockedByEmail = "blocked_by_email",
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Identifier = "identifier",
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/blocklist/customers?blocked_by_email=blocked_by_email&created_at_gte=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at_lte=2019-12-27T18%3a11%3a19.117%2b00%3a00&identifier=identifier&page_number=0&page_size=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerListParams
        {
            BlockedByEmail = "blocked_by_email",
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identifier = "identifier",
            PageNumber = 0,
            PageSize = 0,
        };

        CustomerListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
