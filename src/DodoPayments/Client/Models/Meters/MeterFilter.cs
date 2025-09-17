using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using MeterFilterProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties;
using System = System;

namespace DodoPayments.Client.Models.Meters;

/// <summary>
/// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
///
/// Supports up to 3 levels of nesting to create complex filter expressions. Each
/// filter has a conjunction (and/or) and clauses that can be either direct conditions
/// or nested filters.
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<MeterFilter>))]
public sealed record class MeterFilter : Client::ModelBase, Client::IFromRaw<MeterFilter>
{
    /// <summary>
    /// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
    /// </summary>
    public required MeterFilterProperties::Clauses Clauses
    {
        get
        {
            if (!this.Properties.TryGetValue("clauses", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "clauses",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterFilterProperties::Clauses>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("clauses");
        }
        set { this.Properties["clauses"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Logical conjunction to apply between clauses (and/or)
    /// </summary>
    public required MeterFilterProperties::Conjunction3 Conjunction
    {
        get
        {
            if (!this.Properties.TryGetValue("conjunction", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conjunction",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterFilterProperties::Conjunction3>(
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
