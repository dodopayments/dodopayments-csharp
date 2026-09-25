using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Moderation;

/// <summary>
/// Your moderation usage.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModerationRetrieveUsageResponse,
        ModerationRetrieveUsageResponseFromRaw
    >)
)]
public sealed record class ModerationRetrieveUsageResponse : JsonModel
{
    /// <summary>
    /// Your billable screens per UTC day for the last 30 days, charged or not. A
    /// day with no screens is not in the list.
    /// </summary>
    public required IReadOnlyList<Daily> Daily
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Daily>>("daily");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Daily>>(
                "daily",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Billable screens still needed to fill the next block of 1000. A full block
    /// is charged within one hour, so this value is 1000 when your unbilled screens
    /// fill whole blocks.
    /// </summary>
    public required long ScreensToNextBlock
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("screens_to_next_block");
        }
        init { this._rawData.Set("screens_to_next_block", value); }
    }

    /// <summary>
    /// Billable screens that Dodo Payments has not charged for yet.
    /// </summary>
    public required long UnbilledScreens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("unbilled_screens");
        }
        init { this._rawData.Set("unbilled_screens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Daily)
        {
            item.Validate();
        }
        _ = this.ScreensToNextBlock;
        _ = this.UnbilledScreens;
    }

    public ModerationRetrieveUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModerationRetrieveUsageResponse(
        ModerationRetrieveUsageResponse moderationRetrieveUsageResponse
    )
        : base(moderationRetrieveUsageResponse) { }
#pragma warning restore CS8618

    public ModerationRetrieveUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModerationRetrieveUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModerationRetrieveUsageResponseFromRaw.FromRawUnchecked"/>
    public static ModerationRetrieveUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModerationRetrieveUsageResponseFromRaw : IFromRawJson<ModerationRetrieveUsageResponse>
{
    /// <inheritdoc/>
    public ModerationRetrieveUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModerationRetrieveUsageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Daily, DailyFromRaw>))]
public sealed record class Daily : JsonModel
{
    /// <summary>
    /// The UTC day.
    /// </summary>
    public required string Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    /// <summary>
    /// Billable screens on that day.
    /// </summary>
    public required long Screens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("screens");
        }
        init { this._rawData.Set("screens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Date;
        _ = this.Screens;
    }

    public Daily() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Daily(Daily daily)
        : base(daily) { }
#pragma warning restore CS8618

    public Daily(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Daily(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DailyFromRaw.FromRawUnchecked"/>
    public static Daily FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DailyFromRaw : IFromRawJson<Daily>
{
    /// <inheritdoc/>
    public Daily FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Daily.FromRawUnchecked(rawData);
}
