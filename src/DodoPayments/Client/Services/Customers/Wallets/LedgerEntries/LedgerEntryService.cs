using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Services.Customers.Wallets.LedgerEntries;

public sealed class LedgerEntryService : ILedgerEntryService
{
    readonly Client::IDodoPaymentsClient _client;

    public LedgerEntryService(Client::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<CustomerWallet> Create(LedgerEntryCreateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
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

        return JsonSerializer.Deserialize<CustomerWallet>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Client::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<LedgerEntryListPageResponse> List(LedgerEntryListParams parameters)
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

        return JsonSerializer.Deserialize<LedgerEntryListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Client::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
