using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILedgerEntryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILedgerEntryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILedgerEntryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /customers/{customer_id}/wallets/ledger-entries<c/>.
    /// </summary>
    Task<CustomerWallet> Create(
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LedgerEntryCreateParams, CancellationToken)"/>
    Task<CustomerWallet> Create(
        string customerID,
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /customers/{customer_id}/wallets/ledger-entries<c/>.
    /// </summary>
    Task<LedgerEntryListPage> List(
        LedgerEntryListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(LedgerEntryListParams, CancellationToken)"/>
    Task<LedgerEntryListPage> List(
        string customerID,
        LedgerEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILedgerEntryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILedgerEntryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILedgerEntryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /customers/{customer_id}/wallets/ledger-entries`, but is otherwise the
    /// same as <see cref="ILedgerEntryService.Create(LedgerEntryCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerWallet>> Create(
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LedgerEntryCreateParams, CancellationToken)"/>
    Task<HttpResponse<CustomerWallet>> Create(
        string customerID,
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/{customer_id}/wallets/ledger-entries`, but is otherwise the
    /// same as <see cref="ILedgerEntryService.List(LedgerEntryListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LedgerEntryListPage>> List(
        LedgerEntryListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(LedgerEntryListParams, CancellationToken)"/>
    Task<HttpResponse<LedgerEntryListPage>> List(
        string customerID,
        LedgerEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
