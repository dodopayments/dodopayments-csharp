using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Services;

public sealed class UsageEventService : IUsageEventService
{
    public IUsageEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageEventService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public UsageEventService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<Event> Retrieve(
        UsageEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UsageEventRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Event>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<UsageEventListPageResponse> List(
        UsageEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UsageEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<UsageEventListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<UsageEventIngestResponse> Ingest(
        UsageEventIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UsageEventIngestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<UsageEventIngestResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
