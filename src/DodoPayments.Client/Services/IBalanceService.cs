using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Balances;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBalanceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBalanceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>get /balances/ledger<c/>.
    /// </summary>
    Task<BalanceRetrieveLedgerPage> RetrieveLedger(
        BalanceRetrieveLedgerParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBalanceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBalanceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /balances/ledger`, but is otherwise the
    /// same as <see cref="IBalanceService.RetrieveLedger(BalanceRetrieveLedgerParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BalanceRetrieveLedgerPage>> RetrieveLedger(
        BalanceRetrieveLedgerParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
