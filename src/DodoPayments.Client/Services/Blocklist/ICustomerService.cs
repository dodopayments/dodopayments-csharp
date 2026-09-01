using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers;
using DodoPayments.Client.Services.Blocklist.Customers;

namespace DodoPayments.Client.Services.Blocklist;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    INoteService Notes { get; }

    /// <summary>
    /// Sends a request to <c>post /blocklist/customers</c>.
    /// </summary>
    Task<BlockedCustomer> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /blocklist/customers/{entry_id}</c>.
    /// </summary>
    Task<BlockedCustomer> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CustomerRetrieveParams, CancellationToken)"/>
    Task<BlockedCustomer> Retrieve(
        string entryID,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /blocklist/customers</c>.
    /// </summary>
    Task<CustomerListPage> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>delete /blocklist/customers/{entry_id}</c>.
    /// </summary>
    Task Delete(CustomerDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CustomerDeleteParams, CancellationToken)"/>
    Task Delete(
        string entryID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICustomerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    INoteServiceWithRawResponse Notes { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /blocklist/customers</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Create(CustomerCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BlockedCustomer>> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /blocklist/customers/{entry_id}</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Retrieve(CustomerRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BlockedCustomer>> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CustomerRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BlockedCustomer>> Retrieve(
        string entryID,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /blocklist/customers</c>, but is otherwise the
    /// same as <see cref="ICustomerService.List(CustomerListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerListPage>> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /blocklist/customers/{entry_id}</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Delete(CustomerDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CustomerDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CustomerDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string entryID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
