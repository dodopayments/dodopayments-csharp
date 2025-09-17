using System.Threading.Tasks;
using Dodopayments.Models.Customers.Wallets;
using Dodopayments.Models.Customers.Wallets.LedgerEntries;

namespace Dodopayments.Services.Customers.Wallets.LedgerEntries;

public interface ILedgerEntryService
{
    Task<CustomerWallet> Create(LedgerEntryCreateParams parameters);

    Task<LedgerEntryListPageResponse> List(LedgerEntryListParams parameters);
}
