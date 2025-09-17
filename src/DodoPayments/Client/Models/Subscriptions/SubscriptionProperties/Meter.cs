using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using Misc = DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Subscriptions.SubscriptionProperties;

/// <summary>
/// Response struct representing usage-based meter cart details for a subscription
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<Meter>))]
public sealed record class Meter : Client::ModelBase, Client::IFromRaw<Meter>
{
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long FreeThreshold
    {
        get
        {
            if (!this.Properties.TryGetValue("free_threshold", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "free_threshold",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["free_threshold"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string MeasurementUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("measurement_unit", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "measurement_unit",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("measurement_unit");
        }
        set { this.Properties["measurement_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string MeterID
    {
        get
        {
            if (!this.Properties.TryGetValue("meter_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("meter_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("meter_id");
        }
        set { this.Properties["meter_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string PricePerUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("price_per_unit", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "price_per_unit",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("price_per_unit");
        }
        set { this.Properties["price_per_unit"] = JsonSerializer.SerializeToElement(value); }
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

    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.FreeThreshold;
        _ = this.MeasurementUnit;
        _ = this.MeterID;
        _ = this.Name;
        _ = this.PricePerUnit;
        _ = this.Description;
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
