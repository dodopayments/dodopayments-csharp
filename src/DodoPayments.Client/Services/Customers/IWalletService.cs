using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Services.Customers.Wallets;

namespace DodoPayments.Client.Services.Customers;

public interface IWalletService
{
    IWalletService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILedgerEntryService LedgerEntries { get; }

    Task<WalletListResponse> List(
        WalletListParams parameters,
        CancellationToken cancellationToken = default
    );
}
