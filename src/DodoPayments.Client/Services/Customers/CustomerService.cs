using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Services.Customers.CustomerPortal;
using DodoPayments.Client.Services.Customers.Wallets;

namespace DodoPayments.Client.Services.Customers;

public sealed class CustomerService : ICustomerService
{
    public ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public CustomerService(IDodoPaymentsClient client)
    {
        _client = client;
        _customerPortal = new(() => new CustomerPortalService(client));
        _wallets = new(() => new WalletService(client));
    }

    readonly Lazy<ICustomerPortalService> _customerPortal;
    public ICustomerPortalService CustomerPortal
    {
        get { return _customerPortal.Value; }
    }

    readonly Lazy<IWalletService> _wallets;
    public IWalletService Wallets
    {
        get { return _wallets.Value; }
    }

    public async Task<Customer> Create(CustomerCreateParams parameters)
    {
        HttpRequest<CustomerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customer = await response.Deserialize<Customer>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<Customer> Retrieve(CustomerRetrieveParams parameters)
    {
        HttpRequest<CustomerRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customer = await response.Deserialize<Customer>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<Customer> Update(CustomerUpdateParams parameters)
    {
        HttpRequest<CustomerUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customer = await response.Deserialize<Customer>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<CustomerListPageResponse> List(CustomerListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<CustomerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<CustomerListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
