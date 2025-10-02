using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services.Misc;

public sealed class MiscService : IMiscService
{
    readonly IDodoPaymentsClient _client;

    public MiscService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<List<ApiEnum<string, CountryCode>>> ListSupportedCountries(
        MiscListSupportedCountriesParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<MiscListSupportedCountriesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<List<ApiEnum<string, CountryCode>>>()
            .ConfigureAwait(false);
    }
}
