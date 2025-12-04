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
[JsonConverter(typeof(ModelConverter<AddonCartResponseItem, AddonCartResponseItemFromRaw>))]
public sealed record class AddonCartResponseItem : ModelBase
{
    public required string AddonID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "addon_id"); }
        init { ModelBase.Set(this._rawData, "addon_id", value); }
    }

    public required int Quantity
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Quantity;
    }

    public AddonCartResponseItem() { }

    public AddonCartResponseItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonCartResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class AddonCartResponseItemFromRaw : IFromRaw<AddonCartResponseItem>
{
    /// <inheritdoc/>
    public AddonCartResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonCartResponseItem.FromRawUnchecked(rawData);
}
