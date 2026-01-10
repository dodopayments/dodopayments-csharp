using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class CheckoutSessionService : ICheckoutSessionService
{
    readonly Lazy<ICheckoutSessionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICheckoutSessionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ICheckoutSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckoutSessionService(this._client.WithOptions(modifier));
    }

    public CheckoutSessionService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CheckoutSessionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CheckoutSessionResponse> Create(
        CheckoutSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CheckoutSessionStatus> Retrieve(
        CheckoutSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckoutSessionStatus> Retrieve(
        string id,
        CheckoutSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CheckoutSessionServiceWithRawResponse : ICheckoutSessionServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICheckoutSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CheckoutSessionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CheckoutSessionServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckoutSessionResponse>> Create(
        CheckoutSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CheckoutSessionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkoutSessionResponse = await response
                    .Deserialize<CheckoutSessionResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkoutSessionResponse.Validate();
                }
                return checkoutSessionResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckoutSessionStatus>> Retrieve(
        CheckoutSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CheckoutSessionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkoutSessionStatus = await response
                    .Deserialize<CheckoutSessionStatus>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkoutSessionStatus.Validate();
                }
                return checkoutSessionStatus;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckoutSessionStatus>> Retrieve(
        string id,
        CheckoutSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}
