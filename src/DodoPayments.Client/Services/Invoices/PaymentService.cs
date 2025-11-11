using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

public sealed class PaymentService : global::DodoPayments.Client.Services.Invoices.IPaymentService
{
    public global::DodoPayments.Client.Services.Invoices.IPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::DodoPayments.Client.Services.Invoices.PaymentService(
            this._client.WithOptions(modifier)
        );
    }

    readonly IDodoPaymentsClient _client;

    public PaymentService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<JsonElement> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PaymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    public async Task<JsonElement> RetrieveRefund(
        PaymentRetrieveRefundParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PaymentRetrieveRefundParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }
}
