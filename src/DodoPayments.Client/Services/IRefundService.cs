using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRefundService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRefundServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRefundService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<Refund> Create(
        RefundCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Refund> Retrieve(
        RefundRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RefundRetrieveParams, CancellationToken)"/>
    Task<Refund> Retrieve(
        string refundID,
        RefundRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<RefundListPage> List(
        RefundListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRefundService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRefundServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRefundServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /refunds`, but is otherwise the
    /// same as <see cref="IRefundService.Create(RefundCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Refund>> Create(
        RefundCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /refunds/{refund_id}`, but is otherwise the
    /// same as <see cref="IRefundService.Retrieve(RefundRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Refund>> Retrieve(
        RefundRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RefundRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Refund>> Retrieve(
        string refundID,
        RefundRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /refunds`, but is otherwise the
    /// same as <see cref="IRefundService.List(RefundListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RefundListPage>> List(
        RefundListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
