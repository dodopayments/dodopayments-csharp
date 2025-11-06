using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Products.Images;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Services.Products;

public sealed class ProductService : IProductService
{
    public IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductService(this._client.WithOptions(modifier));
    }

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

    public async Task<Products::Product> Create(Products::ProductCreateParams parameters)
    {
        HttpRequest<Products::ProductCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var product = await response.Deserialize<Products::Product>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            product.Validate();
        }
        return product;
    }

    public async Task<Products::Product> Retrieve(Products::ProductRetrieveParams parameters)
    {
        HttpRequest<Products::ProductRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var product = await response.Deserialize<Products::Product>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            product.Validate();
        }
        return product;
    }

    public async Task Update(Products::ProductUpdateParams parameters)
    {
        HttpRequest<Products::ProductUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<Products::ProductListPageResponse> List(
        Products::ProductListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<Products::ProductListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<Products::ProductListPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Archive(Products::ProductArchiveParams parameters)
    {
        HttpRequest<Products::ProductArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task Unarchive(Products::ProductUnarchiveParams parameters)
    {
        HttpRequest<Products::ProductUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<Products::ProductUpdateFilesResponse> UpdateFiles(
        Products::ProductUpdateFilesParams parameters
    )
    {
        HttpRequest<Products::ProductUpdateFilesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Products::ProductUpdateFilesResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
