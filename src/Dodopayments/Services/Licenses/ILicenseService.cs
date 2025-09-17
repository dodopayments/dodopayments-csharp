using System.Threading.Tasks;
using Dodopayments.Models.Licenses;

namespace Dodopayments.Services.Licenses;

public interface ILicenseService
{
    Task<LicenseActivateResponse> Activate(LicenseActivateParams parameters);

    Task Deactivate(LicenseDeactivateParams parameters);

    Task<LicenseValidateResponse> Validate(LicenseValidateParams parameters);
}
