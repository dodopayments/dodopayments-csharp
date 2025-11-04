using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks;
using DodoPayments.Client.Services.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks;

public sealed class WebhookService : IWebhookService
{
    readonly IDodoPaymentsClient _client;

    public WebhookService(IDodoPaymentsClient client)
    {
        _client = client;
        _headers = new(() => new HeaderService(client));
    }

    readonly Lazy<IHeaderService> _headers;
    public IHeaderService Headers
    {
        get { return _headers.Value; }
    }

    public async Task<WebhookDetails> Create(WebhookCreateParams parameters)
    {
        HttpRequest<WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var webhookDetails = await response.Deserialize<WebhookDetails>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<WebhookDetails> Retrieve(WebhookRetrieveParams parameters)
    {
        HttpRequest<WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var webhookDetails = await response.Deserialize<WebhookDetails>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<WebhookDetails> Update(WebhookUpdateParams parameters)
    {
        HttpRequest<WebhookUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var webhookDetails = await response.Deserialize<WebhookDetails>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<WebhookListPageResponse> List(WebhookListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<WebhookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<WebhookListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Delete(WebhookDeleteParams parameters)
    {
        HttpRequest<WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<WebhookRetrieveSecretResponse> RetrieveSecret(
        WebhookRetrieveSecretParams parameters
    )
    {
        HttpRequest<WebhookRetrieveSecretParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<WebhookRetrieveSecretResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
