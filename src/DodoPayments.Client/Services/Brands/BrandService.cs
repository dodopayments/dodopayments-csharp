using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Services.Brands;

public sealed class BrandService : IBrandService
{
    readonly IDodoPaymentsClient _client;

    public BrandService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<Brand> Create(BrandCreateParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<BrandCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Brand>().ConfigureAwait(false);
    }

    public async Task<Brand> Retrieve(BrandRetrieveParams parameters)
    {
        HttpRequest<BrandRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Brand>().ConfigureAwait(false);
    }

    public async Task<Brand> Update(BrandUpdateParams parameters)
    {
        HttpRequest<BrandUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Brand>().ConfigureAwait(false);
    }

    public async Task<BrandListResponse> List(BrandListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<BrandListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BrandListResponse>().ConfigureAwait(false);
    }

    public async Task<BrandUpdateImagesResponse> UpdateImages(BrandUpdateImagesParams parameters)
    {
        HttpRequest<BrandUpdateImagesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BrandUpdateImagesResponse>().ConfigureAwait(false);
    }
}
