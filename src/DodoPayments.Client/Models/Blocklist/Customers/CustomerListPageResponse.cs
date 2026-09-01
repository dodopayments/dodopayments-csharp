using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Blocklist.Customers;

[JsonConverter(
    typeof(JsonModelConverter<CustomerListPageResponse, CustomerListPageResponseFromRaw>)
)]
public sealed record class CustomerListPageResponse : JsonModel
{
    public required IReadOnlyList<BlockedCustomer> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BlockedCustomer>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BlockedCustomer>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Blocked customers that match the filters, before pagination.
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.Total;
    }

    public CustomerListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListPageResponse(CustomerListPageResponse customerListPageResponse)
        : base(customerListPageResponse) { }
#pragma warning restore CS8618

    public CustomerListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListPageResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListPageResponseFromRaw : IFromRawJson<CustomerListPageResponse>
{
    /// <inheritdoc/>
    public CustomerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListPageResponse.FromRawUnchecked(rawData);
}
