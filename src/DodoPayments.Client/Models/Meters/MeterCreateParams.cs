using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Meters;

public sealed record class MeterCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Aggregation configuration for the meter
    /// </summary>
    public required MeterAggregation Aggregation
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("aggregation", out JsonElement element))
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
            this._rawBodyData["aggregation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event name to track
    /// </summary>
    public required string EventName
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("event_name", out JsonElement element))
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
            this._rawBodyData["event_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// measurement unit
    /// </summary>
    public required string MeasurementUnit
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("measurement_unit", out JsonElement element))
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
            this._rawBodyData["measurement_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the meter
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("name", out JsonElement element))
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
            this._rawBodyData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional description of the meter
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional filter to apply to the meter
    /// </summary>
    public MeterMeterFilter? Filter
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MeterMeterFilter?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MeterCreateParams() { }

    public MeterCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static MeterCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/meters")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
