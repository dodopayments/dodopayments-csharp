using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers.Notes;

namespace DodoPayments.Client.Services.Blocklist.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INoteService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INoteServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INoteService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /blocklist/customers/{entry_id}/notes</c>.
    /// </summary>
    Task<BlockedCustomerNote> Create(
        NoteCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(NoteCreateParams, CancellationToken)"/>
    Task<BlockedCustomerNote> Create(
        string entryID,
        NoteCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /blocklist/customers/{entry_id}/notes/{note_id}</c>.
    /// </summary>
    Task<BlockedCustomerNote> Update(
        NoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(NoteUpdateParams, CancellationToken)"/>
    Task<BlockedCustomerNote> Update(
        string noteID,
        NoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INoteService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INoteServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INoteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /blocklist/customers/{entry_id}/notes</c>, but is otherwise the
    /// same as <see cref="INoteService.Create(NoteCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BlockedCustomerNote>> Create(
        NoteCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(NoteCreateParams, CancellationToken)"/>
    Task<HttpResponse<BlockedCustomerNote>> Create(
        string entryID,
        NoteCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /blocklist/customers/{entry_id}/notes/{note_id}</c>, but is otherwise the
    /// same as <see cref="INoteService.Update(NoteUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BlockedCustomerNote>> Update(
        NoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(NoteUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BlockedCustomerNote>> Update(
        string noteID,
        NoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}
