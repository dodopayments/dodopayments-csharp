using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Services.Payments;

public sealed class PaymentService : IPaymentService
{
    readonly IDodoPaymentsClient _client;

    public PaymentService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<PaymentCreateResponse> Create(PaymentCreateParams parameters)
    {
        HttpRequest<PaymentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PaymentCreateResponse>().ConfigureAwait(false);
    }

    public async Task<Payment> Retrieve(PaymentRetrieveParams parameters)
    {
        HttpRequest<PaymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Payment>().ConfigureAwait(false);
    }

    public async Task<PaymentListPageResponse> List(PaymentListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<PaymentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PaymentListPageResponse>().ConfigureAwait(false);
    }

    public async Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        PaymentRetrieveLineItemsParams parameters
    )
    {
        HttpRequest<PaymentRetrieveLineItemsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PaymentRetrieveLineItemsResponse>().ConfigureAwait(false);
    }
}
