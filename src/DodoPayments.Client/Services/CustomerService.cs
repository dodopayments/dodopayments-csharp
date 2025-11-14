using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Services.Customers;

namespace DodoPayments.Client.Services;

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

    public async Task<Customer> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customer = await response
            .Deserialize<Customer>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<Customer> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customer = await response
            .Deserialize<Customer>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<Customer> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customer = await response
            .Deserialize<Customer>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<CustomerListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<CustomerListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<CustomerRetrievePaymentMethodsResponse> RetrievePaymentMethods(
        CustomerRetrievePaymentMethodsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerRetrievePaymentMethodsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<CustomerRetrievePaymentMethodsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
