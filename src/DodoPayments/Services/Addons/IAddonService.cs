using System.Threading.Tasks;
using DodoPayments.Models.Addons;

namespace DodoPayments.Services.Addons;

public interface IAddonService
{
    Task<AddonResponse> Create(AddonCreateParams parameters);

    Task<AddonResponse> Retrieve(AddonRetrieveParams parameters);

    Task<AddonResponse> Update(AddonUpdateParams parameters);

    Task<AddonListPageResponse> List(AddonListParams parameters);

    Task<AddonUpdateImagesResponse> UpdateImages(AddonUpdateImagesParams parameters);
}
