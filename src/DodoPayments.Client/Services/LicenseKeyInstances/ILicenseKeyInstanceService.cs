using System.Threading.Tasks;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Services.LicenseKeyInstances;

public interface ILicenseKeyInstanceService
{
    Task<LicenseKeyInstance> Retrieve(LicenseKeyInstanceRetrieveParams parameters);

    Task<LicenseKeyInstance> Update(LicenseKeyInstanceUpdateParams parameters);

    Task<LicenseKeyInstanceListPageResponse> List(LicenseKeyInstanceListParams? parameters = null);
}
