using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Customers.CustomerPortal;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Services.Customers.CustomerPortal;

public sealed class CustomerPortalService : ICustomerPortalService
{
    readonly Client::IDodoPaymentsClient _client;

    public CustomerPortalService(Client::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<CustomerPortalSession> Create(CustomerPortalCreateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Client::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<CustomerPortalSession>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Client::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
