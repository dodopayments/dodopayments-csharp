using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.CustomerPortal;

namespace DodoPayments.Client.Services.Customers;

public interface ICustomerPortalService
{
    ICustomerPortalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<CustomerPortalSession> Create(
        CustomerPortalCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
