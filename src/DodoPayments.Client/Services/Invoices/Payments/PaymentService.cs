using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices.Payments;

public sealed class PaymentService : IPaymentService
{
    public IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public PaymentService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<JsonElement> Retrieve(PaymentRetrieveParams parameters)
    {
        HttpRequest<PaymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<JsonElement>().ConfigureAwait(false);
    }

    public async Task<JsonElement> RetrieveRefund(PaymentRetrieveRefundParams parameters)
    {
        HttpRequest<PaymentRetrieveRefundParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<JsonElement>().ConfigureAwait(false);
    }
}
