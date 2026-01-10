using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class PayoutService : IPayoutService
{
    readonly Lazy<IPayoutServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPayoutServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IPayoutService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PayoutService(this._client.WithOptions(modifier));
    }

    public PayoutService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PayoutServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PayoutListPage> List(
        PayoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PayoutServiceWithRawResponse : IPayoutServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPayoutServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PayoutServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PayoutServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayoutListPage>> List(
        PayoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PayoutListParams> request = new()
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
                    .Deserialize<PayoutListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PayoutListPage(this, parameters, page);
            }
        );
    }
}
