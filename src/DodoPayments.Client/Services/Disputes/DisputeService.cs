using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Services.Disputes;

public sealed class DisputeService : IDisputeService
{
    public IDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DisputeService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public DisputeService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<GetDispute> Retrieve(DisputeRetrieveParams parameters)
    {
        HttpRequest<DisputeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var getDispute = await response.Deserialize<GetDispute>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            getDispute.Validate();
        }
        return getDispute;
    }

    public async Task<DisputeListPageResponse> List(DisputeListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<DisputeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<DisputeListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
