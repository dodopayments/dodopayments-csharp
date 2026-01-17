using System;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Tests.Models.Webhooks.Headers;

public class HeaderRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HeaderRetrieveParams { WebhookID = "webhook_id" };

        string expectedWebhookID = "webhook_id";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
    }

    [Fact]
    public void Url_Works()
    {
        HeaderRetrieveParams parameters = new() { WebhookID = "webhook_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/webhooks/webhook_id/headers"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new HeaderRetrieveParams { WebhookID = "webhook_id" };

        HeaderRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
