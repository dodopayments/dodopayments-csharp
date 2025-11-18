using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IHeaderService
{
    IHeaderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a webhook by id
    /// </summary>
    Task<HeaderRetrieveResponse> Retrieve(
        HeaderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task Update(HeaderUpdateParams parameters, CancellationToken cancellationToken = default);
}
