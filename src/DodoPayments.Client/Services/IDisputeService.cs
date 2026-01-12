using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDisputeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDisputeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>get /disputes/{dispute_id}<c/>.
    /// </summary>
    Task<GetDispute> Retrieve(
        DisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DisputeRetrieveParams, CancellationToken)"/>
    Task<GetDispute> Retrieve(
        string disputeID,
        DisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /disputes<c/>.
    /// </summary>
    Task<DisputeListPage> List(
        DisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDisputeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDisputeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDisputeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /disputes/{dispute_id}`, but is otherwise the
    /// same as <see cref="IDisputeService.Retrieve(DisputeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GetDispute>> Retrieve(
        DisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DisputeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<GetDispute>> Retrieve(
        string disputeID,
        DisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /disputes`, but is otherwise the
    /// same as <see cref="IDisputeService.List(DisputeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DisputeListPage>> List(
        DisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
