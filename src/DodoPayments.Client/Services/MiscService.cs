using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class MiscService : IMiscService
{
    readonly Lazy<IMiscServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMiscServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IMiscService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MiscService(this._client.WithOptions(modifier));
    }

    public MiscService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MiscServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<LocaleInfo>> ListLocales(
        MiscListLocalesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListLocales(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<ApiEnum<string, CountryCode>>> ListSupportedCountries(
        MiscListSupportedCountriesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSupportedCountries(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MiscServiceWithRawResponse : IMiscServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMiscServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MiscServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MiscServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<LocaleInfo>>> ListLocales(
        MiscListLocalesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MiscListLocalesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var localeInfos = await response
                    .Deserialize<List<LocaleInfo>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in localeInfos)
                    {
                        item.Validate();
                    }
                }
                return localeInfos;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ApiEnum<string, CountryCode>>>> ListSupportedCountries(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var countryCodes = await response
                    .Deserialize<List<ApiEnum<string, CountryCode>>>(token)
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
        );
    }
}
