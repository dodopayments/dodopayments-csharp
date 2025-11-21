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
    IWalletService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILedgerEntryService LedgerEntries { get; }

    Task<WalletListResponse> List(
        WalletListParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<WalletListResponse> List(
        string customerID,
        WalletListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
