using System;
using System.Net.Http;
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

    public async Task<Meters::Meter> Create(Meters::MeterCreateParams parameters)
    {
        HttpRequest<Meters::MeterCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var meter = await response.Deserialize<Meters::Meter>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            meter.Validate();
        }
        return meter;
    }

    public async Task<Meters::Meter> Retrieve(Meters::MeterRetrieveParams parameters)
    {
        HttpRequest<Meters::MeterRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var meter = await response.Deserialize<Meters::Meter>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            meter.Validate();
        }
        return meter;
    }

    public async Task<Meters::MeterListPageResponse> List(
        Meters::MeterListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<Meters::MeterListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<Meters::MeterListPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Archive(Meters::MeterArchiveParams parameters)
    {
        HttpRequest<Meters::MeterArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task Unarchive(Meters::MeterUnarchiveParams parameters)
    {
        HttpRequest<Meters::MeterUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }
}
