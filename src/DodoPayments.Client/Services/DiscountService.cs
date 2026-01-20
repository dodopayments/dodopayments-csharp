using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class DiscountService : IDiscountService
{
    readonly Lazy<IDiscountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDiscountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IDiscountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DiscountService(this._client.WithOptions(modifier));
    }

    public DiscountService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DiscountServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Discount> Create(
        DiscountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Discount> Retrieve(
        DiscountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Discount> Retrieve(
        string discountID,
        DiscountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DiscountID = discountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Discount> Update(
        DiscountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Discount> Update(
        string discountID,
        DiscountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { DiscountID = discountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DiscountListPage> List(
        DiscountListParams? parameters = null,
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
        DiscountDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string discountID,
        DiscountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { DiscountID = discountID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Discount> RetrieveByCode(
        DiscountRetrieveByCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveByCode(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Discount> RetrieveByCode(
        string code,
        DiscountRetrieveByCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByCode(parameters with { Code = code }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DiscountServiceWithRawResponse : IDiscountServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDiscountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DiscountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DiscountServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Discount>> Create(
        DiscountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DiscountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var discount = await response.Deserialize<Discount>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    discount.Validate();
                }
                return discount;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Discount>> Retrieve(
        DiscountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DiscountID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.DiscountID' cannot be null");
        }

        HttpRequest<DiscountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var discount = await response.Deserialize<Discount>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    discount.Validate();
                }
                return discount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Discount>> Retrieve(
        string discountID,
        DiscountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DiscountID = discountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Discount>> Update(
        DiscountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DiscountID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.DiscountID' cannot be null");
        }

        HttpRequest<DiscountUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var discount = await response.Deserialize<Discount>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    discount.Validate();
                }
                return discount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Discount>> Update(
        string discountID,
        DiscountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { DiscountID = discountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DiscountListPage>> List(
        DiscountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DiscountListParams> request = new()
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
                    .Deserialize<DiscountListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DiscountListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DiscountDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DiscountID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.DiscountID' cannot be null");
        }

        HttpRequest<DiscountDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string discountID,
        DiscountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DiscountID = discountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Discount>> RetrieveByCode(
        DiscountRetrieveByCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<DiscountRetrieveByCodeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var discount = await response.Deserialize<Discount>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    discount.Validate();
                }
                return discount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Discount>> RetrieveByCode(
        string code,
        DiscountRetrieveByCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByCode(parameters with { Code = code }, cancellationToken);
    }
}
