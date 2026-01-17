using System;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Models.UsageEvents;

public class UsageEventListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageEventListParams
        {
            CustomerID = "customer_id",
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventName = "event_name",
            MeterID = "meter_id",
            PageNumber = 0,
            PageSize = 0,
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCustomerID = "customer_id";
        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventName = "event_name";
        string expectedMeterID = "meter_id";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedEventName, parameters.EventName);
        Assert.Equal(expectedMeterID, parameters.MeterID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedStart, parameters.Start);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageEventListParams { };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.EventName);
        Assert.False(parameters.RawQueryData.ContainsKey("event_name"));
        Assert.Null(parameters.MeterID);
        Assert.False(parameters.RawQueryData.ContainsKey("meter_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UsageEventListParams
        {
            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            End = null,
            EventName = null,
            MeterID = null,
            PageNumber = null,
            PageSize = null,
            Start = null,
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.EventName);
        Assert.False(parameters.RawQueryData.ContainsKey("event_name"));
        Assert.Null(parameters.MeterID);
        Assert.False(parameters.RawQueryData.ContainsKey("meter_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
    }

    [Fact]
    public void Url_Works()
    {
        UsageEventListParams parameters = new()
        {
            CustomerID = "customer_id",
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventName = "event_name",
            MeterID = "meter_id",
            PageNumber = 0,
            PageSize = 0,
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/events?customer_id=customer_id&end=2019-12-27T18%3a11%3a19.117%2b00%3a00&event_name=event_name&meter_id=meter_id&page_number=0&page_size=0&start=2019-12-27T18%3a11%3a19.117%2b00%3a00"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageEventListParams
        {
            CustomerID = "customer_id",
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventName = "event_name",
            MeterID = "meter_id",
            PageNumber = 0,
            PageSize = 0,
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        UsageEventListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
