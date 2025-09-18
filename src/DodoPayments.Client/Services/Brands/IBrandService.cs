using System.Threading.Tasks;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Services.Brands;

public interface IBrandService
{
    Task<Brand> Create(BrandCreateParams? parameters = null);

    /// <summary>
    /// Thin handler just calls `get_brand` and wraps in `Json(...)`
    /// </summary>
    Task<Brand> Retrieve(BrandRetrieveParams parameters);

    Task<Brand> Update(BrandUpdateParams parameters);

    Task<BrandListResponse> List(BrandListParams? parameters = null);

    Task<BrandUpdateImagesResponse> UpdateImages(BrandUpdateImagesParams parameters);
}
