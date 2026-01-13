using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(JsonModelConverter<MeterListPageResponse, MeterListPageResponseFromRaw>))]
public sealed record class MeterListPageResponse : JsonModel
{
    public required IReadOnlyList<Meter> Items
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<Meter>>("items"); }
        init
        {
            this._rawData.Set<ImmutableArray<Meter>>(
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

    public MeterListPageResponse() { }

    public MeterListPageResponse(MeterListPageResponse meterListPageResponse)
        : base(meterListPageResponse) { }

    public MeterListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterListPageResponseFromRaw.FromRawUnchecked"/>
    public static MeterListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MeterListPageResponse(List<Meter> items)
        : this()
    {
        this.Items = items;
    }
}

class MeterListPageResponseFromRaw : IFromRawJson<MeterListPageResponse>
{
    /// <inheritdoc/>
    public MeterListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MeterListPageResponse.FromRawUnchecked(rawData);
}
