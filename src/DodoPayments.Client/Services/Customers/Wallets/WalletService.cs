using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Services.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets;

public sealed class WalletService : IWalletService
{
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

    public async Task<WalletListResponse> List(WalletListParams parameters)
    {
        HttpRequest<WalletListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<WalletListResponse>().ConfigureAwait(false);
    }
}
