using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Models.Invoices.Payments;
using DodoPayments = DodoPayments;

namespace DodoPayments.Services.Invoices.Payments;

public sealed class PaymentService : IPaymentService
{
    readonly DodoPayments::IDodoPaymentsClient _client;

    public PaymentService(DodoPayments::IDodoPaymentsClient client)
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<JsonElement>(
            await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
            DodoPayments::ModelBase.SerializerOptions
        );
    }
}
