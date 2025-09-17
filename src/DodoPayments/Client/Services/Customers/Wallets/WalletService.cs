using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Customers.Wallets;
using Client = DodoPayments.Client;
using LedgerEntries = DodoPayments.Client.Services.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets;

public sealed class WalletService : IWalletService
{
    readonly Client::IDodoPaymentsClient _client;

    public WalletService(Client::IDodoPaymentsClient client)
    {
        _client = client;
        _ledgerEntries = new(() => new LedgerEntries::LedgerEntryService(client));
    }

    readonly Lazy<LedgerEntries::ILedgerEntryService> _ledgerEntries;
    public LedgerEntries::ILedgerEntryService LedgerEntries
    {
        get { return _ledgerEntries.Value; }
    }

    public async Task<WalletListResponse> List(WalletListParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Client::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WalletListResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Client::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
