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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::DodoPayments.Client.Services.Invoices.IPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

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
