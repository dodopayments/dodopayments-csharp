using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using MeterFilterProperties = Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;
using System = System;

namespace Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

/// <summary>
/// Level 3 nested filter (final nesting level)
/// </summary>
[JsonConverter(typeof(Dodopayments::ModelConverter<MeterFilter3>))]
public sealed record class MeterFilter3
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<MeterFilter3>
{
    /// <summary>
    /// Level 3: Filter conditions only (max depth reached)
    /// </summary>
    public required List<MeterFilterProperties::Clause> Clauses
    {
        get
        {
            if (!this.Properties.TryGetValue("clauses", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "clauses",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<MeterFilterProperties::Clause>>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("clauses");
        }
        set { this.Properties["clauses"] = JsonSerializer.SerializeToElement(value); }
    }

    public required MeterFilterProperties::Conjunction Conjunction
    {
        get
        {
            if (!this.Properties.TryGetValue("conjunction", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conjunction",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterFilterProperties::Conjunction>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("conjunction");
        }
        set { this.Properties["conjunction"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Clauses)
        {
            item.Validate();
        }
        this.Conjunction.Validate();
    }

    public MeterFilter3() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter3(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MeterFilter3 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
