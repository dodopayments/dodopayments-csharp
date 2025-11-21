using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Services;

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

    public async Task<GetDispute> Retrieve(
        DisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DisputeID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.DisputeID' cannot be null");
        }

        HttpRequest<DisputeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var getDispute = await response
            .Deserialize<GetDispute>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            getDispute.Validate();
        }
        return getDispute;
    }

    public async Task<GetDispute> Retrieve(
        string disputeID,
        DisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { DisputeID = disputeID }, cancellationToken);
    }

    public async Task<DisputeListPageResponse> List(
        DisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DisputeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<DisputeListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
