using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Services.Misc;

public sealed class MiscService : IMiscService
{
    readonly Client::IDodoPaymentsClient _client;

    public MiscService(Client::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<List<CountryCode>> ListSupportedCountries(
        MiscListSupportedCountriesParams parameters
    )
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

        return JsonSerializer.Deserialize<List<CountryCode>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Client::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
