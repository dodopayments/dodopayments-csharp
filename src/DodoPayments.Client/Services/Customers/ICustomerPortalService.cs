using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.CustomerPortal;

namespace DodoPayments.Client.Services.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICustomerPortalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomerPortalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerPortalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<CustomerPortalSession> Create(
        CustomerPortalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CustomerPortalCreateParams, CancellationToken)"/>
    Task<CustomerPortalSession> Create(
        string customerID,
        CustomerPortalCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICustomerPortalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomerPortalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerPortalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /customers/{customer_id}/customer-portal/session`, but is otherwise the
    /// same as <see cref="ICustomerPortalService.Create(CustomerPortalCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerPortalSession>> Create(
        CustomerPortalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CustomerPortalCreateParams, CancellationToken)"/>
    Task<HttpResponse<CustomerPortalSession>> Create(
        string customerID,
        CustomerPortalCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
