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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILedgerEntryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

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

    Task<LedgerEntryListPageResponse> List(
        LedgerEntryListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(LedgerEntryListParams, CancellationToken)"/>
    Task<LedgerEntryListPageResponse> List(
        string customerID,
        LedgerEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
