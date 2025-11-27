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

    Task<RefundListPageResponse> List(
        RefundListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
