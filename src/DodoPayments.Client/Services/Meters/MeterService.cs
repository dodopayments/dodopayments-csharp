using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using Meters = DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services.Meters;

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

    public async Task<Meters::Meter> Create(
        Meters::MeterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Meters::MeterCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var meter = await response
            .Deserialize<Meters::Meter>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            meter.Validate();
        }
        return meter;
    }

    public async Task<Meters::Meter> Retrieve(
        Meters::MeterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Meters::MeterRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var meter = await response
            .Deserialize<Meters::Meter>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            meter.Validate();
        }
        return meter;
    }

    public async Task<Meters::MeterListPageResponse> List(
        Meters::MeterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Meters::MeterListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<Meters::MeterListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Archive(
        Meters::MeterArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Meters::MeterArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Unarchive(
        Meters::MeterUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Meters::MeterUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
