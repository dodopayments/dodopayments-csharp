using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Services.Licenses;

public sealed class LicenseService : ILicenseService
{
    readonly IDodoPaymentsClient _client;

    public LicenseService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<LicenseActivateResponse> Activate(LicenseActivateParams parameters)
    {
        HttpRequest<LicenseActivateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LicenseActivateResponse>().ConfigureAwait(false);
    }

    public async Task Deactivate(LicenseDeactivateParams parameters)
    {
        HttpRequest<LicenseDeactivateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<LicenseValidateResponse> Validate(LicenseValidateParams parameters)
    {
        HttpRequest<LicenseValidateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LicenseValidateResponse>().ConfigureAwait(false);
    }
}
