using System;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookDeleteParams { WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab" };

        string expectedWebhookID = "whk_YdWqVEGKmSYKbsIyDxEab";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookDeleteParams parameters = new() { WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/webhooks/whk_YdWqVEGKmSYKbsIyDxEab"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookDeleteParams { WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab" };

        WebhookDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
