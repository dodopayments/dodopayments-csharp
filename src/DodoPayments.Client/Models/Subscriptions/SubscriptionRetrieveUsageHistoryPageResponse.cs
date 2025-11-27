using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(ModelConverter<
        SubscriptionRetrieveUsageHistoryPageResponse,
        SubscriptionRetrieveUsageHistoryPageResponseFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveUsageHistoryPageResponse : ModelBase
{
    /// <summary>
    /// List of usage history items
    /// </summary>
    public required IReadOnlyList<ItemModel> Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
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
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
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

    public SubscriptionRetrieveUsageHistoryPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionRetrieveUsageHistoryPageResponse(List<ItemModel> items)
        : this()
    {
        this.Items = items;
    }
}

class SubscriptionRetrieveUsageHistoryPageResponseFromRaw
    : IFromRaw<SubscriptionRetrieveUsageHistoryPageResponse>
{
    public SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveUsageHistoryPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ItemModel, ItemModelFromRaw>))]
public sealed record class ItemModel : ModelBase
{
    /// <summary>
    /// End date of the billing period
    /// </summary>
    public required DateTimeOffset EndDate
    {
        get
        {
            if (!this._rawData.TryGetValue("end_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'end_date' cannot be null",
                    new ArgumentOutOfRangeException("end_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of meters and their usage for this billing period
    /// </summary>
    public required IReadOnlyList<MeterModel> Meters
    {
        get
        {
            if (!this._rawData.TryGetValue("meters", out JsonElement element))
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
        init
        {
            this._rawData["meters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Start date of the billing period
    /// </summary>
    public required DateTimeOffset StartDate
    {
        get
        {
            if (!this._rawData.TryGetValue("start_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'start_date' cannot be null",
                    new ArgumentOutOfRangeException("start_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["start_date"] = JsonSerializer.SerializeToElement(
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

    public ItemModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ItemModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemModelFromRaw : IFromRaw<ItemModel>
{
    public ItemModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ItemModel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<MeterModel, MeterModelFromRaw>))]
public sealed record class MeterModel : ModelBase
{
    /// <summary>
    /// Meter identifier
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
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
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("chargeable_units", out JsonElement element))
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
        init
        {
            this._rawData["chargeable_units"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("consumed_units", out JsonElement element))
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
        init
        {
            this._rawData["consumed_units"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("free_threshold", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'free_threshold' cannot be null",
                    new ArgumentOutOfRangeException("free_threshold", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["free_threshold"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("name", out JsonElement element))
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
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("price_per_unit", out JsonElement element))
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
        init
        {
            this._rawData["price_per_unit"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("total_price", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'total_price' cannot be null",
                    new ArgumentOutOfRangeException("total_price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["total_price"] = JsonSerializer.SerializeToElement(
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

    public MeterModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MeterModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterModelFromRaw : IFromRaw<MeterModel>
{
    public MeterModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeterModel.FromRawUnchecked(rawData);
}
