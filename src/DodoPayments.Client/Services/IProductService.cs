using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Services.Products;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProductServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IImageService Images { get; }

    IShortLinkService ShortLinks { get; }

    /// <summary>
    /// Sends a request to <c>post /products<c/>.
    /// </summary>
    Task<Product> Create(
        ProductCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /products/{id}<c/>.
    /// </summary>
    Task<Product> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProductRetrieveParams, CancellationToken)"/>
    Task<Product> Retrieve(
        string id,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /products/{id}<c/>.
    /// </summary>
    Task Update(ProductUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ProductUpdateParams, CancellationToken)"/>
    Task Update(
        string id,
        ProductUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /products<c/>.
    /// </summary>
    Task<ProductListPage> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>delete /products/{id}<c/>.
    /// </summary>
    Task Archive(ProductArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(ProductArchiveParams, CancellationToken)"/>
    Task Archive(
        string id,
        ProductArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>post /products/{id}/unarchive<c/>.
    /// </summary>
    Task Unarchive(
        ProductUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(ProductUnarchiveParams, CancellationToken)"/>
    Task Unarchive(
        string id,
        ProductUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>put /products/{id}/files<c/>.
    /// </summary>
    Task<ProductUpdateFilesResponse> UpdateFiles(
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateFiles(ProductUpdateFilesParams, CancellationToken)"/>
    Task<ProductUpdateFilesResponse> UpdateFiles(
        string id,
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProductService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProductServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IImageServiceWithRawResponse Images { get; }

    IShortLinkServiceWithRawResponse ShortLinks { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /products`, but is otherwise the
    /// same as <see cref="IProductService.Create(ProductCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Product>> Create(
        ProductCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /products/{id}`, but is otherwise the
    /// same as <see cref="IProductService.Retrieve(ProductRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Product>> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProductRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Product>> Retrieve(
        string id,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /products/{id}`, but is otherwise the
    /// same as <see cref="IProductService.Update(ProductUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        ProductUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProductUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string id,
        ProductUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /products`, but is otherwise the
    /// same as <see cref="IProductService.List(ProductListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductListPage>> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /products/{id}`, but is otherwise the
    /// same as <see cref="IProductService.Archive(ProductArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        ProductArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(ProductArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string id,
        ProductArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /products/{id}/unarchive`, but is otherwise the
    /// same as <see cref="IProductService.Unarchive(ProductUnarchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Unarchive(
        ProductUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(ProductUnarchiveParams, CancellationToken)"/>
    Task<HttpResponse> Unarchive(
        string id,
        ProductUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /products/{id}/files`, but is otherwise the
    /// same as <see cref="IProductService.UpdateFiles(ProductUpdateFilesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductUpdateFilesResponse>> UpdateFiles(
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateFiles(ProductUpdateFilesParams, CancellationToken)"/>
    Task<HttpResponse<ProductUpdateFilesResponse>> UpdateFiles(
        string id,
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    );
}
