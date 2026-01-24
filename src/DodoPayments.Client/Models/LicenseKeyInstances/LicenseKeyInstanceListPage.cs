using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services;

namespace DodoPayments.Client.Models.LicenseKeyInstances;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ILicenseKeyInstanceService.List(LicenseKeyInstanceListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class LicenseKeyInstanceListPage(
    ILicenseKeyInstanceServiceWithRawResponse service,
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
        using var nextResponse = await service
            .List(parameters with { PageNumber = currentPageNumber + 1 }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this.Items, ModelBase.ToStringSerializerOptions);

    public override bool Equals(object? obj)
    {
        if (obj is not LicenseKeyInstanceListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
