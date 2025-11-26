using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(ModelConverter<Meter, MeterFromRaw>))]
public sealed record class Meter : ModelBase
{
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

    public required MeterAggregation Aggregation
    {
        get
        {
            if (!this._rawData.TryGetValue("aggregation", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'aggregation' cannot be null",
                    new ArgumentOutOfRangeException("aggregation", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MeterAggregation>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'aggregation' cannot be null",
                    new ArgumentNullException("aggregation")
                );
        }
        init
        {
            this._rawData["aggregation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string BusinessID
    {
        get
        {
            if (!this._rawData.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentOutOfRangeException("business_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentNullException("business_id")
                );
        }
        init
        {
            this._rawData["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string EventName
    {
        get
        {
            if (!this._rawData.TryGetValue("event_name", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'event_name' cannot be null",
                    new ArgumentOutOfRangeException("event_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'event_name' cannot be null",
                    new ArgumentNullException("event_name")
                );
        }
        init
        {
            this._rawData["event_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MeasurementUnit
    {
        get
        {
            if (!this._rawData.TryGetValue("measurement_unit", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'measurement_unit' cannot be null",
                    new ArgumentOutOfRangeException("measurement_unit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'measurement_unit' cannot be null",
                    new ArgumentNullException("measurement_unit")
                );
        }
        init
        {
            this._rawData["measurement_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("updated_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'updated_at' cannot be null",
                    new ArgumentOutOfRangeException("updated_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
    ///
    /// <para>Supports up to 3 levels of nesting to create complex filter expressions.
    /// Each filter has a conjunction (and/or) and clauses that can be either direct
    /// conditions or nested filters.</para>
    /// </summary>
    public MeterMeterFilter? Filter
    {
        get
        {
            if (!this._rawData.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MeterMeterFilter?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public Meter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFromRaw : IFromRaw<Meter>
{
    public Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meter.FromRawUnchecked(rawData);
}
