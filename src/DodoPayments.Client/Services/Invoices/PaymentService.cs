using System;
using System.Net.Http;
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

    public async Task<HttpResponse> Retrieve(
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
        return response;
    }

    public async Task<HttpResponse> RetrieveRefund(
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
        return response;
    }
}
