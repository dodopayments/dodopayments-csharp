using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClauseProperties = Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClauseProperties;
using Dodopayments = Dodopayments;
using System = System;

namespace Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(Dodopayments::ModelConverter<Clause>))]
public sealed record class Clause : Dodopayments::ModelBase, Dodopayments::IFromRaw<Clause>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this.Properties.TryGetValue("key", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("key", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("key");
        }
        set { this.Properties["key"] = JsonSerializer.SerializeToElement(value); }
    }

    public required ClauseProperties::Operator Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "operator",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ClauseProperties::Operator>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("operator");
        }
        set { this.Properties["operator"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ClauseProperties::Value Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("value", "Missing required argument");

            return JsonSerializer.Deserialize<ClauseProperties::Value>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("value");
        }
        set { this.Properties["value"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public Clause() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Clause(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Clause FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
