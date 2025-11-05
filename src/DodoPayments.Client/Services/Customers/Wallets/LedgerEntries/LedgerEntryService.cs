using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets.LedgerEntries;

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

    public async Task<CustomerWallet> Create(LedgerEntryCreateParams parameters)
    {
        HttpRequest<LedgerEntryCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customerWallet = await response.Deserialize<CustomerWallet>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customerWallet.Validate();
        }
        return customerWallet;
    }

    public async Task<LedgerEntryListPageResponse> List(LedgerEntryListParams parameters)
    {
        HttpRequest<LedgerEntryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<LedgerEntryListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
