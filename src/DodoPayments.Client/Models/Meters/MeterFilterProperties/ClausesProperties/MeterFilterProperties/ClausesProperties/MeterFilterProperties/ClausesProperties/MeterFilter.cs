using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MeterFilterProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

/// <summary>
/// Level 3 nested filter (final nesting level)
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilter>))]
public sealed record class MeterFilter : ModelBase, IFromRaw<MeterFilter>
{
    /// <summary>
    /// Level 3: Filter conditions only (max depth reached)
    /// </summary>
    public required List<MeterFilterProperties::Clause> Clauses
    {
        get
        {
            if (!this.Properties.TryGetValue("clauses", out JsonElement element))
                throw new ArgumentOutOfRangeException("clauses", "Missing required argument");

            return JsonSerializer.Deserialize<List<MeterFilterProperties::Clause>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("clauses");
        }
        set
        {
            this.Properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, MeterFilterProperties::Conjunction> Conjunction
    {
        get
        {
            if (!this.Properties.TryGetValue("conjunction", out JsonElement element))
                throw new ArgumentOutOfRangeException("conjunction", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, MeterFilterProperties::Conjunction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Clauses)
        {
            item.Validate();
        }
        this.Conjunction.Validate();
    }

    public MeterFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MeterFilter FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
