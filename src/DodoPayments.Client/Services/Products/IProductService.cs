using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Services.Products.Images;

namespace DodoPayments.Client.Services.Products;

public interface IProductService
{
    IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IImageService Images { get; }

    Task<Product> Create(
        ProductCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Product> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task Update(ProductUpdateParams parameters, CancellationToken cancellationToken = default);

    Task<ProductListPageResponse> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Archive(ProductArchiveParams parameters, CancellationToken cancellationToken = default);

    Task Unarchive(
        ProductUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<ProductUpdateFilesResponse> UpdateFiles(
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    );
}
