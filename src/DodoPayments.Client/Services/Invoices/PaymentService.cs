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
    readonly Lazy<global::DodoPayments.Client.Services.Invoices.IPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public global::DodoPayments.Client.Services.Invoices.IPaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public global::DodoPayments.Client.Services.Invoices.IPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::DodoPayments.Client.Services.Invoices.PaymentService(
            this._client.WithOptions(modifier)
        );
    }

    public PaymentService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new global::DodoPayments.Client.Services.Invoices.PaymentServiceWithRawResponse(
                client.WithRawResponse
            )
        );
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
public sealed class PaymentServiceWithRawResponse
    : global::DodoPayments.Client.Services.Invoices.IPaymentServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public global::DodoPayments.Client.Services.Invoices.IPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::DodoPayments.Client.Services.Invoices.PaymentServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
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
