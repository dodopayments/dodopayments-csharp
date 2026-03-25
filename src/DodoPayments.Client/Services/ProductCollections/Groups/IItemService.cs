using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections.Groups.Items;

namespace DodoPayments.Client.Services.ProductCollections.Groups;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /product-collections/{id}/groups/{group_id}/items</c>.
    /// </summary>
    Task<List<ItemCreateResponse>> Create(
        ItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ItemCreateParams, CancellationToken)"/>
    Task<List<ItemCreateResponse>> Create(
        string groupID,
        ItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /product-collections/{id}/groups/{group_id}/items/{item_id}</c>.
    /// </summary>
    Task Update(ItemUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ItemUpdateParams, CancellationToken)"/>
    Task Update(
        string itemID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>delete /product-collections/{id}/groups/{group_id}/items/{item_id}</c>.
    /// </summary>
    Task Delete(ItemDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ItemDeleteParams, CancellationToken)"/>
    Task Delete(
        string itemID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /product-collections/{id}/groups/{group_id}/items</c>, but is otherwise the
    /// same as <see cref="IItemService.Create(ItemCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ItemCreateResponse>>> Create(
        ItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ItemCreateParams, CancellationToken)"/>
    Task<HttpResponse<List<ItemCreateResponse>>> Create(
        string groupID,
        ItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /product-collections/{id}/groups/{group_id}/items/{item_id}</c>, but is otherwise the
    /// same as <see cref="IItemService.Update(ItemUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ItemUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string itemID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /product-collections/{id}/groups/{group_id}/items/{item_id}</c>, but is otherwise the
    /// same as <see cref="IItemService.Delete(ItemDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ItemDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string itemID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
