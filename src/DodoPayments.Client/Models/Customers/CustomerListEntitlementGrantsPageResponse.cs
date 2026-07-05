using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListEntitlementGrantsPageResponse,
        CustomerListEntitlementGrantsPageResponseFromRaw
    >)
)]
public sealed record class CustomerListEntitlementGrantsPageResponse : JsonModel
{
    public required IReadOnlyList<EntitlementGrant> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntitlementGrant>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntitlementGrant>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public CustomerListEntitlementGrantsPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListEntitlementGrantsPageResponse(
        CustomerListEntitlementGrantsPageResponse customerListEntitlementGrantsPageResponse
    )
        : base(customerListEntitlementGrantsPageResponse) { }
#pragma warning restore CS8618

    public CustomerListEntitlementGrantsPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListEntitlementGrantsPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListEntitlementGrantsPageResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListEntitlementGrantsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerListEntitlementGrantsPageResponse(IReadOnlyList<EntitlementGrant> items)
        : this()
    {
        this.Items = items;
    }
}

class CustomerListEntitlementGrantsPageResponseFromRaw
    : IFromRawJson<CustomerListEntitlementGrantsPageResponse>
{
    /// <inheritdoc/>
    public CustomerListEntitlementGrantsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListEntitlementGrantsPageResponse.FromRawUnchecked(rawData);
}
