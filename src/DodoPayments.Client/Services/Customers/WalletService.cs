using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Services.Customers.Wallets;

namespace DodoPayments.Client.Services.Customers;

/// <inheritdoc />
public sealed class WalletService : IWalletService
{
    /// <inheritdoc/>
    public IWalletService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WalletService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public WalletService(IDodoPaymentsClient client)
    {
        _client = client;
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
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<WalletListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var wallets = await response
            .Deserialize<WalletListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            wallets.Validate();
        }
        return wallets;
    }

    /// <inheritdoc/>
    public async Task<WalletListResponse> List(
        string customerID,
        WalletListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }
}
