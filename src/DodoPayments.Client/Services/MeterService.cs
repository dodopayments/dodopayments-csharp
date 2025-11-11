using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services;

public sealed class MeterService : IMeterService
{
    public IMeterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MeterService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public MeterService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<Meter> Create(
        MeterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MeterCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var meter = await response.Deserialize<Meter>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            meter.Validate();
        }
        return meter;
    }

    public async Task<Meter> Retrieve(
        MeterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MeterRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var meter = await response.Deserialize<Meter>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            meter.Validate();
        }
        return meter;
    }

    public async Task<MeterListPageResponse> List(
        MeterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MeterListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<MeterListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Archive(
        MeterArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MeterArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Unarchive(
        MeterUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MeterUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
