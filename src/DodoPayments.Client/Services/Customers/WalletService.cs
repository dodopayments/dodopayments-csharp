using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Services.Customers.Wallets;

namespace DodoPayments.Client.Services.Customers;

/// <inheritdoc/>
public sealed class WalletService : IWalletService
{
    readonly Lazy<IWalletServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWalletServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IWalletService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WalletService(this._client.WithOptions(modifier));
    }

    public WalletService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WalletServiceWithRawResponse(client.WithRawResponse));
        _ledgerEntries = new(() => new LedgerEntryService(client));
    }

    readonly Lazy<ILedgerEntryService> _ledgerEntries;
    public ILedgerEntryService LedgerEntries
    {
        get { return _ledgerEntries.Value; }
    }

    /// <inheritdoc/>
    public async Task<WalletListResponse> List(
        WalletListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WalletListResponse> List(
        string customerID,
        WalletListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WalletServiceWithRawResponse : IWalletServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWalletServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WalletServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WalletServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _ledgerEntries = new(() => new LedgerEntryServiceWithRawResponse(client));
    }

    readonly Lazy<ILedgerEntryServiceWithRawResponse> _ledgerEntries;
    public ILedgerEntryServiceWithRawResponse LedgerEntries
    {
        get { return _ledgerEntries.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WalletListResponse>> List(
        WalletListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<WalletListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wallets = await response
                    .Deserialize<WalletListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wallets.Validate();
                }
                return wallets;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WalletListResponse>> List(
        string customerID,
        WalletListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }
}
