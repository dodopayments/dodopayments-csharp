using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Customers.Wallets;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ILedgerEntryService.List(LedgerEntryListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class LedgerEntryListPage(
    ILedgerEntryServiceWithRawResponse service,
    LedgerEntryListParams parameters,
    LedgerEntryListPageResponse response
) : IPage<CustomerWalletTransaction>
{
    /// <inheritdoc/>
    public IReadOnlyList<CustomerWalletTransaction> Items
    {
        get { return response.Items; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<CustomerWalletTransaction>> IPage<CustomerWalletTransaction>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<LedgerEntryListPage> Next(CancellationToken cancellationToken = default)
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
}
