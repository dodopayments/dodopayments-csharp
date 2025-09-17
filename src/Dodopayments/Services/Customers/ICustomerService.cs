using System.Threading.Tasks;
using Dodopayments.Models.Customers;
using CustomerPortal = Dodopayments.Services.Customers.CustomerPortal;
using Wallets = Dodopayments.Services.Customers.Wallets;

namespace Dodopayments.Services.Customers;

public interface ICustomerService
{
    CustomerPortal::ICustomerPortalService CustomerPortal { get; }

    Wallets::IWalletService Wallets { get; }

    Task<Customer> Create(CustomerCreateParams parameters);

    Task<Customer> Retrieve(CustomerRetrieveParams parameters);

    Task<Customer> Update(CustomerUpdateParams parameters);

    Task<CustomerListPageResponse> List(CustomerListParams parameters);
}
