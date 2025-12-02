using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Services;

/// <inheritdoc />
public sealed class SubscriptionService : ISubscriptionService
{
    /// <inheritdoc/>
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public SubscriptionService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<Subscription> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "'parameters.SubscriptionID' cannot be null"
            );
        }

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

    /// <inheritdoc/>
    public async Task<Subscription> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Subscription> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "'parameters.SubscriptionID' cannot be null"
            );
        }

        HttpRequest<SubscriptionUpdateParams> request = new()
        {
            Method = DodoPaymentsClient.PatchMethod,
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

    /// <inheritdoc/>
    public async Task<Subscription> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task ChangePlan(
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "'parameters.SubscriptionID' cannot be null"
            );
        }

        HttpRequest<SubscriptionChangePlanParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task ChangePlan(
        string subscriptionID,
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.ChangePlan(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChargeResponse> Charge(
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "'parameters.SubscriptionID' cannot be null"
            );
        }

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

    /// <inheritdoc/>
    public async Task<SubscriptionChargeResponse> Charge(
        string subscriptionID,
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Charge(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionRetrieveUsageHistoryPageResponse> RetrieveUsageHistory(
        SubscriptionRetrieveUsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "'parameters.SubscriptionID' cannot be null"
            );
        }

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

    /// <inheritdoc/>
    public async Task<SubscriptionRetrieveUsageHistoryPageResponse> RetrieveUsageHistory(
        string subscriptionID,
        SubscriptionRetrieveUsageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.RetrieveUsageHistory(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionUpdatePaymentMethodResponse> UpdatePaymentMethod(
        SubscriptionUpdatePaymentMethodParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "'parameters.SubscriptionID' cannot be null"
            );
        }

        HttpRequest<SubscriptionUpdatePaymentMethodParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SubscriptionUpdatePaymentMethodResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionUpdatePaymentMethodResponse> UpdatePaymentMethod(
        string subscriptionID,
        SubscriptionUpdatePaymentMethodParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.UpdatePaymentMethod(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }
}
