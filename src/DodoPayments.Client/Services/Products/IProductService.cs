using System.Threading.Tasks;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Services.Products.Images;

namespace DodoPayments.Client.Services.Products;

public interface IProductService
{
    IImageService Images { get; }

    Task<Product> Create(ProductCreateParams parameters);

    Task<Product> Retrieve(ProductRetrieveParams parameters);

    Task Update(ProductUpdateParams parameters);

    Task<ProductListPageResponse> List(ProductListParams? parameters = null);

    Task Archive(ProductArchiveParams parameters);

    Task Unarchive(ProductUnarchiveParams parameters);

    Task<ProductUpdateFilesResponse> UpdateFiles(ProductUpdateFilesParams parameters);
}
