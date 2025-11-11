using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets;

public sealed class LedgerEntryService : ILedgerEntryService
{
    public ILedgerEntryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LedgerEntryService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public LedgerEntryService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<CustomerWallet> Create(
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<LedgerEntryListPageResponse> List(
        LedgerEntryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
        return page;
    }
}
