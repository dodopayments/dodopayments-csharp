using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Services.LicenseKeys;

public interface ILicenseKeyService
{
    ILicenseKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<LicenseKey> Retrieve(LicenseKeyRetrieveParams parameters);

    Task<LicenseKey> Update(LicenseKeyUpdateParams parameters);

    Task<LicenseKeyListPageResponse> List(LicenseKeyListParams? parameters = null);
}
