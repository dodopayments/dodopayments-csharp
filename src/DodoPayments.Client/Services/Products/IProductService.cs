using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Products.Images;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Services.Products;

public interface IProductService
{
    IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IImageService Images { get; }

    Task<Products::Product> Create(
        Products::ProductCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Products::Product> Retrieve(
        Products::ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task Update(
        Products::ProductUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Products::ProductListPageResponse> List(
        Products::ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Archive(
        Products::ProductArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task Unarchive(
        Products::ProductUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<Products::ProductUpdateFilesResponse> UpdateFiles(
        Products::ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    );
}
