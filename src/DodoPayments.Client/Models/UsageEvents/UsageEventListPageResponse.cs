using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.UsageEvents;

[JsonConverter(
    typeof(JsonModelConverter<UsageEventListPageResponse, UsageEventListPageResponseFromRaw>)
)]
public sealed record class UsageEventListPageResponse : JsonModel
{
    public required IReadOnlyList<Event> Items
    {
        get { return JsonModel.GetNotNullClass<List<Event>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public UsageEventListPageResponse() { }

    public UsageEventListPageResponse(UsageEventListPageResponse usageEventListPageResponse)
        : base(usageEventListPageResponse) { }

    public UsageEventListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageEventListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageEventListPageResponseFromRaw.FromRawUnchecked"/>
    public static UsageEventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageEventListPageResponse(List<Event> items)
        : this()
    {
        this.Items = items;
    }
}

class UsageEventListPageResponseFromRaw : IFromRawJson<UsageEventListPageResponse>
{
    /// <inheritdoc/>
    public UsageEventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageEventListPageResponse.FromRawUnchecked(rawData);
}
