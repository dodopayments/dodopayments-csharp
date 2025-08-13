using System.Threading.Tasks;
using DodoPayments.Models.Products;
using Images = DodoPayments.Services.Products.Images;

namespace DodoPayments.Services.Products;

public interface IProductService
{
    Images::IImageService Images { get; }

    Task<Product> Create(ProductCreateParams parameters);

    Task<Product> Retrieve(ProductRetrieveParams parameters);

    Task Update(ProductUpdateParams parameters);

    Task<ProductListPageResponse> List(ProductListParams parameters);

    Task Delete(ProductDeleteParams parameters);

    Task Unarchive(ProductUnarchiveParams parameters);

    Task<ProductUpdateFilesResponse> UpdateFiles(ProductUpdateFilesParams parameters);
}
