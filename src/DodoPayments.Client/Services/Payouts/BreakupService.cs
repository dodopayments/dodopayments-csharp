using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payouts.Breakup;
using DodoPayments.Client.Services.Payouts.Breakup;

namespace DodoPayments.Client.Services.Payouts;

/// <inheritdoc/>
public sealed class BreakupService : IBreakupService
{
    readonly Lazy<IBreakupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBreakupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IBreakupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BreakupService(this._client.WithOptions(modifier));
    }

    public BreakupService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BreakupServiceWithRawResponse(client.WithRawResponse));
        _details = new(() => new DetailService(client));
    }

    readonly Lazy<IDetailService> _details;
    public IDetailService Details
    {
        get { return _details.Value; }
    }

    /// <inheritdoc/>
    public async Task<List<BreakupRetrieveResponse>> Retrieve(
        BreakupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<BreakupRetrieveResponse>> Retrieve(
        string payoutID,
        BreakupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PayoutID = payoutID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BreakupServiceWithRawResponse : IBreakupServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBreakupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BreakupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BreakupServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _details = new(() => new DetailServiceWithRawResponse(client));
    }

    readonly Lazy<IDetailServiceWithRawResponse> _details;
    public IDetailServiceWithRawResponse Details
    {
        get { return _details.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<BreakupRetrieveResponse>>> Retrieve(
        BreakupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PayoutID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.PayoutID' cannot be null");
        }

        HttpRequest<BreakupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var breakups = await response
                    .Deserialize<List<BreakupRetrieveResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in breakups)
                    {
                        item.Validate();
                    }
                }
                return breakups;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<BreakupRetrieveResponse>>> Retrieve(
        string payoutID,
        BreakupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PayoutID = payoutID }, cancellationToken);
    }
}
