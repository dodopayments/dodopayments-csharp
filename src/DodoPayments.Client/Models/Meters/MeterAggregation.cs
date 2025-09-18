using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MeterAggregationProperties = DodoPayments.Client.Models.Meters.MeterAggregationProperties;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(ModelConverter<MeterAggregation>))]
public sealed record class MeterAggregation : ModelBase, IFromRaw<MeterAggregation>
{
    /// <summary>
    /// Aggregation type for the meter
    /// </summary>
    public required ApiEnum<string, MeterAggregationProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, MeterAggregationProperties::Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
    public MeterAggregation(ApiEnum<string, MeterAggregationProperties::Type> type)
        : this()
    {
        this.Type = type;
    }
}
