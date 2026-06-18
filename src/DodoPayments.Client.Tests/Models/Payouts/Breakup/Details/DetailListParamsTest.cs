using System;
using DodoPayments.Client.Models.Payouts.Breakup.Details;

namespace DodoPayments.Client.Tests.Models.Payouts.Breakup.Details;

public class DetailListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DetailListParams
        {
            PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T",
            PageNumber = 0,
            PageSize = 0,
        };

        string expectedPayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedPayoutID, parameters.PayoutID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DetailListParams { PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T" };

        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DetailListParams
        {
            PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T",

            // Null should be interpreted as omitted for these properties
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        DetailListParams parameters = new()
        {
            PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T",
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/payouts/pyt_zFTrrn4sk3x3y2vjDBW3T/breakup/details?page_number=0&page_size=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DetailListParams
        {
            PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T",
            PageNumber = 0,
            PageSize = 0,
        };

        DetailListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
