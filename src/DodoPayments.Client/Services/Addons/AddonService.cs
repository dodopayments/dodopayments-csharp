using System;
using System.Net.Http;
using System.Threading;
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

    public async Task<AddonResponse> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddonCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var addonResponse = await response
            .Deserialize<AddonResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            addonResponse.Validate();
        }
        return addonResponse;
    }

    public async Task<AddonResponse> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddonRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var addonResponse = await response
            .Deserialize<AddonResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            addonResponse.Validate();
        }
        return addonResponse;
    }

    public async Task<AddonResponse> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddonUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var addonResponse = await response
            .Deserialize<AddonResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            addonResponse.Validate();
        }
        return addonResponse;
    }

    public async Task<AddonListPageResponse> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AddonListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<AddonListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<AddonUpdateImagesResponse> UpdateImages(
        AddonUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddonUpdateImagesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AddonUpdateImagesResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
