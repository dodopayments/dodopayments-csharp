using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Services.UsageEvents;

public sealed class UsageEventService : IUsageEventService
{
    readonly IDodoPaymentsClient _client;

    public UsageEventService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<Event> Retrieve(UsageEventRetrieveParams parameters)
    {
        HttpRequest<UsageEventRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Event>().ConfigureAwait(false);
    }

    public async Task<UsageEventListPageResponse> List(UsageEventListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<UsageEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<UsageEventListPageResponse>().ConfigureAwait(false);
    }

    public async Task<UsageEventIngestResponse> Ingest(UsageEventIngestParams parameters)
    {
        HttpRequest<UsageEventIngestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<UsageEventIngestResponse>().ConfigureAwait(false);
    }
}
