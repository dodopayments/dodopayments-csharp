using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Services.Addons;

public sealed class AddonService : IAddonService
{
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
        return await response.Deserialize<AddonResponse>().ConfigureAwait(false);
    }

    public async Task<AddonResponse> Retrieve(AddonRetrieveParams parameters)
    {
        HttpRequest<AddonRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AddonResponse>().ConfigureAwait(false);
    }

    public async Task<AddonResponse> Update(AddonUpdateParams parameters)
    {
        HttpRequest<AddonUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AddonResponse>().ConfigureAwait(false);
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
        return await response.Deserialize<AddonListPageResponse>().ConfigureAwait(false);
    }

    public async Task<AddonUpdateImagesResponse> UpdateImages(AddonUpdateImagesParams parameters)
    {
        HttpRequest<AddonUpdateImagesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AddonUpdateImagesResponse>().ConfigureAwait(false);
    }
}
