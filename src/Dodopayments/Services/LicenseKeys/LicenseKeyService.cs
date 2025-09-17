using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.LicenseKeys;
using Dodopayments = Dodopayments;

namespace Dodopayments.Services.LicenseKeys;

public sealed class LicenseKeyService : ILicenseKeyService
{
    readonly Dodopayments::IDodoPaymentsClient _client;

    public LicenseKeyService(Dodopayments::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<LicenseKey> Retrieve(LicenseKeyRetrieveParams parameters)
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

        return JsonSerializer.Deserialize<LicenseKey>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<LicenseKey> Update(LicenseKeyUpdateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Patch, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
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

        return JsonSerializer.Deserialize<LicenseKey>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<LicenseKeyListPageResponse> List(LicenseKeyListParams parameters)
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

        return JsonSerializer.Deserialize<LicenseKeyListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
