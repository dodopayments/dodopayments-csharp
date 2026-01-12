using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Services.Products;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IImageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IImageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>put /products/{id}/images<c/>.
    /// </summary>
    Task<ImageUpdateResponse> Update(
        ImageUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ImageUpdateParams, CancellationToken)"/>
    Task<ImageUpdateResponse> Update(
        string id,
        ImageUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IImageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IImageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `put /products/{id}/images`, but is otherwise the
    /// same as <see cref="IImageService.Update(ImageUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ImageUpdateResponse>> Update(
        ImageUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ImageUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ImageUpdateResponse>> Update(
        string id,
        ImageUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
