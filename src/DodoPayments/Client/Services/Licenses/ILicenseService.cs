using System.Threading.Tasks;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Services.Licenses;

public interface ILicenseService
{
    Task<LicenseActivateResponse> Activate(LicenseActivateParams parameters);

    Task Deactivate(LicenseDeactivateParams parameters);

    Task<LicenseValidateResponse> Validate(LicenseValidateParams parameters);
}
