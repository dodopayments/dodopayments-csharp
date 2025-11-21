using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Services.Products;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
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
    Task<Product> Retrieve(
        string id,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Update(ProductUpdateParams parameters, CancellationToken cancellationToken = default);
    Task Update(
        string id,
        ProductUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<ProductListPageResponse> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Archive(ProductArchiveParams parameters, CancellationToken cancellationToken = default);
    Task Archive(
        string id,
        ProductArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task Unarchive(
        ProductUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );
    Task Unarchive(
        string id,
        ProductUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<ProductUpdateFilesResponse> UpdateFiles(
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<ProductUpdateFilesResponse> UpdateFiles(
        string id,
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    );
}
