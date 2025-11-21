using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.CustomerPortal;

namespace DodoPayments.Client.Services.Customers;

public sealed class CustomerPortalService : ICustomerPortalService
{
    public ICustomerPortalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerPortalService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public CustomerPortalService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<CustomerPortalSession> Create(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customerPortalSession = await response
            .Deserialize<CustomerPortalSession>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customerPortalSession.Validate();
        }
        return customerPortalSession;
    }

    public async Task<CustomerPortalSession> Create(
        string customerID,
        CustomerPortalCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }
}
