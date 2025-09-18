using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices.Payments;

public sealed class PaymentService : IPaymentService
{
    readonly IDodoPaymentsClient _client;

    public PaymentService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<JsonElement> Retrieve(PaymentRetrieveParams parameters)
    {
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

        return JsonSerializer.Deserialize<JsonElement>(
            await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
            ModelBase.SerializerOptions
        );
    }

    public async Task<JsonElement> RetrieveRefund(PaymentRetrieveRefundParams parameters)
    {
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

        return JsonSerializer.Deserialize<JsonElement>(
            await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
            ModelBase.SerializerOptions
        );
    }
}
