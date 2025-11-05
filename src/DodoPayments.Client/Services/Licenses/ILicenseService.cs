using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Services.Licenses;

public interface ILicenseService
{
    ILicenseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<LicenseActivateResponse> Activate(LicenseActivateParams parameters);

    Task Deactivate(LicenseDeactivateParams parameters);

    Task<LicenseValidateResponse> Validate(LicenseValidateParams parameters);
}
