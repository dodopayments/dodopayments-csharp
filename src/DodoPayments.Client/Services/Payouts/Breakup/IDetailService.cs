using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts.Breakup.Details;

namespace DodoPayments.Client.Services.Payouts.Breakup;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDetailService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDetailServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDetailService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns paginated individual balance ledger entries for a payout, with each
    /// entry's amount pro-rated into the payout's currency. Supports pagination via
    /// `page_size` (default 10, max 100) and `page_number` (default 0) query
    /// parameters.
    /// </summary>
    Task<DetailListPage> List(
        DetailListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DetailListParams, CancellationToken)"/>
    Task<DetailListPage> List(
        string payoutID,
        DetailListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Downloads the complete payout breakup as a CSV file. Each row represents a
    /// balance ledger entry with columns: Ledger ID, Event Type, Original Amount,
    /// Original Currency, Reference Object ID, Description, Created At, USD Equivalent
    /// Amount, and Payout Currency Amount.
    /// </summary>
    Task DownloadCsv(
        DetailDownloadCsvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DownloadCsv(DetailDownloadCsvParams, CancellationToken)"/>
    Task DownloadCsv(
        string payoutID,
        DetailDownloadCsvParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDetailService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDetailServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDetailServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /payouts/{payout_id}/breakup/details</c>, but is otherwise the
    /// same as <see cref="IDetailService.List(DetailListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DetailListPage>> List(
        DetailListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DetailListParams, CancellationToken)"/>
    Task<HttpResponse<DetailListPage>> List(
        string payoutID,
        DetailListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /payouts/{payout_id}/breakup/details/csv</c>, but is otherwise the
    /// same as <see cref="IDetailService.DownloadCsv(DetailDownloadCsvParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DownloadCsv(
        DetailDownloadCsvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DownloadCsv(DetailDownloadCsvParams, CancellationToken)"/>
    Task<HttpResponse> DownloadCsv(
        string payoutID,
        DetailDownloadCsvParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
