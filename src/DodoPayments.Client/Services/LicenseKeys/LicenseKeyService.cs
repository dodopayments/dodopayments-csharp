using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Services.LicenseKeys;

public sealed class LicenseKeyService : ILicenseKeyService
{
    readonly IDodoPaymentsClient _client;

    public LicenseKeyService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<LicenseKey> Retrieve(LicenseKeyRetrieveParams parameters)
    {
        HttpRequest<LicenseKeyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LicenseKey>().ConfigureAwait(false);
    }

    public async Task<LicenseKey> Update(LicenseKeyUpdateParams parameters)
    {
        HttpRequest<LicenseKeyUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LicenseKey>().ConfigureAwait(false);
    }

    public async Task<LicenseKeyListPageResponse> List(LicenseKeyListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<LicenseKeyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LicenseKeyListPageResponse>().ConfigureAwait(false);
    }
}
