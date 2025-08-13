using System.Threading.Tasks;
using DodoPayments.Models.Customers;
using CustomerPortal = DodoPayments.Services.Customers.CustomerPortal;

namespace DodoPayments.Services.Customers;

public interface ICustomerService
{
    CustomerPortal::ICustomerPortalService CustomerPortal { get; }

    Task<Customer> Create(CustomerCreateParams parameters);

    Task<Customer> Retrieve(CustomerRetrieveParams parameters);

    Task<Customer> Update(CustomerUpdateParams parameters);

    Task<CustomerListPageResponse> List(CustomerListParams parameters);
}
