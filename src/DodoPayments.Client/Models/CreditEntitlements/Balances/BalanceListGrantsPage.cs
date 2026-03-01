using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.CreditEntitlements;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IBalanceService.ListGrants(BalanceListGrantsParams, CancellationToken)"/> queries.
/// </summary>
public sealed class BalanceListGrantsPage(
    IBalanceServiceWithRawResponse service,
    BalanceListGrantsParams parameters,
    BalanceListGrantsPageResponse response
) : IPage<BalanceListGrantsResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<BalanceListGrantsResponse> Items
    {
        get { return response.Items; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<BalanceListGrantsResponse>> IPage<BalanceListGrantsResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<BalanceListGrantsPage> Next(CancellationToken cancellationToken = default)
    {
        var currentPageNumber = parameters.PageNumber ?? 1;
        using var nextResponse = await service
            .ListGrants(parameters with { PageNumber = currentPageNumber + 1 }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not BalanceListGrantsPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
