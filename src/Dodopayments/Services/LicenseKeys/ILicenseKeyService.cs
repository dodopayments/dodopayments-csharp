using System.Threading.Tasks;
using Dodopayments.Models.LicenseKeys;

namespace Dodopayments.Services.LicenseKeys;

public interface ILicenseKeyService
{
    Task<LicenseKey> Retrieve(LicenseKeyRetrieveParams parameters);

    Task<LicenseKey> Update(LicenseKeyUpdateParams parameters);

    Task<LicenseKeyListPageResponse> List(LicenseKeyListParams parameters);
}
