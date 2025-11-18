using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMiscService
{
    IMiscService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<List<ApiEnum<string, CountryCode>>> ListSupportedCountries(
        MiscListSupportedCountriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
