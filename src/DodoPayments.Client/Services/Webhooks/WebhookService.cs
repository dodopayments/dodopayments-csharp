using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Webhooks.Headers;
using Webhooks = DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Services.Webhooks;

public sealed class WebhookService : IWebhookService
{
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

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

    public async Task<Webhooks::WebhookDetails> Create(
        Webhooks::WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Webhooks::WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var webhookDetails = await response
            .Deserialize<Webhooks::WebhookDetails>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<Webhooks::WebhookDetails> Retrieve(
        Webhooks::WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Webhooks::WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var webhookDetails = await response
            .Deserialize<Webhooks::WebhookDetails>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<Webhooks::WebhookDetails> Update(
        Webhooks::WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Webhooks::WebhookUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var webhookDetails = await response
            .Deserialize<Webhooks::WebhookDetails>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<Webhooks::WebhookListPageResponse> List(
        Webhooks::WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Webhooks::WebhookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<Webhooks::WebhookListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Delete(
        Webhooks::WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Webhooks::WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<Webhooks::WebhookRetrieveSecretResponse> RetrieveSecret(
        Webhooks::WebhookRetrieveSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Webhooks::WebhookRetrieveSecretParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Webhooks::WebhookRetrieveSecretResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
