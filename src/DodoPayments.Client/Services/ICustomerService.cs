using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Services.Customers;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    /// <inheritdoc cref="Retrieve(CustomerRetrieveParams, CancellationToken)"/>
    Task<Customer> Retrieve(
        string customerID,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<Customer> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomerUpdateParams, CancellationToken)"/>
    Task<Customer> Update(
        string customerID,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<CustomerListPageResponse> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<CustomerRetrievePaymentMethodsResponse> RetrievePaymentMethods(
        CustomerRetrievePaymentMethodsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrievePaymentMethods(CustomerRetrievePaymentMethodsParams, CancellationToken)"/>
    Task<CustomerRetrievePaymentMethodsResponse> RetrievePaymentMethods(
        string customerID,
        CustomerRetrievePaymentMethodsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
