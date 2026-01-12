using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAddonService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAddonServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /addons<c/>.
    /// </summary>
    Task<AddonResponse> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /addons/{id}<c/>.
    /// </summary>
    Task<AddonResponse> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AddonRetrieveParams, CancellationToken)"/>
    Task<AddonResponse> Retrieve(
        string id,
        AddonRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /addons/{id}<c/>.
    /// </summary>
    Task<AddonResponse> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AddonUpdateParams, CancellationToken)"/>
    Task<AddonResponse> Update(
        string id,
        AddonUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /addons<c/>.
    /// </summary>
    Task<AddonListPage> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>put /addons/{id}/images<c/>.
    /// </summary>
    Task<AddonUpdateImagesResponse> UpdateImages(
        AddonUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateImages(AddonUpdateImagesParams, CancellationToken)"/>
    Task<AddonUpdateImagesResponse> UpdateImages(
        string id,
        AddonUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAddonService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAddonServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddonServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /addons`, but is otherwise the
    /// same as <see cref="IAddonService.Create(AddonCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonResponse>> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /addons/{id}`, but is otherwise the
    /// same as <see cref="IAddonService.Retrieve(AddonRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonResponse>> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AddonRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AddonResponse>> Retrieve(
        string id,
        AddonRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /addons/{id}`, but is otherwise the
    /// same as <see cref="IAddonService.Update(AddonUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonResponse>> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AddonUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AddonResponse>> Update(
        string id,
        AddonUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /addons`, but is otherwise the
    /// same as <see cref="IAddonService.List(AddonListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonListPage>> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /addons/{id}/images`, but is otherwise the
    /// same as <see cref="IAddonService.UpdateImages(AddonUpdateImagesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonUpdateImagesResponse>> UpdateImages(
        AddonUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateImages(AddonUpdateImagesParams, CancellationToken)"/>
    Task<HttpResponse<AddonUpdateImagesResponse>> UpdateImages(
        string id,
        AddonUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
