using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using MeterAggregationProperties = DodoPayments.Client.Models.Meters.MeterAggregationProperties;
using System = System;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(Client::ModelConverter<MeterAggregation>))]
public sealed record class MeterAggregation : Client::ModelBase, Client::IFromRaw<MeterAggregation>
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
                    Client::ModelBase.SerializerOptions
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
                Client::ModelBase.SerializerOptions
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
