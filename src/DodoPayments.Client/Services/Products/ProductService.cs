using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Services.Products.Images;

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

    public async Task<Product> Create(
        ProductCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var product = await response.Deserialize<Product>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            product.Validate();
        }
        return product;
    }

    public async Task<Product> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var product = await response.Deserialize<Product>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            product.Validate();
        }
        return product;
    }

    public async Task Update(
        ProductUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<ProductListPageResponse> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProductListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<ProductListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Archive(
        ProductArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Unarchive(
        ProductUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<ProductUpdateFilesResponse> UpdateFiles(
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductUpdateFilesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ProductUpdateFilesResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
