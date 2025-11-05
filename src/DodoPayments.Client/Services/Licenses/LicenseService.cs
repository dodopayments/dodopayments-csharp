using System;
using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Services.Licenses;

public sealed class LicenseService : ILicenseService
{
    public ILicenseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseService(this._client.WithOptions(modifier));
    }

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
        var deserializedResponse = await response
            .Deserialize<LicenseActivateResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task Deactivate(LicenseDeactivateParams parameters)
    {
        HttpRequest<LicenseDeactivateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<LicenseValidateResponse> Validate(LicenseValidateParams parameters)
    {
        HttpRequest<LicenseValidateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<LicenseValidateResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
