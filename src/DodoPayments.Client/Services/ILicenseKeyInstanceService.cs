using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILicenseKeyInstanceService
{
    ILicenseKeyInstanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<LicenseKeyInstance> Retrieve(
        LicenseKeyInstanceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<LicenseKeyInstance> Retrieve(
        string id,
        LicenseKeyInstanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    Task<LicenseKeyInstance> Update(
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
    Task<LicenseKeyInstance> Update(
        string id,
        LicenseKeyInstanceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    Task<LicenseKeyInstanceListPageResponse> List(
        LicenseKeyInstanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
