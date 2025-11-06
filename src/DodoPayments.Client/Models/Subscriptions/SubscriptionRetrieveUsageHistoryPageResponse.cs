using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<SubscriptionRetrieveUsageHistoryPageResponse>))]
public sealed record class SubscriptionRetrieveUsageHistoryPageResponse
    : ModelBase,
        IFromRaw<SubscriptionRetrieveUsageHistoryPageResponse>
{
    /// <summary>
    /// List of usage history items
    /// </summary>
    public required List<ItemModel> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<ItemModel>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        set
        {
            this.Properties["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public SubscriptionRetrieveUsageHistoryPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SubscriptionRetrieveUsageHistoryPageResponse(List<ItemModel> items)
        : this()
    {
        this.Items = items;
    }
}

[JsonConverter(typeof(ModelConverter<ItemModel>))]
public sealed record class ItemModel : ModelBase, IFromRaw<ItemModel>
{
    /// <summary>
    /// End date of the billing period
    /// </summary>
    public required DateTime EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'end_date' cannot be null",
                    new ArgumentOutOfRangeException("end_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of meters and their usage for this billing period
    /// </summary>
    public required List<MeterModel> Meters
    {
        get
        {
            if (!this.Properties.TryGetValue("meters", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'meters' cannot be null",
                    new ArgumentOutOfRangeException("meters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<MeterModel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'meters' cannot be null",
                    new ArgumentNullException("meters")
                );
        }
        set
        {
            this.Properties["meters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Start date of the billing period
    /// </summary>
    public required DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'start_date' cannot be null",
                    new ArgumentOutOfRangeException("start_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EndDate;
        foreach (var item in this.Meters)
        {
            item.Validate();
        }
        _ = this.StartDate;
    }

    public ItemModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ItemModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<MeterModel>))]
public sealed record class MeterModel : ModelBase, IFromRaw<MeterModel>
{
    /// <summary>
    /// Meter identifier
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Chargeable units (after free threshold) as string for precision
    /// </summary>
    public required string ChargeableUnits
    {
        get
        {
            if (!this.Properties.TryGetValue("chargeable_units", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'chargeable_units' cannot be null",
                    new ArgumentOutOfRangeException("chargeable_units", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'chargeable_units' cannot be null",
                    new ArgumentNullException("chargeable_units")
                );
        }
        set
        {
            this.Properties["chargeable_units"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total units consumed as string for precision
    /// </summary>
    public required string ConsumedUnits
    {
        get
        {
            if (!this.Properties.TryGetValue("consumed_units", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'consumed_units' cannot be null",
                    new ArgumentOutOfRangeException("consumed_units", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'consumed_units' cannot be null",
                    new ArgumentNullException("consumed_units")
                );
        }
        set
        {
            this.Properties["consumed_units"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Currency for the price per unit
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Free threshold units for this meter
    /// </summary>
    public required long FreeThreshold
    {
        get
        {
            if (!this.Properties.TryGetValue("free_threshold", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'free_threshold' cannot be null",
                    new ArgumentOutOfRangeException("free_threshold", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["free_threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Meter name
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Price per unit in string format for precision
    /// </summary>
    public required string PricePerUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("price_per_unit", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'price_per_unit' cannot be null",
                    new ArgumentOutOfRangeException("price_per_unit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'price_per_unit' cannot be null",
                    new ArgumentNullException("price_per_unit")
                );
        }
        set
        {
            this.Properties["price_per_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total price charged for this meter in smallest currency unit (cents)
    /// </summary>
    public required int TotalPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("total_price", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'total_price' cannot be null",
                    new ArgumentOutOfRangeException("total_price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["total_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public MeterModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MeterModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
