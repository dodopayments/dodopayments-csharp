using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services.LicenseKeyInstances;

public sealed class LicenseKeyInstanceService : ILicenseKeyInstanceService
{
    readonly IDodoPaymentsClient _client;

    public LicenseKeyInstanceService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<LicenseKeyInstance> Retrieve(LicenseKeyInstanceRetrieveParams parameters)
    {
        HttpRequest<LicenseKeyInstanceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LicenseKeyInstance>().ConfigureAwait(false);
    }

    public async Task<LicenseKeyInstance> Update(LicenseKeyInstanceUpdateParams parameters)
    {
        HttpRequest<LicenseKeyInstanceUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LicenseKeyInstance>().ConfigureAwait(false);
    }

    public async Task<LicenseKeyInstanceListPageResponse> List(
        LicenseKeyInstanceListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<LicenseKeyInstanceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<LicenseKeyInstanceListPageResponse>()
            .ConfigureAwait(false);
    }
}
