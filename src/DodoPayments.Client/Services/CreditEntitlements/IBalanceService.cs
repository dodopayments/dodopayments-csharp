using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Services.CreditEntitlements;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBalanceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBalanceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the credit balance details for a specific customer and credit entitlement.
    ///
    /// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
    ///
    /// <para># Path Parameters - `credit_entitlement_id` - The unique identifier
    /// of the credit entitlement - `customer_id` - The unique identifier of the customer</para>
    ///
    /// <para># Responses - `200 OK` - Returns the customer's balance - `404 Not Found`
    /// - Credit entitlement or customer balance not found - `500 Internal Server
    /// Error` - Database or server error</para>
    /// </summary>
    Task<CustomerCreditBalance> Retrieve(
        BalanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BalanceRetrieveParams, CancellationToken)"/>
    Task<CustomerCreditBalance> Retrieve(
        string customerID,
        BalanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of customer credit balances for the given credit entitlement.
    ///
    /// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
    ///
    /// <para># Path Parameters - `credit_entitlement_id` - The unique identifier
    /// of the credit entitlement</para>
    ///
    /// <para># Query Parameters - `page_size` - Number of items per page (default:
    /// 10, max: 100) - `page_number` - Zero-based page number (default: 0) - `customer_id`
    /// - Optional filter by specific customer</para>
    ///
    /// <para># Responses - `200 OK` - Returns list of customer balances - `404 Not
    /// Found` - Credit entitlement not found - `500 Internal Server Error` - Database
    /// or server error</para>
    /// </summary>
    Task<BalanceListPage> List(
        BalanceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(BalanceListParams, CancellationToken)"/>
    Task<BalanceListPage> List(
        string creditEntitlementID,
        BalanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// For credit entries, a new grant is created. For debit entries, credits are
    /// deducted from existing grants using FIFO (oldest first).
    ///
    /// <para># Authentication Requires an API key with `Editor` role.</para>
    ///
    /// <para># Path Parameters - `credit_entitlement_id` - The unique identifier
    /// of the credit entitlement - `customer_id` - The unique identifier of the customer</para>
    ///
    /// <para># Request Body - `entry_type` - "credit" or "debit" - `amount` - Amount
    /// to credit or debit - `reason` - Optional human-readable reason - `expires_at`
    /// - Optional expiration for credited amount (only for credit type) - `idempotency_key`
    /// - Optional key to prevent duplicate entries</para>
    ///
    /// <para># Responses - `201 Created` - Ledger entry created successfully - `400
    /// Bad Request` - Invalid request (e.g., debit with insufficient balance) - `404
    /// Not Found` - Credit entitlement or customer not found - `409 Conflict` - Idempotency
    /// key already exists - `500 Internal Server Error` - Database or server error</para>
    /// </summary>
    Task<BalanceCreateLedgerEntryResponse> CreateLedgerEntry(
        BalanceCreateLedgerEntryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateLedgerEntry(BalanceCreateLedgerEntryParams, CancellationToken)"/>
    Task<BalanceCreateLedgerEntryResponse> CreateLedgerEntry(
        string customerID,
        BalanceCreateLedgerEntryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of credit grants with optional filtering by status.
    ///
    /// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
    ///
    /// <para># Path Parameters - `credit_entitlement_id` - The unique identifier
    /// of the credit entitlement - `customer_id` - The unique identifier of the customer</para>
    ///
    /// <para># Query Parameters - `page_size` - Number of items per page (default:
    /// 10, max: 100) - `page_number` - Zero-based page number (default: 0) - `status`
    /// - Filter by status: active, expired, depleted</para>
    ///
    /// <para># Responses - `200 OK` - Returns list of grants - `404 Not Found` -
    /// Credit entitlement not found - `500 Internal Server Error` - Database or server error</para>
    /// </summary>
    Task<BalanceListGrantsPage> ListGrants(
        BalanceListGrantsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListGrants(BalanceListGrantsParams, CancellationToken)"/>
    Task<BalanceListGrantsPage> ListGrants(
        string customerID,
        BalanceListGrantsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of credit transaction history with optional filtering.
    ///
    /// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
    ///
    /// <para># Path Parameters - `credit_entitlement_id` - The unique identifier
    /// of the credit entitlement - `customer_id` - The unique identifier of the customer</para>
    ///
    /// <para># Query Parameters - `page_size` - Number of items per page (default:
    /// 10, max: 100) - `page_number` - Zero-based page number (default: 0) - `transaction_type`
    /// - Filter by transaction type - `start_date` - Filter entries from this date
    /// - `end_date` - Filter entries until this date</para>
    ///
    /// <para># Responses - `200 OK` - Returns list of ledger entries - `404 Not
    /// Found` - Credit entitlement not found - `500 Internal Server Error` - Database
    /// or server error</para>
    /// </summary>
    Task<BalanceListLedgerPage> ListLedger(
        BalanceListLedgerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListLedger(BalanceListLedgerParams, CancellationToken)"/>
    Task<BalanceListLedgerPage> ListLedger(
        string customerID,
        BalanceListLedgerParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBalanceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBalanceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /credit-entitlements/{credit_entitlement_id}/balances/{customer_id}`, but is otherwise the
    /// same as <see cref="IBalanceService.Retrieve(BalanceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerCreditBalance>> Retrieve(
        BalanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BalanceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CustomerCreditBalance>> Retrieve(
        string customerID,
        BalanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /credit-entitlements/{credit_entitlement_id}/balances`, but is otherwise the
    /// same as <see cref="IBalanceService.List(BalanceListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BalanceListPage>> List(
        BalanceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(BalanceListParams, CancellationToken)"/>
    Task<HttpResponse<BalanceListPage>> List(
        string creditEntitlementID,
        BalanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /credit-entitlements/{credit_entitlement_id}/balances/{customer_id}/ledger-entries`, but is otherwise the
    /// same as <see cref="IBalanceService.CreateLedgerEntry(BalanceCreateLedgerEntryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BalanceCreateLedgerEntryResponse>> CreateLedgerEntry(
        BalanceCreateLedgerEntryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateLedgerEntry(BalanceCreateLedgerEntryParams, CancellationToken)"/>
    Task<HttpResponse<BalanceCreateLedgerEntryResponse>> CreateLedgerEntry(
        string customerID,
        BalanceCreateLedgerEntryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /credit-entitlements/{credit_entitlement_id}/balances/{customer_id}/grants`, but is otherwise the
    /// same as <see cref="IBalanceService.ListGrants(BalanceListGrantsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BalanceListGrantsPage>> ListGrants(
        BalanceListGrantsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListGrants(BalanceListGrantsParams, CancellationToken)"/>
    Task<HttpResponse<BalanceListGrantsPage>> ListGrants(
        string customerID,
        BalanceListGrantsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /credit-entitlements/{credit_entitlement_id}/balances/{customer_id}/ledger`, but is otherwise the
    /// same as <see cref="IBalanceService.ListLedger(BalanceListLedgerParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BalanceListLedgerPage>> ListLedger(
        BalanceListLedgerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListLedger(BalanceListLedgerParams, CancellationToken)"/>
    Task<HttpResponse<BalanceListLedgerPage>> ListLedger(
        string customerID,
        BalanceListLedgerParams parameters,
        CancellationToken cancellationToken = default
    );
}
