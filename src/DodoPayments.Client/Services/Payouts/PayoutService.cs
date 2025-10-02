using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Services.Payouts;

public sealed class PayoutService : IPayoutService
{
    readonly IDodoPaymentsClient _client;

    public PayoutService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<PayoutListPageResponse> List(PayoutListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<PayoutListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PayoutListPageResponse>().ConfigureAwait(false);
    }
}
