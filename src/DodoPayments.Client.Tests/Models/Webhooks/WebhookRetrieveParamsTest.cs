using System;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookRetrieveParams { WebhookID = "webhook_id" };

        string expectedWebhookID = "webhook_id";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookRetrieveParams parameters = new() { WebhookID = "webhook_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/webhooks/webhook_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookRetrieveParams { WebhookID = "webhook_id" };

        WebhookRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
