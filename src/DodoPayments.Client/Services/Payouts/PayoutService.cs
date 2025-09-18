using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Services.Payouts;

public sealed class PayoutService : IPayoutService
{
    readonly IDodoPaymentsClient _client;

    public PayoutService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<PayoutListPageResponse> List(PayoutListParams? parameters = null)
    {
        parameters ??= new();

        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<PayoutListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
