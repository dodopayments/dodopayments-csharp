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
        return await response.Deserialize<CheckoutSessionResponse>().ConfigureAwait(false);
    }
}
