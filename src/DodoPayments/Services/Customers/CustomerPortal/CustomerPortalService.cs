using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Models.Customers;
using DodoPayments.Models.Customers.CustomerPortal;
using DodoPayments = DodoPayments;

namespace DodoPayments.Services.Customers.CustomerPortal;

public sealed class CustomerPortalService : ICustomerPortalService
{
    readonly DodoPayments::IDodoPaymentsClient _client;

    public CustomerPortalService(DodoPayments::IDodoPaymentsClient client)
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<CustomerPortalSession>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
