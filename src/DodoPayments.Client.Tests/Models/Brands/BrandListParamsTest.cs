using System;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandListParams { IncludeArchived = true };

        bool expectedIncludeArchived = true;

        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandListParams { };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BrandListParams
        {
            // Null should be interpreted as omitted for these properties
            IncludeArchived = null,
        };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandListParams parameters = new() { IncludeArchived = true };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/brands?include_archived=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandListParams { IncludeArchived = true };

        BrandListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
