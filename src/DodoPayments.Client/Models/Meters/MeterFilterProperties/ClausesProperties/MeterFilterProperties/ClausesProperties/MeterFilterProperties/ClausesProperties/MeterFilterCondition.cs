using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterCondition>))]
public sealed record class MeterFilterCondition : ModelBase, IFromRaw<MeterFilterCondition>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this.Properties.TryGetValue("key", out JsonElement element))
                throw new ArgumentOutOfRangeException("key", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("key");
        }
        set
        {
            this.Properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new ArgumentOutOfRangeException("operator", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required Value Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                throw new ArgumentOutOfRangeException("value", "Missing required argument");

            return JsonSerializer.Deserialize<Value>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("value");
        }
        set
        {
            this.Properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterCondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterCondition(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MeterFilterCondition FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
