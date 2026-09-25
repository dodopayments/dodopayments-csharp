using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Moderation;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IModerationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IModerationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IModerationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Shows how many billable screens you made and how close you are to your next
    /// charge.
    ///
    /// <para>**Billing.** A billable screen is a live-mode screen that returns a
    /// verdict. Dodo Payments charges $0.30 for each full block of 1000 billable
    /// screens and debits the fee from your balance. Each full block is charged within
    /// one hour. Screens that do not fill a block stay unbilled until they do. Errors
    /// and test-mode screens are free and are not counted.</para>
    /// </summary>
    Task<ModerationRetrieveUsageResponse> RetrieveUsage(
        ModerationRetrieveUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Screens text, an image, or both, and returns a verdict: `allow`, `flag` or
    /// `deny`. The API is fail-closed: do not generate when you get no verdict.
    ///
    /// <para>**Pricing.** Dodo Payments charges $0.30 per 1000 billable screens and
    /// debits the fee from your balance. A billable screen is a live-mode screen that
    /// returns a verdict. Errors and test-mode screens are free.</para>
    ///
    /// <para>**429.** Honour `Retry-After` and retry. A 429 is a throughput limit, not
    /// a verdict.</para>
    ///
    /// <para>**Test mode** returns mock verdicts and never calls the model. The default
    /// verdict is `allow`. Put one of these strings in `text` to select another
    /// outcome: `dodo_mock_flag` (`flag`), `dodo_mock_deny` (`deny`),
    /// `dodo_mock_overloaded` (429) or `dodo_mock_not_ready` (503).</para>
    /// </summary>
    Task<ModerationScreenResponse> Screen(
        ModerationScreenParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IModerationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IModerationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IModerationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /moderation/usage</c>, but is otherwise the
    /// same as <see cref="IModerationService.RetrieveUsage(ModerationRetrieveUsageParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ModerationRetrieveUsageResponse>> RetrieveUsage(
        ModerationRetrieveUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /moderation/screen</c>, but is otherwise the
    /// same as <see cref="IModerationService.Screen(ModerationScreenParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ModerationScreenResponse>> Screen(
        ModerationScreenParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
