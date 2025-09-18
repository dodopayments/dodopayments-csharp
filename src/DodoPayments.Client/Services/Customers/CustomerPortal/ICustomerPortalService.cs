using System.Threading.Tasks;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.CustomerPortal;

namespace DodoPayments.Client.Services.Customers.CustomerPortal;

public interface ICustomerPortalService
{
    Task<CustomerPortalSession> Create(CustomerPortalCreateParams parameters);
}
