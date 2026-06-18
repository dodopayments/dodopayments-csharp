using System;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionRetrieveUsageHistoryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionRetrieveUsageHistoryParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MeterID = "meter_id",
            PageNumber = 0,
            PageSize = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedSubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMeterID = "meter_id";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedMeterID, parameters.MeterID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedStartDate, parameters.StartDate);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionRetrieveUsageHistoryParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
        };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.MeterID);
        Assert.False(parameters.RawQueryData.ContainsKey("meter_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionRetrieveUsageHistoryParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",

            EndDate = null,
            MeterID = null,
            PageNumber = null,
            PageSize = null,
            StartDate = null,
        };

        Assert.Null(parameters.EndDate);
        Assert.True(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.MeterID);
        Assert.True(parameters.RawQueryData.ContainsKey("meter_id"));
        Assert.Null(parameters.PageNumber);
        Assert.True(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.StartDate);
        Assert.True(parameters.RawQueryData.ContainsKey("start_date"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionRetrieveUsageHistoryParams parameters = new()
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            MeterID = "meter_id",
            PageNumber = 0,
            PageSize = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/subscriptions/sub_Iuaq622bbmmfOGrVTqdXv/usage-history?end_date=2019-12-27T18%3a11%3a19.117%2b00%3a00&meter_id=meter_id&page_number=0&page_size=0&start_date=2019-12-27T18%3a11%3a19.117%2b00%3a00"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionRetrieveUsageHistoryParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MeterID = "meter_id",
            PageNumber = 0,
            PageSize = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionRetrieveUsageHistoryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
