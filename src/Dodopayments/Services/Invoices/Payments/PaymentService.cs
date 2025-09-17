using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.Invoices.Payments;
using Dodopayments = Dodopayments;

namespace Dodopayments.Services.Invoices.Payments;

public sealed class PaymentService : IPaymentService
{
    readonly Dodopayments::IDodoPaymentsClient _client;

    public PaymentService(Dodopayments::IDodoPaymentsClient client)
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
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<JsonElement>(
            await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
            Dodopayments::ModelBase.SerializerOptions
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
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<JsonElement>(
            await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
            Dodopayments::ModelBase.SerializerOptions
        );
    }
}
