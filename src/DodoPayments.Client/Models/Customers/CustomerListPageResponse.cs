using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<CustomerListPageResponse, CustomerListPageResponseFromRaw>)
)]
public sealed record class CustomerListPageResponse : JsonModel
{
    public required IReadOnlyList<Customer> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Customer>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Customer>>(
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

    public CustomerListPageResponse() { }

    public CustomerListPageResponse(CustomerListPageResponse customerListPageResponse)
        : base(customerListPageResponse) { }

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

    [SetsRequiredMembers]
    public CustomerListPageResponse(IReadOnlyList<Customer> items)
        : this()
    {
        this.Items = items;
    }
}

class CustomerListPageResponseFromRaw : IFromRawJson<CustomerListPageResponse>
{
    /// <inheritdoc/>
    public CustomerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListPageResponse.FromRawUnchecked(rawData);
}
