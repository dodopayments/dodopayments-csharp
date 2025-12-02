using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Services;

/// <inheritdoc />
public sealed class DiscountService : IDiscountService
{
    /// <inheritdoc/>
    public IDiscountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DiscountService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public DiscountService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Discount> Create(
        DiscountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DiscountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var discount = await response
            .Deserialize<Discount>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            discount.Validate();
        }
        return discount;
    }

    /// <inheritdoc/>
    public async Task<Discount> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var discount = await response
            .Deserialize<Discount>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            discount.Validate();
        }
        return discount;
    }

    /// <inheritdoc/>
    public async Task<Discount> Retrieve(
        string discountID,
        DiscountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { DiscountID = discountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Discount> Update(
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
            Method = DodoPaymentsClient.PatchMethod,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var discount = await response
            .Deserialize<Discount>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            discount.Validate();
        }
        return discount;
    }

    /// <inheritdoc/>
    public async Task<Discount> Update(
        string discountID,
        DiscountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { DiscountID = discountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DiscountListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<DiscountListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task Delete(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string discountID,
        DiscountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { DiscountID = discountID }, cancellationToken);
    }
}
