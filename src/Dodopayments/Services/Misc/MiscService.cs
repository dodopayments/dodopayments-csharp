using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.Misc;
using Dodopayments = Dodopayments;

namespace Dodopayments.Services.Misc;

public sealed class MiscService : IMiscService
{
    readonly Dodopayments::IDodoPaymentsClient _client;

    public MiscService(Dodopayments::IDodoPaymentsClient client)
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
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<List<CountryCode>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
