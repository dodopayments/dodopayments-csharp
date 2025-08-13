using System.Collections.Generic;
using System.Threading.Tasks;
using DodoPayments.Models.Misc;

namespace DodoPayments.Services.Misc;

public interface IMiscService
{
    Task<List<CountryCode>> ListSupportedCountries(MiscListSupportedCountriesParams parameters);
}
