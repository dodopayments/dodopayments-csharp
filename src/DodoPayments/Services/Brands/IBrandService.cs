using System.Threading.Tasks;
using DodoPayments.Models.Brands;

namespace DodoPayments.Services.Brands;

public interface IBrandService
{
    Task<Brand> Create(BrandCreateParams parameters);

    /// <summary>
    /// Thin handler just calls `get_brand` and wraps in `Json(...)`
    /// </summary>
    Task<Brand> Retrieve(BrandRetrieveParams parameters);

    Task<Brand> Update(BrandUpdateParams parameters);

    Task<BrandListResponse> List(BrandListParams parameters);

    Task<BrandUpdateImagesResponse> UpdateImages(BrandUpdateImagesParams parameters);
}
