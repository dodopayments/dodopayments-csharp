using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.CustomerPortal;

namespace DodoPayments.Client.Services.Customers;

/// <inheritdoc/>
public sealed class CustomerPortalService : ICustomerPortalService
{
    readonly Lazy<ICustomerPortalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomerPortalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ICustomerPortalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerPortalService(this._client.WithOptions(modifier));
    }

    public CustomerPortalService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CustomerPortalServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CustomerPortalSession> Create(
        CustomerPortalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerPortalSession> Create(
        string customerID,
        CustomerPortalCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CustomerPortalServiceWithRawResponse : ICustomerPortalServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomerPortalServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CustomerPortalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomerPortalServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerPortalSession>> Create(
        CustomerPortalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<CustomerPortalCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerPortalSession = await response
                    .Deserialize<CustomerPortalSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerPortalSession.Validate();
                }
                return customerPortalSession;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerPortalSession>> Create(
        string customerID,
        CustomerPortalCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }
}
