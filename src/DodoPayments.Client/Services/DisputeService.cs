using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class DisputeService : IDisputeService
{
    readonly Lazy<IDisputeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDisputeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DisputeService(this._client.WithOptions(modifier));
    }

    public DisputeService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DisputeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<GetDispute> Retrieve(
        DisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GetDispute> Retrieve(
        string disputeID,
        DisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DisputeID = disputeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DisputeListPage> List(
        DisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DisputeServiceWithRawResponse : IDisputeServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDisputeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DisputeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DisputeServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GetDispute>> Retrieve(
        DisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DisputeID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.DisputeID' cannot be null");
        }

        HttpRequest<DisputeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var getDispute = await response
                    .Deserialize<GetDispute>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    getDispute.Validate();
                }
                return getDispute;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GetDispute>> Retrieve(
        string disputeID,
        DisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DisputeID = disputeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DisputeListPage>> List(
        DisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DisputeListParams> request = new()
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
                    .Deserialize<DisputeListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DisputeListPage(this, parameters, page);
            }
        );
    }
}
