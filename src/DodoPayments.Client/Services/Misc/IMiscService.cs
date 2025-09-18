using System.Collections.Generic;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services.Misc;

public interface IMiscService
{
    Task<List<ApiEnum<string, CountryCode>>> ListSupportedCountries(
        MiscListSupportedCountriesParams? parameters = null
    );
}
