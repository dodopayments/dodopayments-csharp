using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Response struct representing subscription details
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AddonCartResponseItem, AddonCartResponseItemFromRaw>))]
public sealed record class AddonCartResponseItem : JsonModel
{
    public required string AddonID
    {
        get { return this._rawData.GetNotNullClass<string>("addon_id"); }
        init { this._rawData.Set("addon_id", value); }
    }

    public required int Quantity
    {
        get { return this._rawData.GetNotNullStruct<int>("quantity"); }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Quantity;
    }

    public AddonCartResponseItem() { }

    public AddonCartResponseItem(AddonCartResponseItem addonCartResponseItem)
        : base(addonCartResponseItem) { }

    public AddonCartResponseItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonCartResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonCartResponseItemFromRaw.FromRawUnchecked"/>
    public static AddonCartResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonCartResponseItemFromRaw : IFromRawJson<AddonCartResponseItem>
{
    /// <inheritdoc/>
    public AddonCartResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonCartResponseItem.FromRawUnchecked(rawData);
}
