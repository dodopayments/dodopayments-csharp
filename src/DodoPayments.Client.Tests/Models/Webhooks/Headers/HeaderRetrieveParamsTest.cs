using System;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Tests.Models.Webhooks.Headers;

public class HeaderRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HeaderRetrieveParams { WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab" };

        string expectedWebhookID = "whk_YdWqVEGKmSYKbsIyDxEab";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
    }

    [Fact]
    public void Url_Works()
    {
        HeaderRetrieveParams parameters = new() { WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/webhooks/whk_YdWqVEGKmSYKbsIyDxEab/headers"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new HeaderRetrieveParams { WebhookID = "whk_YdWqVEGKmSYKbsIyDxEab" };

        HeaderRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
