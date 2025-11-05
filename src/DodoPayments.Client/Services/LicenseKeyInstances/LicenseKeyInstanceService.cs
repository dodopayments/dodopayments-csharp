using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services.LicenseKeyInstances;

public sealed class LicenseKeyInstanceService : ILicenseKeyInstanceService
{
    public ILicenseKeyInstanceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseKeyInstanceService(this._client.WithOptions(modifier));
    }

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
        var licenseKeyInstance = await response
            .Deserialize<LicenseKeyInstance>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            licenseKeyInstance.Validate();
        }
        return licenseKeyInstance;
    }

    public async Task<LicenseKeyInstance> Update(LicenseKeyInstanceUpdateParams parameters)
    {
        HttpRequest<LicenseKeyInstanceUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var licenseKeyInstance = await response
            .Deserialize<LicenseKeyInstance>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            licenseKeyInstance.Validate();
        }
        return licenseKeyInstance;
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
        var page = await response
            .Deserialize<LicenseKeyInstanceListPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
