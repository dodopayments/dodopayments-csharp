using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.WebhookEvents;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookCreateParams
        {
            UrlValue = "url",
            Description = "description",
            Disabled = true,
            FilterTypes = [WebhookEventType.PaymentSucceeded],
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            IdempotencyKey = "idempotency_key",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RateLimit = 0,
        };

        string expectedUrlValue = "url";
        string expectedDescription = "description";
        bool expectedDisabled = true;
        List<ApiEnum<string, WebhookEventType>> expectedFilterTypes =
        [
            WebhookEventType.PaymentSucceeded,
        ];
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedIdempotencyKey = "idempotency_key";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        int expectedRateLimit = 0;

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisabled, parameters.Disabled);
        Assert.NotNull(parameters.FilterTypes);
        Assert.Equal(expectedFilterTypes.Count, parameters.FilterTypes.Count);
        for (int i = 0; i < expectedFilterTypes.Count; i++)
        {
            Assert.Equal(expectedFilterTypes[i], parameters.FilterTypes[i]);
        }
        Assert.NotNull(parameters.Headers);
        Assert.Equal(expectedHeaders.Count, parameters.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(parameters.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Headers[item.Key]);
        }
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedRateLimit, parameters.RateLimit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            UrlValue = "url",
            Description = "description",
            Disabled = true,
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            IdempotencyKey = "idempotency_key",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RateLimit = 0,
        };

        Assert.Null(parameters.FilterTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("filter_types"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            UrlValue = "url",
            Description = "description",
            Disabled = true,
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            IdempotencyKey = "idempotency_key",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            RateLimit = 0,

            // Null should be interpreted as omitted for these properties
            FilterTypes = null,
        };

        Assert.Null(parameters.FilterTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("filter_types"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            UrlValue = "url",
            FilterTypes = [WebhookEventType.PaymentSucceeded],
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Disabled);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.Headers);
        Assert.False(parameters.RawBodyData.ContainsKey("headers"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawBodyData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RateLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("rate_limit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookCreateParams
        {
            UrlValue = "url",
            FilterTypes = [WebhookEventType.PaymentSucceeded],

            Description = null,
            Disabled = null,
            Headers = null,
            IdempotencyKey = null,
            Metadata = null,
            RateLimit = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Disabled);
        Assert.True(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.Headers);
        Assert.True(parameters.RawBodyData.ContainsKey("headers"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.True(parameters.RawBodyData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RateLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("rate_limit"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookCreateParams parameters = new() { UrlValue = "url" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/webhooks"), url);
    }
}
