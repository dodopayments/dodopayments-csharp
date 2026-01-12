using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Services.Customers.Wallets;

namespace DodoPayments.Client.Services.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWalletService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWalletServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWalletService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILedgerEntryService LedgerEntries { get; }

    /// <summary>
    /// Sends a request to <c>get /customers/{customer_id}/wallets<c/>.
    /// </summary>
    Task<WalletListResponse> List(
        WalletListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WalletListParams, CancellationToken)"/>
    Task<WalletListResponse> List(
        string customerID,
        WalletListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWalletService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWalletServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWalletServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILedgerEntryServiceWithRawResponse LedgerEntries { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/{customer_id}/wallets`, but is otherwise the
    /// same as <see cref="IWalletService.List(WalletListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WalletListResponse>> List(
        WalletListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WalletListParams, CancellationToken)"/>
    Task<HttpResponse<WalletListResponse>> List(
        string customerID,
        WalletListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
