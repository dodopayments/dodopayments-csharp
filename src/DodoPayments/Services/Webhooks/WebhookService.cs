using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Models.Webhooks;
using DodoPayments = DodoPayments;
using Headers = DodoPayments.Services.Webhooks.Headers;

namespace DodoPayments.Services.Webhooks;

public sealed class WebhookService : IWebhookService
{
    readonly DodoPayments::IDodoPaymentsClient _client;

    public WebhookService(DodoPayments::IDodoPaymentsClient client)
    {
        _client = client;
        _headers = new(() => new Headers::HeaderService(client));
    }

    readonly Lazy<Headers::IHeaderService> _headers;
    public Headers::IHeaderService Headers
    {
        get { return _headers.Value; }
    }

    public async Task<WebhookCreateResponse> Create(WebhookCreateParams parameters)
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookCreateResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<WebhookRetrieveResponse> Retrieve(WebhookRetrieveParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookRetrieveResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<WebhookUpdateResponse> Update(WebhookUpdateParams parameters)
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookUpdateResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WebhookListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
    }
}
