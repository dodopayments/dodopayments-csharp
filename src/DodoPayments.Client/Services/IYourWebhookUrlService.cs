using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.YourWebhookUrl;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IYourWebhookUrlService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IYourWebhookUrlServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IYourWebhookUrlService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /your-webhook-url</c>.
    /// </summary>
    Task Create(
        YourWebhookUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IYourWebhookUrlService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IYourWebhookUrlServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IYourWebhookUrlServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /your-webhook-url</c>, but is otherwise the
    /// same as <see cref="IYourWebhookUrlService.Create(YourWebhookUrlCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        YourWebhookUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
