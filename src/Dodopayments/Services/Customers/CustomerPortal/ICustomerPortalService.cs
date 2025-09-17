using System.Threading.Tasks;
using Dodopayments.Models.Customers;
using Dodopayments.Models.Customers.CustomerPortal;

namespace Dodopayments.Services.Customers.CustomerPortal;

public interface ICustomerPortalService
{
    Task<CustomerPortalSession> Create(CustomerPortalCreateParams parameters);
}
