using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Tests.Models.Webhooks.Headers;

public class HeaderUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HeaderUpdateParams
        {
            WebhookID = "webhook_id",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedWebhookID = "webhook_id";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
        Assert.Equal(expectedHeaders.Count, parameters.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(parameters.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Headers[item.Key]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        HeaderUpdateParams parameters = new()
        {
            WebhookID = "webhook_id",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/webhooks/webhook_id/headers"), url);
    }
}
