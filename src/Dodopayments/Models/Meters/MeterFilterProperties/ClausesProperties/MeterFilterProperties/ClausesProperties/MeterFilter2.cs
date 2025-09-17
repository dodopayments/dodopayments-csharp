using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using MeterFilterProperties = Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;
using System = System;

namespace Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

/// <summary>
/// Level 2 nested filter
/// </summary>
[JsonConverter(typeof(Dodopayments::ModelConverter<MeterFilter2>))]
public sealed record class MeterFilter2
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<MeterFilter2>
{
    /// <summary>
    /// Level 2: Can be conditions or nested filters (1 more level allowed)
    /// </summary>
    public required MeterFilterProperties::Clauses2 Clauses
    {
        get
        {
            if (!this.Properties.TryGetValue("clauses", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "clauses",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterFilterProperties::Clauses2>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("clauses");
        }
        set { this.Properties["clauses"] = JsonSerializer.SerializeToElement(value); }
    }

    public required MeterFilterProperties::Conjunction1 Conjunction
    {
        get
        {
            if (!this.Properties.TryGetValue("conjunction", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conjunction",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterFilterProperties::Conjunction1>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("conjunction");
        }
        set { this.Properties["conjunction"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilter2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter2(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MeterFilter2 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
