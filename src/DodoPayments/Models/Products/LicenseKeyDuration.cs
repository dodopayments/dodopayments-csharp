using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Models.Subscriptions;
using DodoPayments = DodoPayments;
using System = System;

namespace DodoPayments.Models.Products;

[JsonConverter(typeof(DodoPayments::ModelConverter<LicenseKeyDuration>))]
public sealed record class LicenseKeyDuration
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<LicenseKeyDuration>
{
    public required int Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("count", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["count"] = JsonSerializer.SerializeToElement(value); }
    }

    public required TimeInterval Interval
    {
        get
        {
            if (!this.Properties.TryGetValue("interval", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "interval",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<TimeInterval>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("interval");
        }
        set { this.Properties["interval"] = JsonSerializer.SerializeToElement(value); }
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
