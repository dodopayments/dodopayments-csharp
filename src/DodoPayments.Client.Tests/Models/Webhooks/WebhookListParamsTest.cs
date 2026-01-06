using System;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookListParams { Iterator = "iterator", Limit = 0 };

        string expectedIterator = "iterator";
        int expectedLimit = 0;

        Assert.Equal(expectedIterator, parameters.Iterator);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookListParams { };

        Assert.Null(parameters.Iterator);
        Assert.False(parameters.RawQueryData.ContainsKey("iterator"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookListParams { Iterator = null, Limit = null };

        Assert.Null(parameters.Iterator);
        Assert.True(parameters.RawQueryData.ContainsKey("iterator"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookListParams parameters = new() { Iterator = "iterator", Limit = 0 };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri("https://live.dodopayments.com/webhooks?iterator=iterator&limit=0"),
            url
        );
    }
}
