using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.ProductCollections;
using DodoPayments.Client.Services.ProductCollections;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class ProductCollectionService : IProductCollectionService
{
    readonly Lazy<IProductCollectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProductCollectionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IProductCollectionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductCollectionService(this._client.WithOptions(modifier));
    }

    public ProductCollectionService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ProductCollectionServiceWithRawResponse(client.WithRawResponse)
        );
        _groups = new(() => new GroupService(client));
    }

    readonly Lazy<IGroupService> _groups;
    public IGroupService Groups
    {
        get { return _groups.Value; }
    }

    /// <inheritdoc/>
    public async Task<ProductCollection> Create(
        ProductCollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProductCollection> Retrieve(
        ProductCollectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProductCollection> Retrieve(
        string id,
        ProductCollectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        ProductCollectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string id,
        ProductCollectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProductCollectionListPage> List(
        ProductCollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ProductCollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        ProductCollectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProductCollectionUnarchiveResponse> Unarchive(
        ProductCollectionUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unarchive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProductCollectionUnarchiveResponse> Unarchive(
        string id,
        ProductCollectionUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unarchive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProductCollectionUpdateImagesResponse> UpdateImages(
        ProductCollectionUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateImages(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProductCollectionUpdateImagesResponse> UpdateImages(
        string id,
        ProductCollectionUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateImages(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ProductCollectionServiceWithRawResponse
    : IProductCollectionServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProductCollectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ProductCollectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProductCollectionServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _groups = new(() => new GroupServiceWithRawResponse(client));
    }

    readonly Lazy<IGroupServiceWithRawResponse> _groups;
    public IGroupServiceWithRawResponse Groups
    {
        get { return _groups.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductCollection>> Create(
        ProductCollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductCollectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var productCollection = await response
                    .Deserialize<ProductCollection>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    productCollection.Validate();
                }
                return productCollection;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductCollection>> Retrieve(
        ProductCollectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductCollectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var productCollection = await response
                    .Deserialize<ProductCollection>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    productCollection.Validate();
                }
                return productCollection;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ProductCollection>> Retrieve(
        string id,
        ProductCollectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        ProductCollectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductCollectionUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string id,
        ProductCollectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductCollectionListPage>> List(
        ProductCollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProductCollectionListParams> request = new()
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
                    .Deserialize<ProductCollectionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ProductCollectionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ProductCollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductCollectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        ProductCollectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductCollectionUnarchiveResponse>> Unarchive(
        ProductCollectionUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductCollectionUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ProductCollectionUnarchiveResponse>(token)
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
    public Task<HttpResponse<ProductCollectionUnarchiveResponse>> Unarchive(
        string id,
        ProductCollectionUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unarchive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductCollectionUpdateImagesResponse>> UpdateImages(
        ProductCollectionUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductCollectionUpdateImagesParams> request = new()
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
                    .Deserialize<ProductCollectionUpdateImagesResponse>(token)
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
    public Task<HttpResponse<ProductCollectionUpdateImagesResponse>> UpdateImages(
        string id,
        ProductCollectionUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateImages(parameters with { ID = id }, cancellationToken);
    }
}
