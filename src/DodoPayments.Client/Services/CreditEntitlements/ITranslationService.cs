using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services.CreditEntitlements;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITranslationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITranslationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranslationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates or replaces the translation of one locale. The response is 201 for a new
    /// locale and 200 for a replaced locale.
    /// </summary>
    Task<CreditEntitlementTranslation> Update(
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TranslationUpdateParams, CancellationToken)"/>
    Task<CreditEntitlementTranslation> Update(
        ApiEnum<string, Locale> locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the translations, for all the locales or for the locales of the filter.
    /// </summary>
    Task<CreditEntitlementTranslationsListResponse> List(
        TranslationListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TranslationListParams, CancellationToken)"/>
    Task<CreditEntitlementTranslationsListResponse> List(
        string id,
        TranslationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the translation of one locale.
    /// </summary>
    Task Delete(TranslationDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TranslationDeleteParams, CancellationToken)"/>
    Task Delete(
        ApiEnum<string, Locale> locale,
        TranslationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITranslationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITranslationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranslationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>put /credit-entitlements/{id}/translations/{locale}</c>, but is otherwise the
    /// same as <see cref="ITranslationService.Update(TranslationUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditEntitlementTranslation>> Update(
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TranslationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CreditEntitlementTranslation>> Update(
        ApiEnum<string, Locale> locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /credit-entitlements/{id}/translations</c>, but is otherwise the
    /// same as <see cref="ITranslationService.List(TranslationListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditEntitlementTranslationsListResponse>> List(
        TranslationListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TranslationListParams, CancellationToken)"/>
    Task<HttpResponse<CreditEntitlementTranslationsListResponse>> List(
        string id,
        TranslationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /credit-entitlements/{id}/translations/{locale}</c>, but is otherwise the
    /// same as <see cref="ITranslationService.Delete(TranslationDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TranslationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TranslationDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        ApiEnum<string, Locale> locale,
        TranslationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
