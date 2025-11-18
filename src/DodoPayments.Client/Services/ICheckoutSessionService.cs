using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckoutSessionService
{
    ICheckoutSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<CheckoutSessionResponse> Create(
        CheckoutSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<CheckoutSessionStatus> Retrieve(
        CheckoutSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
