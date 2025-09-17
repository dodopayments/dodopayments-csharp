using System.Threading.Tasks;
using Dodopayments.Models.Customers.Wallets;
using LedgerEntries = Dodopayments.Services.Customers.Wallets.LedgerEntries;

namespace Dodopayments.Services.Customers.Wallets;

public interface IWalletService
{
    LedgerEntries::ILedgerEntryService LedgerEntries { get; }

    Task<WalletListResponse> List(WalletListParams parameters);
}
