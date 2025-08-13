using System.Threading.Tasks;
using DodoPayments.Models.LicenseKeyInstances;

namespace DodoPayments.Services.LicenseKeyInstances;

public interface ILicenseKeyInstanceService
{
    Task<LicenseKeyInstance> Retrieve(LicenseKeyInstanceRetrieveParams parameters);

    Task<LicenseKeyInstance> Update(LicenseKeyInstanceUpdateParams parameters);

    Task<LicenseKeyInstanceListPageResponse> List(LicenseKeyInstanceListParams parameters);
}
