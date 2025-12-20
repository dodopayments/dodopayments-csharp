using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services;

namespace DodoPayments.Client.Models.LicenseKeyInstances;

public sealed class LicenseKeyInstanceListPage(
    ILicenseKeyInstanceService service,
    LicenseKeyInstanceListParams parameters,
    LicenseKeyInstanceListPageResponse response
) : IPage<LicenseKeyInstance>
{
    /// <inheritdoc/>
    public IReadOnlyList<LicenseKeyInstance> Items
    {
        get { return response.Items; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<LicenseKeyInstance>> IPage<LicenseKeyInstance>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<LicenseKeyInstanceListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var currentPageNumber = parameters.PageNumber ?? 1;
        return await service
            .List(parameters with { PageNumber = currentPageNumber + 1 }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
