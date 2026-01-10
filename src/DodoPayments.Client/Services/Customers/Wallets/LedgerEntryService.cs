using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

namespace DodoPayments.Client.Services.Customers.Wallets;

/// <inheritdoc/>
public sealed class LedgerEntryService : ILedgerEntryService
{
    readonly Lazy<ILedgerEntryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILedgerEntryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ILedgerEntryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LedgerEntryService(this._client.WithOptions(modifier));
    }

    public LedgerEntryService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LedgerEntryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CustomerWallet> Create(
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerWallet> Create(
        string customerID,
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LedgerEntryListPage> List(
        LedgerEntryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LedgerEntryListPage> List(
        string customerID,
        LedgerEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LedgerEntryServiceWithRawResponse : ILedgerEntryServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILedgerEntryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LedgerEntryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LedgerEntryServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerWallet>> Create(
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<LedgerEntryCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerWallet = await response
                    .Deserialize<CustomerWallet>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerWallet.Validate();
                }
                return customerWallet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerWallet>> Create(
        string customerID,
        LedgerEntryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LedgerEntryListPage>> List(
        LedgerEntryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<LedgerEntryListParams> request = new()
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
                    .Deserialize<LedgerEntryListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LedgerEntryListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LedgerEntryListPage>> List(
        string customerID,
        LedgerEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }
}
