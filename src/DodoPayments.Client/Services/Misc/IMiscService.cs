using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services.Misc;

public interface IMiscService
{
    IMiscService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<List<ApiEnum<string, CountryCode>>> ListSupportedCountries(
        MiscListSupportedCountriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
