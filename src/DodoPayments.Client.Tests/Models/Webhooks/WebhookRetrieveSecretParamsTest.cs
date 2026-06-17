using System;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookRetrieveSecretParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookRetrieveSecretParams
        {
            WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab",
        };

        string expectedWebhookID = "whk_YdWqVEGKmSYKbsIyDxEab";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookRetrieveSecretParams parameters = new() { WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/webhooks/whk_YdWqVEGKmSYKbsIyDxEab/secret"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookRetrieveSecretParams
        {
            WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab",
        };

        WebhookRetrieveSecretParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
