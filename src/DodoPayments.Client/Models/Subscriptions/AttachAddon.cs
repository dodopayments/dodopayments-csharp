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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("addon_id");
        }
        init { this._rawData.Set("addon_id", value); }
    }

    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Quantity;
    }

    public AttachAddon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachAddon(AttachAddon attachAddon)
        : base(attachAddon) { }
#pragma warning restore CS8618

    public AttachAddon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachAddon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
