using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Services.Products;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class ProductService : IProductService
{
    readonly Lazy<IProductServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProductServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductService(this._client.WithOptions(modifier));
    }

    public ProductService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProductServiceWithRawResponse(client.WithRawResponse));
        _images = new(() => new ImageService(client));
        _shortLinks = new(() => new ShortLinkService(client));
    }

    readonly Lazy<IImageService> _images;
    public IImageService Images
    {
        get { return _images.Value; }
    }

    readonly Lazy<IShortLinkService> _shortLinks;
    public IShortLinkService ShortLinks
    {
        get { return _shortLinks.Value; }
    }

    /// <inheritdoc/>
    public async Task<Product> Create(
        ProductCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Product> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Product> Retrieve(
        string id,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        ProductUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string id,
        ProductUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProductListPage> List(
        ProductListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Archive(
        ProductArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string id,
        ProductArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Unarchive(
        ProductUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Unarchive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Unarchive(
        string id,
        ProductUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Unarchive(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProductUpdateFilesResponse> UpdateFiles(
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateFiles(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProductUpdateFilesResponse> UpdateFiles(
        string id,
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateFiles(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ProductServiceWithRawResponse : IProductServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProductServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProductServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _images = new(() => new ImageServiceWithRawResponse(client));
        _shortLinks = new(() => new ShortLinkServiceWithRawResponse(client));
    }

    readonly Lazy<IImageServiceWithRawResponse> _images;
    public IImageServiceWithRawResponse Images
    {
        get { return _images.Value; }
    }

    readonly Lazy<IShortLinkServiceWithRawResponse> _shortLinks;
    public IShortLinkServiceWithRawResponse ShortLinks
    {
        get { return _shortLinks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Product>> Create(
        ProductCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var product = await response.Deserialize<Product>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    product.Validate();
                }
                return product;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Product>> Retrieve(
        ProductRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var product = await response.Deserialize<Product>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    product.Validate();
                }
                return product;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Product>> Retrieve(
        string id,
        ProductRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        ProductUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductUpdateParams> request = new()
        {
            Method = DodoPaymentsClient.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string id,
        ProductUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ProductListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ProductListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        ProductArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string id,
        ProductArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unarchive(
        ProductUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unarchive(
        string id,
        ProductUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unarchive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductUpdateFilesResponse>> UpdateFiles(
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductUpdateFilesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ProductUpdateFilesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ProductUpdateFilesResponse>> UpdateFiles(
        string id,
        ProductUpdateFilesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateFiles(parameters with { ID = id }, cancellationToken);
    }
}
