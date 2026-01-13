using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class SubscriptionService : ISubscriptionService
{
    readonly Lazy<ISubscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    public SubscriptionService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SubscriptionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<SubscriptionCreateResponse> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Subscription> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Subscription> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
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
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Subscription> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListPage> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ChangePlan(
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ChangePlan(parameters, cancellationToken);
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
            )
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChargeResponse> Charge(
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Charge(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionChargeResponse> Charge(
        string subscriptionID,
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Charge(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionPreviewChangePlanResponse> PreviewChangePlan(
        SubscriptionPreviewChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.PreviewChangePlan(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionPreviewChangePlanResponse> PreviewChangePlan(
        string subscriptionID,
        SubscriptionPreviewChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PreviewChangePlan(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionRetrieveUsageHistoryPage> RetrieveUsageHistory(
        SubscriptionRetrieveUsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveUsageHistory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionRetrieveUsageHistoryPage> RetrieveUsageHistory(
        string subscriptionID,
        SubscriptionRetrieveUsageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveUsageHistory(
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
        using var response = await this
            .WithRawResponse.UpdatePaymentMethod(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionUpdatePaymentMethodResponse> UpdatePaymentMethod(
        string subscriptionID,
        SubscriptionUpdatePaymentMethodParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdatePaymentMethod(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class SubscriptionServiceWithRawResponse : ISubscriptionServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubscriptionServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<SubscriptionCreateResponse>> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<SubscriptionCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Subscription>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<Subscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Subscription>> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Subscription>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<Subscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Subscription>> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SubscriptionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SubscriptionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ChangePlan(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ChangePlan(
        string subscriptionID,
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ChangePlan(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionChargeResponse>> Charge(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SubscriptionChargeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionChargeResponse>> Charge(
        string subscriptionID,
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Charge(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionPreviewChangePlanResponse>> PreviewChangePlan(
        SubscriptionPreviewChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "'parameters.SubscriptionID' cannot be null"
            );
        }

        HttpRequest<SubscriptionPreviewChangePlanParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SubscriptionPreviewChangePlanResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionPreviewChangePlanResponse>> PreviewChangePlan(
        string subscriptionID,
        SubscriptionPreviewChangePlanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PreviewChangePlan(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionRetrieveUsageHistoryPage>> RetrieveUsageHistory(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SubscriptionRetrieveUsageHistoryPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SubscriptionRetrieveUsageHistoryPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionRetrieveUsageHistoryPage>> RetrieveUsageHistory(
        string subscriptionID,
        SubscriptionRetrieveUsageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveUsageHistory(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionUpdatePaymentMethodResponse>> UpdatePaymentMethod(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SubscriptionUpdatePaymentMethodResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionUpdatePaymentMethodResponse>> UpdatePaymentMethod(
        string subscriptionID,
        SubscriptionUpdatePaymentMethodParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdatePaymentMethod(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }
}
