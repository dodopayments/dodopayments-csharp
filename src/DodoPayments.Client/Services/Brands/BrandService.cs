using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Services.Brands;

public sealed class BrandService : IBrandService
{
    public IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrandService(this._client.WithOptions(modifier));
    }

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
        var brand = await response.Deserialize<Brand>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            brand.Validate();
        }
        return brand;
    }

    public async Task<Brand> Retrieve(BrandRetrieveParams parameters)
    {
        HttpRequest<BrandRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var brand = await response.Deserialize<Brand>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            brand.Validate();
        }
        return brand;
    }

    public async Task<Brand> Update(BrandUpdateParams parameters)
    {
        HttpRequest<BrandUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var brand = await response.Deserialize<Brand>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            brand.Validate();
        }
        return brand;
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
        var brands = await response.Deserialize<BrandListResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            brands.Validate();
        }
        return brands;
    }

    public async Task<BrandUpdateImagesResponse> UpdateImages(BrandUpdateImagesParams parameters)
    {
        HttpRequest<BrandUpdateImagesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BrandUpdateImagesResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
