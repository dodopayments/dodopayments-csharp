using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Services.Entitlements;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEntitlementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEntitlementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFileService Files { get; }

    IGrantService Grants { get; }

    /// <summary>
    /// POST /entitlements
    /// </summary>
    Task<Entitlement> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// GET /entitlements/{id}
    /// </summary>
    Task<Entitlement> Retrieve(
        EntitlementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntitlementRetrieveParams, CancellationToken)"/>
    Task<Entitlement> Retrieve(
        string id,
        EntitlementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// PATCH /entitlements/{id}
    /// </summary>
    Task<Entitlement> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntitlementUpdateParams, CancellationToken)"/>
    Task<Entitlement> Update(
        string id,
        EntitlementUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// GET /entitlements
    /// </summary>
    Task<EntitlementListPage> List(
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// DELETE /entitlements/{id} (soft-delete)
    /// </summary>
    Task Delete(EntitlementDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(EntitlementDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        EntitlementDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEntitlementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEntitlementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntitlementServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFileServiceWithRawResponse Files { get; }

    IGrantServiceWithRawResponse Grants { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /entitlements</c>, but is otherwise the
    /// same as <see cref="IEntitlementService.Create(EntitlementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entitlement>> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entitlements/{id}</c>, but is otherwise the
    /// same as <see cref="IEntitlementService.Retrieve(EntitlementRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entitlement>> Retrieve(
        EntitlementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntitlementRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Entitlement>> Retrieve(
        string id,
        EntitlementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /entitlements/{id}</c>, but is otherwise the
    /// same as <see cref="IEntitlementService.Update(EntitlementUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entitlement>> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntitlementUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Entitlement>> Update(
        string id,
        EntitlementUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entitlements</c>, but is otherwise the
    /// same as <see cref="IEntitlementService.List(EntitlementListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementListPage>> List(
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /entitlements/{id}</c>, but is otherwise the
    /// same as <see cref="IEntitlementService.Delete(EntitlementDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EntitlementDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        EntitlementDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
