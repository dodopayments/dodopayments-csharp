using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Services.Subscriptions;

public sealed class SubscriptionService : ISubscriptionService
{
    readonly IDodoPaymentsClient _client;

    public SubscriptionService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<SubscriptionCreateResponse> Create(SubscriptionCreateParams parameters)
    {
        HttpRequest<SubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionCreateResponse>().ConfigureAwait(false);
    }

    public async Task<Subscription> Retrieve(SubscriptionRetrieveParams parameters)
    {
        HttpRequest<SubscriptionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Subscription>().ConfigureAwait(false);
    }

    public async Task<Subscription> Update(SubscriptionUpdateParams parameters)
    {
        HttpRequest<SubscriptionUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Subscription>().ConfigureAwait(false);
    }

    public async Task<SubscriptionListPageResponse> List(SubscriptionListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionListPageResponse>().ConfigureAwait(false);
    }

    public async Task ChangePlan(SubscriptionChangePlanParams parameters)
    {
        HttpRequest<SubscriptionChangePlanParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<SubscriptionChargeResponse> Charge(SubscriptionChargeParams parameters)
    {
        HttpRequest<SubscriptionChargeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionChargeResponse>().ConfigureAwait(false);
    }

    public async Task<SubscriptionRetrieveUsageHistoryPageResponse> RetrieveUsageHistory(
        SubscriptionRetrieveUsageHistoryParams parameters
    )
    {
        HttpRequest<SubscriptionRetrieveUsageHistoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<SubscriptionRetrieveUsageHistoryPageResponse>()
            .ConfigureAwait(false);
    }
}
