using System.Threading.Tasks;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Services.Customers.CustomerPortal;
using DodoPayments.Client.Services.Customers.Wallets;

namespace DodoPayments.Client.Services.Customers;

public interface ICustomerService
{
    ICustomerPortalService CustomerPortal { get; }

    IWalletService Wallets { get; }

    Task<Customer> Create(CustomerCreateParams parameters);

    Task<Customer> Retrieve(CustomerRetrieveParams parameters);

    Task<Customer> Update(CustomerUpdateParams parameters);

    Task<CustomerListPageResponse> List(CustomerListParams? parameters = null);
}
