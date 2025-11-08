using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Services.Webhooks.Headers;

public sealed class HeaderService : IHeaderService
{
    public IHeaderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HeaderService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public HeaderService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<HeaderRetrieveResponse> Retrieve(
        HeaderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<HeaderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var header = await response
            .Deserialize<HeaderRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            header.Validate();
        }
        return header;
    }

    public async Task Update(
        HeaderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<HeaderUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
