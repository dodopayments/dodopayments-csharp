using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Webhooks;
using DodoPayments.Client.Services.Webhooks;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    readonly Lazy<IWebhookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

    public WebhookService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WebhookServiceWithRawResponse(client.WithRawResponse));
        _headers = new(() => new HeaderService(client));
    }

    readonly Lazy<IHeaderService> _headers;
    public IHeaderService Headers
    {
        get { return _headers.Value; }
    }

    /// <inheritdoc/>
    public async Task<WebhookDetails> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WebhookDetails> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookDetails> Retrieve(
        string webhookID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookDetails> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookDetails> Update(
        string webhookID,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookListPage> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string webhookID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { WebhookID = webhookID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WebhookRetrieveSecretResponse> RetrieveSecret(
        WebhookRetrieveSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveSecret(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookRetrieveSecretResponse> RetrieveSecret(
        string webhookID,
        WebhookRetrieveSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSecret(parameters with { WebhookID = webhookID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WebhookServiceWithRawResponse : IWebhookServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _headers = new(() => new HeaderServiceWithRawResponse(client));
    }

    readonly Lazy<IHeaderServiceWithRawResponse> _headers;
    public IHeaderServiceWithRawResponse Headers
    {
        get { return _headers.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookDetails>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookDetails = await response
                    .Deserialize<WebhookDetails>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookDetails.Validate();
                }
                return webhookDetails;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookDetails>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookDetails = await response
                    .Deserialize<WebhookDetails>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookDetails.Validate();
                }
                return webhookDetails;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WebhookDetails>> Retrieve(
        string webhookID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookDetails>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<WebhookUpdateParams> request = new()
        {
            Method = DodoPaymentsClient.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookDetails = await response
                    .Deserialize<WebhookDetails>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookDetails.Validate();
                }
                return webhookDetails;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WebhookDetails>> Update(
        string webhookID,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<WebhookListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new WebhookListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string webhookID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookRetrieveSecretResponse>> RetrieveSecret(
        WebhookRetrieveSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<WebhookRetrieveSecretParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<WebhookRetrieveSecretResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WebhookRetrieveSecretResponse>> RetrieveSecret(
        string webhookID,
        WebhookRetrieveSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSecret(parameters with { WebhookID = webhookID }, cancellationToken);
    }
}
