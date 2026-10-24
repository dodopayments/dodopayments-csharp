using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services.Entitlements;

/// <inheritdoc/>
public sealed class TranslationService : ITranslationService
{
    readonly Lazy<ITranslationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITranslationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ITranslationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranslationService(this._client.WithOptions(modifier));
    }

    public TranslationService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TranslationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EntitlementTranslation> Update(
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementTranslation> Update(
        ApiEnum<string, Locale> locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Locale = locale }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntitlementTranslationsListResponse> List(
        TranslationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementTranslationsListResponse> List(
        string id,
        TranslationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        TranslationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        ApiEnum<string, Locale> locale,
        TranslationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { Locale = locale }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TranslationServiceWithRawResponse : ITranslationServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITranslationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TranslationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TranslationServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementTranslation>> Update(
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Locale == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.Locale' cannot be null");
        }

        HttpRequest<TranslationUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlementTranslation = await response
                    .Deserialize<EntitlementTranslation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlementTranslation.Validate();
                }
                return entitlementTranslation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementTranslation>> Update(
        ApiEnum<string, Locale> locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Locale = locale }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementTranslationsListResponse>> List(
        TranslationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TranslationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlementTranslationsListResponse = await response
                    .Deserialize<EntitlementTranslationsListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlementTranslationsListResponse.Validate();
                }
                return entitlementTranslationsListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementTranslationsListResponse>> List(
        string id,
        TranslationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TranslationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Locale == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.Locale' cannot be null");
        }

        HttpRequest<TranslationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ApiEnum<string, Locale> locale,
        TranslationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { Locale = locale }, cancellationToken);
    }
}
