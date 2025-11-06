using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(ModelConverter<LicenseKeyDuration>))]
public sealed record class LicenseKeyDuration : ModelBase, IFromRaw<LicenseKeyDuration>
{
    public required int Count
    {
        get
        {
            if (!this._properties.TryGetValue("count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'count' cannot be null",
                    new System::ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Subscriptions::TimeInterval> Interval
    {
        get
        {
            if (!this._properties.TryGetValue("interval", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'interval' cannot be null",
                    new System::ArgumentOutOfRangeException("interval", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::TimeInterval>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["interval"] = JsonSerializer.SerializeToElement(
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

    public LicenseKeyDuration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyDuration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static LicenseKeyDuration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
