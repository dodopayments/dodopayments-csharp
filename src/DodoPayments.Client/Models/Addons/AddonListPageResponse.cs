using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Addons;

[JsonConverter(typeof(ModelConverter<AddonListPageResponse, AddonListPageResponseFromRaw>))]
public sealed record class AddonListPageResponse : ModelBase
{
    public required IReadOnlyList<AddonResponse> Items
    {
        get { return ModelBase.GetNotNullClass<List<AddonResponse>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public AddonListPageResponse() { }

    public AddonListPageResponse(AddonListPageResponse addonListPageResponse)
        : base(addonListPageResponse) { }

    public AddonListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListPageResponseFromRaw.FromRawUnchecked"/>
    public static AddonListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonListPageResponse(List<AddonResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class AddonListPageResponseFromRaw : IFromRaw<AddonListPageResponse>
{
    /// <inheritdoc/>
    public AddonListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListPageResponse.FromRawUnchecked(rawData);
}
