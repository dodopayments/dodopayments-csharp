using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services;

namespace DodoPayments.Client.Models.Refunds;

public sealed class RefundListPage(
    IRefundServiceWithRawResponse service,
    RefundListParams parameters,
    RefundListPageResponse response
) : IPage<RefundListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<RefundListResponse> Items
    {
        get { return response.Items; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<RefundListResponse>> IPage<RefundListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<RefundListPage> Next(CancellationToken cancellationToken = default)
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
