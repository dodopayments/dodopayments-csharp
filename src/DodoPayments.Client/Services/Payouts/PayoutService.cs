using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Services.Payouts;

public sealed class PayoutService : IPayoutService
{
    public IPayoutService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PayoutService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public PayoutService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<PayoutListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<PayoutListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
