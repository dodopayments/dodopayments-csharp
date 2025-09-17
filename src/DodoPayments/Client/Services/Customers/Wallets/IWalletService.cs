using System.Threading.Tasks;
using DodoPayments.Client.Models.Customers.Wallets;
using LedgerEntries = DodoPayments.Client.Services.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets;

public interface IWalletService
{
    LedgerEntries::ILedgerEntryService LedgerEntries { get; }

    Task<WalletListResponse> List(WalletListParams parameters);
}
