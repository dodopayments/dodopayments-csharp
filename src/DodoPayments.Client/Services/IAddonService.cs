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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<AddonResponse> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    );

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

    Task<AddonListPage> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

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
