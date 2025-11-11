using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Services;

public interface IAddonService
{
    IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<AddonResponse> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<AddonResponse> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<AddonResponse> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<AddonListPageResponse> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<AddonUpdateImagesResponse> UpdateImages(
        AddonUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    );
}
