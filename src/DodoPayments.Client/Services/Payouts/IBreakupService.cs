using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts.Breakup;
using DodoPayments.Client.Services.Payouts.Breakup;

namespace DodoPayments.Client.Services.Payouts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBreakupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBreakupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBreakupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDetailService Details { get; }

    /// <summary>
    /// Returns the breakdown of a payout by event type (payments, refunds, disputes,
    /// fees, etc.) in the payout's currency. Each amount is proportionally allocated
    /// based on USD equivalent values, ensuring the total sums exactly to the payout
    /// amount.
    /// </summary>
    Task<List<BreakupRetrieveResponse>> Retrieve(
        BreakupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BreakupRetrieveParams, CancellationToken)"/>
    Task<List<BreakupRetrieveResponse>> Retrieve(
        string payoutID,
        BreakupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBreakupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBreakupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBreakupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDetailServiceWithRawResponse Details { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /payouts/{payout_id}/breakup</c>, but is otherwise the
    /// same as <see cref="IBreakupService.Retrieve(BreakupRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<BreakupRetrieveResponse>>> Retrieve(
        BreakupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BreakupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<List<BreakupRetrieveResponse>>> Retrieve(
        string payoutID,
        BreakupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
