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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

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

    Task<DisputeListPageResponse> List(
        DisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
