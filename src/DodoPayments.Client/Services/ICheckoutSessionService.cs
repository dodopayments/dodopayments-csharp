using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckoutSessionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICheckoutSessionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckoutSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /checkouts<c/>.
    /// </summary>
    Task<CheckoutSessionResponse> Create(
        CheckoutSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /checkouts/{id}<c/>.
    /// </summary>
    Task<CheckoutSessionStatus> Retrieve(
        CheckoutSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckoutSessionRetrieveParams, CancellationToken)"/>
    Task<CheckoutSessionStatus> Retrieve(
        string id,
        CheckoutSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>post /checkouts/preview<c/>.
    /// </summary>
    Task<CheckoutSessionPreviewResponse> Preview(
        CheckoutSessionPreviewParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICheckoutSessionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICheckoutSessionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckoutSessionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /checkouts`, but is otherwise the
    /// same as <see cref="ICheckoutSessionService.Create(CheckoutSessionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckoutSessionResponse>> Create(
        CheckoutSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /checkouts/{id}`, but is otherwise the
    /// same as <see cref="ICheckoutSessionService.Retrieve(CheckoutSessionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckoutSessionStatus>> Retrieve(
        CheckoutSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckoutSessionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CheckoutSessionStatus>> Retrieve(
        string id,
        CheckoutSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /checkouts/preview`, but is otherwise the
    /// same as <see cref="ICheckoutSessionService.Preview(CheckoutSessionPreviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckoutSessionPreviewResponse>> Preview(
        CheckoutSessionPreviewParams parameters,
        CancellationToken cancellationToken = default
    );
}
