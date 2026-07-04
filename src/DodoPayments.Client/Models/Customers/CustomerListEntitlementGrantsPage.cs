using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements.Grants;
using DodoPayments.Client.Services;

namespace DodoPayments.Client.Models.Customers;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ICustomerService.ListEntitlementGrants(CustomerListEntitlementGrantsParams, CancellationToken)"/> queries.
/// </summary>
public sealed class CustomerListEntitlementGrantsPage(
    ICustomerServiceWithRawResponse service,
    CustomerListEntitlementGrantsParams parameters,
    CustomerListEntitlementGrantsPageResponse response
) : IPage<EntitlementGrant>
{
    /// <inheritdoc/>
    public IReadOnlyList<EntitlementGrant> Items
    {
        get { return response.Items; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<EntitlementGrant>> IPage<EntitlementGrant>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<CustomerListEntitlementGrantsPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var currentPageNumber = parameters.PageNumber ?? 1;
        using var nextResponse = await service
            .ListEntitlementGrants(
                parameters with
                {
                    PageNumber = currentPageNumber + 1,
                },
                cancellationToken
            )
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
        if (obj is not CustomerListEntitlementGrantsPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
