using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.Customers;
using CustomerPortal = Dodopayments.Services.Customers.CustomerPortal;
using Dodopayments = Dodopayments;
using Wallets = Dodopayments.Services.Customers.Wallets;

namespace Dodopayments.Services.Customers;

public sealed class CustomerService : ICustomerService
{
    readonly Dodopayments::IDodoPaymentsClient _client;

    public CustomerService(Dodopayments::IDodoPaymentsClient client)
    {
        _client = client;
        _customerPortal = new(() => new CustomerPortal::CustomerPortalService(client));
        _wallets = new(() => new Wallets::WalletService(client));
    }

    readonly Lazy<CustomerPortal::ICustomerPortalService> _customerPortal;
    public CustomerPortal::ICustomerPortalService CustomerPortal
    {
        get { return _customerPortal.Value; }
    }

    readonly Lazy<Wallets::IWalletService> _wallets;
    public Wallets::IWalletService Wallets
    {
        get { return _wallets.Value; }
    }

    public async Task<Customer> Create(CustomerCreateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Customer>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<Customer> Retrieve(CustomerRetrieveParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Customer>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<Customer> Update(CustomerUpdateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Patch, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Customer>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<CustomerListPageResponse> List(CustomerListParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<CustomerListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
