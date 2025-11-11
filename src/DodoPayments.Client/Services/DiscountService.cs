using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Services;

public sealed class DiscountService : IDiscountService
{
    public IDiscountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DiscountService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public DiscountService(IDodoPaymentsClient client)
    {
        _client = client;
    }

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

    public async Task<Discount> Retrieve(
        DiscountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Discount> Update(
        DiscountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DiscountUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
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

    public async Task Delete(
        DiscountDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DiscountDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
