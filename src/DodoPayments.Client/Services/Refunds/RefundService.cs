using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Services.Refunds;

public sealed class RefundService : IRefundService
{
    readonly IDodoPaymentsClient _client;

    public RefundService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<Refund> Create(RefundCreateParams parameters)
    {
        HttpRequest<RefundCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Refund>().ConfigureAwait(false);
    }

    public async Task<Refund> Retrieve(RefundRetrieveParams parameters)
    {
        HttpRequest<RefundRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Refund>().ConfigureAwait(false);
    }

    public async Task<RefundListPageResponse> List(RefundListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<RefundListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<RefundListPageResponse>().ConfigureAwait(false);
    }
}
