using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Meters.MeterFilterProperties;

namespace DodoPayments.Client.Models.Meters;

/// <summary>
/// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
///
/// Supports up to 3 levels of nesting to create complex filter expressions. Each
/// filter has a conjunction (and/or) and clauses that can be either direct conditions
/// or nested filters.
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilter>))]
public sealed record class MeterFilter : ModelBase, IFromRaw<MeterFilter>
{
    /// <summary>
    /// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
    /// </summary>
    public required Clauses Clauses
    {
        get
        {
            if (!this.Properties.TryGetValue("clauses", out JsonElement element))
                throw new ArgumentOutOfRangeException("clauses", "Missing required argument");

            return JsonSerializer.Deserialize<Clauses>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("clauses");
        }
        set
        {
            this.Properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Logical conjunction to apply between clauses (and/or)
    /// </summary>
    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            if (!this.Properties.TryGetValue("conjunction", out JsonElement element))
                throw new ArgumentOutOfRangeException("conjunction", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
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
