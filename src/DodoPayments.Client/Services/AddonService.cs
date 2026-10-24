using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Addons;
using DodoPayments.Client.Services.Addons;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class AddonService : IAddonService
{
    readonly Lazy<IAddonServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAddonServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddonService(this._client.WithOptions(modifier));
    }

    public AddonService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AddonServiceWithRawResponse(client.WithRawResponse));
        _translations = new(() => new TranslationService(client));
    }

    readonly Lazy<ITranslationService> _translations;
    public ITranslationService Translations
    {
        get { return _translations.Value; }
    }

    /// <inheritdoc/>
    public async Task<AddonResponse> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddonResponse> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonResponse> Retrieve(
        string id,
        AddonRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonResponse> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonResponse> Update(
        string id,
        AddonUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonListPage> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(AddonDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        AddonDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Unarchive(
        AddonUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Unarchive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Unarchive(
        string id,
        AddonUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Unarchive(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddonUpdateImagesResponse> UpdateImages(
        AddonUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateImages(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonUpdateImagesResponse> UpdateImages(
        string id,
        AddonUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateImages(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AddonServiceWithRawResponse : IAddonServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAddonServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddonServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AddonServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _translations = new(() => new TranslationServiceWithRawResponse(client));
    }

    readonly Lazy<ITranslationServiceWithRawResponse> _translations;
    public ITranslationServiceWithRawResponse Translations
    {
        get { return _translations.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonResponse>> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddonCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addonResponse = await response
                    .Deserialize<AddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addonResponse.Validate();
                }
                return addonResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonResponse>> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addonResponse = await response
                    .Deserialize<AddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addonResponse.Validate();
                }
                return addonResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonResponse>> Retrieve(
        string id,
        AddonRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonResponse>> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addonResponse = await response
                    .Deserialize<AddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addonResponse.Validate();
                }
                return addonResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonResponse>> Update(
        string id,
        AddonUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<AddonListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AddonListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        AddonDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        AddonDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unarchive(
        AddonUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unarchive(
        string id,
        AddonUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unarchive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonUpdateImagesResponse>> UpdateImages(
        AddonUpdateImagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonUpdateImagesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AddonUpdateImagesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonUpdateImagesResponse>> UpdateImages(
        string id,
        AddonUpdateImagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateImages(parameters with { ID = id }, cancellationToken);
    }
}
