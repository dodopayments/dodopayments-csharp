using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;
using SubscriptionListPageResponseProperties = DodoPayments.Models.Subscriptions.SubscriptionListPageResponseProperties;

namespace DodoPayments.Models.Subscriptions;

[JsonConverter(typeof(DodoPayments::ModelConverter<SubscriptionListPageResponse>))]
public sealed record class SubscriptionListPageResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<SubscriptionListPageResponse>
{
    public required List<SubscriptionListPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<SubscriptionListPageResponseProperties::Item>>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("items");
        }
        set { this.Properties["items"] = JsonSerializer.SerializeToElement(value); }
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
    public SubscriptionListPageResponse(List<SubscriptionListPageResponseProperties::Item> items)
        : this()
    {
        this.Items = items;
    }
}
