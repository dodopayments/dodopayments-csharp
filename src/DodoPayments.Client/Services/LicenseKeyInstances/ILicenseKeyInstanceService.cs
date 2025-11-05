using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services.LicenseKeyInstances;

public interface ILicenseKeyInstanceService
{
    ILicenseKeyInstanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<LicenseKeyInstance> Retrieve(LicenseKeyInstanceRetrieveParams parameters);

    Task<LicenseKeyInstance> Update(LicenseKeyInstanceUpdateParams parameters);

    Task<LicenseKeyInstanceListPageResponse> List(LicenseKeyInstanceListParams? parameters = null);
}
