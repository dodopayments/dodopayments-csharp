using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services.CreditEntitlements;

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
    public async Task<CreditEntitlementTranslation> Update(
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
    public Task<CreditEntitlementTranslation> Update(
        ApiEnum<string, Locale> locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Locale = locale }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CreditEntitlementTranslationsListResponse> List(
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
    public Task<CreditEntitlementTranslationsListResponse> List(
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
    public async Task<HttpResponse<CreditEntitlementTranslation>> Update(
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
                var creditEntitlementTranslation = await response
                    .Deserialize<CreditEntitlementTranslation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditEntitlementTranslation.Validate();
                }
                return creditEntitlementTranslation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CreditEntitlementTranslation>> Update(
        ApiEnum<string, Locale> locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Locale = locale }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditEntitlementTranslationsListResponse>> List(
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
                var creditEntitlementTranslationsListResponse = await response
                    .Deserialize<CreditEntitlementTranslationsListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditEntitlementTranslationsListResponse.Validate();
                }
                return creditEntitlementTranslationsListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CreditEntitlementTranslationsListResponse>> List(
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
