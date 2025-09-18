using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Subscriptions.SubscriptionListPageResponseProperties;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<SubscriptionListPageResponse>))]
public sealed record class SubscriptionListPageResponse
    : ModelBase,
        IFromRaw<SubscriptionListPageResponse>
{
    public required List<Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Item>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("items");
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

    public SubscriptionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SubscriptionListPageResponse(List<Item> items)
        : this()
    {
        this.Items = items;
    }
}
