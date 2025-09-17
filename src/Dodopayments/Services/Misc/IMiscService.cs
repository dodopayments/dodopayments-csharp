using System.Collections.Generic;
using System.Threading.Tasks;
using Dodopayments.Models.Misc;

namespace Dodopayments.Services.Misc;

public interface IMiscService
{
    Task<List<CountryCode>> ListSupportedCountries(MiscListSupportedCountriesParams parameters);
}
