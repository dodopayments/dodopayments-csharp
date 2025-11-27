using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services;

/// <inheritdoc />
public sealed class MiscService : IMiscService
{
    /// <inheritdoc/>
    public IMiscService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MiscService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public MiscService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<ApiEnum<string, CountryCode>>> ListSupportedCountries(
        MiscListSupportedCountriesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MiscListSupportedCountriesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var countryCodes = await response
            .Deserialize<List<ApiEnum<string, CountryCode>>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in countryCodes)
            {
                item.Validate();
            }
        }
        return countryCodes;
    }
}
