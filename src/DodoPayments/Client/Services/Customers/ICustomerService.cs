using System.Threading.Tasks;
using DodoPayments.Client.Models.Customers;
using CustomerPortal = DodoPayments.Client.Services.Customers.CustomerPortal;
using Wallets = DodoPayments.Client.Services.Customers.Wallets;

namespace DodoPayments.Client.Services.Customers;

public interface ICustomerService
{
    CustomerPortal::ICustomerPortalService CustomerPortal { get; }

    Wallets::IWalletService Wallets { get; }

    Task<Customer> Create(CustomerCreateParams parameters);

    Task<Customer> Retrieve(CustomerRetrieveParams parameters);

    Task<Customer> Update(CustomerUpdateParams parameters);

    Task<CustomerListPageResponse> List(CustomerListParams parameters);
}
