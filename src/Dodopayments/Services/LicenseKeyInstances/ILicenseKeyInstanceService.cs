using System.Threading.Tasks;
using Dodopayments.Models.LicenseKeyInstances;

namespace Dodopayments.Services.LicenseKeyInstances;

public interface ILicenseKeyInstanceService
{
    Task<LicenseKeyInstance> Retrieve(LicenseKeyInstanceRetrieveParams parameters);

    Task<LicenseKeyInstance> Update(LicenseKeyInstanceUpdateParams parameters);

    Task<LicenseKeyInstanceListPageResponse> List(LicenseKeyInstanceListParams parameters);
}
