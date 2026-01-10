using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Services;

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
    IPaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    [Obsolete("deprecated")]
    Task<PaymentCreateResponse> Create(
        PaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Payment> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PaymentRetrieveParams, CancellationToken)"/>
    Task<Payment> Retrieve(
        string paymentID,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<PaymentListPage> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        PaymentRetrieveLineItemsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLineItems(PaymentRetrieveLineItemsParams, CancellationToken)"/>
    Task<PaymentRetrieveLineItemsResponse> RetrieveLineItems(
        string paymentID,
        PaymentRetrieveLineItemsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /payments`, but is otherwise the
    /// same as <see cref="IPaymentService.Create(PaymentCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<PaymentCreateResponse>> Create(
        PaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/{payment_id}`, but is otherwise the
    /// same as <see cref="IPaymentService.Retrieve(PaymentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Payment>> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PaymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Payment>> Retrieve(
        string paymentID,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments`, but is otherwise the
    /// same as <see cref="IPaymentService.List(PaymentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaymentListPage>> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/{payment_id}/line-items`, but is otherwise the
    /// same as <see cref="IPaymentService.RetrieveLineItems(PaymentRetrieveLineItemsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaymentRetrieveLineItemsResponse>> RetrieveLineItems(
        PaymentRetrieveLineItemsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLineItems(PaymentRetrieveLineItemsParams, CancellationToken)"/>
    Task<HttpResponse<PaymentRetrieveLineItemsResponse>> RetrieveLineItems(
        string paymentID,
        PaymentRetrieveLineItemsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
