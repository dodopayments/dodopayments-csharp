using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(JsonModelConverter<AttachAddon, AttachAddonFromRaw>))]
public sealed record class AttachAddon : JsonModel
{
    public required string AddonID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "addon_id"); }
        init { JsonModel.Set(this._rawData, "addon_id", value); }
    }

    public required int Quantity
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Quantity;
    }

    public AttachAddon() { }

    public AttachAddon(AttachAddon attachAddon)
        : base(attachAddon) { }

    public AttachAddon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachAddon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachAddonFromRaw.FromRawUnchecked"/>
    public static AttachAddon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttachAddonFromRaw : IFromRawJson<AttachAddon>
{
    /// <inheritdoc/>
    public AttachAddon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AttachAddon.FromRawUnchecked(rawData);
}
