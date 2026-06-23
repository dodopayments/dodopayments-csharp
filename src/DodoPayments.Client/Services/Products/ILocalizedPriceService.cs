using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.LocalizedPrices;

namespace DodoPayments.Client.Services.Products;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILocalizedPriceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILocalizedPriceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILocalizedPriceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /products/{product_id}/localized-prices</c>.
    /// </summary>
    Task<LocalizedPrice> Create(
        LocalizedPriceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LocalizedPriceCreateParams, CancellationToken)"/>
    Task<LocalizedPrice> Create(
        string productID,
        LocalizedPriceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /products/{product_id}/localized-prices/{id}</c>.
    /// </summary>
    Task<LocalizedPrice> Retrieve(
        LocalizedPriceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LocalizedPriceRetrieveParams, CancellationToken)"/>
    Task<LocalizedPrice> Retrieve(
        string id,
        LocalizedPriceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /products/{product_id}/localized-prices/{id}</c>.
    /// </summary>
    Task<LocalizedPrice> Update(
        LocalizedPriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LocalizedPriceUpdateParams, CancellationToken)"/>
    Task<LocalizedPrice> Update(
        string id,
        LocalizedPriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /products/{product_id}/localized-prices</c>.
    /// </summary>
    Task<ListLocalizedPricesResponse> List(
        LocalizedPriceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(LocalizedPriceListParams, CancellationToken)"/>
    Task<ListLocalizedPricesResponse> List(
        string productID,
        LocalizedPriceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>delete /products/{product_id}/localized-prices/{id}</c>.
    /// </summary>
    Task Archive(
        LocalizedPriceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(LocalizedPriceArchiveParams, CancellationToken)"/>
    Task Archive(
        string id,
        LocalizedPriceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILocalizedPriceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILocalizedPriceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILocalizedPriceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /products/{product_id}/localized-prices</c>, but is otherwise the
    /// same as <see cref="ILocalizedPriceService.Create(LocalizedPriceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LocalizedPrice>> Create(
        LocalizedPriceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LocalizedPriceCreateParams, CancellationToken)"/>
    Task<HttpResponse<LocalizedPrice>> Create(
        string productID,
        LocalizedPriceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /products/{product_id}/localized-prices/{id}</c>, but is otherwise the
    /// same as <see cref="ILocalizedPriceService.Retrieve(LocalizedPriceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LocalizedPrice>> Retrieve(
        LocalizedPriceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LocalizedPriceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LocalizedPrice>> Retrieve(
        string id,
        LocalizedPriceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /products/{product_id}/localized-prices/{id}</c>, but is otherwise the
    /// same as <see cref="ILocalizedPriceService.Update(LocalizedPriceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LocalizedPrice>> Update(
        LocalizedPriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LocalizedPriceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<LocalizedPrice>> Update(
        string id,
        LocalizedPriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /products/{product_id}/localized-prices</c>, but is otherwise the
    /// same as <see cref="ILocalizedPriceService.List(LocalizedPriceListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ListLocalizedPricesResponse>> List(
        LocalizedPriceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(LocalizedPriceListParams, CancellationToken)"/>
    Task<HttpResponse<ListLocalizedPricesResponse>> List(
        string productID,
        LocalizedPriceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /products/{product_id}/localized-prices/{id}</c>, but is otherwise the
    /// same as <see cref="ILocalizedPriceService.Archive(LocalizedPriceArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        LocalizedPriceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(LocalizedPriceArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string id,
        LocalizedPriceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}
