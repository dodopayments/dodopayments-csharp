using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IHeaderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IHeaderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHeaderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a webhook by id
    /// </summary>
    Task<HeaderRetrieveResponse> Retrieve(
        HeaderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(HeaderRetrieveParams, CancellationToken)"/>
    Task<HeaderRetrieveResponse> Retrieve(
        string webhookID,
        HeaderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Patch a webhook by id
    /// </summary>
    Task Update(HeaderUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(HeaderUpdateParams, CancellationToken)"/>
    Task Update(
        string webhookID,
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IHeaderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IHeaderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHeaderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /webhooks/{webhook_id}/headers`, but is otherwise the
    /// same as <see cref="IHeaderService.Retrieve(HeaderRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<HeaderRetrieveResponse>> Retrieve(
        HeaderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(HeaderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<HeaderRetrieveResponse>> Retrieve(
        string webhookID,
        HeaderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /webhooks/{webhook_id}/headers`, but is otherwise the
    /// same as <see cref="IHeaderService.Update(HeaderUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(HeaderUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string webhookID,
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}
