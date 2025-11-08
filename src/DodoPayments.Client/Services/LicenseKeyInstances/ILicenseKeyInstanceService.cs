using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services.LicenseKeyInstances;

public interface ILicenseKeyInstanceService
{
    ILicenseKeyInstanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<LicenseKeyInstance> Retrieve(
        LicenseKeyInstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<LicenseKeyInstance> Update(
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<LicenseKeyInstanceListPageResponse> List(
        LicenseKeyInstanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
