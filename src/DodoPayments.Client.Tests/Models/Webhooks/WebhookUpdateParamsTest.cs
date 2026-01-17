using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.WebhookEvents;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            WebhookID = "webhook_id",
            Description = "description",
            Disabled = true,
            FilterTypes = [WebhookEventType.PaymentSucceeded],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RateLimit = 0,
            UrlValue = "url",
        };

        string expectedWebhookID = "webhook_id";
        string expectedDescription = "description";
        bool expectedDisabled = true;
        List<ApiEnum<string, WebhookEventType>> expectedFilterTypes =
        [
            WebhookEventType.PaymentSucceeded,
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        int expectedRateLimit = 0;
        string expectedUrlValue = "url";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisabled, parameters.Disabled);
        Assert.NotNull(parameters.FilterTypes);
        Assert.Equal(expectedFilterTypes.Count, parameters.FilterTypes.Count);
        for (int i = 0; i < expectedFilterTypes.Count; i++)
        {
            Assert.Equal(expectedFilterTypes[i], parameters.FilterTypes[i]);
        }
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedRateLimit, parameters.RateLimit);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams { WebhookID = "webhook_id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Disabled);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.FilterTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("filter_types"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RateLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("rate_limit"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            WebhookID = "webhook_id",

            Description = null,
            Disabled = null,
            FilterTypes = null,
            Metadata = null,
            RateLimit = null,
            UrlValue = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Disabled);
        Assert.True(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.FilterTypes);
        Assert.True(parameters.RawBodyData.ContainsKey("filter_types"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RateLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("rate_limit"));
        Assert.Null(parameters.UrlValue);
        Assert.True(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookUpdateParams parameters = new() { WebhookID = "webhook_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/webhooks/webhook_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            WebhookID = "webhook_id",
            Description = "description",
            Disabled = true,
            FilterTypes = [WebhookEventType.PaymentSucceeded],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RateLimit = 0,
            UrlValue = "url",
        };

        WebhookUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
