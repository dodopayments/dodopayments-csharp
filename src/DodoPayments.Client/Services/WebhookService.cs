using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks;
using DodoPayments.Client.Services.Webhooks;

namespace DodoPayments.Client.Services;

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

    public async Task<WebhookDetails> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var webhookDetails = await response
            .Deserialize<WebhookDetails>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<WebhookDetails> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var webhookDetails = await response
            .Deserialize<WebhookDetails>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<WebhookDetails> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var webhookDetails = await response
            .Deserialize<WebhookDetails>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            webhookDetails.Validate();
        }
        return webhookDetails;
    }

    public async Task<WebhookListPageResponse> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<WebhookListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<WebhookRetrieveSecretResponse> RetrieveSecret(
        WebhookRetrieveSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookRetrieveSecretParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<WebhookRetrieveSecretResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
