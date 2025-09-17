using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(Client::ModelConverter<AddMeterToPrice>))]
public sealed record class AddMeterToPrice : Client::ModelBase, Client::IFromRaw<AddMeterToPrice>
{
    public required string MeterID
    {
        get
        {
            if (!this.Properties.TryGetValue("meter_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "meter_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("meter_id");
        }
        set { this.Properties["meter_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The price per unit in lowest denomination. Must be greater than zero. Supports
    /// up to 5 digits before decimal point and 12 decimal places.
    /// </summary>
    public required string PricePerUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("price_per_unit", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_per_unit",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("price_per_unit");
        }
        set { this.Properties["price_per_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Meter description. Will ignored on Request, but will be shown in response
    /// </summary>
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

    public long? FreeThreshold
    {
        get
        {
            if (!this.Properties.TryGetValue("free_threshold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["free_threshold"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Meter measurement unit. Will ignored on Request, but will be shown in response
    /// </summary>
    public string? MeasurementUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("measurement_unit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["measurement_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Meter name. Will ignored on Request, but will be shown in response
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.MeterID;
        _ = this.PricePerUnit;
        _ = this.Description;
        _ = this.FreeThreshold;
        _ = this.MeasurementUnit;
        _ = this.Name;
    }

    public AddMeterToPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddMeterToPrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddMeterToPrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
