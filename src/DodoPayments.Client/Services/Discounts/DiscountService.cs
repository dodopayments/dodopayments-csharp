using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Services.Discounts;

public sealed class DiscountService : IDiscountService
{
    readonly IDodoPaymentsClient _client;

    public DiscountService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<Discount> Create(DiscountCreateParams parameters)
    {
        HttpRequest<DiscountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Discount>().ConfigureAwait(false);
    }

    public async Task<Discount> Retrieve(DiscountRetrieveParams parameters)
    {
        HttpRequest<DiscountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Discount>().ConfigureAwait(false);
    }

    public async Task<Discount> Update(DiscountUpdateParams parameters)
    {
        HttpRequest<DiscountUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Discount>().ConfigureAwait(false);
    }

    public async Task<DiscountListPageResponse> List(DiscountListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<DiscountListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<DiscountListPageResponse>().ConfigureAwait(false);
    }

    public async Task Delete(DiscountDeleteParams parameters)
    {
        HttpRequest<DiscountDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
