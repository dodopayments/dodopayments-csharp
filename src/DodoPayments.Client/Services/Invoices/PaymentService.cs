using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

/// <inheritdoc/>
public sealed class PaymentService : global::DodoPayments.Client.Services.Invoices.IPaymentService
{
    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<HttpResponse> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PaymentID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.PaymentID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<HttpResponse> Retrieve(
        string paymentID,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { PaymentID = paymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> RetrieveRefund(
        PaymentRetrieveRefundParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RefundID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.RefundID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<HttpResponse> RetrieveRefund(
        string refundID,
        PaymentRetrieveRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.RetrieveRefund(
            parameters with
            {
                RefundID = refundID,
            },
            cancellationToken
        );
    }
}
