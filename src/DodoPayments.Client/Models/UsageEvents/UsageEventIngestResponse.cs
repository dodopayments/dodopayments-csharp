using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.UsageEvents;

[JsonConverter(
    typeof(JsonModelConverter<UsageEventIngestResponse, UsageEventIngestResponseFromRaw>)
)]
public sealed record class UsageEventIngestResponse : JsonModel
{
    public required long IngestedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("ingested_count");
        }
        init { this._rawData.Set("ingested_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IngestedCount;
    }

    public UsageEventIngestResponse() { }

    public UsageEventIngestResponse(UsageEventIngestResponse usageEventIngestResponse)
        : base(usageEventIngestResponse) { }

    public UsageEventIngestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageEventIngestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageEventIngestResponseFromRaw.FromRawUnchecked"/>
    public static UsageEventIngestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageEventIngestResponse(long ingestedCount)
        : this()
    {
        this.IngestedCount = ingestedCount;
    }
}

class UsageEventIngestResponseFromRaw : IFromRawJson<UsageEventIngestResponse>
{
    /// <inheritdoc/>
    public UsageEventIngestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageEventIngestResponse.FromRawUnchecked(rawData);
}
