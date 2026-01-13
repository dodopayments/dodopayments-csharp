using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks;

/// <inheritdoc/>
public sealed class HeaderService : IHeaderService
{
    readonly Lazy<IHeaderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IHeaderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IHeaderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HeaderService(this._client.WithOptions(modifier));
    }

    public HeaderService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new HeaderServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<HeaderRetrieveResponse> Retrieve(
        HeaderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HeaderRetrieveResponse> Retrieve(
        string webhookID,
        HeaderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(HeaderUpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string webhookID,
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { WebhookID = webhookID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class HeaderServiceWithRawResponse : IHeaderServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IHeaderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HeaderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public HeaderServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<HeaderRetrieveResponse>> Retrieve(
        HeaderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<HeaderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var header = await response
                    .Deserialize<HeaderRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    header.Validate();
                }
                return header;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<HeaderRetrieveResponse>> Retrieve(
        string webhookID,
        HeaderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<HeaderUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string webhookID,
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { WebhookID = webhookID }, cancellationToken);
    }
}
