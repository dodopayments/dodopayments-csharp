using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Services.Addons;

public sealed class AddonService : IAddonService
{
    public IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddonService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public AddonService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<AddonResponse> Create(AddonCreateParams parameters)
    {
        HttpRequest<AddonCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var addonResponse = await response.Deserialize<AddonResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            addonResponse.Validate();
        }
        return addonResponse;
    }

    public async Task<AddonResponse> Retrieve(AddonRetrieveParams parameters)
    {
        HttpRequest<AddonRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var addonResponse = await response.Deserialize<AddonResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            addonResponse.Validate();
        }
        return addonResponse;
    }

    public async Task<AddonResponse> Update(AddonUpdateParams parameters)
    {
        HttpRequest<AddonUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var addonResponse = await response.Deserialize<AddonResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            addonResponse.Validate();
        }
        return addonResponse;
    }

    public async Task<AddonListPageResponse> List(AddonListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<AddonListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<AddonListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<AddonUpdateImagesResponse> UpdateImages(AddonUpdateImagesParams parameters)
    {
        HttpRequest<AddonUpdateImagesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AddonUpdateImagesResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
