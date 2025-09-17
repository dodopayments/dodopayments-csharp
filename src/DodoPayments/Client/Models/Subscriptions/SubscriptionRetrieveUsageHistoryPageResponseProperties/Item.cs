using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using ItemProperties = DodoPayments.Client.Models.Subscriptions.SubscriptionRetrieveUsageHistoryPageResponseProperties.ItemProperties;

namespace DodoPayments.Client.Models.Subscriptions.SubscriptionRetrieveUsageHistoryPageResponseProperties;

[JsonConverter(typeof(Client::ModelConverter<Item>))]
public sealed record class Item : Client::ModelBase, Client::IFromRaw<Item>
{
    /// <summary>
    /// End date of the billing period
    /// </summary>
    public required DateTime EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new ArgumentOutOfRangeException("end_date", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["end_date"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// List of meters and their usage for this billing period
    /// </summary>
    public required List<ItemProperties::Meter> Meters
    {
        get
        {
            if (!this.Properties.TryGetValue("meters", out JsonElement element))
                throw new ArgumentOutOfRangeException("meters", "Missing required argument");

            return JsonSerializer.Deserialize<List<ItemProperties::Meter>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("meters");
        }
        set { this.Properties["meters"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Start date of the billing period
    /// </summary>
    public required DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new ArgumentOutOfRangeException("start_date", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["start_date"] = JsonSerializer.SerializeToElement(value); }
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

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
