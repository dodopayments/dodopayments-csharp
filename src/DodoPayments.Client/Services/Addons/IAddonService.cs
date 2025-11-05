using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Services.Addons;

public interface IAddonService
{
    IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<AddonResponse> Create(AddonCreateParams parameters);

    Task<AddonResponse> Retrieve(AddonRetrieveParams parameters);

    Task<AddonResponse> Update(AddonUpdateParams parameters);

    Task<AddonListPageResponse> List(AddonListParams? parameters = null);

    Task<AddonUpdateImagesResponse> UpdateImages(AddonUpdateImagesParams parameters);
}
