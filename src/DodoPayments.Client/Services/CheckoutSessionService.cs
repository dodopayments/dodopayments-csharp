using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Services;

public sealed class CheckoutSessionService : ICheckoutSessionService
{
    public ICheckoutSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckoutSessionService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public CheckoutSessionService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<CheckoutSessionResponse> Create(
        CheckoutSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CheckoutSessionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var checkoutSessionResponse = await response
            .Deserialize<CheckoutSessionResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            checkoutSessionResponse.Validate();
        }
        return checkoutSessionResponse;
    }

    public async Task<CheckoutSessionStatus> Retrieve(
        CheckoutSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CheckoutSessionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var checkoutSessionStatus = await response
            .Deserialize<CheckoutSessionStatus>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            checkoutSessionStatus.Validate();
        }
        return checkoutSessionStatus;
    }
}
