using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Models.LicenseKeys;
using DodoPayments = DodoPayments;

namespace DodoPayments.Services.LicenseKeys;

public sealed class LicenseKeyService : ILicenseKeyService
{
    readonly DodoPayments::IDodoPaymentsClient _client;

    public LicenseKeyService(DodoPayments::IDodoPaymentsClient client)
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<LicenseKey>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<LicenseKey>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<LicenseKeyListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
