using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.Payouts;
using Dodopayments = Dodopayments;

namespace Dodopayments.Services.Payouts;

public sealed class PayoutService : IPayoutService
{
    readonly Dodopayments::IDodoPaymentsClient _client;

    public PayoutService(Dodopayments::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<PayoutListPageResponse> List(PayoutListParams parameters)
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

        return JsonSerializer.Deserialize<PayoutListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
