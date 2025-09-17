using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using Misc = Dodopayments.Models.Misc;

namespace Dodopayments.Models.Subscriptions.SubscriptionRetrieveUsageHistoryPageResponseProperties.ItemProperties;

[JsonConverter(typeof(Dodopayments::ModelConverter<Meter>))]
public sealed record class Meter : Dodopayments::ModelBase, Dodopayments::IFromRaw<Meter>
{
    /// <summary>
    /// Meter identifier
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Chargeable units (after free threshold) as string for precision
    /// </summary>
    public required string ChargeableUnits
    {
        get
        {
            if (!this.Properties.TryGetValue("chargeable_units", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "chargeable_units",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("chargeable_units");
        }
        set { this.Properties["chargeable_units"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Total units consumed as string for precision
    /// </summary>
    public required string ConsumedUnits
    {
        get
        {
            if (!this.Properties.TryGetValue("consumed_units", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "consumed_units",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("consumed_units");
        }
        set { this.Properties["consumed_units"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Currency for the price per unit
    /// </summary>
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Free threshold units for this meter
    /// </summary>
    public required long FreeThreshold
    {
        get
        {
            if (!this.Properties.TryGetValue("free_threshold", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "free_threshold",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["free_threshold"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Meter name
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Price per unit in string format for precision
    /// </summary>
    public required string PricePerUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("price_per_unit", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "price_per_unit",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("price_per_unit");
        }
        set { this.Properties["price_per_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Total price charged for this meter in smallest currency unit (cents)
    /// </summary>
    public required int TotalPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("total_price", out JsonElement element))
                throw new ArgumentOutOfRangeException("total_price", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["total_price"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChargeableUnits;
        _ = this.ConsumedUnits;
        this.Currency.Validate();
        _ = this.FreeThreshold;
        _ = this.Name;
        _ = this.PricePerUnit;
        _ = this.TotalPrice;
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
