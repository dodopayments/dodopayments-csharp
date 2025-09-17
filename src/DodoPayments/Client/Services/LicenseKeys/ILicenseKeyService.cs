using System.Threading.Tasks;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Services.LicenseKeys;

public interface ILicenseKeyService
{
    Task<LicenseKey> Retrieve(LicenseKeyRetrieveParams parameters);

    Task<LicenseKey> Update(LicenseKeyUpdateParams parameters);

    Task<LicenseKeyListPageResponse> List(LicenseKeyListParams parameters);
}
