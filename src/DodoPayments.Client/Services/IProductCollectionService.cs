using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections;
using DodoPayments.Client.Services.ProductCollections;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProductCollectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProductCollectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductCollectionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGroupService Groups { get; }

    /// <summary>
    /// Sends a request to <c>post /product-collections</c>.
    /// </summary>
    Task<ProductCollectionCreateResponse> Create(
        ProductCollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /product-collections/{id}</c>.
    /// </summary>
    Task<ProductCollectionRetrieveResponse> Retrieve(
        ProductCollectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProductCollectionRetrieveParams, CancellationToken)"/>
    Task<ProductCollectionRetrieveResponse> Retrieve(
        string id,
        ProductCollectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /product-collections/{id}</c>.
    /// </summary>
    Task Update(
        ProductCollectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProductCollectionUpdateParams, CancellationToken)"/>
    Task Update(
        string id,
        ProductCollectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /product-collections</c>.
    /// </summary>
    Task<ProductCollectionListPage> List(
        ProductCollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>delete /product-collections/{id}</c>.
    /// </summary>
    Task Delete(
        ProductCollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProductCollectionDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        ProductCollectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>post /product-collections/{id}/unarchive</c>.
    /// </summary>
    Task<ProductCollectionUnarchiveResponse> Unarchive(
        ProductCollectionUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(ProductCollectionUnarchiveParams, CancellationToken)"/>
    Task<ProductCollectionUnarchiveResponse> Unarchive(
        string id,
        ProductCollectionUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>put /product-collections/{id}/images</c>.
    /// </summary>
    Task<ProductCollectionUpdateImagesResponse> UpdateImages(
        ProductCollectionUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateImages(ProductCollectionUpdateImagesParams, CancellationToken)"/>
    Task<ProductCollectionUpdateImagesResponse> UpdateImages(
        string id,
        ProductCollectionUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProductCollectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProductCollectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductCollectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    IGroupServiceWithRawResponse Groups { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /product-collections</c>, but is otherwise the
    /// same as <see cref="IProductCollectionService.Create(ProductCollectionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductCollectionCreateResponse>> Create(
        ProductCollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /product-collections/{id}</c>, but is otherwise the
    /// same as <see cref="IProductCollectionService.Retrieve(ProductCollectionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductCollectionRetrieveResponse>> Retrieve(
        ProductCollectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProductCollectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ProductCollectionRetrieveResponse>> Retrieve(
        string id,
        ProductCollectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /product-collections/{id}</c>, but is otherwise the
    /// same as <see cref="IProductCollectionService.Update(ProductCollectionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        ProductCollectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProductCollectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string id,
        ProductCollectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /product-collections</c>, but is otherwise the
    /// same as <see cref="IProductCollectionService.List(ProductCollectionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductCollectionListPage>> List(
        ProductCollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /product-collections/{id}</c>, but is otherwise the
    /// same as <see cref="IProductCollectionService.Delete(ProductCollectionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ProductCollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProductCollectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        ProductCollectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /product-collections/{id}/unarchive</c>, but is otherwise the
    /// same as <see cref="IProductCollectionService.Unarchive(ProductCollectionUnarchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductCollectionUnarchiveResponse>> Unarchive(
        ProductCollectionUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(ProductCollectionUnarchiveParams, CancellationToken)"/>
    Task<HttpResponse<ProductCollectionUnarchiveResponse>> Unarchive(
        string id,
        ProductCollectionUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /product-collections/{id}/images</c>, but is otherwise the
    /// same as <see cref="IProductCollectionService.UpdateImages(ProductCollectionUpdateImagesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductCollectionUpdateImagesResponse>> UpdateImages(
        ProductCollectionUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateImages(ProductCollectionUpdateImagesParams, CancellationToken)"/>
    Task<HttpResponse<ProductCollectionUpdateImagesResponse>> UpdateImages(
        string id,
        ProductCollectionUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
