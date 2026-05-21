using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections.Groups;
using DodoPayments.Client.Services.ProductCollections.Groups;

namespace DodoPayments.Client.Services.ProductCollections;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemService Items { get; }

    /// <summary>
    /// Sends a request to <c>post /product-collections/{id}/groups</c>.
    /// </summary>
    Task<ProductCollectionGroupResponse> Create(
        GroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(GroupCreateParams, CancellationToken)"/>
    Task<ProductCollectionGroupResponse> Create(
        string id,
        GroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /product-collections/{id}/groups/{group_id}</c>.
    /// </summary>
    Task Update(GroupUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(GroupUpdateParams, CancellationToken)"/>
    Task Update(
        string groupID,
        GroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>delete /product-collections/{id}/groups/{group_id}</c>.
    /// </summary>
    Task Delete(GroupDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(GroupDeleteParams, CancellationToken)"/>
    Task Delete(
        string groupID,
        GroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemServiceWithRawResponse Items { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /product-collections/{id}/groups</c>, but is otherwise the
    /// same as <see cref="IGroupService.Create(GroupCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductCollectionGroupResponse>> Create(
        GroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(GroupCreateParams, CancellationToken)"/>
    Task<HttpResponse<ProductCollectionGroupResponse>> Create(
        string id,
        GroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /product-collections/{id}/groups/{group_id}</c>, but is otherwise the
    /// same as <see cref="IGroupService.Update(GroupUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        GroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(GroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string groupID,
        GroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /product-collections/{id}/groups/{group_id}</c>, but is otherwise the
    /// same as <see cref="IGroupService.Delete(GroupDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        GroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(GroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string groupID,
        GroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
