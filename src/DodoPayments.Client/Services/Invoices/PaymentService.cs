using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

/// <inheritdoc/>
public sealed class PaymentService : IPaymentService
{
    readonly Lazy<IPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentService(this._client.WithOptions(modifier));
    }

    public PaymentService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PaymentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string paymentID,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PaymentID = paymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveRefund(
        PaymentRetrieveRefundParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveRefund(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveRefund(
        string refundID,
        PaymentRetrieveRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRefund(parameters with { RefundID = refundID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PaymentServiceWithRawResponse : IPaymentServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPaymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PaymentServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string paymentID,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PaymentID = paymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveRefund(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveRefund(
        string refundID,
        PaymentRetrieveRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRefund(parameters with { RefundID = refundID }, cancellationToken);
    }
}
