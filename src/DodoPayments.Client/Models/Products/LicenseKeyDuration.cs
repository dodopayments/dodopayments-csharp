using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(ModelConverter<LicenseKeyDuration>))]
public sealed record class LicenseKeyDuration : ModelBase, IFromRaw<LicenseKeyDuration>
{
    public required int Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, TimeInterval> Interval
    {
        get
        {
            if (!this.Properties.TryGetValue("interval", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'interval' cannot be null",
                    new ArgumentOutOfRangeException("interval", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["interval"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyDuration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LicenseKeyDuration FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
