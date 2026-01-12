using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMeterService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMeterServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeterService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /meters<c/>.
    /// </summary>
    Task<Meter> Create(MeterCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a request to <c>get /meters/{id}<c/>.
    /// </summary>
    Task<Meter> Retrieve(
        MeterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MeterRetrieveParams, CancellationToken)"/>
    Task<Meter> Retrieve(
        string id,
        MeterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /meters<c/>.
    /// </summary>
    Task<MeterListPage> List(
        MeterListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>delete /meters/{id}<c/>.
    /// </summary>
    Task Archive(MeterArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(MeterArchiveParams, CancellationToken)"/>
    Task Archive(
        string id,
        MeterArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>post /meters/{id}/unarchive<c/>.
    /// </summary>
    Task Unarchive(MeterUnarchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Unarchive(MeterUnarchiveParams, CancellationToken)"/>
    Task Unarchive(
        string id,
        MeterUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMeterService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMeterServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeterServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /meters`, but is otherwise the
    /// same as <see cref="IMeterService.Create(MeterCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Meter>> Create(
        MeterCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /meters/{id}`, but is otherwise the
    /// same as <see cref="IMeterService.Retrieve(MeterRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Meter>> Retrieve(
        MeterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MeterRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Meter>> Retrieve(
        string id,
        MeterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /meters`, but is otherwise the
    /// same as <see cref="IMeterService.List(MeterListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MeterListPage>> List(
        MeterListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /meters/{id}`, but is otherwise the
    /// same as <see cref="IMeterService.Archive(MeterArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        MeterArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(MeterArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string id,
        MeterArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /meters/{id}/unarchive`, but is otherwise the
    /// same as <see cref="IMeterService.Unarchive(MeterUnarchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Unarchive(
        MeterUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(MeterUnarchiveParams, CancellationToken)"/>
    Task<HttpResponse> Unarchive(
        string id,
        MeterUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
