using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Blocklist.Customers.Notes;

namespace DodoPayments.Client.Services.Blocklist.Customers;

/// <inheritdoc/>
public sealed class NoteService : INoteService
{
    readonly Lazy<INoteServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INoteServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public INoteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NoteService(this._client.WithOptions(modifier));
    }

    public NoteService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new NoteServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BlockedCustomerNote> Create(
        NoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BlockedCustomerNote> Create(
        string entryID,
        NoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { EntryID = entryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BlockedCustomerNote> Update(
        NoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BlockedCustomerNote> Update(
        string noteID,
        NoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { NoteID = noteID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NoteServiceWithRawResponse : INoteServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public INoteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NoteServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NoteServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BlockedCustomerNote>> Create(
        NoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntryID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.EntryID' cannot be null");
        }

        HttpRequest<NoteCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var blockedCustomerNote = await response
                    .Deserialize<BlockedCustomerNote>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    blockedCustomerNote.Validate();
                }
                return blockedCustomerNote;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BlockedCustomerNote>> Create(
        string entryID,
        NoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { EntryID = entryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BlockedCustomerNote>> Update(
        NoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NoteID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.NoteID' cannot be null");
        }

        HttpRequest<NoteUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var blockedCustomerNote = await response
                    .Deserialize<BlockedCustomerNote>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    blockedCustomerNote.Validate();
                }
                return blockedCustomerNote;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BlockedCustomerNote>> Update(
        string noteID,
        NoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { NoteID = noteID }, cancellationToken);
    }
}
