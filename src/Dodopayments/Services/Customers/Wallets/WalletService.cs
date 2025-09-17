using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.Customers.Wallets;
using Dodopayments = Dodopayments;
using LedgerEntries = Dodopayments.Services.Customers.Wallets.LedgerEntries;

namespace Dodopayments.Services.Customers.Wallets;

public sealed class WalletService : IWalletService
{
    readonly Dodopayments::IDodoPaymentsClient _client;

    public WalletService(Dodopayments::IDodoPaymentsClient client)
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
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<WalletListResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
