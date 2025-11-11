using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Services.Customers;

namespace DodoPayments.Client.Services;

public interface ICustomerService
{
    ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomerPortalService CustomerPortal { get; }

    IWalletService Wallets { get; }

    Task<Customer> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Customer> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Customer> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<CustomerListPageResponse> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
