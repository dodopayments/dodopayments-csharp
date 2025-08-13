using System.Threading.Tasks;
using DodoPayments.Models.Customers;
using DodoPayments.Models.Customers.CustomerPortal;

namespace DodoPayments.Services.Customers.CustomerPortal;

public interface ICustomerPortalService
{
    Task<CustomerPortalSession> Create(CustomerPortalCreateParams parameters);
}
