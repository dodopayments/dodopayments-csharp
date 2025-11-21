using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services;

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

    public async Task<LicenseKeyInstance> Retrieve(
        LicenseKeyInstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LicenseKeyInstanceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var licenseKeyInstance = await response
            .Deserialize<LicenseKeyInstance>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            licenseKeyInstance.Validate();
        }
        return licenseKeyInstance;
    }

    public async Task<LicenseKeyInstance> Retrieve(
        string id,
        LicenseKeyInstanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    public async Task<LicenseKeyInstance> Update(
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LicenseKeyInstanceUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var licenseKeyInstance = await response
            .Deserialize<LicenseKeyInstance>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            licenseKeyInstance.Validate();
        }
        return licenseKeyInstance;
    }

    public async Task<LicenseKeyInstance> Update(
        string id,
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Update(parameters with { ID = id }, cancellationToken);
    }

    public async Task<LicenseKeyInstanceListPageResponse> List(
        LicenseKeyInstanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LicenseKeyInstanceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<LicenseKeyInstanceListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
