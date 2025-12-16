using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(ModelConverter<LicenseKeyDuration, LicenseKeyDurationFromRaw>))]
public sealed record class LicenseKeyDuration : ModelBase
{
    public required int Count
    {
        get
        {
            if (!this._rawData.TryGetValue("count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, TimeInterval> Interval
    {
        get
        {
            if (!this._rawData.TryGetValue("interval", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'interval' cannot be null",
                    new ArgumentOutOfRangeException("interval", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'interval' cannot be null",
                    new ArgumentNullException("interval")
                );
        }
        init
        {
            this._rawData["interval"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Count;
        this.Interval.Validate();
    }

    public LicenseKeyDuration() { }

    public LicenseKeyDuration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyDuration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LicenseKeyDuration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyDurationFromRaw : IFromRaw<LicenseKeyDuration>
{
    public LicenseKeyDuration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKeyDuration.FromRawUnchecked(rawData);
}
