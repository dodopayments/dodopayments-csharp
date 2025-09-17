using System.Threading.Tasks;
using Dodopayments.Models.Products;
using Images = Dodopayments.Services.Products.Images;

namespace Dodopayments.Services.Products;

public interface IProductService
{
    Images::IImageService Images { get; }

    Task<Product> Create(ProductCreateParams parameters);

    Task<Product> Retrieve(ProductRetrieveParams parameters);

    Task Update(ProductUpdateParams parameters);

    Task<ProductListPageResponse> List(ProductListParams parameters);

    Task Archive(ProductArchiveParams parameters);

    Task Unarchive(ProductUnarchiveParams parameters);

    Task<ProductUpdateFilesResponse> UpdateFiles(ProductUpdateFilesParams parameters);
}
