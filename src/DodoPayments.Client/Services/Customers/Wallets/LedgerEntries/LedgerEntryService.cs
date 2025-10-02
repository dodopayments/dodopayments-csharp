using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets.LedgerEntries;

public sealed class LedgerEntryService : ILedgerEntryService
{
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
        return await response.Deserialize<CustomerWallet>().ConfigureAwait(false);
    }

    public async Task<LedgerEntryListPageResponse> List(LedgerEntryListParams parameters)
    {
        HttpRequest<LedgerEntryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LedgerEntryListPageResponse>().ConfigureAwait(false);
    }
}
