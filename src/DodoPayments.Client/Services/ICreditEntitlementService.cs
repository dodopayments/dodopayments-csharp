using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using CreditEntitlements = DodoPayments.Client.Services.CreditEntitlements;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICreditEntitlementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICreditEntitlementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    CreditEntitlements::IBalanceService Balances { get; }

    /// <summary>
    /// Credit entitlements define reusable credit templates that can be attached
    /// to products. Each entitlement defines how credits behave in terms of expiration,
    /// rollover, and overage.
    ///
    /// <para># Authentication Requires an API key with `Editor` role.</para>
    ///
    /// <para># Request Body - `name` - Human-readable name of the credit entitlement
    /// (1-255 characters, required) - `description` - Optional description (max 1000
    /// characters) - `precision` - Decimal precision for credit amounts (0-10 decimal
    /// places) - `unit` - Unit of measurement for the credit (e.g., "API Calls",
    /// "Tokens", "Credits") - `expires_after_days` - Number of days after which
    /// credits expire (optional) - `rollover_enabled` - Whether unused credits can
    /// rollover to the next period - `rollover_percentage` - Percentage of unused
    /// credits that rollover (0-100) - `rollover_timeframe_count` - Count of timeframe
    /// periods for rollover limit - `rollover_timeframe_interval` - Interval type
    /// (day, week, month, year) - `max_rollover_count` - Maximum number of times
    /// credits can be rolled over - `overage_enabled` - Whether overage charges
    /// apply when credits run out (requires price_per_unit) - `overage_limit` -
    /// Maximum overage units allowed (optional) - `currency` - Currency for pricing
    /// (required if price_per_unit is set) - `price_per_unit` - Price per credit
    /// unit (decimal)</para>
    ///
    /// <para># Responses - `201 Created` - Credit entitlement created successfully,
    /// returns the full entitlement object - `422 Unprocessable Entity` - Invalid
    /// request parameters or validation failure - `500 Internal Server Error` -
    /// Database or server error</para>
    ///
    /// <para># Business Logic - A unique ID with prefix `cde_` is automatically
    /// generated for the entitlement - Created and updated timestamps are automatically
    /// set - Currency is required when price_per_unit is set - price_per_unit is
    /// required when overage_enabled is true - rollover_timeframe_count and rollover_timeframe_interval
    /// must both be set or both be null</para>
    /// </summary>
    Task<CreditEntitlement> Create(
        CreditEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the full details of a single credit entitlement including all configuration
    /// settings for expiration, rollover, and overage policies.
    ///
    /// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
    ///
    /// <para># Path Parameters - `id` - The unique identifier of the credit entitlement
    /// (format: `cde_...`)</para>
    ///
    /// <para># Responses - `200 OK` - Returns the full credit entitlement object
    /// - `404 Not Found` - Credit entitlement does not exist or does not belong
    /// to the authenticated business - `500 Internal Server Error` - Database or
    /// server error</para>
    ///
    /// <para># Business Logic - Only non-deleted credit entitlements can be retrieved
    /// through this endpoint - The entitlement must belong to the authenticated
    /// business (business_id check) - Deleted entitlements return a 404 error and
    /// must be retrieved via the list endpoint with `deleted=true`</para>
    /// </summary>
    Task<CreditEntitlement> Retrieve(
        CreditEntitlementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CreditEntitlementRetrieveParams, CancellationToken)"/>
    Task<CreditEntitlement> Retrieve(
        string id,
        CreditEntitlementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Allows partial updates to a credit entitlement's configuration. Only the
    /// fields provided in the request body will be updated; all other fields remain
    /// unchanged. This endpoint supports nullable fields using the double option pattern.
    ///
    /// <para># Authentication Requires an API key with `Editor` role.</para>
    ///
    /// <para># Path Parameters - `id` - The unique identifier of the credit entitlement
    /// to update (format: `cde_...`)</para>
    ///
    /// <para># Request Body (all fields optional) - `name` - Human-readable name
    /// of the credit entitlement (1-255 characters) - `description` - Optional description
    /// (max 1000 characters) - `unit` - Unit of measurement for the credit (1-50 characters)</para>
    ///
    /// <para>Note: `precision` cannot be modified after creation as it would invalidate
    /// existing grants. - `expires_after_days` - Number of days after which credits
    /// expire (use `null` to remove expiration) - `rollover_enabled` - Whether unused
    /// credits can rollover to the next period - `rollover_percentage` - Percentage
    /// of unused credits that rollover (0-100, nullable) - `rollover_timeframe_count`
    /// - Count of timeframe periods for rollover limit (nullable) - `rollover_timeframe_interval`
    /// - Interval type (day, week, month, year, nullable) - `max_rollover_count`
    /// - Maximum number of times credits can be rolled over (nullable) - `overage_enabled`
    /// - Whether overage charges apply when credits run out - `overage_limit` - Maximum
    /// overage units allowed (nullable) - `currency` - Currency for pricing (nullable)
    /// - `price_per_unit` - Price per credit unit (decimal, nullable)</para>
    ///
    /// <para># Responses - `200 OK` - Credit entitlement updated successfully - `404
    /// Not Found` - Credit entitlement does not exist or does not belong to the
    /// authenticated business - `422 Unprocessable Entity` - Invalid request parameters
    /// or validation failure - `500 Internal Server Error` - Database or server error</para>
    ///
    /// <para># Business Logic - Only non-deleted credit entitlements can be updated
    /// - Fields set to `null` explicitly will clear the database value (using double
    /// option pattern) - The `updated_at` timestamp is automatically updated on
    /// successful modification - Changes take effect immediately but do not retroactively
    /// affect existing credit grants - The merged state is validated: currency required
    /// with price, rollover timeframe fields together, price required for overage</para>
    /// </summary>
    Task Update(
        CreditEntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CreditEntitlementUpdateParams, CancellationToken)"/>
    Task Update(
        string id,
        CreditEntitlementUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of credit entitlements, allowing filtering of deleted
    /// entitlements. By default, only non-deleted entitlements are returned.
    ///
    /// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
    ///
    /// <para># Query Parameters - `page_size` - Number of items per page (default:
    /// 10, max: 100) - `page_number` - Zero-based page number (default: 0) - `deleted`
    /// - Boolean flag to list deleted entitlements instead of active ones (default: false)</para>
    ///
    /// <para># Responses - `200 OK` - Returns a list of credit entitlements wrapped
    /// in a response object - `422 Unprocessable Entity` - Invalid query parameters
    /// (e.g., page_size > 100) - `500 Internal Server Error` - Database or server error</para>
    ///
    /// <para># Business Logic - Results are ordered by creation date in descending
    /// order (newest first) - Only entitlements belonging to the authenticated business
    /// are returned - The `deleted` parameter controls visibility of soft-deleted
    /// entitlements - Pagination uses offset-based pagination (offset = page_number
    /// * page_size)</para>
    /// </summary>
    Task<CreditEntitlementListPage> List(
        CreditEntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>delete /credit-entitlements/{id}<c/>.
    /// </summary>
    Task Delete(
        CreditEntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CreditEntitlementDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        CreditEntitlementDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Undeletes a soft-deleted credit entitlement by clearing `deleted_at`, making
    /// it available again through standard list and get endpoints.
    ///
    /// <para># Authentication Requires an API key with `Editor` role.</para>
    ///
    /// <para># Path Parameters - `id` - The unique identifier of the credit entitlement
    /// to restore (format: `cde_...`)</para>
    ///
    /// <para># Responses - `200 OK` - Credit entitlement restored successfully -
    /// `500 Internal Server Error` - Database error, entitlement not found, or entitlement
    /// is not deleted</para>
    ///
    /// <para># Business Logic - Only deleted credit entitlements can be restored
    /// - The query filters for `deleted_at IS NOT NULL`, so non-deleted entitlements
    /// will result in 0 rows affected - If no rows are affected (entitlement doesn't
    /// exist, doesn't belong to business, or is not deleted), returns 500 - The
    /// `updated_at` timestamp is automatically updated on successful restoration
    /// - Once restored, the entitlement becomes immediately available in the standard
    /// list and get endpoints - All configuration settings are preserved during
    /// delete/restore operations</para>
    ///
    /// <para># Error Handling This endpoint returns 500 Internal Server Error in
    /// several cases: - The credit entitlement does not exist - The credit entitlement
    /// belongs to a different business - The credit entitlement is not currently
    /// deleted (already active)</para>
    ///
    /// <para>Callers should verify the entitlement exists and is deleted before
    /// calling this endpoint.</para>
    /// </summary>
    Task Undelete(
        CreditEntitlementUndeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Undelete(CreditEntitlementUndeleteParams, CancellationToken)"/>
    Task Undelete(
        string id,
        CreditEntitlementUndeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICreditEntitlementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICreditEntitlementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditEntitlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    CreditEntitlements::IBalanceServiceWithRawResponse Balances { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /credit-entitlements`, but is otherwise the
    /// same as <see cref="ICreditEntitlementService.Create(CreditEntitlementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditEntitlement>> Create(
        CreditEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /credit-entitlements/{id}`, but is otherwise the
    /// same as <see cref="ICreditEntitlementService.Retrieve(CreditEntitlementRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditEntitlement>> Retrieve(
        CreditEntitlementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CreditEntitlementRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CreditEntitlement>> Retrieve(
        string id,
        CreditEntitlementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /credit-entitlements/{id}`, but is otherwise the
    /// same as <see cref="ICreditEntitlementService.Update(CreditEntitlementUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        CreditEntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CreditEntitlementUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string id,
        CreditEntitlementUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /credit-entitlements`, but is otherwise the
    /// same as <see cref="ICreditEntitlementService.List(CreditEntitlementListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditEntitlementListPage>> List(
        CreditEntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /credit-entitlements/{id}`, but is otherwise the
    /// same as <see cref="ICreditEntitlementService.Delete(CreditEntitlementDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CreditEntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CreditEntitlementDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        CreditEntitlementDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /credit-entitlements/{id}/undelete`, but is otherwise the
    /// same as <see cref="ICreditEntitlementService.Undelete(CreditEntitlementUndeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Undelete(
        CreditEntitlementUndeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Undelete(CreditEntitlementUndeleteParams, CancellationToken)"/>
    Task<HttpResponse> Undelete(
        string id,
        CreditEntitlementUndeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
