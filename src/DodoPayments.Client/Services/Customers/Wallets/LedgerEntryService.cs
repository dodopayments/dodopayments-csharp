using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets;

/// <inheritdoc/>
public sealed class LedgerEntryService : ILedgerEntryService
{
    /// <inheritdoc/>
    public ILedgerEntryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LedgerEntryService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public LedgerEntryService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<CustomerWallet> Create(
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<LedgerEntryCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customerWallet = await response
            .Deserialize<CustomerWallet>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customerWallet.Validate();
        }
        return customerWallet;
    }

    /// <inheritdoc/>
    public async Task<CustomerWallet> Create(
        string customerID,
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LedgerEntryListPage> List(
        LedgerEntryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<LedgerEntryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<LedgerEntryListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new LedgerEntryListPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task<LedgerEntryListPage> List(
        string customerID,
        LedgerEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }
}
