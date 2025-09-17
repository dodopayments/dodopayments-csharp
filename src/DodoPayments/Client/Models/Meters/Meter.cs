using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(Client::ModelConverter<Meter>))]
public sealed record class Meter : Client::ModelBase, Client::IFromRaw<Meter>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required MeterAggregation Aggregation
    {
        get
        {
            if (!this.Properties.TryGetValue("aggregation", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "aggregation",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterAggregation>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("aggregation");
        }
        set { this.Properties["aggregation"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "business_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("business_id");
        }
        set { this.Properties["business_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string EventName
    {
        get
        {
            if (!this.Properties.TryGetValue("event_name", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "event_name",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("event_name");
        }
        set { this.Properties["event_name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string MeasurementUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("measurement_unit", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "measurement_unit",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("measurement_unit");
        }
        set { this.Properties["measurement_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "updated_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["updated_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
    ///
    /// Supports up to 3 levels of nesting to create complex filter expressions. Each
    /// filter has a conjunction (and/or) and clauses that can be either direct conditions
    /// or nested filters.
    /// </summary>
    public MeterFilter? Filter
    {
        get
        {
            if (!this.Properties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MeterFilter?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["filter"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.Aggregation.Validate();
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.EventName;
        _ = this.MeasurementUnit;
        _ = this.Name;
        _ = this.UpdatedAt;
        _ = this.Description;
        this.Filter?.Validate();
    }

    public Meter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meter(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Meter FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
