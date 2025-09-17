using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using MeterAggregationProperties = Dodopayments.Models.Meters.MeterAggregationProperties;
using System = System;

namespace Dodopayments.Models.Meters;

[JsonConverter(typeof(Dodopayments::ModelConverter<MeterAggregation>))]
public sealed record class MeterAggregation
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<MeterAggregation>
{
    /// <summary>
    /// Aggregation type for the meter
    /// </summary>
    public required MeterAggregationProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<MeterAggregationProperties::Type>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Required when type is not COUNT
    /// </summary>
    public string? Key
    {
        get
        {
            if (!this.Properties.TryGetValue("key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["key"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Key;
    }

    public MeterAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterAggregation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MeterAggregation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MeterAggregation(MeterAggregationProperties::Type type)
        : this()
    {
        this.Type = type;
    }
}
