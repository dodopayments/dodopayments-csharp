using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.CustomerPortal;

namespace DodoPayments.Client.Services.Customers.CustomerPortal;

public sealed class CustomerPortalService : ICustomerPortalService
{
    readonly IDodoPaymentsClient _client;

    public CustomerPortalService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<CustomerPortalSession> Create(CustomerPortalCreateParams parameters)
    {
        HttpRequest<CustomerPortalCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customerPortalSession = await response
            .Deserialize<CustomerPortalSession>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customerPortalSession.Validate();
        }
        return customerPortalSession;
    }
}
