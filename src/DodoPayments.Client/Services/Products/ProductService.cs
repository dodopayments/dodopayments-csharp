using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Services.Products.Images;

namespace DodoPayments.Client.Services.Products;

public sealed class ProductService : IProductService
{
    readonly IDodoPaymentsClient _client;

    public ProductService(IDodoPaymentsClient client)
    {
        _client = client;
        _images = new(() => new ImageService(client));
    }

    readonly Lazy<IImageService> _images;
    public IImageService Images
    {
        get { return _images.Value; }
    }

    public async Task<Product> Create(ProductCreateParams parameters)
    {
        HttpRequest<ProductCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Product>().ConfigureAwait(false);
    }

    public async Task<Product> Retrieve(ProductRetrieveParams parameters)
    {
        HttpRequest<ProductRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Product>().ConfigureAwait(false);
    }

    public async Task Update(ProductUpdateParams parameters)
    {
        HttpRequest<ProductUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<ProductListPageResponse> List(ProductListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ProductListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ProductListPageResponse>().ConfigureAwait(false);
    }

    public async Task Archive(ProductArchiveParams parameters)
    {
        HttpRequest<ProductArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task Unarchive(ProductUnarchiveParams parameters)
    {
        HttpRequest<ProductUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<ProductUpdateFilesResponse> UpdateFiles(ProductUpdateFilesParams parameters)
    {
        HttpRequest<ProductUpdateFilesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ProductUpdateFilesResponse>().ConfigureAwait(false);
    }
}
