using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.CreditEntitlements;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IBalanceService.ListLedger(BalanceListLedgerParams, CancellationToken)"/> queries.
/// </summary>
public sealed class BalanceListLedgerPage(
    IBalanceServiceWithRawResponse service,
    BalanceListLedgerParams parameters,
    BalanceListLedgerPageResponse response
) : IPage<CreditLedgerEntry>
{
    /// <inheritdoc/>
    public IReadOnlyList<CreditLedgerEntry> Items
    {
        get { return response.Items; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<CreditLedgerEntry>> IPage<CreditLedgerEntry>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<BalanceListLedgerPage> Next(CancellationToken cancellationToken = default)
    {
        var currentPageNumber = parameters.PageNumber ?? 1;
        using var nextResponse = await service
            .ListLedger(parameters with { PageNumber = currentPageNumber + 1 }, cancellationToken)
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
        if (obj is not BalanceListLedgerPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
