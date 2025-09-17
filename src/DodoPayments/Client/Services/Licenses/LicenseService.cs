using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Licenses;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Services.Licenses;

public sealed class LicenseService : ILicenseService
{
    readonly Client::IDodoPaymentsClient _client;

    public LicenseService(Client::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<LicenseActivateResponse> Activate(LicenseActivateParams parameters)
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

        return JsonSerializer.Deserialize<LicenseActivateResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Client::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task Deactivate(LicenseDeactivateParams parameters)
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
    }

    public async Task<LicenseValidateResponse> Validate(LicenseValidateParams parameters)
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

        return JsonSerializer.Deserialize<LicenseValidateResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Client::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
