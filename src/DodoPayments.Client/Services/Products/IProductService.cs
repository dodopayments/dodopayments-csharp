using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Products.Images;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Services.Products;

public interface IProductService
{
    IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IImageService Images { get; }

    Task<Products::Product> Create(Products::ProductCreateParams parameters);

    Task<Products::Product> Retrieve(Products::ProductRetrieveParams parameters);

    Task Update(Products::ProductUpdateParams parameters);

    Task<Products::ProductListPageResponse> List(Products::ProductListParams? parameters = null);

    Task Archive(Products::ProductArchiveParams parameters);

    Task Unarchive(Products::ProductUnarchiveParams parameters);

    Task<Products::ProductUpdateFilesResponse> UpdateFiles(
        Products::ProductUpdateFilesParams parameters
    );
}
