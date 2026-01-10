using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Services.Invoices;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    global::DodoPayments.Client.Services.Invoices.IPaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::DodoPayments.Client.Services.Invoices.IPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// It's the caller's responsibility to dispose the returned response.
    /// </summary>
    Task<HttpResponse> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PaymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string paymentID,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// It's the caller's responsibility to dispose the returned response.
    /// </summary>
    Task<HttpResponse> RetrieveRefund(
        PaymentRetrieveRefundParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveRefund(PaymentRetrieveRefundParams, CancellationToken)"/>
    Task<HttpResponse> RetrieveRefund(
        string refundID,
        PaymentRetrieveRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="global::DodoPayments.Client.Services.Invoices.IPaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::DodoPayments.Client.Services.Invoices.IPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /invoices/payments/{payment_id}`, but is otherwise the
    /// same as <see cref="global::DodoPayments.Client.Services.Invoices.IPaymentService.Retrieve(PaymentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PaymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string paymentID,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /invoices/refunds/{refund_id}`, but is otherwise the
    /// same as <see cref="global::DodoPayments.Client.Services.Invoices.IPaymentService.RetrieveRefund(PaymentRetrieveRefundParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RetrieveRefund(
        PaymentRetrieveRefundParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveRefund(PaymentRetrieveRefundParams, CancellationToken)"/>
    Task<HttpResponse> RetrieveRefund(
        string refundID,
        PaymentRetrieveRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
