using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using MeterFilterProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties;
using System = System;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties;

/// <summary>
/// Level 1 nested filter - can contain Level 2 filters
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<MeterFilter1>))]
public sealed record class MeterFilter1 : Client::ModelBase, Client::IFromRaw<MeterFilter1>
{
    /// <summary>
    /// Level 1: Can be conditions or nested filters (2 more levels allowed)
    /// </summary>
    public required MeterFilterProperties::Clauses1 Clauses
    {
        get
        {
            if (!this.Properties.TryGetValue("clauses", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "clauses",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterFilterProperties::Clauses1>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("clauses");
        }
        set { this.Properties["clauses"] = JsonSerializer.SerializeToElement(value); }
    }

    public required MeterFilterProperties::Conjunction2 Conjunction
    {
        get
        {
            if (!this.Properties.TryGetValue("conjunction", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conjunction",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterFilterProperties::Conjunction2>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("conjunction");
        }
        set { this.Properties["conjunction"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilter1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MeterFilter1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
