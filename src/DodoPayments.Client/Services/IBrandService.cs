using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBrandService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBrandServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<Brand> Create(
        BrandCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Thin handler just calls `get_brand` and wraps in `Json(...)`
    /// </summary>
    Task<Brand> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<Brand> Retrieve(
        string id,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<Brand> Update(BrandUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<Brand> Update(
        string id,
        BrandUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<BrandListResponse> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<BrandUpdateImagesResponse> UpdateImages(
        BrandUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateImages(BrandUpdateImagesParams, CancellationToken)"/>
    Task<BrandUpdateImagesResponse> UpdateImages(
        string id,
        BrandUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBrandService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBrandServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /brands`, but is otherwise the
    /// same as <see cref="IBrandService.Create(BrandCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Brand>> Create(
        BrandCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /brands/{id}`, but is otherwise the
    /// same as <see cref="IBrandService.Retrieve(BrandRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Brand>> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Brand>> Retrieve(
        string id,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /brands/{id}`, but is otherwise the
    /// same as <see cref="IBrandService.Update(BrandUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Brand>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Brand>> Update(
        string id,
        BrandUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /brands`, but is otherwise the
    /// same as <see cref="IBrandService.List(BrandListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandListResponse>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /brands/{id}/images`, but is otherwise the
    /// same as <see cref="IBrandService.UpdateImages(BrandUpdateImagesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandUpdateImagesResponse>> UpdateImages(
        BrandUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateImages(BrandUpdateImagesParams, CancellationToken)"/>
    Task<HttpResponse<BrandUpdateImagesResponse>> UpdateImages(
        string id,
        BrandUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
