using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.Webhooks;
using Dodopayments = Dodopayments;
using Headers = Dodopayments.Services.Webhooks.Headers;

namespace Dodopayments.Services.Webhooks;

public sealed class WebhookService : IWebhookService
{
    readonly Dodopayments::IDodoPaymentsClient _client;

    public WebhookService(Dodopayments::IDodoPaymentsClient client)
    {
        _client = client;
        _headers = new(() => new Headers::HeaderService(client));
    }

    readonly Lazy<Headers::IHeaderService> _headers;
    public Headers::IHeaderService Headers
    {
        get { return _headers.Value; }
    }

    public async Task<WebhookDetails> Create(WebhookCreateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookDetails>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<WebhookDetails> Retrieve(WebhookRetrieveParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookDetails>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<WebhookDetails> Update(WebhookUpdateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Patch, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookDetails>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<WebhookListPageResponse> List(WebhookListParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task Delete(WebhookDeleteParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Delete, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
    }

    public async Task<WebhookRetrieveSecretResponse> RetrieveSecret(
        WebhookRetrieveSecretParams parameters
    )
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookRetrieveSecretResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
