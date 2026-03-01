using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements;
using CreditEntitlements = DodoPayments.Client.Services.CreditEntitlements;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class CreditEntitlementService : ICreditEntitlementService
{
    readonly Lazy<ICreditEntitlementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICreditEntitlementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ICreditEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditEntitlementService(this._client.WithOptions(modifier));
    }

    public CreditEntitlementService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CreditEntitlementServiceWithRawResponse(client.WithRawResponse)
        );
        _balances = new(() => new CreditEntitlements::BalanceService(client));
    }

    readonly Lazy<CreditEntitlements::IBalanceService> _balances;
    public CreditEntitlements::IBalanceService Balances
    {
        get { return _balances.Value; }
    }

    /// <inheritdoc/>
    public async Task<CreditEntitlement> Create(
        CreditEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditEntitlement> Retrieve(
        CreditEntitlementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CreditEntitlement> Retrieve(
        string id,
        CreditEntitlementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        CreditEntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string id,
        CreditEntitlementUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditEntitlementListPage> List(
        CreditEntitlementListParams? parameters = null,
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
        CreditEntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        CreditEntitlementDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Undelete(
        CreditEntitlementUndeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Undelete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Undelete(
        string id,
        CreditEntitlementUndeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Undelete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CreditEntitlementServiceWithRawResponse
    : ICreditEntitlementServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICreditEntitlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CreditEntitlementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CreditEntitlementServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _balances = new(() => new CreditEntitlements::BalanceServiceWithRawResponse(client));
    }

    readonly Lazy<CreditEntitlements::IBalanceServiceWithRawResponse> _balances;
    public CreditEntitlements::IBalanceServiceWithRawResponse Balances
    {
        get { return _balances.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditEntitlement>> Create(
        CreditEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditEntitlementCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var creditEntitlement = await response
                    .Deserialize<CreditEntitlement>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditEntitlement.Validate();
                }
                return creditEntitlement;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditEntitlement>> Retrieve(
        CreditEntitlementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CreditEntitlementRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var creditEntitlement = await response
                    .Deserialize<CreditEntitlement>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditEntitlement.Validate();
                }
                return creditEntitlement;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CreditEntitlement>> Retrieve(
        string id,
        CreditEntitlementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        CreditEntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CreditEntitlementUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string id,
        CreditEntitlementUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditEntitlementListPage>> List(
        CreditEntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CreditEntitlementListParams> request = new()
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
                    .Deserialize<CreditEntitlementListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CreditEntitlementListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CreditEntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CreditEntitlementDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        CreditEntitlementDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Undelete(
        CreditEntitlementUndeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CreditEntitlementUndeleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Undelete(
        string id,
        CreditEntitlementUndeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Undelete(parameters with { ID = id }, cancellationToken);
    }
}
