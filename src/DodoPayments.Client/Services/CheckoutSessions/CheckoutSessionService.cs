using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Services.CheckoutSessions;

public sealed class CheckoutSessionService : ICheckoutSessionService
{
    readonly IDodoPaymentsClient _client;

    public CheckoutSessionService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<CheckoutSessionResponse> Create(CheckoutSessionCreateParams parameters)
    {
        HttpRequest<CheckoutSessionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var checkoutSessionResponse = await response
            .Deserialize<CheckoutSessionResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            checkoutSessionResponse.Validate();
        }
        return checkoutSessionResponse;
    }

    public async Task<CheckoutSessionStatus> Retrieve(CheckoutSessionRetrieveParams parameters)
    {
        HttpRequest<CheckoutSessionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var checkoutSessionStatus = await response
            .Deserialize<CheckoutSessionStatus>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            checkoutSessionStatus.Validate();
        }
        return checkoutSessionStatus;
    }
}
