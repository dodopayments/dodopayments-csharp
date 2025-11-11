using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Services;

public sealed class SubscriptionService : ISubscriptionService
{
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public SubscriptionService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<SubscriptionCreateResponse> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscription = await response
            .Deserialize<SubscriptionCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<Subscription> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscription = await response
            .Deserialize<Subscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<Subscription> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscription = await response
            .Deserialize<Subscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<SubscriptionListPageResponse> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<SubscriptionListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task ChangePlan(
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionChangePlanParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<SubscriptionChargeResponse> Charge(
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionChargeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SubscriptionChargeResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<SubscriptionRetrieveUsageHistoryPageResponse> RetrieveUsageHistory(
        SubscriptionRetrieveUsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionRetrieveUsageHistoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<SubscriptionRetrieveUsageHistoryPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
