using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Meters;

/// <summary>
/// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
///
/// <para>Supports up to 3 levels of nesting to create complex filter expressions.
/// Each filter has a conjunction (and/or) and clauses that can be either direct conditions
/// or nested filters.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MeterFilter, MeterFilterFromRaw>))]
public sealed record class MeterFilter : JsonModel
{
    /// <summary>
    /// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
    /// </summary>
    public required FilterType Clauses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FilterType>("clauses");
        }
        init { this._rawData.Set("clauses", value); }
    }

    /// <summary>
    /// Logical conjunction to apply between clauses (and/or)
    /// </summary>
    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Conjunction>>("conjunction");
        }
        init { this._rawData.Set("conjunction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeterFilter(MeterFilter meterFilter)
        : base(meterFilter) { }
#pragma warning restore CS8618

    public MeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterFilterFromRaw.FromRawUnchecked"/>
    public static MeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFilterFromRaw : IFromRawJson<MeterFilter>
{
    /// <inheritdoc/>
    public MeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeterFilter.FromRawUnchecked(rawData);
}
