using System.Threading.Tasks;
using DodoPayments.Models.LicenseKeys;

namespace DodoPayments.Services.LicenseKeys;

public interface ILicenseKeyService
{
    Task<LicenseKey> Retrieve(LicenseKeyRetrieveParams parameters);

    Task<LicenseKey> Update(LicenseKeyUpdateParams parameters);

    Task<LicenseKeyListPageResponse> List(LicenseKeyListParams parameters);
}
