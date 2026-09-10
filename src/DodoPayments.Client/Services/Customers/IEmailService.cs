using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Services.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns every transactional email sent to this customer in the last 180 days,
    /// newest first, with its delivery outcome. Delivery status comes from the email
    /// provider and is as fresh as replication, typically seconds.
    /// </summary>
    Task<EmailListPage> List(
        EmailListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EmailListParams, CancellationToken)"/>
    Task<EmailListPage> List(
        string customerID,
        EmailListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the email exactly as it was sent, plus the reason it failed when it did.
    /// Some emails have no body to show: an authentication email carries a live login
    /// token, a blocked email never reached the provider, and the provider clears
    /// bodies at 180 days.
    /// </summary>
    Task<EmailBody> RetrieveBody(
        EmailRetrieveBodyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveBody(EmailRetrieveBodyParams, CancellationToken)"/>
    Task<EmailBody> RetrieveBody(
        string emailLogID,
        EmailRetrieveBodyParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEmailService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /customers/{customer_id}/emails</c>, but is otherwise the
    /// same as <see cref="IEmailService.List(EmailListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EmailListPage>> List(
        EmailListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EmailListParams, CancellationToken)"/>
    Task<HttpResponse<EmailListPage>> List(
        string customerID,
        EmailListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /customers/{customer_id}/emails/{email_log_id}/body</c>, but is otherwise the
    /// same as <see cref="IEmailService.RetrieveBody(EmailRetrieveBodyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EmailBody>> RetrieveBody(
        EmailRetrieveBodyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveBody(EmailRetrieveBodyParams, CancellationToken)"/>
    Task<HttpResponse<EmailBody>> RetrieveBody(
        string emailLogID,
        EmailRetrieveBodyParams parameters,
        CancellationToken cancellationToken = default
    );
}
