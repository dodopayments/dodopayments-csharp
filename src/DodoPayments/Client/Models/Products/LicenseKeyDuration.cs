using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Subscriptions;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(Client::ModelConverter<LicenseKeyDuration>))]
public sealed record class LicenseKeyDuration
    : Client::ModelBase,
        Client::IFromRaw<LicenseKeyDuration>
{
    public required int Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("count", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
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
                    Client::ModelBase.SerializerOptions
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
