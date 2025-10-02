using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks.Headers;

public sealed class HeaderService : IHeaderService
{
    readonly IDodoPaymentsClient _client;

    public HeaderService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<HeaderRetrieveResponse> Retrieve(HeaderRetrieveParams parameters)
    {
        HttpRequest<HeaderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<HeaderRetrieveResponse>().ConfigureAwait(false);
    }

    public async Task Update(HeaderUpdateParams parameters)
    {
        HttpRequest<HeaderUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
