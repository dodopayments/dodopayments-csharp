using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Services.Meters;

public sealed class MeterService : IMeterService
{
    readonly IDodoPaymentsClient _client;

    public MeterService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<Meter> Create(MeterCreateParams parameters)
    {
        HttpRequest<MeterCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Meter>().ConfigureAwait(false);
    }

    public async Task<Meter> Retrieve(MeterRetrieveParams parameters)
    {
        HttpRequest<MeterRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Meter>().ConfigureAwait(false);
    }

    public async Task<MeterListPageResponse> List(MeterListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<MeterListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MeterListPageResponse>().ConfigureAwait(false);
    }

    public async Task Archive(MeterArchiveParams parameters)
    {
        HttpRequest<MeterArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task Unarchive(MeterUnarchiveParams parameters)
    {
        HttpRequest<MeterUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
