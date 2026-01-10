using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.ShortLinks;

namespace DodoPayments.Client.Services.Products;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IShortLinkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IShortLinkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShortLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Gives a Short Checkout URL with custom slug for a product. Uses a Static
    /// Checkout URL under the hood.
    /// </summary>
    Task<ShortLinkCreateResponse> Create(
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ShortLinkCreateParams, CancellationToken)"/>
    Task<ShortLinkCreateResponse> Create(
        string id,
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all short links created by the business.
    /// </summary>
    Task<ShortLinkListPage> List(
        ShortLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IShortLinkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IShortLinkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShortLinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /products/{id}/short_links`, but is otherwise the
    /// same as <see cref="IShortLinkService.Create(ShortLinkCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ShortLinkCreateResponse>> Create(
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ShortLinkCreateParams, CancellationToken)"/>
    Task<HttpResponse<ShortLinkCreateResponse>> Create(
        string id,
        ShortLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /products/short_links`, but is otherwise the
    /// same as <see cref="IShortLinkService.List(ShortLinkListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ShortLinkListPage>> List(
        ShortLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
