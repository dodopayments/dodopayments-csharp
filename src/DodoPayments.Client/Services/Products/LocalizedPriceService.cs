using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Products.LocalizedPrices;

namespace DodoPayments.Client.Services.Products;

/// <inheritdoc/>
public sealed class LocalizedPriceService : ILocalizedPriceService
{
    readonly Lazy<ILocalizedPriceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILocalizedPriceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ILocalizedPriceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LocalizedPriceService(this._client.WithOptions(modifier));
    }

    public LocalizedPriceService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new LocalizedPriceServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<LocalizedPrice> Create(
        LocalizedPriceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LocalizedPrice> Create(
        string productID,
        LocalizedPriceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ProductID = productID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LocalizedPrice> Retrieve(
        LocalizedPriceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LocalizedPrice> Retrieve(
        string id,
        LocalizedPriceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LocalizedPrice> Update(
        LocalizedPriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LocalizedPrice> Update(
        string id,
        LocalizedPriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ListLocalizedPricesResponse> List(
        LocalizedPriceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ListLocalizedPricesResponse> List(
        string productID,
        LocalizedPriceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ProductID = productID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Archive(
        LocalizedPriceArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string id,
        LocalizedPriceArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Archive(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class LocalizedPriceServiceWithRawResponse : ILocalizedPriceServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILocalizedPriceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LocalizedPriceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LocalizedPriceServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LocalizedPrice>> Create(
        LocalizedPriceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProductID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ProductID' cannot be null");
        }

        HttpRequest<LocalizedPriceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var localizedPrice = await response
                    .Deserialize<LocalizedPrice>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    localizedPrice.Validate();
                }
                return localizedPrice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LocalizedPrice>> Create(
        string productID,
        LocalizedPriceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ProductID = productID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LocalizedPrice>> Retrieve(
        LocalizedPriceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LocalizedPriceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var localizedPrice = await response
                    .Deserialize<LocalizedPrice>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    localizedPrice.Validate();
                }
                return localizedPrice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LocalizedPrice>> Retrieve(
        string id,
        LocalizedPriceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LocalizedPrice>> Update(
        LocalizedPriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LocalizedPriceUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var localizedPrice = await response
                    .Deserialize<LocalizedPrice>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    localizedPrice.Validate();
                }
                return localizedPrice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LocalizedPrice>> Update(
        string id,
        LocalizedPriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ListLocalizedPricesResponse>> List(
        LocalizedPriceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProductID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ProductID' cannot be null");
        }

        HttpRequest<LocalizedPriceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var listLocalizedPricesResponse = await response
                    .Deserialize<ListLocalizedPricesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    listLocalizedPricesResponse.Validate();
                }
                return listLocalizedPricesResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ListLocalizedPricesResponse>> List(
        string productID,
        LocalizedPriceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ProductID = productID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        LocalizedPriceArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LocalizedPriceArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string id,
        LocalizedPriceArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { ID = id }, cancellationToken);
    }
}
