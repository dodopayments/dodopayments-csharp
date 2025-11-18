using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPayoutService
{
    IPayoutService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<PayoutListPageResponse> List(
        PayoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
