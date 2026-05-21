using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.ProductCollections.Groups;

[JsonConverter(typeof(JsonModelConverter<GroupProduct, GroupProductFromRaw>))]
public sealed record class GroupProduct : JsonModel
{
    /// <summary>
    /// Product ID to include in the group
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Status of the product in this group (defaults to true if not provided)
    /// </summary>
    public bool? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Status;
    }

    public GroupProduct() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupProduct(GroupProduct groupProduct)
        : base(groupProduct) { }
#pragma warning restore CS8618

    public GroupProduct(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupProduct(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupProductFromRaw.FromRawUnchecked"/>
    public static GroupProduct FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GroupProduct(string productID)
        : this()
    {
        this.ProductID = productID;
    }
}

class GroupProductFromRaw : IFromRawJson<GroupProduct>
{
    /// <inheritdoc/>
    public GroupProduct FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GroupProduct.FromRawUnchecked(rawData);
}
