using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Models.Webhooks.Headers;
using DodoPayments = DodoPayments;

namespace DodoPayments.Services.Webhooks.Headers;

public sealed class HeaderService : IHeaderService
{
    readonly DodoPayments::IDodoPaymentsClient _client;

    public HeaderService(DodoPayments::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<HeaderRetrieveResponse> Retrieve(HeaderRetrieveParams parameters)
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

        return JsonSerializer.Deserialize<HeaderRetrieveResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task Update(HeaderUpdateParams parameters)
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
    }
}
