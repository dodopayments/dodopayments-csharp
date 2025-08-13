using System.Threading.Tasks;
using DodoPayments.Models.LicenseKeyInstances;
using DodoPayments.Models.Licenses;

namespace DodoPayments.Services.Licenses;

public interface ILicenseService
{
    Task<LicenseKeyInstance> Activate(LicenseActivateParams parameters);

    Task Deactivate(LicenseDeactivateParams parameters);

    Task<LicenseValidateResponse> Validate(LicenseValidateParams parameters);
}
