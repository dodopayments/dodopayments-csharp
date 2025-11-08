using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets.LedgerEntries;

public interface ILedgerEntryService
{
    ILedgerEntryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<CustomerWallet> Create(
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<LedgerEntryListPageResponse> List(
        LedgerEntryListParams parameters,
        CancellationToken cancellationToken = default
    );
}
