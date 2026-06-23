using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Services.Entitlements;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGrantService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGrantServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGrantService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// GET /entitlements/{id}/grants (public API)
    /// </summary>
    Task<GrantListPage> List(
        GrantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(GrantListParams, CancellationToken)"/>
    Task<GrantListPage> List(
        string id,
        GrantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// For entitlements whose license-key config uses `manual` fulfillment, grants are
    /// created in the `pending` state without a key. Call this endpoint to deliver the
    /// key: the grant moves to `delivered`, the customer is emailed the key, and the
    /// `license_key.created` and `entitlement_grant.delivered` webhook events are sent.
    /// </summary>
    Task<EntitlementGrant> FulfillLicenseKey(
        GrantFulfillLicenseKeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="FulfillLicenseKey(GrantFulfillLicenseKeyParams, CancellationToken)"/>
    Task<EntitlementGrant> FulfillLicenseKey(
        string grantID,
        GrantFulfillLicenseKeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revoke a single grant. Idempotent: re-revoking an already-revoked grant returns
    /// the grant in its current state.
    /// </summary>
    Task<EntitlementGrant> Revoke(
        GrantRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(GrantRevokeParams, CancellationToken)"/>
    Task<EntitlementGrant> Revoke(
        string grantID,
        GrantRevokeParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGrantService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGrantServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGrantServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entitlements/{id}/grants</c>, but is otherwise the
    /// same as <see cref="IGrantService.List(GrantListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GrantListPage>> List(
        GrantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(GrantListParams, CancellationToken)"/>
    Task<HttpResponse<GrantListPage>> List(
        string id,
        GrantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /grants/{grant_id}/license-key</c>, but is otherwise the
    /// same as <see cref="IGrantService.FulfillLicenseKey(GrantFulfillLicenseKeyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementGrant>> FulfillLicenseKey(
        GrantFulfillLicenseKeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="FulfillLicenseKey(GrantFulfillLicenseKeyParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementGrant>> FulfillLicenseKey(
        string grantID,
        GrantFulfillLicenseKeyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /entitlements/{id}/grants/{grant_id}</c>, but is otherwise the
    /// same as <see cref="IGrantService.Revoke(GrantRevokeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementGrant>> Revoke(
        GrantRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(GrantRevokeParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementGrant>> Revoke(
        string grantID,
        GrantRevokeParams parameters,
        CancellationToken cancellationToken = default
    );
}
