using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Blocklist.Customers;
using DodoPayments.Client.Services.Blocklist.Customers;

namespace DodoPayments.Client.Services.Blocklist;

/// <inheritdoc/>
public sealed class CustomerService : ICustomerService
{
    readonly Lazy<ICustomerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerService(this._client.WithOptions(modifier));
    }

    public CustomerService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CustomerServiceWithRawResponse(client.WithRawResponse));
        _notes = new(() => new NoteService(client));
    }

    readonly Lazy<INoteService> _notes;
    public INoteService Notes
    {
        get { return _notes.Value; }
    }

    /// <inheritdoc/>
    public async Task<BlockedCustomer> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BlockedCustomer> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BlockedCustomer> Retrieve(
        string entryID,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EntryID = entryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerListPage> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        CustomerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string entryID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { EntryID = entryID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CustomerServiceWithRawResponse : ICustomerServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomerServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _notes = new(() => new NoteServiceWithRawResponse(client));
    }

    readonly Lazy<INoteServiceWithRawResponse> _notes;
    public INoteServiceWithRawResponse Notes
    {
        get { return _notes.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BlockedCustomer>> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var blockedCustomer = await response
                    .Deserialize<BlockedCustomer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    blockedCustomer.Validate();
                }
                return blockedCustomer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BlockedCustomer>> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntryID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.EntryID' cannot be null");
        }

        HttpRequest<CustomerRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var blockedCustomer = await response
                    .Deserialize<BlockedCustomer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    blockedCustomer.Validate();
                }
                return blockedCustomer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BlockedCustomer>> Retrieve(
        string entryID,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EntryID = entryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerListPage>> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CustomerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<CustomerListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CustomerListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CustomerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntryID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.EntryID' cannot be null");
        }

        HttpRequest<CustomerDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string entryID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { EntryID = entryID }, cancellationToken);
    }
}
