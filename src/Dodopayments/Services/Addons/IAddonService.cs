using System.Threading.Tasks;
using Dodopayments.Models.Addons;

namespace Dodopayments.Services.Addons;

public interface IAddonService
{
    Task<AddonResponse> Create(AddonCreateParams parameters);

    Task<AddonResponse> Retrieve(AddonRetrieveParams parameters);

    Task<AddonResponse> Update(AddonUpdateParams parameters);

    Task<AddonListPageResponse> List(AddonListParams parameters);

    Task<AddonUpdateImagesResponse> UpdateImages(AddonUpdateImagesParams parameters);
}
