using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Balances;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class BalanceService : IBalanceService
{
    readonly Lazy<IBalanceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBalanceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BalanceService(this._client.WithOptions(modifier));
    }

    public BalanceService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BalanceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BalanceRetrieveLedgerPage> RetrieveLedger(
        BalanceRetrieveLedgerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveLedger(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BalanceServiceWithRawResponse : IBalanceServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBalanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BalanceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BalanceServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceRetrieveLedgerPage>> RetrieveLedger(
        BalanceRetrieveLedgerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BalanceRetrieveLedgerParams> request = new()
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
                    .Deserialize<BalanceRetrieveLedgerPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BalanceRetrieveLedgerPage(this, parameters, page);
            }
        );
    }
}
