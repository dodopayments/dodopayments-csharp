using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Services.CreditEntitlements;

/// <inheritdoc/>
public sealed class BalanceService : IBalanceService
{
    readonly Lazy<IBalanceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBalanceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BalanceService(this._client.WithOptions(modifier));
    }

    public BalanceService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BalanceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CustomerCreditBalance> Retrieve(
        BalanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerCreditBalance> Retrieve(
        string customerID,
        BalanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BalanceListPage> List(
        BalanceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BalanceListPage> List(
        string creditEntitlementID,
        BalanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(
            parameters with
            {
                CreditEntitlementID = creditEntitlementID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BalanceCreateLedgerEntryResponse> CreateLedgerEntry(
        BalanceCreateLedgerEntryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateLedgerEntry(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BalanceCreateLedgerEntryResponse> CreateLedgerEntry(
        string customerID,
        BalanceCreateLedgerEntryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateLedgerEntry(
            parameters with
            {
                CustomerID = customerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BalanceListGrantsPage> ListGrants(
        BalanceListGrantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListGrants(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BalanceListGrantsPage> ListGrants(
        string customerID,
        BalanceListGrantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListGrants(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BalanceListLedgerPage> ListLedger(
        BalanceListLedgerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListLedger(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BalanceListLedgerPage> ListLedger(
        string customerID,
        BalanceListLedgerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListLedger(parameters with { CustomerID = customerID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BalanceServiceWithRawResponse : IBalanceServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBalanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BalanceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BalanceServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerCreditBalance>> Retrieve(
        BalanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<BalanceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerCreditBalance = await response
                    .Deserialize<CustomerCreditBalance>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerCreditBalance.Validate();
                }
                return customerCreditBalance;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerCreditBalance>> Retrieve(
        string customerID,
        BalanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceListPage>> List(
        BalanceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CreditEntitlementID == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "'parameters.CreditEntitlementID' cannot be null"
            );
        }

        HttpRequest<BalanceListParams> request = new()
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
                    .Deserialize<BalanceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BalanceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BalanceListPage>> List(
        string creditEntitlementID,
        BalanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(
            parameters with
            {
                CreditEntitlementID = creditEntitlementID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceCreateLedgerEntryResponse>> CreateLedgerEntry(
        BalanceCreateLedgerEntryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<BalanceCreateLedgerEntryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<BalanceCreateLedgerEntryResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BalanceCreateLedgerEntryResponse>> CreateLedgerEntry(
        string customerID,
        BalanceCreateLedgerEntryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateLedgerEntry(
            parameters with
            {
                CustomerID = customerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceListGrantsPage>> ListGrants(
        BalanceListGrantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<BalanceListGrantsParams> request = new()
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
                    .Deserialize<BalanceListGrantsPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BalanceListGrantsPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BalanceListGrantsPage>> ListGrants(
        string customerID,
        BalanceListGrantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListGrants(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceListLedgerPage>> ListLedger(
        BalanceListLedgerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<BalanceListLedgerParams> request = new()
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
                    .Deserialize<BalanceListLedgerPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BalanceListLedgerPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BalanceListLedgerPage>> ListLedger(
        string customerID,
        BalanceListLedgerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListLedger(parameters with { CustomerID = customerID }, cancellationToken);
    }
}
