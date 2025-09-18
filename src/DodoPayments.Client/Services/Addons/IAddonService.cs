using System.Threading.Tasks;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Services.Addons;

public interface IAddonService
{
    Task<AddonResponse> Create(AddonCreateParams parameters);

    Task<AddonResponse> Retrieve(AddonRetrieveParams parameters);

    Task<AddonResponse> Update(AddonUpdateParams parameters);

    Task<AddonListPageResponse> List(AddonListParams? parameters = null);

    Task<AddonUpdateImagesResponse> UpdateImages(AddonUpdateImagesParams parameters);
}
